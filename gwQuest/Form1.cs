using gwQuest.Domain;
using gwQuest.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace gwQuest
{
    public partial class Form1 : Form
    {
        private readonly Settings _settings;
        private readonly IQuestService _questService;
        private readonly ISettingsRepository _settingsRepository;

        private Quest _activeQuest;

        public Form1(IQuestService questService, ISettingsRepository settingsRepository)
        {
            _questService = questService;
            _settingsRepository = settingsRepository;
            _settings = _settingsRepository.GetSettings();

            InitializeComponent();
            SetupContainers();
        }

        private void SetupContainers()
        {
            //campaign
            comboBoxCampaign.SelectedIndexChanged -= new EventHandler(ComboBoxCampaign_SelectedIndexChanged);
            comboBoxCampaign.DataSource = CampaignExtensions.GetCampaigns();
            comboBoxCampaign.SelectedIndex = comboBoxCampaign.FindStringExact(_settings.Campaign.ToCapitalString());
            comboBoxCampaign.SelectedIndexChanged += new EventHandler(ComboBoxCampaign_SelectedIndexChanged);

            //region
            comboBoxRegion.SelectedIndexChanged -= new EventHandler(ComboBoxRegion_SelectedIndexChanged);
            comboBoxRegion.DataSource = ((string)comboBoxCampaign.SelectedItem).ToCampaign().GetRegions();
            comboBoxRegion.SelectedIndex = comboBoxRegion.FindStringExact(_settings.Region.ToReadableString());
            comboBoxRegion.SelectedIndexChanged += new EventHandler(ComboBoxRegion_SelectedIndexChanged);

            //filters
            checkBoxHidePrimary.Checked = _settings.HidePrimary;
            checkBoxHidePrimary.CheckedChanged += new EventHandler(CheckBoxHidePrimary_CheckedChanged);
            
            checkBoxShowCompleted.Checked = _settings.ShowCompleted;
            checkBoxShowCompleted.CheckedChanged += new EventHandler(CheckBoxShowCompleted_CheckedChanged);

            //listview for quests
            var imageList = new ImageList() { };
            imageList.Images.Add("primary", Resources.Resources.primary);
            imageList.Images.Add("war", Resources.Resources.Warrior_tango_icon_20);
            imageList.Images.Add("monk", Resources.Resources.Monk_tango_icon_20);
            imageList.Images.Add("necro", Resources.Resources.Necromancer_tango_icon_20);
            imageList.Images.Add("ranger", Resources.Resources.Ranger_tango_icon_20);
            imageList.Images.Add("ele", Resources.Resources.Elementalist_tango_icon_20);
            imageList.Images.Add("mesmer", Resources.Resources.Mesmer_tango_icon_20);

            listView1.SmallImageList = imageList;
            ColumnHeader header = new()
            {
                Text = "",
                Name = "col1",
                TextAlign = HorizontalAlignment.Right
            };
            listView1.Columns.Add(header);
            listView1.Columns[0].Width = listView1.Width - 4 - SystemInformation.VerticalScrollBarWidth;
            listView1.SelectedIndexChanged += new EventHandler(ActiveQuestChanged);

            RefreshQuestList();
        }

        private void RefreshQuestList()
        {
            var index = (listView1.SelectedItems.Count > 0 && listView1.Items.Count > 0) ? listView1.SelectedItems[0]?.Index ?? 0 : 0;

            listView1.SelectedItems.Clear();
            listView1.Items.Clear();

            var currentCampaign = ((string)comboBoxCampaign.SelectedItem).ToCampaign();
            var currentRegion = ((string)comboBoxRegion.SelectedItem).ToRegion();

            IEnumerable<Quest> questsToShow = _questService.GetQuests(currentCampaign, currentRegion);

            if (!checkBoxShowCompleted.Checked)
                questsToShow = questsToShow.Where(q => !q.Completed);

            if (checkBoxHidePrimary.Checked)
                questsToShow = questsToShow.Where(q => !q.Primary);


            foreach (var quest in questsToShow.OrderBy(q => q.Name))
            {
                ListViewItem listItem = new() { };
                var questName = quest.Name;

                if (checkBoxShowCompleted.Checked && quest.Completed)
                {
                    questName += " (Completed)";
                    listItem.ForeColor = Color.Green;
                }

                if (quest.Primary)
                    listItem.ImageIndex = listItem.ImageIndex = 0;

                if (quest.Profession == Profession.None)
                {
                    listItem.Text = questName;
                    listItem.Tag = quest;
                }
                else
                {
                    listItem.ImageIndex = (int)quest.Profession;
                    listItem.Text = questName;
                    listItem.Tag = quest;
                }

                listView1.Alignment = ListViewAlignment.SnapToGrid;
                listView1.HideSelection = false;
                listView1.AutoArrange = true;
                listView1.Items.Add(listItem);
            }

            if (listView1.Items.Count > 0)
            {
                if (listView1.Items.Count > index)
                {
                    listView1.Items[index].Selected = true;
                }
                else
                {
                    listView1.Items[0].Selected = true;
                }
            }

            listView1.Select();
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {

            var region = ((string)comboBoxRegion.SelectedItem).ToRegion();
            var regCompleted = (double)_questService.CompletedQuests(region);
            var regAvailable = (double)_questService.AvailableQuests(region);
            if (regAvailable == 0)
                labelCampaignCount.Text = "N/A";
            else
                labelRegionCount.Text = $"{regCompleted}/{regAvailable} ({(int)(regCompleted / regAvailable * 100)}%)";


            var campaign = ((string)comboBoxCampaign.SelectedItem).ToCampaign();
            var campaignCompleted = (double)_questService.CompletedQuests(campaign);
            var campaignAvailable = (double)_questService.AvailableQuests(campaign);
            if (campaignAvailable == 0)
                labelCampaignCount.Text = "N/A";
            else
                labelCampaignCount.Text = $"{campaignCompleted}/{campaignAvailable} ({(int)(campaignCompleted / campaignAvailable * 100)}%)";

            var completed = (double)_questService.CompletedQuests();
            var available = (double)_questService.AvailableQuests();
            labelTotalCount.Text = $"{completed}/{available} ({(int)(completed / available * 100)}%)";
        }

        #region events
        private void ActiveQuestChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                labelQuestDetails.Visible = false;
                labelPrimary.Visible = false;
                labelPrimaryImage.Visible = false;
                linkLabelQuest.Visible = false;
                labelQuestName.Visible = false;
                button1.Visible = false;
                return;
            }

            labelQuestDetails.Visible = true;
            labelPrimary.Visible = true;
            labelPrimaryImage.Visible = true;
            linkLabelQuest.Visible = true;
            labelQuestName.Visible = true;

            _activeQuest = (Quest)listView1.SelectedItems[0].Tag;

            if(!_activeQuest.Completed)
            {
                button1.Visible = true;
                button1.Text = "Completed";
            }
            else if(_activeQuest.Completed)
            {
                button1.Visible = true;
                button1.Text = "Mark as uncompleted";
            }

            labelPrimary.Text = _activeQuest.Primary ? "Primary" : "Secondary";
            if (_activeQuest.Primary)
            {
                labelPrimaryImage.Visible = true;
            }
            else
            {
                labelPrimaryImage.Visible = false;
            }


            labelQuestName.Text = _activeQuest.Name;
        }

        private void LinkLabelQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = _activeQuest.Uri.ToString().Replace("&", "^&");
            Process.Start(url);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _activeQuest.Completed = !_activeQuest.Completed;
            _questService.Update(_activeQuest);

            RefreshQuestList();
        }

        private void CheckBoxShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ShowCompleted = checkBoxShowCompleted.Checked;
            _settingsRepository.Save(_settings);
            RefreshQuestList();
        }

        private void CheckBoxHidePrimary_CheckedChanged(object sender, EventArgs e)
        {
            _settings.HidePrimary = checkBoxHidePrimary.Checked;
            _settingsRepository.Save(_settings);
            RefreshQuestList();
        }

        private void ComboBoxCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newCampaign = ((string)comboBoxCampaign.SelectedItem).ToCampaign();
            if (_settings.Campaign == 0)
            {
                _settings.Campaign = newCampaign;
                return;
            }
            else if (_settings.Campaign == newCampaign)
            {
                return;
            }

            _settings.Campaign = newCampaign;

            var regions = _settings.Campaign.GetRegions();

            if (!regions.Contains(_settings.Region.ToReadableString()))
            {
                comboBoxRegion.DataSource = ((string)comboBoxCampaign.SelectedItem).ToCampaign().GetRegions();
            }
        }

        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newRegion = ((string)comboBoxRegion.SelectedItem).ToRegion();
            if (_settings.Region == 0)
            {
                _settings.Region = newRegion;
                return;
            }
            else if (_settings.Region == newRegion)
            {
                return;
            }

            _settings.Region = newRegion;
            _settingsRepository.Save(_settings);
            RefreshQuestList();
        }
        #endregion


    }
}
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
        private readonly List<Profession> _professions;
        private readonly IQuestService _questService;
        private readonly ISettingsRepository _settingsRepository;

        private Quest _activeQuest;
        private Campaign _activeCampaign;
        private Domain.Region _activeRegion;

        public Form1(IQuestService questService, ISettingsRepository settingsRepository)
        {
            _questService = questService;
            _settingsRepository = settingsRepository;
            _professions = _settingsRepository.GetProfessions().ToList();

            InitializeComponent();
            SetupContainers();            
        }

        private void SetupContainers()
        {
            //campaign
            comboBoxCampaign.DataSource = CampaignExtensions.GetCampaigns();
            _activeCampaign = ((string)comboBoxCampaign.SelectedItem).ToCampaign();

            //region
            comboBoxRegion.DataSource = ((string)comboBoxCampaign.SelectedItem).ToCampaign().GetRegions();

            //listview for quests
            var imageList = new ImageList() { };
            imageList.Images.Add("none", Resources.Resources.Tango_quest_icon_primary);
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

            //main profession
            comboBoxProfessionMain.Items.Add(Profession.None);
            comboBoxProfessionMain.Items.Add(Profession.Warrior);
            comboBoxProfessionMain.Items.Add(Profession.Monk);
            comboBoxProfessionMain.Items.Add(Profession.Necromancer);
            comboBoxProfessionMain.Items.Add(Profession.Ranger);
            comboBoxProfessionMain.Items.Add(Profession.Elementalist);
            comboBoxProfessionMain.Items.Add(Profession.Mesmer);

            comboBoxProfessionMain.SelectedIndex = (int)_professions.First();

            //secondary profession
            comboBoxProfessionSecondary.Items.Add(Profession.None);
            comboBoxProfessionSecondary.Items.Add(Profession.Warrior);
            comboBoxProfessionSecondary.Items.Add(Profession.Monk);
            comboBoxProfessionSecondary.Items.Add(Profession.Necromancer);
            comboBoxProfessionSecondary.Items.Add(Profession.Ranger);
            comboBoxProfessionSecondary.Items.Add(Profession.Elementalist);
            comboBoxProfessionSecondary.Items.Add(Profession.Mesmer);
           
            comboBoxProfessionSecondary.SelectedIndex = (int)_professions.Skip(1).First();

            RefreshQuestList();
        }

        private void RefreshQuestList()
        {
            var index = listView1.Items.Count > 0 ? listView1.SelectedItems[0]?.Index ?? 0 : 0;

            listView1.SelectedItems.Clear();
            listView1.Items.Clear();

            var filterQuests = _professions[0] != Profession.None && _professions[1] != Profession.None;
            var currentCampaign = ((string) comboBoxCampaign.SelectedItem).ToCampaign();
            var currentRegion = ((string) comboBoxRegion.SelectedItem).ToRegion();

            IEnumerable<Quest> questsToShow = _questService.GetQuests(currentCampaign, currentRegion);

            if (!checkBoxShowCompleted.Checked)
                questsToShow = questsToShow.Where(q => !q.Completed);

            
            foreach (var quest in questsToShow.OrderBy(q => q.Name))
            {
                ListViewItem listItem = new() { };
                var questName = quest.Name;

                if (checkBoxShowCompleted.Checked && quest.Completed)
                {
                    questName += " (Completed)";
                    listItem.ForeColor = Color.Green;
                }
                    

                var displayProfQuest = quest.Profession == _professions[0] || quest.Profession == _professions[1];

                if (filterQuests && displayProfQuest)
                {
                    listItem.ImageIndex = (int)quest.Profession;
                    listItem.Text = questName;
                    listItem.Tag = quest;
                }
                else if (filterQuests && (quest.Profession == Profession.None))
                {
                    listItem.Text = questName;
                    listItem.Tag = quest;
                }
                else if (!filterQuests)
                {
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

                }
                else
                {
                    continue;
                }
                listView1.Alignment = ListViewAlignment.SnapToGrid;
                listView1.HideSelection = false;
                listView1.AutoArrange = true;
                listView1.Items.Add(listItem);               
            }

            if (listView1.Items.Count > 0)
                listView1.Items[index].Selected = true;

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
            button1.Visible = true;


            _activeQuest = (Quest)listView1.SelectedItems[0].Tag;
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
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _activeQuest.Completed = true;
            _questService.Update(_activeQuest);

            RefreshQuestList();
        }

        private void ComboBoxProfessionMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_professions[0] == (Profession)comboBoxProfessionMain.SelectedItem)
                return;

            _professions[0] = (Profession)comboBoxProfessionMain.SelectedItem;
            _settingsRepository.Save(_professions);
            RefreshQuestList();
        }

        private void ComboBoxProfessionSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_professions[1] == (Profession)comboBoxProfessionSecondary.SelectedItem)
                return;

            _professions[1] = (Profession)comboBoxProfessionSecondary.SelectedItem;
            _settingsRepository.Save(_professions);
            RefreshQuestList();
        }

        private void CheckBoxShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            RefreshQuestList();
        }

        private void ComboBoxCampaign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var newCampaign = ((string)comboBoxCampaign.SelectedItem).ToCampaign();
            if (_activeCampaign == 0)
            {
                _activeCampaign = newCampaign;
                return;
            }

            if (_activeCampaign == newCampaign)
            {
                return;
            }

            _activeCampaign = newCampaign;

            var regions = _activeCampaign.GetRegions();

            if (!regions.Contains(_activeRegion.ToReadableString()))
            {
                comboBoxRegion.DataSource = ((string)comboBoxCampaign.SelectedItem).ToCampaign().GetRegions();
            }               

            RefreshQuestList();
        }

        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newRegion = ((string)comboBoxRegion.SelectedItem).ToRegion();
            if(_activeRegion == 0)
            {
                _activeRegion = newRegion;
                return;
            }

            if (_activeRegion == newRegion)
            {
                return;
            }

            _activeRegion = newRegion;
            RefreshQuestList();
        }
        #endregion
    }
}
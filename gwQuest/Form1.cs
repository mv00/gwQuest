using gwQuest.Domain;
using gwQuest.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gwQuest
{
    public partial class Form1 : Form
    {
        private Quest _activeQuest;
        private IEnumerable<Quest> _quests => _repository.GetQuests();
        private List<Profession> _professions;
        private IQuestRepository _repository { get; }
        private ISettingsRepository _settingsRepository { get; }

        public Form1(IQuestRepository questRepository, ISettingsRepository settingsRepository)
        {
            _repository = questRepository;

            _settingsRepository = settingsRepository;
            _professions = _settingsRepository.GetProfessions().ToList();

            InitializeComponent();
            SetupContainers();
            SetQuestList();
        }

        private void SetupContainers()
        {
            //campaign
            comboBoxCampaign.DataSource = new Campaign[] { Campaign.Prophecies, Campaign.Cantha, Campaign.Nightfall, Campaign.EyeOfTheNorth };
            tabControl.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);

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
            ColumnHeader header = new ColumnHeader
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
        }

        private void SetQuestList()
        {
            listView1.Items.Clear();
            ActiveQuestChanged(null, null);

            var filterQuests = _professions[0] != Profession.None && _professions[1] != Profession.None;
            var currentCampaign = (Campaign)comboBoxCampaign.SelectedItem;
            IEnumerable<Quest> questsToShow = _quests.Where(p => p.Campaign.Name == currentCampaign.Name);

            if (!checkBoxShowCompleted.Checked)
                questsToShow = questsToShow.Where(q => !q.Completed);

            
            foreach (var quest in questsToShow.OrderBy(q => q.Name))
            {
                ListViewItem listItem = new ListViewItem {};
                var questName = quest.Name;

                if (checkBoxShowCompleted.Checked && quest.Completed)
                {
                    questName = questName + " (Completed)";
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
        }

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

        void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = (TabControl)sender;
            var y = x.SelectedIndex;
        }

        private void linkLabelQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = _activeQuest.Uri.ToString().Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _activeQuest.Completed = true;
            _repository.Update(_activeQuest);

            SetQuestList();
        }

        private void comboBoxProfessionMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_professions.ToList()[0] == (Profession)comboBoxProfessionMain.SelectedItem)
                return;

            _professions[0] = (Profession)comboBoxProfessionMain.SelectedItem;
            _settingsRepository.Save(_professions);
            SetQuestList();
        }

        private void comboBoxProfessionSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_professions[1] == (Profession)comboBoxProfessionSecondary.SelectedItem)
                return;

            _professions[1] = (Profession)comboBoxProfessionSecondary.SelectedItem;
            _settingsRepository.Save(_professions);
            SetQuestList();
        }

        private void checkBoxShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            SetQuestList();
        }

        private void comboBoxCampaign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetQuestList();
        }
    }
}
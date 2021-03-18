using gwQuest.Domain;
using gwQuest.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gwQuest
{
    public partial class Form1 : Form
    {
        private Quest _activeQuest;
        private IEnumerable<Quest> _quests => _repository.GetQuests();
        private IQuestRepository _repository { get; }

        public Form1(IQuestRepository repository)
        {
            _repository = repository;

            InitializeComponent();
            comboBoxCampaign.DataSource = new Campaign[] { Campaign.Prophecies, Campaign.Cantha, Campaign.Nightfall, Campaign.EyeOfTheNorth };
            tabControl.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            
            var imageList = new ImageList() { };
            imageList.Images.Add("necro", Resources.Resources.Necromancer_tango_icon_20);
            imageList.Images.Add("ele", Resources.Resources.Elementalist_tango_icon_20);
            imageList.Images.Add("war", Resources.Resources.Warrior_tango_icon_20);
            imageList.Images.Add("monk", Resources.Resources.Monk_tango_icon_20);
            imageList.Images.Add("ranger", Resources.Resources.Ranger_tango_icon_20);
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

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var item = (Quest)listView1.Items[i].Tag;

                if (item.Profession != Profession.None)
                {
                    listView1.Items[i].ImageIndex = GetImageIndex(item.Profession);
                }
            }

            comboBoxProfessionMain.Items.Add(Profession.None);
            comboBoxProfessionMain.Items.Add(Profession.Elementalist);
            comboBoxProfessionMain.Items.Add(Profession.Necromancer);
            comboBoxProfessionMain.Items.Add(Profession.Monk);
            comboBoxProfessionMain.Items.Add(Profession.Mesmer);
            comboBoxProfessionMain.Items.Add(Profession.Ranger);
            comboBoxProfessionMain.Items.Add(Profession.Warrior);
            comboBoxProfessionMain.SelectedIndex = 0;

            comboBoxProfessionSecondary.Items.Add(Profession.None);
            comboBoxProfessionSecondary.Items.Add(Profession.Elementalist);
            comboBoxProfessionSecondary.Items.Add(Profession.Necromancer);
            comboBoxProfessionSecondary.Items.Add(Profession.Monk);
            comboBoxProfessionSecondary.Items.Add(Profession.Mesmer);
            comboBoxProfessionSecondary.Items.Add(Profession.Ranger);
            comboBoxProfessionSecondary.Items.Add(Profession.Warrior);
            comboBoxProfessionSecondary.SelectedIndex = 0;

            listView1.SelectedIndexChanged += new EventHandler(ActiveQuestChanged);


            SetQuestList();

        }

        private void SetQuestList()
        {
            Profession mainProf = Profession.None;
            Profession secProf = Profession.None;

            if (comboBoxProfessionMain.SelectedItem != null)
            {
                mainProf = (Profession)comboBoxProfessionMain.SelectedItem;
            }
            if (comboBoxProfessionSecondary.SelectedItem != null)
            {
                secProf = (Profession)comboBoxProfessionSecondary.SelectedItem;
            }

            listView1.Items.Clear();


            foreach (var item in _quests.Where(q => !q.Completed).OrderBy(q => q.Name))
            {
                ListViewItem listItem;

                var filterQuests = mainProf != Profession.None && secProf != Profession.None;

                if (filterQuests && (item.Profession == mainProf || item.Profession == secProf))
                {
                    listItem = new ListViewItem { ImageIndex = GetImageIndex(item.Profession), Text = item.Name, Tag = item };
                }
                else if (!filterQuests)
                {
                    if (item.Profession == Profession.None)
                    {
                        listItem = new ListViewItem { Text = item.Name, Tag = item };
                    }
                    else
                    {
                        listItem = new ListViewItem { ImageIndex = GetImageIndex(item.Profession), Text = item.Name, Tag = item };
                    }

                }
                else
                {
                    return;
                }
                listView1.Alignment = ListViewAlignment.SnapToGrid;
                listView1.AutoArrange = true;
                listView1.Items.Add(listItem);
            }
        }

        private int GetImageIndex(Profession profession)
        {
            switch (profession)
            {
                case Profession.Necromancer:
                    return 0;
                case Profession.Elementalist:
                    return 1;
                case Profession.Warrior:
                    return 2;
                case Profession.Monk:
                    return 3;
                case Profession.Ranger:
                    return 4;
                case Profession.Mesmer:
                    return 5;
                default:
                    throw new ArgumentException("Profession has to have value");
            }
        }


        private void ActiveQuestChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                labelQuestDetails.Visible = false;
                labelPrimary.Visible = false;
                labelPrimary.Visible = false;
                labelProfessionMain.Visible = false;
                linkLabelQuest.Visible = false;
                labelQuestName.Visible = false;
                button1.Visible = false;
                return;
            }

            labelQuestDetails.Visible = true;
            labelPrimary.Visible = true;
            labelPrimary.Visible = true;
            labelProfessionMain.Visible = true;
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

        private void comboBoxCampaign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = (TabControl)sender;
            var y = x.SelectedIndex;
        }

        private void linkLabelQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(_activeQuest.Uri.ToString());
        }

        private void comboBoxProfessionSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetQuestList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _activeQuest.Completed = true;
            _repository.Update(_activeQuest);
            SetQuestList();
        }

        private void comboBoxProfessionMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetQuestList();
        }
    }
}
using gwQuest.Domain;
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
        private Quest activeQuest;

        public Form1()
        {
            InitializeComponent();
            comboBoxCampaign.DataSource = new Campaign[] { Campaign.Prophecies, Campaign.Cantha, Campaign.Nightfall, Campaign.EyeOfTheNorth };
            tabControl.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);

            var items = JsonConvert.DeserializeObject<List<Quest>>(File.ReadAllText(@"Resources\ascalon.json"));

            items.Select(item => new ListViewItem { Text = item.Name, Tag = item }).ToList().ForEach(listItem => listView1.Items.Add(listItem));



            var imageList = new ImageList() { };
            imageList.Images.Add("necro", Resources.Resources.Necromancer_tango_icon_20);
            imageList.Images.Add("ele", Resources.Resources.Elementalist_tango_icon_20);
            imageList.Images.Add("war", Resources.Resources.Warrior_tango_icon_20);
            imageList.Images.Add("monk", Resources.Resources.Monk_tango_icon_20);
            imageList.Images.Add("ranger", Resources.Resources.Ranger_tango_icon_20);
            imageList.Images.Add("mesmer", Resources.Resources.Mesmer_tango_icon_20);

            listView1.SmallImageList = imageList;
            listView1.View = View.SmallIcon;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var item = (Quest)listView1.Items[0].Tag;

                if (item.Profession != Profession.None)
                {                  
                    listView1.Items[i].ImageIndex = GetImageIndex(item.Profession);
                }

                listBoxQuests.DataSource = items;
                listBoxQuests.DisplayMember = "Name";
                listBoxQuests.SelectionMode = SelectionMode.One;
                listBoxQuests.SelectedIndexChanged += new EventHandler(ActiveQuestChanged);
                listBoxQuests.SetSelected(0, true);


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
            var activeQuest = (Quest)listBoxQuests.SelectedItem;
            labelPrimary.Text = activeQuest.Primary ? "Primary" : "Secondary";
            if (activeQuest.Primary)
            {
                labelPrimaryImage.Visible = true;
            }
            else
            {
                labelPrimaryImage.Visible = false;
            }


            labelQuestName.Text = activeQuest.Name;
        }

        private void comboBoxCampaign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxCampaign.SelectedIndex == 1)
                tabControl.TabPages.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxCampaign.SelectedIndex == 1)
                tabControl.TabPages.Clear();
        }

        void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = (TabControl)sender;
            var y = x.SelectedIndex;
        }

        private void linkLabelQuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var activeQuest = (Quest)listBoxQuests.SelectedItem;
            System.Diagnostics.Process.Start(activeQuest.Uri.ToString());
        }
    }
}
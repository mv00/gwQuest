using gwQuest.Common;
using gwQuest.Domain;

namespace gwQuest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelPrimaryImage = new System.Windows.Forms.Label();
            this.labelQuestName = new System.Windows.Forms.Label();
            this.labelPrimary = new System.Windows.Forms.Label();
            this.linkLabelQuest = new System.Windows.Forms.LinkLabel();
            this.labelQuestDetails = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCampaign = new System.Windows.Forms.Label();
            this.labelProfessionMain = new System.Windows.Forms.Label();
            this.comboBoxProfessionMain = new System.Windows.Forms.ComboBox();
            this.comboBoxCampaign = new System.Windows.Forms.ComboBox();
            this.comboBoxProfessionSecondary = new System.Windows.Forms.ComboBox();
            this.checkBoxShowCompleted = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 150);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(903, 693);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.labelPrimaryImage);
            this.tabPage1.Controls.Add(this.labelQuestName);
            this.tabPage1.Controls.Add(this.labelPrimary);
            this.tabPage1.Controls.Add(this.linkLabelQuest);
            this.tabPage1.Controls.Add(this.labelQuestDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(895, 665);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ascalon";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 192);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Completed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AutoArrange = false;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 3);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(424, 663);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // labelPrimaryImage
            // 
            this.labelPrimaryImage.AutoSize = true;
            this.labelPrimaryImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrimaryImage.Image = global::gwQuest.Resources.Resources.Tango_quest_icon_primary;
            this.labelPrimaryImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPrimaryImage.Location = new System.Drawing.Point(532, 57);
            this.labelPrimaryImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrimaryImage.Name = "labelPrimaryImage";
            this.labelPrimaryImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPrimaryImage.Size = new System.Drawing.Size(13, 20);
            this.labelPrimaryImage.TabIndex = 8;
            this.labelPrimaryImage.Text = " ";
            this.labelPrimaryImage.Visible = false;
            // 
            // labelQuestName
            // 
            this.labelQuestName.AutoSize = true;
            this.labelQuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestName.Location = new System.Drawing.Point(574, 108);
            this.labelQuestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestName.Name = "labelQuestName";
            this.labelQuestName.Size = new System.Drawing.Size(127, 20);
            this.labelQuestName.TabIndex = 7;
            this.labelQuestName.Text = "labelQuestName";
            this.labelQuestName.Visible = false;
            // 
            // labelPrimary
            // 
            this.labelPrimary.AutoSize = true;
            this.labelPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrimary.Location = new System.Drawing.Point(454, 57);
            this.labelPrimary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrimary.Name = "labelPrimary";
            this.labelPrimary.Size = new System.Drawing.Size(61, 20);
            this.labelPrimary.TabIndex = 5;
            this.labelPrimary.Text = "Primary";
            this.labelPrimary.Visible = false;
            // 
            // linkLabelQuest
            // 
            this.linkLabelQuest.AutoSize = true;
            this.linkLabelQuest.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelQuest.Location = new System.Drawing.Point(454, 108);
            this.linkLabelQuest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelQuest.Name = "linkLabelQuest";
            this.linkLabelQuest.Size = new System.Drawing.Size(97, 20);
            this.linkLabelQuest.TabIndex = 4;
            this.linkLabelQuest.TabStop = true;
            this.linkLabelQuest.Text = "Open in Wiki";
            this.linkLabelQuest.Visible = false;
            this.linkLabelQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQuest_LinkClicked);
            // 
            // labelQuestDetails
            // 
            this.labelQuestDetails.AutoSize = true;
            this.labelQuestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestDetails.Location = new System.Drawing.Point(441, 7);
            this.labelQuestDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestDetails.Name = "labelQuestDetails";
            this.labelQuestDetails.Size = new System.Drawing.Size(186, 33);
            this.labelQuestDetails.TabIndex = 3;
            this.labelQuestDetails.Text = "Quest details";
            this.labelQuestDetails.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(895, 665);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Northen Shiverpeaks";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // lblCampaign
            // 
            this.lblCampaign.AutoSize = true;
            this.lblCampaign.Location = new System.Drawing.Point(9, 28);
            this.lblCampaign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampaign.Name = "lblCampaign";
            this.lblCampaign.Size = new System.Drawing.Size(62, 15);
            this.lblCampaign.TabIndex = 2;
            this.lblCampaign.Text = "Campaign";
            // 
            // labelProfessionMain
            // 
            this.labelProfessionMain.AutoSize = true;
            this.labelProfessionMain.Location = new System.Drawing.Point(182, 28);
            this.labelProfessionMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProfessionMain.Name = "labelProfessionMain";
            this.labelProfessionMain.Size = new System.Drawing.Size(67, 15);
            this.labelProfessionMain.TabIndex = 4;
            this.labelProfessionMain.Text = "Professions";
            // 
            // comboBoxProfessionMain
            // 
            this.comboBoxProfessionMain.DisplayMember = "Name";
            this.comboBoxProfessionMain.FormattingEnabled = true;
            this.comboBoxProfessionMain.Location = new System.Drawing.Point(186, 50);
            this.comboBoxProfessionMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProfessionMain.Name = "comboBoxProfessionMain";
            this.comboBoxProfessionMain.Size = new System.Drawing.Size(140, 23);
            this.comboBoxProfessionMain.TabIndex = 3;
            this.comboBoxProfessionMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfessionMain_SelectedIndexChanged);
            // 
            // comboBoxCampaign
            // 
            this.comboBoxCampaign.DisplayMember = "Name";
            this.comboBoxCampaign.FormattingEnabled = true;
            this.comboBoxCampaign.Location = new System.Drawing.Point(13, 50);
            this.comboBoxCampaign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxCampaign.Name = "comboBoxCampaign";
            this.comboBoxCampaign.Size = new System.Drawing.Size(140, 23);
            this.comboBoxCampaign.TabIndex = 1;
            this.comboBoxCampaign.SelectedIndexChanged += new System.EventHandler(this.comboBoxCampaign_SelectedIndexChanged);
            // 
            // comboBoxProfessionSecondary
            // 
            this.comboBoxProfessionSecondary.DisplayMember = "Name";
            this.comboBoxProfessionSecondary.FormattingEnabled = true;
            this.comboBoxProfessionSecondary.Location = new System.Drawing.Point(186, 81);
            this.comboBoxProfessionSecondary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProfessionSecondary.Name = "comboBoxProfessionSecondary";
            this.comboBoxProfessionSecondary.Size = new System.Drawing.Size(140, 23);
            this.comboBoxProfessionSecondary.TabIndex = 5;
            this.comboBoxProfessionSecondary.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfessionSecondary_SelectedIndexChanged);
            // 
            // checkBoxShowCompleted
            // 
            this.checkBoxShowCompleted.AutoSize = true;
            this.checkBoxShowCompleted.Location = new System.Drawing.Point(8, 125);
            this.checkBoxShowCompleted.Name = "checkBoxShowCompleted";
            this.checkBoxShowCompleted.Size = new System.Drawing.Size(152, 19);
            this.checkBoxShowCompleted.TabIndex = 6;
            this.checkBoxShowCompleted.Text = "Show completed quests";
            this.checkBoxShowCompleted.UseVisualStyleBackColor = true;
            this.checkBoxShowCompleted.CheckedChanged += new System.EventHandler(this.checkBoxShowCompleted_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 842);
            this.Controls.Add(this.checkBoxShowCompleted);
            this.Controls.Add(this.comboBoxProfessionSecondary);
            this.Controls.Add(this.labelProfessionMain);
            this.Controls.Add(this.comboBoxProfessionMain);
            this.Controls.Add(this.lblCampaign);
            this.Controls.Add(this.comboBoxCampaign);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Guild Wars Questing";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAscalon;
        private System.Windows.Forms.TabPage tabPageNorthernShiverpeaks;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxCampaign;
        private System.Windows.Forms.Label lblCampaign;
        private System.Windows.Forms.Label labelProfessionMain;
        private System.Windows.Forms.ComboBox comboBoxProfessionMain;
        private System.Windows.Forms.Label labelQuestDetails;
        private System.Windows.Forms.LinkLabel linkLabelQuest;
        private System.Windows.Forms.Label labelPrimary;
        private System.Windows.Forms.Label labelQuestName;
        private System.Windows.Forms.Label labelPrimaryImage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBoxProfessionSecondary;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxShowCompleted;
    }
}


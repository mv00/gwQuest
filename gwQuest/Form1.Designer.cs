﻿namespace gwQuest
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
            this.lblCampaign = new System.Windows.Forms.Label();
            this.labelProfessionMain = new System.Windows.Forms.Label();
            this.comboBoxProfessionMain = new System.Windows.Forms.ComboBox();
            this.comboBoxCampaign = new System.Windows.Forms.ComboBox();
            this.comboBoxProfessionSecondary = new System.Windows.Forms.ComboBox();
            this.checkBoxShowCompleted = new System.Windows.Forms.CheckBox();
            this.labelQuestDetails = new System.Windows.Forms.Label();
            this.linkLabelQuest = new System.Windows.Forms.LinkLabel();
            this.labelPrimary = new System.Windows.Forms.Label();
            this.labelQuestName = new System.Windows.Forms.Label();
            this.labelPrimaryImage = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.labelRegion = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.labelStatRegion = new System.Windows.Forms.Label();
            this.labelStatCampaign = new System.Windows.Forms.Label();
            this.labeTotal = new System.Windows.Forms.Label();
            this.labelRegionCount = new System.Windows.Forms.Label();
            this.labelCampaignCount = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCampaign
            // 
            this.lblCampaign.AutoSize = true;
            this.lblCampaign.Location = new System.Drawing.Point(445, 241);
            this.lblCampaign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCampaign.Name = "lblCampaign";
            this.lblCampaign.Size = new System.Drawing.Size(62, 15);
            this.lblCampaign.TabIndex = 2;
            this.lblCampaign.Text = "Campaign";
            // 
            // labelProfessionMain
            // 
            this.labelProfessionMain.AutoSize = true;
            this.labelProfessionMain.Location = new System.Drawing.Point(449, 404);
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
            this.comboBoxProfessionMain.Location = new System.Drawing.Point(449, 422);
            this.comboBoxProfessionMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProfessionMain.Name = "comboBoxProfessionMain";
            this.comboBoxProfessionMain.Size = new System.Drawing.Size(140, 23);
            this.comboBoxProfessionMain.TabIndex = 3;
            this.comboBoxProfessionMain.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProfessionMain_SelectedIndexChanged);
            // 
            // comboBoxCampaign
            // 
            this.comboBoxCampaign.DisplayMember = "Name";
            this.comboBoxCampaign.FormattingEnabled = true;
            this.comboBoxCampaign.Location = new System.Drawing.Point(449, 259);
            this.comboBoxCampaign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxCampaign.Name = "comboBoxCampaign";
            this.comboBoxCampaign.Size = new System.Drawing.Size(140, 23);
            this.comboBoxCampaign.TabIndex = 1;
            this.comboBoxCampaign.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCampaign_SelectedIndexChanged);
            // 
            // comboBoxProfessionSecondary
            // 
            this.comboBoxProfessionSecondary.DisplayMember = "Name";
            this.comboBoxProfessionSecondary.FormattingEnabled = true;
            this.comboBoxProfessionSecondary.Location = new System.Drawing.Point(449, 453);
            this.comboBoxProfessionSecondary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProfessionSecondary.Name = "comboBoxProfessionSecondary";
            this.comboBoxProfessionSecondary.Size = new System.Drawing.Size(140, 23);
            this.comboBoxProfessionSecondary.TabIndex = 5;
            this.comboBoxProfessionSecondary.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProfessionSecondary_SelectedIndexChanged);
            // 
            // checkBoxShowCompleted
            // 
            this.checkBoxShowCompleted.AutoSize = true;
            this.checkBoxShowCompleted.Location = new System.Drawing.Point(445, 656);
            this.checkBoxShowCompleted.Name = "checkBoxShowCompleted";
            this.checkBoxShowCompleted.Size = new System.Drawing.Size(152, 19);
            this.checkBoxShowCompleted.TabIndex = 6;
            this.checkBoxShowCompleted.Text = "Show completed quests";
            this.checkBoxShowCompleted.UseVisualStyleBackColor = true;
            this.checkBoxShowCompleted.CheckedChanged += new System.EventHandler(this.CheckBoxShowCompleted_CheckedChanged);
            // 
            // labelQuestDetails
            // 
            this.labelQuestDetails.AutoSize = true;
            this.labelQuestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestDetails.Location = new System.Drawing.Point(445, 12);
            this.labelQuestDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestDetails.Name = "labelQuestDetails";
            this.labelQuestDetails.Size = new System.Drawing.Size(186, 33);
            this.labelQuestDetails.TabIndex = 3;
            this.labelQuestDetails.Text = "Quest details";
            this.labelQuestDetails.Visible = false;
            // 
            // linkLabelQuest
            // 
            this.linkLabelQuest.AutoSize = true;
            this.linkLabelQuest.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelQuest.Location = new System.Drawing.Point(451, 135);
            this.linkLabelQuest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelQuest.Name = "linkLabelQuest";
            this.linkLabelQuest.Size = new System.Drawing.Size(97, 20);
            this.linkLabelQuest.TabIndex = 4;
            this.linkLabelQuest.TabStop = true;
            this.linkLabelQuest.Text = "Open in Wiki";
            this.linkLabelQuest.Visible = false;
            this.linkLabelQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelQuest_LinkClicked);
            // 
            // labelPrimary
            // 
            this.labelPrimary.AutoSize = true;
            this.labelPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrimary.Location = new System.Drawing.Point(451, 58);
            this.labelPrimary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrimary.Name = "labelPrimary";
            this.labelPrimary.Size = new System.Drawing.Size(61, 20);
            this.labelPrimary.TabIndex = 5;
            this.labelPrimary.Text = "Primary";
            this.labelPrimary.Visible = false;
            // 
            // labelQuestName
            // 
            this.labelQuestName.AutoSize = true;
            this.labelQuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestName.Location = new System.Drawing.Point(451, 98);
            this.labelQuestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestName.Name = "labelQuestName";
            this.labelQuestName.Size = new System.Drawing.Size(127, 20);
            this.labelQuestName.TabIndex = 7;
            this.labelQuestName.Text = "labelQuestName";
            this.labelQuestName.Visible = false;
            // 
            // labelPrimaryImage
            // 
            this.labelPrimaryImage.AutoSize = true;
            this.labelPrimaryImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPrimaryImage.Image = global::gwQuest.Resources.Resources.Tango_quest_icon_primary;
            this.labelPrimaryImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPrimaryImage.Location = new System.Drawing.Point(520, 58);
            this.labelPrimaryImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrimaryImage.Name = "labelPrimaryImage";
            this.labelPrimaryImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPrimaryImage.Size = new System.Drawing.Size(13, 20);
            this.labelPrimaryImage.TabIndex = 8;
            this.labelPrimaryImage.Text = " ";
            this.labelPrimaryImage.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AutoArrange = false;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 12);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(424, 663);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 173);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Completed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(449, 309);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(44, 15);
            this.labelRegion.TabIndex = 11;
            this.labelRegion.Text = "Region";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(449, 327);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(140, 23);
            this.comboBoxRegion.TabIndex = 12;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRegion_SelectedIndexChanged);
            // 
            // labelStatistics
            // 
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStatistics.Location = new System.Drawing.Point(445, 560);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(84, 25);
            this.labelStatistics.TabIndex = 13;
            this.labelStatistics.Text = "Statistics";
            // 
            // labelStatRegion
            // 
            this.labelStatRegion.AutoSize = true;
            this.labelStatRegion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStatRegion.Location = new System.Drawing.Point(449, 585);
            this.labelStatRegion.Name = "labelStatRegion";
            this.labelStatRegion.Size = new System.Drawing.Size(52, 17);
            this.labelStatRegion.TabIndex = 14;
            this.labelStatRegion.Text = "Region:";
            // 
            // labelStatCampaign
            // 
            this.labelStatCampaign.AutoSize = true;
            this.labelStatCampaign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStatCampaign.Location = new System.Drawing.Point(449, 602);
            this.labelStatCampaign.Name = "labelStatCampaign";
            this.labelStatCampaign.Size = new System.Drawing.Size(70, 17);
            this.labelStatCampaign.TabIndex = 15;
            this.labelStatCampaign.Text = "Campaign:";
            // 
            // labeTotal
            // 
            this.labeTotal.AutoSize = true;
            this.labeTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labeTotal.Location = new System.Drawing.Point(449, 619);
            this.labeTotal.Name = "labeTotal";
            this.labeTotal.Size = new System.Drawing.Size(39, 17);
            this.labeTotal.TabIndex = 16;
            this.labeTotal.Text = "Total:";
            // 
            // labelRegionCount
            // 
            this.labelRegionCount.AutoSize = true;
            this.labelRegionCount.Location = new System.Drawing.Point(540, 587);
            this.labelRegionCount.Name = "labelRegionCount";
            this.labelRegionCount.Size = new System.Drawing.Size(38, 15);
            this.labelRegionCount.TabIndex = 17;
            this.labelRegionCount.Text = "label4";
            // 
            // labelCampaignCount
            // 
            this.labelCampaignCount.AutoSize = true;
            this.labelCampaignCount.Location = new System.Drawing.Point(540, 604);
            this.labelCampaignCount.Name = "labelCampaignCount";
            this.labelCampaignCount.Size = new System.Drawing.Size(38, 15);
            this.labelCampaignCount.TabIndex = 18;
            this.labelCampaignCount.Text = "label5";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Location = new System.Drawing.Point(540, 622);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(38, 15);
            this.labelTotalCount.TabIndex = 19;
            this.labelTotalCount.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 691);
            this.Controls.Add(this.labelTotalCount);
            this.Controls.Add(this.labelCampaignCount);
            this.Controls.Add(this.labelRegionCount);
            this.Controls.Add(this.labeTotal);
            this.Controls.Add(this.labelStatCampaign);
            this.Controls.Add(this.labelStatRegion);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxShowCompleted);
            this.Controls.Add(this.labelPrimaryImage);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelQuestName);
            this.Controls.Add(this.comboBoxProfessionSecondary);
            this.Controls.Add(this.labelPrimary);
            this.Controls.Add(this.labelProfessionMain);
            this.Controls.Add(this.linkLabelQuest);
            this.Controls.Add(this.comboBoxProfessionMain);
            this.Controls.Add(this.labelQuestDetails);
            this.Controls.Add(this.lblCampaign);
            this.Controls.Add(this.comboBoxCampaign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Guild Wars Questing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCampaign;
        private System.Windows.Forms.Label lblCampaign;
        private System.Windows.Forms.Label labelProfessionMain;
        private System.Windows.Forms.ComboBox comboBoxProfessionMain;
        private System.Windows.Forms.ComboBox comboBoxProfessionSecondary;
        private System.Windows.Forms.CheckBox checkBoxShowCompleted;
        private System.Windows.Forms.Label labelQuestDetails;
        private System.Windows.Forms.LinkLabel linkLabelQuest;
        private System.Windows.Forms.Label labelPrimary;
        private System.Windows.Forms.Label labelQuestName;
        private System.Windows.Forms.Label labelPrimaryImage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Label labelStatRegion;
        private System.Windows.Forms.Label labelStatCampaign;
        private System.Windows.Forms.Label labeTotal;
        private System.Windows.Forms.Label labelRegionCount;
        private System.Windows.Forms.Label labelCampaignCount;
        private System.Windows.Forms.Label labelTotalCount;
    }
}


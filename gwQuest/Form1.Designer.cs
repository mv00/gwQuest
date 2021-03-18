﻿using gwQuest.Common;
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelPrimaryImage = new System.Windows.Forms.Label();
            this.labelQuestName = new System.Windows.Forms.Label();
            this.listBoxQuests = new System.Windows.Forms.ListBox();
            this.labelPrimary = new System.Windows.Forms.Label();
            this.linkLabelQuest = new System.Windows.Forms.LinkLabel();
            this.labelQuestDetails = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCampaign = new System.Windows.Forms.Label();
            this.labelProfession = new System.Windows.Forms.Label();
            this.comboBoxProfession = new System.Windows.Forms.ComboBox();
            this.comboBoxCampaign = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 112);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1188, 619);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.labelPrimaryImage);
            this.tabPage1.Controls.Add(this.labelQuestName);
            this.tabPage1.Controls.Add(this.listBoxQuests);
            this.tabPage1.Controls.Add(this.labelPrimary);
            this.tabPage1.Controls.Add(this.linkLabelQuest);
            this.tabPage1.Controls.Add(this.labelQuestDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1180, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ascalon";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Visible = false;
            // 
            // labelPrimaryImage
            // 
            this.labelPrimaryImage.AutoSize = true;
            this.labelPrimaryImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrimaryImage.Image = global::gwQuest.Resources.Resources.Tango_quest_icon_primary;
            this.labelPrimaryImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPrimaryImage.Location = new System.Drawing.Point(404, 49);
            this.labelPrimaryImage.Name = "labelPrimaryImage";
            this.labelPrimaryImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPrimaryImage.Size = new System.Drawing.Size(13, 20);
            this.labelPrimaryImage.TabIndex = 8;
            this.labelPrimaryImage.Text = " ";
            // 
            // labelQuestName
            // 
            this.labelQuestName.AutoSize = true;
            this.labelQuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestName.Location = new System.Drawing.Point(440, 94);
            this.labelQuestName.Name = "labelQuestName";
            this.labelQuestName.Size = new System.Drawing.Size(127, 20);
            this.labelQuestName.TabIndex = 7;
            this.labelQuestName.Text = "labelQuestName";
            // 
            // listBoxQuests
            // 
            this.listBoxQuests.FormattingEnabled = true;
            this.listBoxQuests.Location = new System.Drawing.Point(8, 6);
            this.listBoxQuests.Name = "listBoxQuests";
            this.listBoxQuests.Size = new System.Drawing.Size(312, 576);
            this.listBoxQuests.TabIndex = 6;
            // 
            // labelPrimary
            // 
            this.labelPrimary.AutoSize = true;
            this.labelPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrimary.Location = new System.Drawing.Point(337, 49);
            this.labelPrimary.Name = "labelPrimary";
            this.labelPrimary.Size = new System.Drawing.Size(61, 20);
            this.labelPrimary.TabIndex = 5;
            this.labelPrimary.Text = "Primary";
            // 
            // linkLabelQuest
            // 
            this.linkLabelQuest.AutoSize = true;
            this.linkLabelQuest.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelQuest.Location = new System.Drawing.Point(337, 94);
            this.linkLabelQuest.Name = "linkLabelQuest";
            this.linkLabelQuest.Size = new System.Drawing.Size(97, 20);
            this.linkLabelQuest.TabIndex = 4;
            this.linkLabelQuest.TabStop = true;
            this.linkLabelQuest.Text = "Open in Wiki";
            this.linkLabelQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQuest_LinkClicked);
            // 
            // labelQuestDetails
            // 
            this.labelQuestDetails.AutoSize = true;
            this.labelQuestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestDetails.Location = new System.Drawing.Point(326, 6);
            this.labelQuestDetails.Name = "labelQuestDetails";
            this.labelQuestDetails.Size = new System.Drawing.Size(186, 33);
            this.labelQuestDetails.TabIndex = 3;
            this.labelQuestDetails.Text = "Quest details";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1180, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Northen Shiverpeaks";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // lblCampaign
            // 
            this.lblCampaign.AutoSize = true;
            this.lblCampaign.Location = new System.Drawing.Point(8, 24);
            this.lblCampaign.Name = "lblCampaign";
            this.lblCampaign.Size = new System.Drawing.Size(54, 13);
            this.lblCampaign.TabIndex = 2;
            this.lblCampaign.Text = "Campaign";
            // 
            // labelProfession
            // 
            this.labelProfession.AutoSize = true;
            this.labelProfession.Location = new System.Drawing.Point(156, 24);
            this.labelProfession.Name = "labelProfession";
            this.labelProfession.Size = new System.Drawing.Size(56, 13);
            this.labelProfession.TabIndex = 4;
            this.labelProfession.Text = "Profession";
            // 
            // comboBoxProfession
            // 
            this.comboBoxProfession.DisplayMember = "Name";
            this.comboBoxProfession.FormattingEnabled = true;
            this.comboBoxProfession.Location = new System.Drawing.Point(159, 43);
            this.comboBoxProfession.Name = "comboBoxProfession";
            this.comboBoxProfession.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProfession.TabIndex = 3;
            this.comboBoxProfession.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxCampaign
            // 
            this.comboBoxCampaign.DisplayMember = "Name";
            this.comboBoxCampaign.FormattingEnabled = true;
            this.comboBoxCampaign.Location = new System.Drawing.Point(11, 43);
            this.comboBoxCampaign.Name = "comboBoxCampaign";
            this.comboBoxCampaign.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCampaign.TabIndex = 1;
            this.comboBoxCampaign.SelectedIndexChanged += new System.EventHandler(this.comboBoxCampaign_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(377, 373);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 743);
            this.Controls.Add(this.labelProfession);
            this.Controls.Add(this.comboBoxProfession);
            this.Controls.Add(this.lblCampaign);
            this.Controls.Add(this.comboBoxCampaign);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label labelProfession;
        private System.Windows.Forms.ComboBox comboBoxProfession;
        private System.Windows.Forms.Label labelQuestDetails;
        private System.Windows.Forms.LinkLabel linkLabelQuest;
        private System.Windows.Forms.Label labelPrimary;
        private System.Windows.Forms.ListBox listBoxQuests;
        private System.Windows.Forms.Label labelQuestName;
        private System.Windows.Forms.Label labelPrimaryImage;
        private System.Windows.Forms.ListView listView1;
    }
}


/* This file is part of AHD ID3 Tag Editor (AITE)
 * A program that edit and create ID3 Tag.
 *
 * Copyright © Alaa Ibrahim Hadid 2012 - 2021
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace AHD.ID3.Editor.GUI
{
    partial class C_UrlLinkEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_UrlLinkEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textEditorControl_Payment = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OfficialInternetRadioStationHomepage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_PublishersOfficialWebpage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_CopyrightLegalInformation = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_CommercialInformation = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OfficialAudioSourceWebpage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OfficialArtistPerformerWebpage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OfficialAudioFileWebpage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_UserDefinedURLLinkFrames = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserDefinedURLLinkFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.Label1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(464, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Save changes";
            this.toolStripButton1.Click += new System.EventHandler(this.SaveChanges);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Reload";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 22);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.textEditorControl_Payment);
            this.tabPage1.Controls.Add(this.textEditorControl_OfficialInternetRadioStationHomepage);
            this.tabPage1.Controls.Add(this.textEditorControl_PublishersOfficialWebpage);
            this.tabPage1.Controls.Add(this.textEditorControl_CopyrightLegalInformation);
            this.tabPage1.Controls.Add(this.textEditorControl_CommercialInformation);
            this.tabPage1.Controls.Add(this.textEditorControl_OfficialAudioSourceWebpage);
            this.tabPage1.Controls.Add(this.textEditorControl_OfficialArtistPerformerWebpage);
            this.tabPage1.Controls.Add(this.textEditorControl_OfficialAudioFileWebpage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Link frames";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textEditorControl_Payment
            // 
            this.textEditorControl_Payment.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_Payment.LinkTooltip = "";
            this.textEditorControl_Payment.LinkValue = "linkLabel1";
            this.textEditorControl_Payment.LinkVisible = false;
            this.textEditorControl_Payment.Location = new System.Drawing.Point(3, 276);
            this.textEditorControl_Payment.MaximumCharsCount = 32767;
            this.textEditorControl_Payment.Name = "textEditorControl_Payment";
            this.textEditorControl_Payment.PropertyName = "Payment:";
            this.textEditorControl_Payment.PropertyValue = "";
            this.textEditorControl_Payment.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_Payment.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textEditorControl_Payment, "   The \'Payment\' frame is a URL pointing at a webpage that will handle\r\n   the pr" +
        "ocess of paying for this file.");
            // 
            // textEditorControl_OfficialInternetRadioStationHomepage
            // 
            this.textEditorControl_OfficialInternetRadioStationHomepage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_OfficialInternetRadioStationHomepage.LinkTooltip = "";
            this.textEditorControl_OfficialInternetRadioStationHomepage.LinkValue = "linkLabel1";
            this.textEditorControl_OfficialInternetRadioStationHomepage.LinkVisible = false;
            this.textEditorControl_OfficialInternetRadioStationHomepage.Location = new System.Drawing.Point(3, 237);
            this.textEditorControl_OfficialInternetRadioStationHomepage.MaximumCharsCount = 32767;
            this.textEditorControl_OfficialInternetRadioStationHomepage.Name = "textEditorControl_OfficialInternetRadioStationHomepage";
            this.textEditorControl_OfficialInternetRadioStationHomepage.PropertyName = "Official internet radio station homepage:";
            this.textEditorControl_OfficialInternetRadioStationHomepage.PropertyValue = "";
            this.textEditorControl_OfficialInternetRadioStationHomepage.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_OfficialInternetRadioStationHomepage.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textEditorControl_OfficialInternetRadioStationHomepage, "   The \'Official internet radio station homepage\' contains a URL\r\n   pointing at " +
        "the homepage of the internet radio station.");
            // 
            // textEditorControl_PublishersOfficialWebpage
            // 
            this.textEditorControl_PublishersOfficialWebpage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_PublishersOfficialWebpage.LinkTooltip = "";
            this.textEditorControl_PublishersOfficialWebpage.LinkValue = "linkLabel1";
            this.textEditorControl_PublishersOfficialWebpage.LinkVisible = false;
            this.textEditorControl_PublishersOfficialWebpage.Location = new System.Drawing.Point(3, 198);
            this.textEditorControl_PublishersOfficialWebpage.MaximumCharsCount = 32767;
            this.textEditorControl_PublishersOfficialWebpage.Name = "textEditorControl_PublishersOfficialWebpage";
            this.textEditorControl_PublishersOfficialWebpage.PropertyName = "Publishers official webpage:";
            this.textEditorControl_PublishersOfficialWebpage.PropertyValue = "";
            this.textEditorControl_PublishersOfficialWebpage.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_PublishersOfficialWebpage.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textEditorControl_PublishersOfficialWebpage, "   The \'Publishers official webpage\' frame is a URL pointing at the\r\n   official " +
        "wepage for the publisher.");
            // 
            // textEditorControl_CopyrightLegalInformation
            // 
            this.textEditorControl_CopyrightLegalInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_CopyrightLegalInformation.LinkTooltip = "";
            this.textEditorControl_CopyrightLegalInformation.LinkValue = "linkLabel1";
            this.textEditorControl_CopyrightLegalInformation.LinkVisible = false;
            this.textEditorControl_CopyrightLegalInformation.Location = new System.Drawing.Point(3, 159);
            this.textEditorControl_CopyrightLegalInformation.MaximumCharsCount = 32767;
            this.textEditorControl_CopyrightLegalInformation.Name = "textEditorControl_CopyrightLegalInformation";
            this.textEditorControl_CopyrightLegalInformation.PropertyName = "Copyright/Legal information:";
            this.textEditorControl_CopyrightLegalInformation.PropertyValue = "";
            this.textEditorControl_CopyrightLegalInformation.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_CopyrightLegalInformation.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textEditorControl_CopyrightLegalInformation, "   The \'Copyright/Legal information\' frame is a URL pointing at a\r\n   webpage whe" +
        "re the terms of use and ownership of the file is described.");
            // 
            // textEditorControl_CommercialInformation
            // 
            this.textEditorControl_CommercialInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_CommercialInformation.LinkTooltip = "";
            this.textEditorControl_CommercialInformation.LinkValue = "linkLabel1";
            this.textEditorControl_CommercialInformation.LinkVisible = false;
            this.textEditorControl_CommercialInformation.Location = new System.Drawing.Point(3, 120);
            this.textEditorControl_CommercialInformation.MaximumCharsCount = 32767;
            this.textEditorControl_CommercialInformation.Name = "textEditorControl_CommercialInformation";
            this.textEditorControl_CommercialInformation.PropertyName = "Commercial information:";
            this.textEditorControl_CommercialInformation.PropertyValue = "";
            this.textEditorControl_CommercialInformation.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_CommercialInformation.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textEditorControl_CommercialInformation, "   The \'Commercial information\' frame is a URL pointing at a webpage\r\n   with inf" +
        "ormation such as where the album can be bought. There may be\r\n   more than one \"" +
        "WCM\" frame in a tag.");
            // 
            // textEditorControl_OfficialAudioSourceWebpage
            // 
            this.textEditorControl_OfficialAudioSourceWebpage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_OfficialAudioSourceWebpage.LinkTooltip = "";
            this.textEditorControl_OfficialAudioSourceWebpage.LinkValue = "linkLabel1";
            this.textEditorControl_OfficialAudioSourceWebpage.LinkVisible = false;
            this.textEditorControl_OfficialAudioSourceWebpage.Location = new System.Drawing.Point(3, 81);
            this.textEditorControl_OfficialAudioSourceWebpage.MaximumCharsCount = 32767;
            this.textEditorControl_OfficialAudioSourceWebpage.Name = "textEditorControl_OfficialAudioSourceWebpage";
            this.textEditorControl_OfficialAudioSourceWebpage.PropertyName = "Official audio source webpage:";
            this.textEditorControl_OfficialAudioSourceWebpage.PropertyValue = "";
            this.textEditorControl_OfficialAudioSourceWebpage.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_OfficialAudioSourceWebpage.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textEditorControl_OfficialAudioSourceWebpage, "   The \'Official audio source webpage\' frame is a URL pointing at the\r\n   officia" +
        "l webpage for the source of the audio file, e.g. a movie.");
            // 
            // textEditorControl_OfficialArtistPerformerWebpage
            // 
            this.textEditorControl_OfficialArtistPerformerWebpage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_OfficialArtistPerformerWebpage.LinkTooltip = "";
            this.textEditorControl_OfficialArtistPerformerWebpage.LinkValue = "linkLabel1";
            this.textEditorControl_OfficialArtistPerformerWebpage.LinkVisible = false;
            this.textEditorControl_OfficialArtistPerformerWebpage.Location = new System.Drawing.Point(3, 42);
            this.textEditorControl_OfficialArtistPerformerWebpage.MaximumCharsCount = 32767;
            this.textEditorControl_OfficialArtistPerformerWebpage.Name = "textEditorControl_OfficialArtistPerformerWebpage";
            this.textEditorControl_OfficialArtistPerformerWebpage.PropertyName = "Official artist/performer webpage:";
            this.textEditorControl_OfficialArtistPerformerWebpage.PropertyValue = "";
            this.textEditorControl_OfficialArtistPerformerWebpage.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_OfficialArtistPerformerWebpage.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textEditorControl_OfficialArtistPerformerWebpage, resources.GetString("textEditorControl_OfficialArtistPerformerWebpage.ToolTip"));
            // 
            // textEditorControl_OfficialAudioFileWebpage
            // 
            this.textEditorControl_OfficialAudioFileWebpage.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_OfficialAudioFileWebpage.LinkTooltip = "";
            this.textEditorControl_OfficialAudioFileWebpage.LinkValue = "linkLabel1";
            this.textEditorControl_OfficialAudioFileWebpage.LinkVisible = false;
            this.textEditorControl_OfficialAudioFileWebpage.Location = new System.Drawing.Point(3, 3);
            this.textEditorControl_OfficialAudioFileWebpage.MaximumCharsCount = 32767;
            this.textEditorControl_OfficialAudioFileWebpage.Name = "textEditorControl_OfficialAudioFileWebpage";
            this.textEditorControl_OfficialAudioFileWebpage.PropertyName = "Official audio file webpage:";
            this.textEditorControl_OfficialAudioFileWebpage.PropertyValue = "";
            this.textEditorControl_OfficialAudioFileWebpage.Size = new System.Drawing.Size(450, 39);
            this.textEditorControl_OfficialAudioFileWebpage.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textEditorControl_OfficialAudioFileWebpage, "   The \'Official audio file webpage\' frame is a URL pointing at a file\r\n   specif" +
        "ic webpage.");
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.dataGridView_UserDefinedURLLinkFrames);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User defined";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_UserDefinedURLLinkFrames
            // 
            this.dataGridView_UserDefinedURLLinkFrames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_UserDefinedURLLinkFrames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UserDefinedURLLinkFrames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView_UserDefinedURLLinkFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_UserDefinedURLLinkFrames.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_UserDefinedURLLinkFrames.Name = "dataGridView_UserDefinedURLLinkFrames";
            this.dataGridView_UserDefinedURLLinkFrames.Size = new System.Drawing.Size(450, 404);
            this.dataGridView_UserDefinedURLLinkFrames.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "URL";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // C_UrlLinkEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_UrlLinkEditor";
            this.Size = new System.Drawing.Size(464, 461);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserDefinedURLLinkFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TextEditorControl textEditorControl_OfficialAudioFileWebpage;
        private System.Windows.Forms.ToolStripLabel Label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private TextEditorControl textEditorControl_OfficialArtistPerformerWebpage;
        private TextEditorControl textEditorControl_OfficialAudioSourceWebpage;
        private TextEditorControl textEditorControl_CommercialInformation;
        private TextEditorControl textEditorControl_CopyrightLegalInformation;
        private TextEditorControl textEditorControl_PublishersOfficialWebpage;
        private TextEditorControl textEditorControl_OfficialInternetRadioStationHomepage;
        private TextEditorControl textEditorControl_Payment;
        private System.Windows.Forms.DataGridView dataGridView_UserDefinedURLLinkFrames;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

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
    partial class C_QuickTagEditorV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_QuickTagEditorV2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxControl_Genre = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_track = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imagePanel1 = new AHD.ID3.Editor.GUI.ImagePanel();
            this.ratingControl1 = new AHD.ID3.Editor.GUI.RatingControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextControl1 = new AHD.ID3.Editor.GUI.RichTextControl();
            this.comboBoxControl_album = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_artist = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_title = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.fileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceStartWithxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sNTxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dateControl_year = new AHD.ID3.Editor.GUI.DateControl();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxControl_Genre);
            this.panel1.Controls.Add(this.dateControl_year);
            this.panel1.Controls.Add(this.textEditorControl_track);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 152);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxControl_Genre
            // 
            this.comboBoxControl_Genre.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_Genre.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_Genre.LinkValue = "^";
            this.comboBoxControl_Genre.LinkVisible = true;
            this.comboBoxControl_Genre.Location = new System.Drawing.Point(135, 90);
            this.comboBoxControl_Genre.Name = "comboBoxControl_Genre";
            this.comboBoxControl_Genre.PropertyName = "Genre:";
            this.comboBoxControl_Genre.PropertyValue = "";
            this.comboBoxControl_Genre.Size = new System.Drawing.Size(156, 43);
            this.comboBoxControl_Genre.TabIndex = 13;
            this.comboBoxControl_Genre.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_Genre_LinkClicked);
            // 
            // textEditorControl_track
            // 
            this.textEditorControl_track.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_track.LinkTooltip = "Fill this field from id3v1";
            this.textEditorControl_track.LinkValue = "^";
            this.textEditorControl_track.LinkVisible = true;
            this.textEditorControl_track.Location = new System.Drawing.Point(135, 0);
            this.textEditorControl_track.MaximumCharsCount = 32767;
            this.textEditorControl_track.Name = "textEditorControl_track";
            this.textEditorControl_track.PropertyName = "Track:";
            this.textEditorControl_track.PropertyValue = "";
            this.textEditorControl_track.Size = new System.Drawing.Size(156, 41);
            this.textEditorControl_track.TabIndex = 1;
            this.textEditorControl_track.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_track_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.imagePanel1);
            this.panel3.Controls.Add(this.ratingControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 152);
            this.panel3.TabIndex = 0;
            // 
            // imagePanel1
            // 
            this.imagePanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imagePanel1.ImageToView = null;
            this.imagePanel1.Location = new System.Drawing.Point(5, 3);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(125, 119);
            this.imagePanel1.TabIndex = 0;
            this.imagePanel1.Text = "imagePanel1";
            this.toolTip1.SetToolTip(this.imagePanel1, "Click to manage pictures.");
            this.imagePanel1.Click += new System.EventHandler(this.imagePanel1_Click);
            // 
            // ratingControl1
            // 
            this.ratingControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ratingControl1.Location = new System.Drawing.Point(4, 124);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Rating = 0;
            this.ratingControl1.Size = new System.Drawing.Size(129, 25);
            this.ratingControl1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ratingControl1, "Click to change rating.\r\n(Move cursor to the right side of the 5th star to unrate" +
        ")");
            this.ratingControl1.RatingChanged += new System.EventHandler(this.ratingControl1_RatingChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.richTextControl1);
            this.panel2.Controls.Add(this.comboBoxControl_album);
            this.panel2.Controls.Add(this.comboBoxControl_artist);
            this.panel2.Controls.Add(this.textEditorControl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 225);
            this.panel2.TabIndex = 2;
            // 
            // richTextControl1
            // 
            this.richTextControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextControl1.LinkTooltip = "Fill this field from id3v1";
            this.richTextControl1.LinkValue = "^";
            this.richTextControl1.LinkVisible = true;
            this.richTextControl1.Location = new System.Drawing.Point(0, 125);
            this.richTextControl1.Name = "richTextControl1";
            this.richTextControl1.PropertyName = "Comment:";
            this.richTextControl1.PropertyValue = "";
            this.richTextControl1.Size = new System.Drawing.Size(274, 114);
            this.richTextControl1.TabIndex = 12;
            this.richTextControl1.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.richTextControl1_LinkClicked);
            // 
            // comboBoxControl_album
            // 
            this.comboBoxControl_album.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_album.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_album.LinkValue = "^";
            this.comboBoxControl_album.LinkVisible = true;
            this.comboBoxControl_album.Location = new System.Drawing.Point(0, 82);
            this.comboBoxControl_album.Name = "comboBoxControl_album";
            this.comboBoxControl_album.PropertyName = "Album:";
            this.comboBoxControl_album.PropertyValue = "";
            this.comboBoxControl_album.Size = new System.Drawing.Size(274, 43);
            this.comboBoxControl_album.TabIndex = 11;
            this.comboBoxControl_album.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_album_LinkClicked);
            // 
            // comboBoxControl_artist
            // 
            this.comboBoxControl_artist.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_artist.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_artist.LinkValue = "^";
            this.comboBoxControl_artist.LinkVisible = true;
            this.comboBoxControl_artist.Location = new System.Drawing.Point(0, 39);
            this.comboBoxControl_artist.Name = "comboBoxControl_artist";
            this.comboBoxControl_artist.PropertyName = "Artist:";
            this.comboBoxControl_artist.PropertyValue = "";
            this.comboBoxControl_artist.Size = new System.Drawing.Size(274, 43);
            this.comboBoxControl_artist.TabIndex = 10;
            this.comboBoxControl_artist.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_artist_LinkClicked);
            // 
            // textEditorControl_title
            // 
            this.textEditorControl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_title.LinkTooltip = "Fill this field from id3v1";
            this.textEditorControl_title.LinkValue = "^";
            this.textEditorControl_title.LinkVisible = true;
            this.textEditorControl_title.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl_title.MaximumCharsCount = 32767;
            this.textEditorControl_title.Name = "textEditorControl_title";
            this.textEditorControl_title.PropertyName = "Title:";
            this.textEditorControl_title.PropertyValue = "";
            this.textEditorControl_title.Size = new System.Drawing.Size(274, 39);
            this.textEditorControl_title.TabIndex = 9;
            this.textEditorControl_title.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_title_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator5,
            this.toolStripSplitButton1,
            this.toolStripSeparator4,
            this.Label1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(291, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.ToolTipText = "Save changes.";
            this.toolStripButton1.Click += new System.EventHandler(this.SaveChanges);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Reload";
            this.toolStripButton2.ToolTipText = "Reload id3v2 data from selected file(s)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Full edit";
            this.toolStripButton3.Click += new System.EventHandler(this.FullEdit);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.IsLink = true;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel1.Text = "v1";
            this.toolStripLabel1.ToolTipText = "Fill fields from id3v1 of a file.";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameToolStripMenuItem,
            this.toolStripSeparator3,
            this.sequenceToolStripMenuItem,
            this.nTToolStripMenuItem,
            this.sequenceStartWithxToolStripMenuItem,
            this.sNTxToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Set code";
            // 
            // fileNameToolStripMenuItem
            // 
            this.fileNameToolStripMenuItem.Name = "fileNameToolStripMenuItem";
            this.fileNameToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.fileNameToolStripMenuItem.Text = "<FileName>";
            this.fileNameToolStripMenuItem.ToolTipText = "The file name without extension. \r\nWorks with Title field only.";
            this.fileNameToolStripMenuItem.Click += new System.EventHandler(this.fileNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
            // 
            // sequenceToolStripMenuItem
            // 
            this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
            this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sequenceToolStripMenuItem.Text = "<Sequence>";
            this.sequenceToolStripMenuItem.ToolTipText = "Set the number of a file as presented in the save sequence.\r\nWorks only with Trac" +
    "k field.";
            this.sequenceToolStripMenuItem.Click += new System.EventHandler(this.sequenceToolStripMenuItem_Click);
            // 
            // nTToolStripMenuItem
            // 
            this.nTToolStripMenuItem.Name = "nTToolStripMenuItem";
            this.nTToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.nTToolStripMenuItem.Text = "<N/T>";
            this.nTToolStripMenuItem.ToolTipText = "Number/Total files count. Sets the file number\r\nas presented in the save sequence" +
    " / total files count\r\nof the saving sequence. Works only with Track field.\r\nWork" +
    "s with Track field only.";
            this.nTToolStripMenuItem.Click += new System.EventHandler(this.nTToolStripMenuItem_Click);
            // 
            // sequenceStartWithxToolStripMenuItem
            // 
            this.sequenceStartWithxToolStripMenuItem.Name = "sequenceStartWithxToolStripMenuItem";
            this.sequenceStartWithxToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sequenceStartWithxToolStripMenuItem.Text = "<SequenceStartWith>(x)";
            this.sequenceStartWithxToolStripMenuItem.ToolTipText = resources.GetString("sequenceStartWithxToolStripMenuItem.ToolTipText");
            this.sequenceStartWithxToolStripMenuItem.Click += new System.EventHandler(this.sequenceStartWithxToolStripMenuItem_Click);
            // 
            // sNTxToolStripMenuItem
            // 
            this.sNTxToolStripMenuItem.Name = "sNTxToolStripMenuItem";
            this.sNTxToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sNTxToolStripMenuItem.Text = "<SN/T>(x)";
            this.sNTxToolStripMenuItem.ToolTipText = resources.GetString("sNTxToolStripMenuItem.ToolTipText");
            this.sNTxToolStripMenuItem.Click += new System.EventHandler(this.sNTxToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 22);
            this.Label1.Text = "Edit 0 files.";
            // 
            // dateControl_year
            // 
            this.dateControl_year.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateControl_year.LinkTooltip = "Fill this field from id3v1";
            this.dateControl_year.LinkValue = "^";
            this.dateControl_year.LinkVisible = true;
            this.dateControl_year.Location = new System.Drawing.Point(135, 41);
            this.dateControl_year.Name = "dateControl_year";
            this.dateControl_year.PropertyName = "Year/Release time:";
            this.dateControl_year.PropertyValue = new System.DateTime(2013, 2, 20, 20, 12, 0, 556);
            this.dateControl_year.Size = new System.Drawing.Size(156, 49);
            this.dateControl_year.TabIndex = 14;
            this.dateControl_year.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_year_LinkClicked);
            // 
            // C_QuickTagEditorV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_QuickTagEditorV2";
            this.Size = new System.Drawing.Size(291, 402);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImagePanel imagePanel1;
        private RatingControl ratingControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private TextEditorControl textEditorControl_title;
        private TextEditorControl textEditorControl_track;
        private System.Windows.Forms.Panel panel3;
        private ComboBoxControl comboBoxControl_album;
        private ComboBoxControl comboBoxControl_artist;
        private ComboBoxControl comboBoxControl_Genre;
        private RichTextControl richTextControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem fileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceStartWithxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sNTxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel Label1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DateControl dateControl_year;
    }
}

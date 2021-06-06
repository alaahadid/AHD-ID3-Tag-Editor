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
    partial class C_QuickTagEditorV1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_QuickTagEditorV1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.fileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceStartWithxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.textEditorControl_comment = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_track = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.numberControl_year = new AHD.ID3.Editor.GUI.NumberControl();
            this.comboBoxControl_genre = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_album = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_artist = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_title = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripSplitButton1,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.Label1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(250, 25);
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
            this.toolStripButton1.Text = "Save";
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
            this.toolStripButton2.Text = "Reload";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameToolStripMenuItem,
            this.toolStripSeparator2,
            this.sequenceToolStripMenuItem,
            this.sequenceStartWithxToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ToolTipText = "Set code";
            // 
            // fileNameToolStripMenuItem
            // 
            this.fileNameToolStripMenuItem.Name = "fileNameToolStripMenuItem";
            this.fileNameToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.fileNameToolStripMenuItem.Text = "<FileName>";
            this.fileNameToolStripMenuItem.ToolTipText = "Sets the file name without extension.\r\nWorks with Title field only.";
            this.fileNameToolStripMenuItem.Click += new System.EventHandler(this.fileNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
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
            // sequenceStartWithxToolStripMenuItem
            // 
            this.sequenceStartWithxToolStripMenuItem.Name = "sequenceStartWithxToolStripMenuItem";
            this.sequenceStartWithxToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sequenceStartWithxToolStripMenuItem.Text = "<SequenceStartWith>(x)";
            this.sequenceStartWithxToolStripMenuItem.ToolTipText = resources.GetString("sequenceStartWithxToolStripMenuItem.ToolTipText");
            this.sequenceStartWithxToolStripMenuItem.Click += new System.EventHandler(this.sequenceStartWithxToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Fill fields from id3v2 of file.";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 22);
            this.Label1.Text = "Edit 0 file.";
            // 
            // textEditorControl_comment
            // 
            this.textEditorControl_comment.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_comment.LinkTooltip = "Fill this field from ID3v2";
            this.textEditorControl_comment.LinkValue = "^";
            this.textEditorControl_comment.LinkVisible = true;
            this.textEditorControl_comment.Location = new System.Drawing.Point(0, 271);
            this.textEditorControl_comment.MaximumCharsCount = 32767;
            this.textEditorControl_comment.Name = "textEditorControl_comment";
            this.textEditorControl_comment.PropertyName = "Comment:";
            this.textEditorControl_comment.PropertyValue = "";
            this.textEditorControl_comment.Size = new System.Drawing.Size(250, 41);
            this.textEditorControl_comment.TabIndex = 7;
            this.textEditorControl_comment.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_comment_LinkClicked);
            // 
            // textEditorControl_track
            // 
            this.textEditorControl_track.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_track.LinkTooltip = "Fill this field from ID3v2";
            this.textEditorControl_track.LinkValue = "^";
            this.textEditorControl_track.LinkVisible = true;
            this.textEditorControl_track.Location = new System.Drawing.Point(0, 230);
            this.textEditorControl_track.MaximumCharsCount = 32767;
            this.textEditorControl_track.Name = "textEditorControl_track";
            this.textEditorControl_track.PropertyName = "Track:";
            this.textEditorControl_track.PropertyValue = "";
            this.textEditorControl_track.Size = new System.Drawing.Size(250, 41);
            this.textEditorControl_track.TabIndex = 8;
            this.textEditorControl_track.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_track_LinkClicked);
            // 
            // numberControl_year
            // 
            this.numberControl_year.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberControl_year.LinkTooltip = "Fill this field from ID3v2";
            this.numberControl_year.LinkValue = "^";
            this.numberControl_year.LinkVisible = true;
            this.numberControl_year.Location = new System.Drawing.Point(0, 189);
            this.numberControl_year.MaximumNumber = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numberControl_year.MinimumNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_year.Name = "numberControl_year";
            this.numberControl_year.PropertyName = "Year:";
            this.numberControl_year.PropertyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numberControl_year.Size = new System.Drawing.Size(250, 41);
            this.numberControl_year.TabIndex = 6;
            this.numberControl_year.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.numberControl_year_LinkClicked);
            // 
            // comboBoxControl_genre
            // 
            this.comboBoxControl_genre.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_genre.LinkTooltip = "Fill this field from ID3v2";
            this.comboBoxControl_genre.LinkValue = "^";
            this.comboBoxControl_genre.LinkVisible = true;
            this.comboBoxControl_genre.Location = new System.Drawing.Point(0, 148);
            this.comboBoxControl_genre.Name = "comboBoxControl_genre";
            this.comboBoxControl_genre.PropertyName = "Genre:";
            this.comboBoxControl_genre.PropertyValue = "";
            this.comboBoxControl_genre.Size = new System.Drawing.Size(250, 41);
            this.comboBoxControl_genre.TabIndex = 4;
            this.comboBoxControl_genre.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_genre_LinkClicked);
            // 
            // comboBoxControl_album
            // 
            this.comboBoxControl_album.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_album.LinkTooltip = "Fill this field from ID3v2";
            this.comboBoxControl_album.LinkValue = "^";
            this.comboBoxControl_album.LinkVisible = true;
            this.comboBoxControl_album.Location = new System.Drawing.Point(0, 107);
            this.comboBoxControl_album.Name = "comboBoxControl_album";
            this.comboBoxControl_album.PropertyName = "Album:";
            this.comboBoxControl_album.PropertyValue = "";
            this.comboBoxControl_album.Size = new System.Drawing.Size(250, 41);
            this.comboBoxControl_album.TabIndex = 3;
            this.comboBoxControl_album.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_album_LinkClicked);
            // 
            // comboBoxControl_artist
            // 
            this.comboBoxControl_artist.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxControl_artist.LinkTooltip = "Fill this field from ID3v2";
            this.comboBoxControl_artist.LinkValue = "^";
            this.comboBoxControl_artist.LinkVisible = true;
            this.comboBoxControl_artist.Location = new System.Drawing.Point(0, 66);
            this.comboBoxControl_artist.Name = "comboBoxControl_artist";
            this.comboBoxControl_artist.PropertyName = "Artist:";
            this.comboBoxControl_artist.PropertyValue = "";
            this.comboBoxControl_artist.Size = new System.Drawing.Size(250, 41);
            this.comboBoxControl_artist.TabIndex = 2;
            this.comboBoxControl_artist.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_artist_LinkClicked);
            // 
            // textEditorControl_title
            // 
            this.textEditorControl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl_title.LinkTooltip = "Fill this field from ID3v2";
            this.textEditorControl_title.LinkValue = "^";
            this.textEditorControl_title.LinkVisible = true;
            this.textEditorControl_title.Location = new System.Drawing.Point(0, 25);
            this.textEditorControl_title.MaximumCharsCount = 32767;
            this.textEditorControl_title.Name = "textEditorControl_title";
            this.textEditorControl_title.PropertyName = "Title:";
            this.textEditorControl_title.PropertyValue = "";
            this.textEditorControl_title.Size = new System.Drawing.Size(250, 41);
            this.textEditorControl_title.TabIndex = 1;
            this.textEditorControl_title.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_title_LinkClicked);
            // 
            // C_QuickTagEditorV1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditorControl_comment);
            this.Controls.Add(this.textEditorControl_track);
            this.Controls.Add(this.numberControl_year);
            this.Controls.Add(this.comboBoxControl_genre);
            this.Controls.Add(this.comboBoxControl_album);
            this.Controls.Add(this.comboBoxControl_artist);
            this.Controls.Add(this.textEditorControl_title);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_QuickTagEditorV1";
            this.Size = new System.Drawing.Size(250, 341);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private TextEditorControl textEditorControl_title;
        private ComboBoxControl comboBoxControl_artist;
        private ComboBoxControl comboBoxControl_album;
        private ComboBoxControl comboBoxControl_genre;
        private NumberControl numberControl_year;
        private TextEditorControl textEditorControl_comment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem fileNameToolStripMenuItem;
        private TextEditorControl textEditorControl_track;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceStartWithxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel Label1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

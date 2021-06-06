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
    partial class C_FullTextFramesEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_FullTextFramesEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textEditorControl_SetSubtitle = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OriginalAlbum = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_partOfSet = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_track = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_SubtitleDescriptionRefinement = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_ContentGroupDescription = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_ISRC = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.comboBoxControl_album = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_title = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textEditorControl1_InvolvedPeopleList = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_MusicianCreditsList = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OriginalLyricist = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_OriginalArtists = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Lyricist = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Composers = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.comboBoxControl_leadArtist = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_Interpreted = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Conductor = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Band = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_EncodedBy = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textEditorControl_Size = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Mood = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.comboBoxControl_InitialKey = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_FileType = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_MediaType = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_genre = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.comboBoxControl_language = new AHD.ID3.Editor.GUI.ComboBoxControl();
            this.textEditorControl_BPM = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Length = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textEditorControl_ProducedNotice = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_InternetRadioStationOwner = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_CopyrightMessage = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_InternetTadioStationName = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_FileOwner = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_Publisher = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textEditorControl_TitleSortOrder = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_PerformerSortOrder = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_AlbumSortOrder = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.dateControl_TaggingTime = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_ReleaseTime = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_RecordingTime = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_OriginalReleaseTime = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_EncodingTime = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_OriginalYear = new AHD.ID3.Editor.GUI.DateControl();
            this.textEditorControl_OriginalFilename = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.textEditorControl_RecordingDates = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.dateControl_Time = new AHD.ID3.Editor.GUI.DateControl();
            this.dateControl_date = new AHD.ID3.Editor.GUI.DateControl();
            this.textEditorControl_PlaylistDelay = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.dateControl_year = new AHD.ID3.Editor.GUI.DateControl();
            this.textEditorControl_Software = new AHD.ID3.Editor.GUI.TextEditorControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.Label1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(428, 25);
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.IsLink = true;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel1.Text = "v1";
            this.toolStripLabel1.ToolTipText = "Fill fields from id3v1 of this file.";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(428, 534);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.textEditorControl_SetSubtitle);
            this.tabPage1.Controls.Add(this.textEditorControl_OriginalAlbum);
            this.tabPage1.Controls.Add(this.textEditorControl_partOfSet);
            this.tabPage1.Controls.Add(this.textEditorControl_track);
            this.tabPage1.Controls.Add(this.textEditorControl_SubtitleDescriptionRefinement);
            this.tabPage1.Controls.Add(this.textEditorControl_ContentGroupDescription);
            this.tabPage1.Controls.Add(this.textEditorControl_ISRC);
            this.tabPage1.Controls.Add(this.comboBoxControl_album);
            this.tabPage1.Controls.Add(this.textEditorControl_title);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(420, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Identification";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textEditorControl_SetSubtitle
            // 
            this.textEditorControl_SetSubtitle.LinkTooltip = "";
            this.textEditorControl_SetSubtitle.LinkValue = "linkLabel1";
            this.textEditorControl_SetSubtitle.LinkVisible = false;
            this.textEditorControl_SetSubtitle.Location = new System.Drawing.Point(6, 377);
            this.textEditorControl_SetSubtitle.MaximumCharsCount = 32767;
            this.textEditorControl_SetSubtitle.Name = "textEditorControl_SetSubtitle";
            this.textEditorControl_SetSubtitle.PropertyName = "Set subtitle:";
            this.textEditorControl_SetSubtitle.PropertyValue = "";
            this.textEditorControl_SetSubtitle.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_SetSubtitle.TabIndex = 16;
            this.toolTip1.SetToolTip(this.textEditorControl_SetSubtitle, "The \'Set subtitle\' frame is intended for the subtitle of the part of\r\na set this " +
        "track belongs to.");
            // 
            // textEditorControl_OriginalAlbum
            // 
            this.textEditorControl_OriginalAlbum.LinkTooltip = "";
            this.textEditorControl_OriginalAlbum.LinkValue = "linkLabel1";
            this.textEditorControl_OriginalAlbum.LinkVisible = false;
            this.textEditorControl_OriginalAlbum.Location = new System.Drawing.Point(6, 145);
            this.textEditorControl_OriginalAlbum.MaximumCharsCount = 32767;
            this.textEditorControl_OriginalAlbum.Name = "textEditorControl_OriginalAlbum";
            this.textEditorControl_OriginalAlbum.PropertyName = "Original album/Movie/Show title:";
            this.textEditorControl_OriginalAlbum.PropertyValue = "";
            this.textEditorControl_OriginalAlbum.Size = new System.Drawing.Size(326, 41);
            this.textEditorControl_OriginalAlbum.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textEditorControl_OriginalAlbum, resources.GetString("textEditorControl_OriginalAlbum.ToolTip"));
            // 
            // textEditorControl_partOfSet
            // 
            this.textEditorControl_partOfSet.LinkTooltip = "";
            this.textEditorControl_partOfSet.LinkValue = "linkLabel1";
            this.textEditorControl_partOfSet.LinkVisible = false;
            this.textEditorControl_partOfSet.Location = new System.Drawing.Point(6, 285);
            this.textEditorControl_partOfSet.MaximumCharsCount = 32767;
            this.textEditorControl_partOfSet.Name = "textEditorControl_partOfSet";
            this.textEditorControl_partOfSet.PropertyName = "Part of a set:";
            this.textEditorControl_partOfSet.PropertyValue = "";
            this.textEditorControl_partOfSet.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_partOfSet.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textEditorControl_partOfSet, resources.GetString("textEditorControl_partOfSet.ToolTip"));
            // 
            // textEditorControl_track
            // 
            this.textEditorControl_track.LinkTooltip = "Fill this field from id3v1";
            this.textEditorControl_track.LinkValue = "^";
            this.textEditorControl_track.LinkVisible = false;
            this.textEditorControl_track.Location = new System.Drawing.Point(6, 239);
            this.textEditorControl_track.MaximumCharsCount = 32767;
            this.textEditorControl_track.Name = "textEditorControl_track";
            this.textEditorControl_track.PropertyName = "Track number/Position in set:";
            this.textEditorControl_track.PropertyValue = "";
            this.textEditorControl_track.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_track.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textEditorControl_track, resources.GetString("textEditorControl_track.ToolTip"));
            this.textEditorControl_track.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_track_LinkClicked);
            // 
            // textEditorControl_SubtitleDescriptionRefinement
            // 
            this.textEditorControl_SubtitleDescriptionRefinement.LinkTooltip = "";
            this.textEditorControl_SubtitleDescriptionRefinement.LinkValue = "linkLabel1";
            this.textEditorControl_SubtitleDescriptionRefinement.LinkVisible = false;
            this.textEditorControl_SubtitleDescriptionRefinement.Location = new System.Drawing.Point(6, 52);
            this.textEditorControl_SubtitleDescriptionRefinement.MaximumCharsCount = 32767;
            this.textEditorControl_SubtitleDescriptionRefinement.Name = "textEditorControl_SubtitleDescriptionRefinement";
            this.textEditorControl_SubtitleDescriptionRefinement.PropertyName = "Subtitle/Description refinement:";
            this.textEditorControl_SubtitleDescriptionRefinement.PropertyValue = "";
            this.textEditorControl_SubtitleDescriptionRefinement.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_SubtitleDescriptionRefinement.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textEditorControl_SubtitleDescriptionRefinement, "   The \'Subtitle/Description refinement\' frame is used for information\r\n   direct" +
        "ly related to the contents title (e.g. \"Op. 16\" or \"Performed\r\n   live at wemble" +
        "y\").");
            // 
            // textEditorControl_ContentGroupDescription
            // 
            this.textEditorControl_ContentGroupDescription.LinkTooltip = "";
            this.textEditorControl_ContentGroupDescription.LinkValue = "linkLabel1";
            this.textEditorControl_ContentGroupDescription.LinkVisible = false;
            this.textEditorControl_ContentGroupDescription.Location = new System.Drawing.Point(6, 192);
            this.textEditorControl_ContentGroupDescription.MaximumCharsCount = 32767;
            this.textEditorControl_ContentGroupDescription.Name = "textEditorControl_ContentGroupDescription";
            this.textEditorControl_ContentGroupDescription.PropertyName = "Content group description:";
            this.textEditorControl_ContentGroupDescription.PropertyValue = "";
            this.textEditorControl_ContentGroupDescription.Size = new System.Drawing.Size(326, 41);
            this.textEditorControl_ContentGroupDescription.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textEditorControl_ContentGroupDescription, resources.GetString("textEditorControl_ContentGroupDescription.ToolTip"));
            // 
            // textEditorControl_ISRC
            // 
            this.textEditorControl_ISRC.LinkTooltip = "";
            this.textEditorControl_ISRC.LinkValue = "linkLabel1";
            this.textEditorControl_ISRC.LinkVisible = false;
            this.textEditorControl_ISRC.Location = new System.Drawing.Point(6, 331);
            this.textEditorControl_ISRC.MaximumCharsCount = 32767;
            this.textEditorControl_ISRC.Name = "textEditorControl_ISRC";
            this.textEditorControl_ISRC.PropertyName = "ISRC:";
            this.textEditorControl_ISRC.PropertyValue = "";
            this.textEditorControl_ISRC.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_ISRC.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textEditorControl_ISRC, "   The \'ISRC\' frame should contian the International Standard Recording\r\n   Code " +
        "[ISRC].");
            // 
            // comboBoxControl_album
            // 
            this.comboBoxControl_album.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_album.LinkValue = "^";
            this.comboBoxControl_album.LinkVisible = false;
            this.comboBoxControl_album.Location = new System.Drawing.Point(6, 98);
            this.comboBoxControl_album.Name = "comboBoxControl_album";
            this.comboBoxControl_album.PropertyName = "Album/Movie/Show title:";
            this.comboBoxControl_album.PropertyValue = "";
            this.comboBoxControl_album.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_album.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxControl_album, "The \'Album/Movie/Show title\' frame is intended for the title of the\r\nrecording(/s" +
        "ource of sound) which the audio in the file is taken from.");
            this.comboBoxControl_album.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_album_LinkClicked);
            // 
            // textEditorControl_title
            // 
            this.textEditorControl_title.LinkTooltip = "Fill this field from id3v1";
            this.textEditorControl_title.LinkValue = "^";
            this.textEditorControl_title.LinkVisible = false;
            this.textEditorControl_title.Location = new System.Drawing.Point(6, 6);
            this.textEditorControl_title.MaximumCharsCount = 32767;
            this.textEditorControl_title.Name = "textEditorControl_title";
            this.textEditorControl_title.PropertyName = "Title/Songname/Content description:";
            this.textEditorControl_title.PropertyValue = "";
            this.textEditorControl_title.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_title.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textEditorControl_title, "The \'Title/Songname/Content description\' frame is the actual name of\r\nthe piece (" +
        "e.g. \"Adagio\", \"Hurricane Donna\").");
            this.textEditorControl_title.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.textEditorControl_title_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.textEditorControl1_InvolvedPeopleList);
            this.tabPage2.Controls.Add(this.textEditorControl_MusicianCreditsList);
            this.tabPage2.Controls.Add(this.textEditorControl_OriginalLyricist);
            this.tabPage2.Controls.Add(this.textEditorControl_OriginalArtists);
            this.tabPage2.Controls.Add(this.textEditorControl_Lyricist);
            this.tabPage2.Controls.Add(this.textEditorControl_Composers);
            this.tabPage2.Controls.Add(this.comboBoxControl_leadArtist);
            this.tabPage2.Controls.Add(this.textEditorControl_Interpreted);
            this.tabPage2.Controls.Add(this.textEditorControl_Conductor);
            this.tabPage2.Controls.Add(this.textEditorControl_Band);
            this.tabPage2.Controls.Add(this.textEditorControl_EncodedBy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(420, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Involved persons";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textEditorControl1_InvolvedPeopleList
            // 
            this.textEditorControl1_InvolvedPeopleList.LinkTooltip = "";
            this.textEditorControl1_InvolvedPeopleList.LinkValue = "linkLabel1";
            this.textEditorControl1_InvolvedPeopleList.LinkVisible = false;
            this.textEditorControl1_InvolvedPeopleList.Location = new System.Drawing.Point(6, 469);
            this.textEditorControl1_InvolvedPeopleList.MaximumCharsCount = 32767;
            this.textEditorControl1_InvolvedPeopleList.Name = "textEditorControl1_InvolvedPeopleList";
            this.textEditorControl1_InvolvedPeopleList.PropertyName = "Involved people list:";
            this.textEditorControl1_InvolvedPeopleList.PropertyValue = "";
            this.textEditorControl1_InvolvedPeopleList.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl1_InvolvedPeopleList.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textEditorControl1_InvolvedPeopleList, "   The \'Involved people list\' is very similar to the musician credits\r\n   list, b" +
        "ut maps between functions, like producer, and names.");
            // 
            // textEditorControl_MusicianCreditsList
            // 
            this.textEditorControl_MusicianCreditsList.LinkTooltip = "";
            this.textEditorControl_MusicianCreditsList.LinkValue = "linkLabel1";
            this.textEditorControl_MusicianCreditsList.LinkVisible = false;
            this.textEditorControl_MusicianCreditsList.Location = new System.Drawing.Point(6, 423);
            this.textEditorControl_MusicianCreditsList.MaximumCharsCount = 32767;
            this.textEditorControl_MusicianCreditsList.Name = "textEditorControl_MusicianCreditsList";
            this.textEditorControl_MusicianCreditsList.PropertyName = "Musician credits list:";
            this.textEditorControl_MusicianCreditsList.PropertyValue = "";
            this.textEditorControl_MusicianCreditsList.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_MusicianCreditsList.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textEditorControl_MusicianCreditsList, resources.GetString("textEditorControl_MusicianCreditsList.ToolTip"));
            // 
            // textEditorControl_OriginalLyricist
            // 
            this.textEditorControl_OriginalLyricist.LinkTooltip = "";
            this.textEditorControl_OriginalLyricist.LinkValue = "linkLabel1";
            this.textEditorControl_OriginalLyricist.LinkVisible = false;
            this.textEditorControl_OriginalLyricist.Location = new System.Drawing.Point(6, 285);
            this.textEditorControl_OriginalLyricist.MaximumCharsCount = 32767;
            this.textEditorControl_OriginalLyricist.Name = "textEditorControl_OriginalLyricist";
            this.textEditorControl_OriginalLyricist.PropertyName = "Original Lyricist(s)/text writer(s):";
            this.textEditorControl_OriginalLyricist.PropertyValue = "";
            this.textEditorControl_OriginalLyricist.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_OriginalLyricist.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textEditorControl_OriginalLyricist, resources.GetString("textEditorControl_OriginalLyricist.ToolTip"));
            // 
            // textEditorControl_OriginalArtists
            // 
            this.textEditorControl_OriginalArtists.LinkTooltip = "";
            this.textEditorControl_OriginalArtists.LinkValue = "linkLabel1";
            this.textEditorControl_OriginalArtists.LinkVisible = false;
            this.textEditorControl_OriginalArtists.Location = new System.Drawing.Point(6, 53);
            this.textEditorControl_OriginalArtists.MaximumCharsCount = 32767;
            this.textEditorControl_OriginalArtists.Name = "textEditorControl_OriginalArtists";
            this.textEditorControl_OriginalArtists.PropertyName = "Original artist(s)/performer(s):";
            this.textEditorControl_OriginalArtists.PropertyValue = "";
            this.textEditorControl_OriginalArtists.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_OriginalArtists.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textEditorControl_OriginalArtists, resources.GetString("textEditorControl_OriginalArtists.ToolTip"));
            // 
            // textEditorControl_Lyricist
            // 
            this.textEditorControl_Lyricist.LinkTooltip = "";
            this.textEditorControl_Lyricist.LinkValue = "linkLabel1";
            this.textEditorControl_Lyricist.LinkVisible = false;
            this.textEditorControl_Lyricist.Location = new System.Drawing.Point(6, 238);
            this.textEditorControl_Lyricist.MaximumCharsCount = 32767;
            this.textEditorControl_Lyricist.Name = "textEditorControl_Lyricist";
            this.textEditorControl_Lyricist.PropertyName = "Lyricist(s)/text writer(s):";
            this.textEditorControl_Lyricist.PropertyValue = "";
            this.textEditorControl_Lyricist.Size = new System.Drawing.Size(326, 41);
            this.textEditorControl_Lyricist.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textEditorControl_Lyricist, "   The \'Lyricist(s)/text writer(s)\' frame is intended for the writer(s)\r\n   of th" +
        "e text or lyrics in the recording. They are seperated with the\r\n   \"/\" character" +
        ".");
            // 
            // textEditorControl_Composers
            // 
            this.textEditorControl_Composers.LinkTooltip = "";
            this.textEditorControl_Composers.LinkValue = "linkLabel1";
            this.textEditorControl_Composers.LinkVisible = false;
            this.textEditorControl_Composers.Location = new System.Drawing.Point(6, 191);
            this.textEditorControl_Composers.MaximumCharsCount = 32767;
            this.textEditorControl_Composers.Name = "textEditorControl_Composers";
            this.textEditorControl_Composers.PropertyName = "Composer(s):";
            this.textEditorControl_Composers.PropertyValue = "";
            this.textEditorControl_Composers.Size = new System.Drawing.Size(326, 41);
            this.textEditorControl_Composers.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textEditorControl_Composers, "   The \'Composer(s)\' frame is intended for the name of the composer(s).\r\n   They " +
        "are seperated with the \"/\" character.");
            // 
            // comboBoxControl_leadArtist
            // 
            this.comboBoxControl_leadArtist.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_leadArtist.LinkValue = "^";
            this.comboBoxControl_leadArtist.LinkVisible = false;
            this.comboBoxControl_leadArtist.Location = new System.Drawing.Point(6, 6);
            this.comboBoxControl_leadArtist.Name = "comboBoxControl_leadArtist";
            this.comboBoxControl_leadArtist.PropertyName = "Lead artist(s)/Lead performer(s)/Soloist(s)/Performing group:";
            this.comboBoxControl_leadArtist.PropertyValue = "";
            this.comboBoxControl_leadArtist.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_leadArtist.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBoxControl_leadArtist, "The \'Lead artist(s)/Lead performer(s)/Soloist(s)/Performing group\' is\r\nused for t" +
        "he main artist(s). They are seperated with the \"/\"\r\ncharacter.");
            this.comboBoxControl_leadArtist.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_leadArtist_LinkClicked);
            // 
            // textEditorControl_Interpreted
            // 
            this.textEditorControl_Interpreted.LinkTooltip = "";
            this.textEditorControl_Interpreted.LinkValue = "linkLabel1";
            this.textEditorControl_Interpreted.LinkVisible = false;
            this.textEditorControl_Interpreted.Location = new System.Drawing.Point(6, 331);
            this.textEditorControl_Interpreted.MaximumCharsCount = 32767;
            this.textEditorControl_Interpreted.Name = "textEditorControl_Interpreted";
            this.textEditorControl_Interpreted.PropertyName = "Interpreted, remixed, or otherwise modified by:";
            this.textEditorControl_Interpreted.PropertyValue = "";
            this.textEditorControl_Interpreted.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Interpreted.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textEditorControl_Interpreted, "   The \'Interpreted, remixed, or otherwise modified by\' frame contains\r\n   more i" +
        "nformation about the people behind a remix and similar\r\n   interpretations of an" +
        "other existing piece.");
            // 
            // textEditorControl_Conductor
            // 
            this.textEditorControl_Conductor.LinkTooltip = "";
            this.textEditorControl_Conductor.LinkValue = "linkLabel1";
            this.textEditorControl_Conductor.LinkVisible = false;
            this.textEditorControl_Conductor.Location = new System.Drawing.Point(6, 145);
            this.textEditorControl_Conductor.MaximumCharsCount = 32767;
            this.textEditorControl_Conductor.Name = "textEditorControl_Conductor";
            this.textEditorControl_Conductor.PropertyName = "Conductor:";
            this.textEditorControl_Conductor.PropertyValue = "";
            this.textEditorControl_Conductor.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Conductor.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textEditorControl_Conductor, "The \'Conductor\' frame is used for the name of the conductor.");
            // 
            // textEditorControl_Band
            // 
            this.textEditorControl_Band.LinkTooltip = "";
            this.textEditorControl_Band.LinkValue = "linkLabel1";
            this.textEditorControl_Band.LinkVisible = false;
            this.textEditorControl_Band.Location = new System.Drawing.Point(6, 99);
            this.textEditorControl_Band.MaximumCharsCount = 32767;
            this.textEditorControl_Band.Name = "textEditorControl_Band";
            this.textEditorControl_Band.PropertyName = "Band/Orchestra/Accompaniment:";
            this.textEditorControl_Band.PropertyValue = "";
            this.textEditorControl_Band.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Band.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textEditorControl_Band, "The \'Band/Orchestra/Accompaniment\' frame is used for additional\r\ninformation abou" +
        "t the performers in the recording.");
            // 
            // textEditorControl_EncodedBy
            // 
            this.textEditorControl_EncodedBy.LinkTooltip = "";
            this.textEditorControl_EncodedBy.LinkValue = "linkLabel1";
            this.textEditorControl_EncodedBy.LinkVisible = false;
            this.textEditorControl_EncodedBy.Location = new System.Drawing.Point(6, 377);
            this.textEditorControl_EncodedBy.MaximumCharsCount = 32767;
            this.textEditorControl_EncodedBy.Name = "textEditorControl_EncodedBy";
            this.textEditorControl_EncodedBy.PropertyName = "Encoded by:";
            this.textEditorControl_EncodedBy.PropertyValue = "";
            this.textEditorControl_EncodedBy.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_EncodedBy.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textEditorControl_EncodedBy, resources.GetString("textEditorControl_EncodedBy.ToolTip"));
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.textEditorControl_Size);
            this.tabPage3.Controls.Add(this.textEditorControl_Mood);
            this.tabPage3.Controls.Add(this.comboBoxControl_InitialKey);
            this.tabPage3.Controls.Add(this.comboBoxControl_FileType);
            this.tabPage3.Controls.Add(this.comboBoxControl_MediaType);
            this.tabPage3.Controls.Add(this.comboBoxControl_genre);
            this.tabPage3.Controls.Add(this.comboBoxControl_language);
            this.tabPage3.Controls.Add(this.textEditorControl_BPM);
            this.tabPage3.Controls.Add(this.textEditorControl_Length);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(420, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Derived and subjective properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textEditorControl_Size
            // 
            this.textEditorControl_Size.LinkTooltip = "";
            this.textEditorControl_Size.LinkValue = "linkLabel1";
            this.textEditorControl_Size.LinkVisible = false;
            this.textEditorControl_Size.Location = new System.Drawing.Point(6, 145);
            this.textEditorControl_Size.MaximumCharsCount = 32767;
            this.textEditorControl_Size.Name = "textEditorControl_Size";
            this.textEditorControl_Size.PropertyName = "Size (bytes):";
            this.textEditorControl_Size.PropertyValue = "";
            this.textEditorControl_Size.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Size.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textEditorControl_Size, "   The \'Size\' frame contains the size of the audiofile in bytes\r\n   excluding the" +
        " tag, represented as a numeric string.");
            // 
            // textEditorControl_Mood
            // 
            this.textEditorControl_Mood.LinkTooltip = "";
            this.textEditorControl_Mood.LinkValue = "linkLabel1";
            this.textEditorControl_Mood.LinkVisible = false;
            this.textEditorControl_Mood.Location = new System.Drawing.Point(6, 377);
            this.textEditorControl_Mood.MaximumCharsCount = 32767;
            this.textEditorControl_Mood.Name = "textEditorControl_Mood";
            this.textEditorControl_Mood.PropertyName = "Mood:";
            this.textEditorControl_Mood.PropertyValue = "";
            this.textEditorControl_Mood.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Mood.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textEditorControl_Mood, "   The \'Mood\' frame is intended to reflect the mood of the audio with a\r\n   few k" +
        "eywords, e.g. \"Romantic\" or \"Sad\".");
            // 
            // comboBoxControl_InitialKey
            // 
            this.comboBoxControl_InitialKey.LinkTooltip = "";
            this.comboBoxControl_InitialKey.LinkValue = "linkLabel1";
            this.comboBoxControl_InitialKey.LinkVisible = false;
            this.comboBoxControl_InitialKey.Location = new System.Drawing.Point(6, 52);
            this.comboBoxControl_InitialKey.Name = "comboBoxControl_InitialKey";
            this.comboBoxControl_InitialKey.PropertyName = "Initial key:";
            this.comboBoxControl_InitialKey.PropertyValue = "";
            this.comboBoxControl_InitialKey.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_InitialKey.TabIndex = 12;
            this.toolTip1.SetToolTip(this.comboBoxControl_InitialKey, resources.GetString("comboBoxControl_InitialKey.ToolTip"));
            // 
            // comboBoxControl_FileType
            // 
            this.comboBoxControl_FileType.LinkTooltip = "";
            this.comboBoxControl_FileType.LinkValue = "linkLabel1";
            this.comboBoxControl_FileType.LinkVisible = false;
            this.comboBoxControl_FileType.Location = new System.Drawing.Point(6, 283);
            this.comboBoxControl_FileType.Name = "comboBoxControl_FileType";
            this.comboBoxControl_FileType.PropertyName = "File type:";
            this.comboBoxControl_FileType.PropertyValue = "";
            this.comboBoxControl_FileType.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_FileType.TabIndex = 10;
            this.toolTip1.SetToolTip(this.comboBoxControl_FileType, "The \'File type\' frame indicates which type of audio this tag defines.");
            // 
            // comboBoxControl_MediaType
            // 
            this.comboBoxControl_MediaType.LinkTooltip = "";
            this.comboBoxControl_MediaType.LinkValue = "linkLabel1";
            this.comboBoxControl_MediaType.LinkVisible = false;
            this.comboBoxControl_MediaType.Location = new System.Drawing.Point(6, 330);
            this.comboBoxControl_MediaType.Name = "comboBoxControl_MediaType";
            this.comboBoxControl_MediaType.PropertyName = "Media type:";
            this.comboBoxControl_MediaType.PropertyValue = "";
            this.comboBoxControl_MediaType.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_MediaType.TabIndex = 9;
            this.toolTip1.SetToolTip(this.comboBoxControl_MediaType, resources.GetString("comboBoxControl_MediaType.ToolTip"));
            // 
            // comboBoxControl_genre
            // 
            this.comboBoxControl_genre.LinkTooltip = "Fill this field from id3v1";
            this.comboBoxControl_genre.LinkValue = "^";
            this.comboBoxControl_genre.LinkVisible = false;
            this.comboBoxControl_genre.Location = new System.Drawing.Point(6, 238);
            this.comboBoxControl_genre.Name = "comboBoxControl_genre";
            this.comboBoxControl_genre.PropertyName = "Content type (Genre):";
            this.comboBoxControl_genre.PropertyValue = "";
            this.comboBoxControl_genre.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_genre.TabIndex = 5;
            this.toolTip1.SetToolTip(this.comboBoxControl_genre, resources.GetString("comboBoxControl_genre.ToolTip"));
            this.comboBoxControl_genre.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.comboBoxControl_genre_LinkClicked);
            // 
            // comboBoxControl_language
            // 
            this.comboBoxControl_language.LinkTooltip = "";
            this.comboBoxControl_language.LinkValue = "linkLabel1";
            this.comboBoxControl_language.LinkVisible = false;
            this.comboBoxControl_language.Location = new System.Drawing.Point(6, 191);
            this.comboBoxControl_language.Name = "comboBoxControl_language";
            this.comboBoxControl_language.PropertyName = "Language:";
            this.comboBoxControl_language.PropertyValue = "";
            this.comboBoxControl_language.Size = new System.Drawing.Size(326, 41);
            this.comboBoxControl_language.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboBoxControl_language, resources.GetString("comboBoxControl_language.ToolTip"));
            // 
            // textEditorControl_BPM
            // 
            this.textEditorControl_BPM.LinkTooltip = "";
            this.textEditorControl_BPM.LinkValue = "linkLabel1";
            this.textEditorControl_BPM.LinkVisible = false;
            this.textEditorControl_BPM.Location = new System.Drawing.Point(6, 6);
            this.textEditorControl_BPM.MaximumCharsCount = 32767;
            this.textEditorControl_BPM.Name = "textEditorControl_BPM";
            this.textEditorControl_BPM.PropertyName = "BPM:";
            this.textEditorControl_BPM.PropertyValue = "";
            this.textEditorControl_BPM.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_BPM.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textEditorControl_BPM, resources.GetString("textEditorControl_BPM.ToolTip"));
            // 
            // textEditorControl_Length
            // 
            this.textEditorControl_Length.LinkTooltip = "";
            this.textEditorControl_Length.LinkValue = "linkLabel1";
            this.textEditorControl_Length.LinkVisible = false;
            this.textEditorControl_Length.Location = new System.Drawing.Point(6, 99);
            this.textEditorControl_Length.MaximumCharsCount = 32767;
            this.textEditorControl_Length.Name = "textEditorControl_Length";
            this.textEditorControl_Length.PropertyName = "Length:";
            this.textEditorControl_Length.PropertyValue = "";
            this.textEditorControl_Length.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Length.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textEditorControl_Length, "   The \'Length\' frame contains the length of the audiofile in\r\n   milliseconds, r" +
        "epresented as a numeric string.");
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.textEditorControl_ProducedNotice);
            this.tabPage4.Controls.Add(this.textEditorControl_InternetRadioStationOwner);
            this.tabPage4.Controls.Add(this.textEditorControl_CopyrightMessage);
            this.tabPage4.Controls.Add(this.textEditorControl_InternetTadioStationName);
            this.tabPage4.Controls.Add(this.textEditorControl_FileOwner);
            this.tabPage4.Controls.Add(this.textEditorControl_Publisher);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(420, 508);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rights and license";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textEditorControl_ProducedNotice
            // 
            this.textEditorControl_ProducedNotice.LinkTooltip = "";
            this.textEditorControl_ProducedNotice.LinkValue = "linkLabel1";
            this.textEditorControl_ProducedNotice.LinkVisible = false;
            this.textEditorControl_ProducedNotice.Location = new System.Drawing.Point(6, 236);
            this.textEditorControl_ProducedNotice.MaximumCharsCount = 32767;
            this.textEditorControl_ProducedNotice.Name = "textEditorControl_ProducedNotice";
            this.textEditorControl_ProducedNotice.PropertyName = "Produced notice:";
            this.textEditorControl_ProducedNotice.PropertyValue = "";
            this.textEditorControl_ProducedNotice.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_ProducedNotice.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textEditorControl_ProducedNotice, resources.GetString("textEditorControl_ProducedNotice.ToolTip"));
            // 
            // textEditorControl_InternetRadioStationOwner
            // 
            this.textEditorControl_InternetRadioStationOwner.LinkTooltip = "";
            this.textEditorControl_InternetRadioStationOwner.LinkValue = "linkLabel1";
            this.textEditorControl_InternetRadioStationOwner.LinkVisible = false;
            this.textEditorControl_InternetRadioStationOwner.Location = new System.Drawing.Point(6, 190);
            this.textEditorControl_InternetRadioStationOwner.MaximumCharsCount = 32767;
            this.textEditorControl_InternetRadioStationOwner.Name = "textEditorControl_InternetRadioStationOwner";
            this.textEditorControl_InternetRadioStationOwner.PropertyName = "Internet radio station owner:";
            this.textEditorControl_InternetRadioStationOwner.PropertyValue = "";
            this.textEditorControl_InternetRadioStationOwner.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_InternetRadioStationOwner.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textEditorControl_InternetRadioStationOwner, "The \'Internet radio station owner\' frame contains the name of the \r\nowner of the " +
        "internet radio station from which the audio is streamed.");
            // 
            // textEditorControl_CopyrightMessage
            // 
            this.textEditorControl_CopyrightMessage.LinkTooltip = "";
            this.textEditorControl_CopyrightMessage.LinkValue = "linkLabel1";
            this.textEditorControl_CopyrightMessage.LinkVisible = false;
            this.textEditorControl_CopyrightMessage.Location = new System.Drawing.Point(6, 6);
            this.textEditorControl_CopyrightMessage.MaximumCharsCount = 32767;
            this.textEditorControl_CopyrightMessage.Name = "textEditorControl_CopyrightMessage";
            this.textEditorControl_CopyrightMessage.PropertyName = "Copyright message (Copyright ©):";
            this.textEditorControl_CopyrightMessage.PropertyValue = "";
            this.textEditorControl_CopyrightMessage.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_CopyrightMessage.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textEditorControl_CopyrightMessage, resources.GetString("textEditorControl_CopyrightMessage.ToolTip"));
            // 
            // textEditorControl_InternetTadioStationName
            // 
            this.textEditorControl_InternetTadioStationName.LinkTooltip = "";
            this.textEditorControl_InternetTadioStationName.LinkValue = "linkLabel1";
            this.textEditorControl_InternetTadioStationName.LinkVisible = false;
            this.textEditorControl_InternetTadioStationName.Location = new System.Drawing.Point(6, 144);
            this.textEditorControl_InternetTadioStationName.MaximumCharsCount = 32767;
            this.textEditorControl_InternetTadioStationName.Name = "textEditorControl_InternetTadioStationName";
            this.textEditorControl_InternetTadioStationName.PropertyName = "Internet radio station name:";
            this.textEditorControl_InternetTadioStationName.PropertyValue = "";
            this.textEditorControl_InternetTadioStationName.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_InternetTadioStationName.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textEditorControl_InternetTadioStationName, "The \'Internet radio station name\' frame contains the name of the internet \r\nradio" +
        " station from which the audio is streamed.");
            // 
            // textEditorControl_FileOwner
            // 
            this.textEditorControl_FileOwner.LinkTooltip = "";
            this.textEditorControl_FileOwner.LinkValue = "linkLabel1";
            this.textEditorControl_FileOwner.LinkVisible = false;
            this.textEditorControl_FileOwner.Location = new System.Drawing.Point(6, 98);
            this.textEditorControl_FileOwner.MaximumCharsCount = 32767;
            this.textEditorControl_FileOwner.Name = "textEditorControl_FileOwner";
            this.textEditorControl_FileOwner.PropertyName = "File owner/licensee:";
            this.textEditorControl_FileOwner.PropertyValue = "";
            this.textEditorControl_FileOwner.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_FileOwner.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textEditorControl_FileOwner, "The \'File owner/licensee\' frame contains the name of the owner or \r\nlicensee of t" +
        "he file and it\'s contents.");
            // 
            // textEditorControl_Publisher
            // 
            this.textEditorControl_Publisher.LinkTooltip = "";
            this.textEditorControl_Publisher.LinkValue = "linkLabel1";
            this.textEditorControl_Publisher.LinkVisible = false;
            this.textEditorControl_Publisher.Location = new System.Drawing.Point(6, 52);
            this.textEditorControl_Publisher.MaximumCharsCount = 32767;
            this.textEditorControl_Publisher.Name = "textEditorControl_Publisher";
            this.textEditorControl_Publisher.PropertyName = "Publisher:";
            this.textEditorControl_Publisher.PropertyValue = "";
            this.textEditorControl_Publisher.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Publisher.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textEditorControl_Publisher, "The \'Publisher\' frame simply contains the name of the label or\r\npublisher.");
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.textEditorControl_TitleSortOrder);
            this.tabPage5.Controls.Add(this.textEditorControl_PerformerSortOrder);
            this.tabPage5.Controls.Add(this.textEditorControl_AlbumSortOrder);
            this.tabPage5.Controls.Add(this.dateControl_TaggingTime);
            this.tabPage5.Controls.Add(this.dateControl_ReleaseTime);
            this.tabPage5.Controls.Add(this.dateControl_RecordingTime);
            this.tabPage5.Controls.Add(this.dateControl_OriginalReleaseTime);
            this.tabPage5.Controls.Add(this.dateControl_EncodingTime);
            this.tabPage5.Controls.Add(this.dateControl_OriginalYear);
            this.tabPage5.Controls.Add(this.textEditorControl_OriginalFilename);
            this.tabPage5.Controls.Add(this.textEditorControl_RecordingDates);
            this.tabPage5.Controls.Add(this.dateControl_Time);
            this.tabPage5.Controls.Add(this.dateControl_date);
            this.tabPage5.Controls.Add(this.textEditorControl_PlaylistDelay);
            this.tabPage5.Controls.Add(this.dateControl_year);
            this.tabPage5.Controls.Add(this.textEditorControl_Software);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(420, 508);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Other";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textEditorControl_TitleSortOrder
            // 
            this.textEditorControl_TitleSortOrder.LinkTooltip = "";
            this.textEditorControl_TitleSortOrder.LinkValue = "linkLabel1";
            this.textEditorControl_TitleSortOrder.LinkVisible = false;
            this.textEditorControl_TitleSortOrder.Location = new System.Drawing.Point(6, 470);
            this.textEditorControl_TitleSortOrder.MaximumCharsCount = 32767;
            this.textEditorControl_TitleSortOrder.Name = "textEditorControl_TitleSortOrder";
            this.textEditorControl_TitleSortOrder.PropertyName = "Title sort order:";
            this.textEditorControl_TitleSortOrder.PropertyValue = "";
            this.textEditorControl_TitleSortOrder.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_TitleSortOrder.TabIndex = 24;
            this.toolTip1.SetToolTip(this.textEditorControl_TitleSortOrder, "   The \'Title sort order\' frame defines a string which should be used\r\n   instead" +
        " of the title (TIT2) for sorting purposes.");
            // 
            // textEditorControl_PerformerSortOrder
            // 
            this.textEditorControl_PerformerSortOrder.LinkTooltip = "";
            this.textEditorControl_PerformerSortOrder.LinkValue = "linkLabel1";
            this.textEditorControl_PerformerSortOrder.LinkVisible = false;
            this.textEditorControl_PerformerSortOrder.Location = new System.Drawing.Point(6, 424);
            this.textEditorControl_PerformerSortOrder.MaximumCharsCount = 32767;
            this.textEditorControl_PerformerSortOrder.Name = "textEditorControl_PerformerSortOrder";
            this.textEditorControl_PerformerSortOrder.PropertyName = "Performer sort order:";
            this.textEditorControl_PerformerSortOrder.PropertyValue = "";
            this.textEditorControl_PerformerSortOrder.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_PerformerSortOrder.TabIndex = 23;
            this.toolTip1.SetToolTip(this.textEditorControl_PerformerSortOrder, "   The \'Performer sort order\' frame defines a string which should be\r\n   used ins" +
        "tead of the performer (TPE2) for sorting purposes.");
            // 
            // textEditorControl_AlbumSortOrder
            // 
            this.textEditorControl_AlbumSortOrder.LinkTooltip = "";
            this.textEditorControl_AlbumSortOrder.LinkValue = "linkLabel1";
            this.textEditorControl_AlbumSortOrder.LinkVisible = false;
            this.textEditorControl_AlbumSortOrder.Location = new System.Drawing.Point(6, 378);
            this.textEditorControl_AlbumSortOrder.MaximumCharsCount = 32767;
            this.textEditorControl_AlbumSortOrder.Name = "textEditorControl_AlbumSortOrder";
            this.textEditorControl_AlbumSortOrder.PropertyName = "Album sort order:";
            this.textEditorControl_AlbumSortOrder.PropertyValue = "";
            this.textEditorControl_AlbumSortOrder.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_AlbumSortOrder.TabIndex = 22;
            this.toolTip1.SetToolTip(this.textEditorControl_AlbumSortOrder, resources.GetString("textEditorControl_AlbumSortOrder.ToolTip"));
            // 
            // dateControl_TaggingTime
            // 
            this.dateControl_TaggingTime.LinkTooltip = "";
            this.dateControl_TaggingTime.LinkValue = "linkLabel1";
            this.dateControl_TaggingTime.LinkVisible = false;
            this.dateControl_TaggingTime.Location = new System.Drawing.Point(176, 238);
            this.dateControl_TaggingTime.Name = "dateControl_TaggingTime";
            this.dateControl_TaggingTime.PropertyName = "Tagging time:";
            this.dateControl_TaggingTime.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_TaggingTime.Size = new System.Drawing.Size(156, 41);
            this.dateControl_TaggingTime.TabIndex = 21;
            this.toolTip1.SetToolTip(this.dateControl_TaggingTime, "   The \'Tagging time\' frame contains a timestamp describing then the\r\n   audio wa" +
        "s tagged.");
            // 
            // dateControl_ReleaseTime
            // 
            this.dateControl_ReleaseTime.LinkTooltip = "";
            this.dateControl_ReleaseTime.LinkValue = "linkLabel1";
            this.dateControl_ReleaseTime.LinkVisible = false;
            this.dateControl_ReleaseTime.Location = new System.Drawing.Point(6, 238);
            this.dateControl_ReleaseTime.Name = "dateControl_ReleaseTime";
            this.dateControl_ReleaseTime.PropertyName = "Release time:";
            this.dateControl_ReleaseTime.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_ReleaseTime.Size = new System.Drawing.Size(164, 41);
            this.dateControl_ReleaseTime.TabIndex = 20;
            this.toolTip1.SetToolTip(this.dateControl_ReleaseTime, "   The \'Release time\' frame contains a timestamp describing when the\r\n   audio wa" +
        "s first released. ");
            // 
            // dateControl_RecordingTime
            // 
            this.dateControl_RecordingTime.LinkTooltip = "";
            this.dateControl_RecordingTime.LinkValue = "linkLabel1";
            this.dateControl_RecordingTime.LinkVisible = false;
            this.dateControl_RecordingTime.Location = new System.Drawing.Point(6, 285);
            this.dateControl_RecordingTime.Name = "dateControl_RecordingTime";
            this.dateControl_RecordingTime.PropertyName = "Recording time:";
            this.dateControl_RecordingTime.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_RecordingTime.Size = new System.Drawing.Size(164, 41);
            this.dateControl_RecordingTime.TabIndex = 19;
            this.toolTip1.SetToolTip(this.dateControl_RecordingTime, "   The \'Recording time\' frame contains a timestamp describing when the\r\n   audio " +
        "was recorded.");
            // 
            // dateControl_OriginalReleaseTime
            // 
            this.dateControl_OriginalReleaseTime.LinkTooltip = "";
            this.dateControl_OriginalReleaseTime.LinkValue = "linkLabel1";
            this.dateControl_OriginalReleaseTime.LinkVisible = false;
            this.dateControl_OriginalReleaseTime.Location = new System.Drawing.Point(176, 191);
            this.dateControl_OriginalReleaseTime.Name = "dateControl_OriginalReleaseTime";
            this.dateControl_OriginalReleaseTime.PropertyName = "Original release time:";
            this.dateControl_OriginalReleaseTime.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_OriginalReleaseTime.Size = new System.Drawing.Size(156, 41);
            this.dateControl_OriginalReleaseTime.TabIndex = 18;
            this.toolTip1.SetToolTip(this.dateControl_OriginalReleaseTime, "The \'Original release time\' frame contains a timestamp describing\r\nwhen the origi" +
        "nal recording of the audio was released.");
            // 
            // dateControl_EncodingTime
            // 
            this.dateControl_EncodingTime.LinkTooltip = "";
            this.dateControl_EncodingTime.LinkValue = "linkLabel1";
            this.dateControl_EncodingTime.LinkVisible = false;
            this.dateControl_EncodingTime.Location = new System.Drawing.Point(6, 191);
            this.dateControl_EncodingTime.Name = "dateControl_EncodingTime";
            this.dateControl_EncodingTime.PropertyName = "Encoding time:";
            this.dateControl_EncodingTime.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_EncodingTime.Size = new System.Drawing.Size(164, 41);
            this.dateControl_EncodingTime.TabIndex = 17;
            this.toolTip1.SetToolTip(this.dateControl_EncodingTime, "The \'Encoding time\' frame contains a timestamp describing when the\r\naudio was enc" +
        "oded.");
            // 
            // dateControl_OriginalYear
            // 
            this.dateControl_OriginalYear.LinkTooltip = "";
            this.dateControl_OriginalYear.LinkValue = "linkLabel1";
            this.dateControl_OriginalYear.LinkVisible = false;
            this.dateControl_OriginalYear.Location = new System.Drawing.Point(176, 285);
            this.dateControl_OriginalYear.Name = "dateControl_OriginalYear";
            this.dateControl_OriginalYear.PropertyName = "Original release year (YYYY):";
            this.dateControl_OriginalYear.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_OriginalYear.Size = new System.Drawing.Size(156, 41);
            this.dateControl_OriginalYear.TabIndex = 16;
            this.toolTip1.SetToolTip(this.dateControl_OriginalYear, resources.GetString("dateControl_OriginalYear.ToolTip"));
            // 
            // textEditorControl_OriginalFilename
            // 
            this.textEditorControl_OriginalFilename.LinkTooltip = "";
            this.textEditorControl_OriginalFilename.LinkValue = "linkLabel1";
            this.textEditorControl_OriginalFilename.LinkVisible = false;
            this.textEditorControl_OriginalFilename.Location = new System.Drawing.Point(6, 6);
            this.textEditorControl_OriginalFilename.MaximumCharsCount = 32767;
            this.textEditorControl_OriginalFilename.Name = "textEditorControl_OriginalFilename";
            this.textEditorControl_OriginalFilename.PropertyName = "Original filename:";
            this.textEditorControl_OriginalFilename.PropertyValue = "";
            this.textEditorControl_OriginalFilename.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_OriginalFilename.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textEditorControl_OriginalFilename, resources.GetString("textEditorControl_OriginalFilename.ToolTip"));
            // 
            // textEditorControl_RecordingDates
            // 
            this.textEditorControl_RecordingDates.LinkTooltip = "";
            this.textEditorControl_RecordingDates.LinkValue = "linkLabel1";
            this.textEditorControl_RecordingDates.LinkVisible = false;
            this.textEditorControl_RecordingDates.Location = new System.Drawing.Point(6, 332);
            this.textEditorControl_RecordingDates.MaximumCharsCount = 32767;
            this.textEditorControl_RecordingDates.Name = "textEditorControl_RecordingDates";
            this.textEditorControl_RecordingDates.PropertyName = "Recording dates:";
            this.textEditorControl_RecordingDates.PropertyValue = "";
            this.textEditorControl_RecordingDates.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_RecordingDates.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textEditorControl_RecordingDates, "   The \'Recording dates\' frame is a intended to be used as complement to\r\n   the " +
        "\"TYE\", \"TDA\" and \"TIM\" frames. E.g. \"4th-7th June, 12th June\" in\r\n   combination" +
        " with the \"TYE\" frame.");
            // 
            // dateControl_Time
            // 
            this.dateControl_Time.LinkTooltip = "";
            this.dateControl_Time.LinkValue = "linkLabel1";
            this.dateControl_Time.LinkVisible = false;
            this.dateControl_Time.Location = new System.Drawing.Point(6, 144);
            this.dateControl_Time.Name = "dateControl_Time";
            this.dateControl_Time.PropertyName = "Time (HH:MM):";
            this.dateControl_Time.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 768);
            this.dateControl_Time.Size = new System.Drawing.Size(102, 41);
            this.dateControl_Time.TabIndex = 11;
            this.toolTip1.SetToolTip(this.dateControl_Time, "The \'Time\' frame is a numeric string in the HHMM format containing\r\nthe time for " +
        "the recording.");
            // 
            // dateControl_date
            // 
            this.dateControl_date.LinkTooltip = "";
            this.dateControl_date.LinkValue = "linkLabel1";
            this.dateControl_date.LinkVisible = false;
            this.dateControl_date.Location = new System.Drawing.Point(114, 144);
            this.dateControl_date.Name = "dateControl_date";
            this.dateControl_date.PropertyName = "Date (MM/DD):";
            this.dateControl_date.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 768);
            this.dateControl_date.Size = new System.Drawing.Size(109, 41);
            this.dateControl_date.TabIndex = 9;
            this.toolTip1.SetToolTip(this.dateControl_date, "The \'Date\' frame is a numeric string in the DDMM format containing\r\nthe date for " +
        "the recording.");
            // 
            // textEditorControl_PlaylistDelay
            // 
            this.textEditorControl_PlaylistDelay.LinkTooltip = "";
            this.textEditorControl_PlaylistDelay.LinkValue = "linkLabel1";
            this.textEditorControl_PlaylistDelay.LinkVisible = false;
            this.textEditorControl_PlaylistDelay.Location = new System.Drawing.Point(6, 52);
            this.textEditorControl_PlaylistDelay.MaximumCharsCount = 32767;
            this.textEditorControl_PlaylistDelay.Name = "textEditorControl_PlaylistDelay";
            this.textEditorControl_PlaylistDelay.PropertyName = "Playlist delay:";
            this.textEditorControl_PlaylistDelay.PropertyValue = "";
            this.textEditorControl_PlaylistDelay.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_PlaylistDelay.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textEditorControl_PlaylistDelay, resources.GetString("textEditorControl_PlaylistDelay.ToolTip"));
            // 
            // dateControl_year
            // 
            this.dateControl_year.LinkTooltip = "Fill this field from id3v1";
            this.dateControl_year.LinkValue = "^";
            this.dateControl_year.LinkVisible = false;
            this.dateControl_year.Location = new System.Drawing.Point(229, 144);
            this.dateControl_year.Name = "dateControl_year";
            this.dateControl_year.PropertyName = "Year (YYYY):";
            this.dateControl_year.PropertyValue = new System.DateTime(2013, 2, 18, 21, 57, 3, 758);
            this.dateControl_year.Size = new System.Drawing.Size(103, 41);
            this.dateControl_year.TabIndex = 10;
            this.toolTip1.SetToolTip(this.dateControl_year, "The \'Year\' frame is a numeric string with a year of the recording.");
            this.dateControl_year.LinkClicked += new System.EventHandler<System.Windows.Forms.LinkLabelLinkClickedEventArgs>(this.dateControl_year_LinkClicked);
            // 
            // textEditorControl_Software
            // 
            this.textEditorControl_Software.LinkTooltip = "";
            this.textEditorControl_Software.LinkValue = "linkLabel1";
            this.textEditorControl_Software.LinkVisible = false;
            this.textEditorControl_Software.Location = new System.Drawing.Point(6, 98);
            this.textEditorControl_Software.MaximumCharsCount = 32767;
            this.textEditorControl_Software.Name = "textEditorControl_Software";
            this.textEditorControl_Software.PropertyName = "Software/hardware and settings used for encoding:";
            this.textEditorControl_Software.PropertyValue = "";
            this.textEditorControl_Software.Size = new System.Drawing.Size(326, 40);
            this.textEditorControl_Software.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textEditorControl_Software, resources.GetString("textEditorControl_Software.ToolTip"));
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridView1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(420, 508);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "User defined";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(414, 502);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Description";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            // 
            // C_FullTextFramesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "C_FullTextFramesEditor";
            this.Size = new System.Drawing.Size(428, 559);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TextEditorControl textEditorControl_title;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Label1;
        private ComboBoxControl comboBoxControl_leadArtist;
        private ComboBoxControl comboBoxControl_album;
        private TextEditorControl textEditorControl_track;
        private ComboBoxControl comboBoxControl_genre;
        private TextEditorControl textEditorControl_Composers;
        private TextEditorControl textEditorControl_Lyricist;
        private TextEditorControl textEditorControl_partOfSet;
        private DateControl dateControl_date;
        private DateControl dateControl_year;
        private DateControl dateControl_Time;
        private TextEditorControl textEditorControl_ContentGroupDescription;
        private TextEditorControl textEditorControl_Band;
        private TextEditorControl textEditorControl_Conductor;
        private TextEditorControl textEditorControl_Interpreted;
        private TextEditorControl textEditorControl_Publisher;
        private TextEditorControl textEditorControl_CopyrightMessage;
        private TextEditorControl textEditorControl_SubtitleDescriptionRefinement;
        private TextEditorControl textEditorControl_RecordingDates;
        private System.Windows.Forms.TabPage tabPage3;
        private TextEditorControl textEditorControl_OriginalFilename;
        private TextEditorControl textEditorControl_Length;
        private TextEditorControl textEditorControl_Size;
        private TextEditorControl textEditorControl_EncodedBy;
        private TextEditorControl textEditorControl_BPM;
        private ComboBoxControl comboBoxControl_language;
        private TextEditorControl textEditorControl_ISRC;
        private ComboBoxControl comboBoxControl_MediaType;
        private ComboBoxControl comboBoxControl_FileType;
        private TextEditorControl textEditorControl_Software;
        private ComboBoxControl comboBoxControl_InitialKey;
        private TextEditorControl textEditorControl_PlaylistDelay;
        private TextEditorControl textEditorControl_OriginalAlbum;
        private TextEditorControl textEditorControl_OriginalArtists;
        private TextEditorControl textEditorControl_OriginalLyricist;
        private DateControl dateControl_OriginalYear;
        private TextEditorControl textEditorControl_FileOwner;
        private System.Windows.Forms.TabPage tabPage4;
        private TextEditorControl textEditorControl_InternetTadioStationName;
        private TextEditorControl textEditorControl_InternetRadioStationOwner;
        private TextEditorControl textEditorControl_SetSubtitle;
        private TextEditorControl textEditorControl_MusicianCreditsList;
        private TextEditorControl textEditorControl1_InvolvedPeopleList;
        private TextEditorControl textEditorControl_Mood;
        private TextEditorControl textEditorControl_ProducedNotice;
        private System.Windows.Forms.TabPage tabPage5;
        private DateControl dateControl_EncodingTime;
        private DateControl dateControl_OriginalReleaseTime;
        private DateControl dateControl_RecordingTime;
        private DateControl dateControl_ReleaseTime;
        private DateControl dateControl_TaggingTime;
        private TextEditorControl textEditorControl_AlbumSortOrder;
        private TextEditorControl textEditorControl_PerformerSortOrder;
        private TextEditorControl textEditorControl_TitleSortOrder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

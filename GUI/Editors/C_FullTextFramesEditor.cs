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
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MLV;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;

namespace AHD.ID3.Editor.GUI
{
    public partial class C_FullTextFramesEditor : EditorControl
    {
        public C_FullTextFramesEditor(StringCollection genreMemory, StringCollection artistsMemory, StringCollection albumsMemory)
        {
            InitializeComponent();
            this.AlbumsMemory = albumsMemory;
            this.ArtistsMemory = artistsMemory;
            this.GenreMemory = genreMemory;
            DisableControls();
            dateControl_year.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_year.dateTimePicker1.CustomFormat = "yyyy";
            dateControl_OriginalYear.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_OriginalYear.dateTimePicker1.CustomFormat = "yyyy";
            dateControl_date.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_date.dateTimePicker1.CustomFormat = "dd/MM";
            dateControl_Time.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_Time.dateTimePicker1.CustomFormat = "HH:mm";
            dateControl_EncodingTime.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_EncodingTime.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
            dateControl_OriginalReleaseTime.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_OriginalReleaseTime.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
            dateControl_RecordingTime.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_RecordingTime.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
            dateControl_ReleaseTime.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_ReleaseTime.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
            dateControl_TaggingTime.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateControl_TaggingTime.dateTimePicker1.CustomFormat = "yyyy-MM-dd; HH:mm:ss";
            // language
            comboBoxControl_language.comboBox1.Items.Add("");
            foreach (string lang in ID3FrameConsts.Languages)
                comboBoxControl_language.comboBox1.Items.Add(lang);
            comboBoxControl_language.comboBox1.SelectedIndex = 0;
            comboBoxControl_language.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // media type
            comboBoxControl_MediaType.comboBox1.Items.Add("");
            foreach (string t in ID3FrameConsts.MediaTypes)
                comboBoxControl_MediaType.comboBox1.Items.Add(t);
            comboBoxControl_MediaType.comboBox1.SelectedIndex = 0;
            comboBoxControl_MediaType.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // file type
            comboBoxControl_FileType.comboBox1.Items.Add("");
            foreach (string t in ID3FrameConsts.FileTypes)
                comboBoxControl_FileType.comboBox1.Items.Add(t);
            comboBoxControl_FileType.comboBox1.SelectedIndex = 0;
            comboBoxControl_FileType.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // Initial key
            comboBoxControl_InitialKey.comboBox1.Items.Add("");
            foreach (string t in ID3FrameConsts.Tkey)
                comboBoxControl_InitialKey.comboBox1.Items.Add(t);
            comboBoxControl_InitialKey.comboBox1.SelectedIndex = 0;
            comboBoxControl_InitialKey.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //events
            comboBoxControl_leadArtist.comboBox1.Validated += comboBoxArtrists_Validated;
            comboBoxControl_genre.comboBox1.Validated += comboBoxGenre_Validated;
            comboBoxControl_album.comboBox1.Validated += comboBoxAlbums_Validated;
            //
            textEditorControl_title.LinkVisible = true;
            textEditorControl_track.LinkVisible = true;
            comboBoxControl_album.LinkVisible = true;
            comboBoxControl_genre.LinkVisible = true;
            comboBoxControl_leadArtist.LinkVisible = true;
            dateControl_year.LinkVisible = true;
        }

        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadFrames(); 
            }
        }
        public override void ClearFields()
        {
            textEditorControl_title.PropertyValue = "";
            comboBoxControl_leadArtist.PropertyValue = "";
            comboBoxControl_album.PropertyValue = "";
            textEditorControl_track.PropertyValue = "";
            dateControl_year.PropertyValue = DateTime.Now;
            dateControl_OriginalYear.PropertyValue = DateTime.Now;
            comboBoxControl_genre.PropertyValue = "";
            textEditorControl_Composers.PropertyValue = "";
            textEditorControl_Lyricist.PropertyValue = "";
            textEditorControl_partOfSet.PropertyValue = "";
            dateControl_date.PropertyValue = DateTime.Now;
            dateControl_Time.PropertyValue = DateTime.Now;
            dateControl_EncodingTime.PropertyValue = DateTime.Now;
            dateControl_OriginalReleaseTime.PropertyValue = DateTime.Now;
            dateControl_RecordingTime.PropertyValue = DateTime.Now;
            dateControl_ReleaseTime.PropertyValue = DateTime.Now;
            dateControl_TaggingTime.PropertyValue = DateTime.Now;
            textEditorControl_ContentGroupDescription.PropertyValue = "";
            textEditorControl_Band.PropertyValue = "";
            textEditorControl_Conductor.PropertyValue = "";
            textEditorControl_Interpreted.PropertyValue = "";
            textEditorControl_Publisher.PropertyValue = "";
            textEditorControl_CopyrightMessage.PropertyValue = "";
            textEditorControl_SubtitleDescriptionRefinement.PropertyValue = "";
            textEditorControl_RecordingDates.PropertyValue = "";
            textEditorControl_OriginalFilename.PropertyValue = "";
            textEditorControl_Length.PropertyValue = "";
            textEditorControl_Size.PropertyValue = "";
            textEditorControl_EncodedBy.PropertyValue = "";
            textEditorControl_BPM.PropertyValue = "";
            comboBoxControl_language.comboBox1.SelectedIndex = 0;
            textEditorControl_ISRC.PropertyValue = "";
            comboBoxControl_MediaType.comboBox1.SelectedIndex = 0;
            comboBoxControl_FileType.comboBox1.SelectedIndex = 0;
            textEditorControl_Software.PropertyValue = "";
            comboBoxControl_InitialKey.comboBox1.SelectedIndex = 0;
            textEditorControl_PlaylistDelay.PropertyValue = "";
            textEditorControl_OriginalAlbum.PropertyValue = "";
            textEditorControl_OriginalArtists.PropertyValue = "";
            textEditorControl_OriginalLyricist.PropertyValue = "";
            textEditorControl_FileOwner.PropertyValue = "";
            textEditorControl_InternetTadioStationName.PropertyValue = "";
            textEditorControl_InternetRadioStationOwner.PropertyValue = "";
            textEditorControl_SetSubtitle.PropertyValue = "";
            textEditorControl_MusicianCreditsList.PropertyValue = "";
            textEditorControl1_InvolvedPeopleList.PropertyValue = "";
            textEditorControl_Mood.PropertyValue = "";
            textEditorControl_ProducedNotice.PropertyValue = "";
            textEditorControl_AlbumSortOrder.PropertyValue = "";
            textEditorControl_PerformerSortOrder.PropertyValue = "";
            textEditorControl_TitleSortOrder.PropertyValue = "";
        }
        private void EnableControls()
        {
            tabControl1.Enabled = toolStrip1.Enabled = true;
            Label1.Text = "";
        }
        private void DisableControls()
        {
            tabControl1.Enabled = toolStrip1.Enabled = false;
            Label1.Text = "";
        }
        public void ReloadFrames()
        {
            ClearFields();
            if (files == null)
            {
                DisableControls();
                return;
            }
            if (files.Length == 0)
            {
                DisableControls();
                return;
            }
            if (files.Length > 1)
            {
                DisableControls();
                Label1.Text = "You can only edit 1 file at a time.";
                return;
            }
            //load frames
            EnableControls();
            LoadFrames(files[0]);
        }
        private int ParseIntValue(string text)
        {
            int val = 0;
            if (int.TryParse(text, out val))
                return val;
            return 0;
        }
        private DateTime GetFromTimeStamp(string timeStamp)
        {
            /*The timestamp fields are based on a subset of ISO 8601. When being as
       precise as possible the format of a time string is
       yyyy-MM-ddTHH:mm:ss (year, "-", month, "-", day, "T", hour (out of
       24), ":", minutes, ":", seconds), but the precision may be reduced by
       removing as many time indicators as wanted. Hence valid timestamps
       are
       yyyy, yyyy-MM, yyyy-MM-dd, yyyy-MM-ddTHH, yyyy-MM-ddTHH:mm and
       yyyy-MM-ddTHH:mm:ss. All time stamps are UTC. For durations, use
       the slash character as described in 8601, and for multiple non-
       contiguous dates, use multiple strings, if allowed by the frame
       definition.*/
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            string[] code = timeStamp.Split(new char[] { '-', 'T', ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (code.Length == 1)//yyyy
            {
                year = ParseIntValue(code[0]);
            }
            else if (code.Length == 2)//yyyy-MM
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
            }
            else if (code.Length == 3)//yyyy-MM-dd
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
            }
            else if (code.Length == 4)//yyyy-MM-ddTHH
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
            }
            else if (code.Length == 5)//yyyy-MM-ddTHH:mm
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
                minute = ParseIntValue(code[4]);
            }
            else if (code.Length == 6)//yyyy-MM-ddTHH:mm:ss
            {
                year = ParseIntValue(code[0]);
                month = ParseIntValue(code[1]);
                day = ParseIntValue(code[2]);
                hour = ParseIntValue(code[3]);
                minute = ParseIntValue(code[4]);
                sec = ParseIntValue(code[5]);
            }
            return new DateTime(year, month, day, hour, minute, sec);
        }
        private string GetTimeStampValue(DateTime time)
        {
            /*The timestamp fields are based on a subset of ISO 8601. When being as
       precise as possible the format of a time string is
       yyyy-MM-ddTHH:mm:ss (year, "-", month, "-", day, "T", hour (out of
       24), ":", minutes, ":", seconds), but the precision may be reduced by
       removing as many time indicators as wanted. Hence valid timestamps
       are
       yyyy, yyyy-MM, yyyy-MM-dd, yyyy-MM-ddTHH, yyyy-MM-ddTHH:mm and
       yyyy-MM-ddTHH:mm:ss. All time stamps are UTC. For durations, use
       the slash character as described in 8601, and for multiple non-
       contiguous dates, use multiple strings, if allowed by the frame
       definition.*/
            // let's use the full format yyyy-MM-ddTHH:mm:ss
            return time.Year.ToString("D4") + "-" + time.Month.ToString("D2") + "-" + time.Day.ToString("D2") + "T" +
                time.Hour.ToString("D2") + ":" + time.Minute.ToString("D2") + ":" + time.Second.ToString("D2");
        }
        /// <summary>
        /// Fill fields from file
        /// </summary>
        /// <param name="file">The file to load</param>
        public void LoadFrames(string file)
        {
            ID3v2 v2 = new ID3v2();
            if (v2.Load(file) == Result.Success)
            {
                LoadFrames(v2);
            }
        }
        /// <summary>
        /// Fill fields using ID3V2 object.
        /// </summary>
        /// <param name="v2">The ID3V2 object (MUST be loaded a file with load success status)</param>
        public void LoadFrames(ID3v2 v2)
        {
            EnableControls();
            // Title/Songname/Content description
            TextFrame frame;
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TT2");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TIT2");
            if (frame != null)
                textEditorControl_title.PropertyValue = frame.Text;

            frame = null;
            // Lead artist(s)/Lead performer(s)/Soloist(s)/Performing group
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TP1");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPE1");
            if (frame != null)
                comboBoxControl_leadArtist.PropertyValue = frame.Text;

            frame = null;
            // Album/Movie/Show title
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TAL");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TALB");
            if (frame != null)
                comboBoxControl_album.PropertyValue = frame.Text;

            frame = null;
            // Track number/Position in set
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TRK");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TRCK");
            if (frame != null)
                textEditorControl_track.PropertyValue = frame.Text;

            frame = null;
            // Year
            if (v2.TagVersion.Major == 2)
            {
                dateControl_year.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TYE");

            }
            else if (v2.TagVersion.Major == 3)
            {
                dateControl_year.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TYER");
            }
            else// no year in version 4
            {
                dateControl_year.PropertyValue = DateTime.Now;
                dateControl_year.Enabled = false;
                frame = null;
            }
            if (frame != null)
            {
                try
                {
                    dateControl_year.PropertyValue =
                        new DateTime(ParseIntValue(frame.Text), DateTime.Now.Month, DateTime.Now.Day);
                }
                catch// in case some bad saved values
                {
                    DebugLogger.WriteLine("Bad date time value for year. The value reset to 'now' year for file:", DebugCode.Warning);
                    DebugLogger.WriteLine(files[0], DebugCode.Warning);
                    dateControl_year.PropertyValue = DateTime.Now;
                }
            }
            frame = null;
            // content type
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TCO");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TCON");
            if (frame != null)
                comboBoxControl_genre.PropertyValue = frame.Text;
            frame = null;
            // Composer(s)
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TCM");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TCOM");
            if (frame != null)
                textEditorControl_Composers.PropertyValue = frame.Text;
            frame = null;
            // Lyricist(s)/text writer(s)
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TXT");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TEXT");
            if (frame != null)
                textEditorControl_Lyricist.PropertyValue = frame.Text;
            frame = null;
            // Part of a set
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TPA");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPOS");
            if (frame != null)
                textEditorControl_partOfSet.PropertyValue = frame.Text;
            frame = null;
            // Date
            if (v2.TagVersion.Major == 2)
            {
                dateControl_date.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TDA");
            }
            else if (v2.TagVersion.Major == 3)
            {
                dateControl_date.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TDAT");
            }
            else// no date in version 4
            {
                dateControl_date.PropertyValue = DateTime.Now;
                dateControl_date.Enabled = false;
                frame = null;
            }
            if (frame != null)
            {
                string code = frame.Text.Replace("/", "");
                if (code.Length == 2)
                {
                    dateControl_date.PropertyValue =
                        new DateTime(2012, ParseIntValue(code.Substring(2, 2)), ParseIntValue(code.Substring(0, 2)));
                }
            }
            frame = null;
            // Time
            if (v2.TagVersion.Major == 2)
            {
                dateControl_Time.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TIM");
            }
            else if (v2.TagVersion.Major == 3)
            {
                dateControl_Time.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TIME");
            }
            else// no time in version 4
            {
                dateControl_Time.PropertyValue = DateTime.Now;
                dateControl_Time.Enabled = false;
                frame = null;
            }
            if (frame != null)
            {
                string code = frame.Text.Replace(":", "");
                if (code.Length == 2)
                {
                    dateControl_Time.PropertyValue =
                        new DateTime(2013, DateTime.Now.Month, DateTime.Now.Day,
                            ParseIntValue(code.Substring(0, 2)), ParseIntValue(code.Substring(2, 2)), 0);
                }
            }
            frame = null;
            // Content group description
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TT1");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TIT1");
            if (frame != null)
                textEditorControl_ContentGroupDescription.PropertyValue = frame.Text;
            frame = null;
            // Band/Orchestra/Accompaniment
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TP2");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPE2");
            if (frame != null)
                textEditorControl_Band.PropertyValue = frame.Text;
            frame = null;
            // Conductor
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TP3");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPE3");
            if (frame != null)
                textEditorControl_Conductor.PropertyValue = frame.Text;
            frame = null;
            // Interpreted, remixed, or otherwise modified by
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TP4");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPE4");
            if (frame != null)
                textEditorControl_Interpreted.PropertyValue = frame.Text;
            frame = null;
            // Publisher
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TPB");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TPUB");
            if (frame != null)
                textEditorControl_Publisher.PropertyValue = frame.Text;
            frame = null;
            // Copyright message
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TCR");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TCOP");
            if (frame != null)
                textEditorControl_CopyrightMessage.PropertyValue = frame.Text;
            frame = null;
            // Subtitle/Description refinement
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TT3");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TIT3");
            if (frame != null)
                textEditorControl_SubtitleDescriptionRefinement.PropertyValue = frame.Text;
            frame = null;
            // Recording dates
            if (v2.TagVersion.Major == 2)
            { frame = (TextFrame)v2.GetFrameLoaded("TRD"); textEditorControl_RecordingDates.Enabled = true; }
            else if (v2.TagVersion.Major == 3)
            { frame = (TextFrame)v2.GetFrameLoaded("TRDA"); textEditorControl_RecordingDates.Enabled = true; }
            else// no Recording dates in v4
            {
                frame = null; textEditorControl_RecordingDates.Enabled = false;
                textEditorControl_RecordingDates.PropertyValue = "N/A";
            }
            if (frame != null)
                textEditorControl_RecordingDates.PropertyValue = frame.Text;
            frame = null;
            // Original filename
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TOF");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TOFN");
            if (frame != null)
                textEditorControl_OriginalFilename.PropertyValue = frame.Text;
            frame = null;
            // Length
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TLE");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TLEN");
            if (frame != null)
                textEditorControl_Length.PropertyValue = frame.Text;
            frame = null;
            // Size
            if (v2.TagVersion.Major == 2)
            { frame = (TextFrame)v2.GetFrameLoaded("TSI"); textEditorControl_Size.Enabled = true; }
            else if (v2.TagVersion.Major == 3)
            { frame = (TextFrame)v2.GetFrameLoaded("TSIZ"); textEditorControl_Size.Enabled = true; }
            else// no Size in v4
            {
                frame = null; textEditorControl_Size.Enabled = false;
                textEditorControl_Size.PropertyValue = "N/A";
            }
            if (frame != null)
                textEditorControl_Size.PropertyValue = frame.Text;
            frame = null;
            // Encoded by
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TEN");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TENC");
            if (frame != null)
                textEditorControl_EncodedBy.PropertyValue = frame.Text;
            frame = null;
            // BPM
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TBP");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TBPM");
            if (frame != null)
                textEditorControl_BPM.PropertyValue = frame.Text;
            frame = null;
            // Language(s)
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TLA");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TLAN");
            if (frame != null)
                comboBoxControl_language.comboBox1.SelectedItem = ID3FrameConsts.GetLanguage(frame.Text);
            frame = null;
            // ISRC
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TRC");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TSRC");
            if (frame != null)
                textEditorControl_ISRC.PropertyValue = frame.Text;
            frame = null;
            // Media type
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TMT");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TMED");
            if (frame != null)
                comboBoxControl_MediaType.comboBox1.SelectedItem = ID3FrameConsts.GetMediaType(frame.Text);
            frame = null;
            // File type
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TFT");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TFLT");
            if (frame != null)
                comboBoxControl_FileType.comboBox1.SelectedItem = ID3FrameConsts.GetFileType(frame.Text);
            frame = null;
            // Software/hardware and settings used for encoding
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TSS");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TSSE");
            if (frame != null)
                textEditorControl_Software.PropertyValue = frame.Text;
            frame = null;
            // Initial key
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TKE");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TKEY");
            if (frame != null)
                comboBoxControl_InitialKey.comboBox1.SelectedItem = ID3FrameConsts.GetTKey(frame.Text);
            frame = null;
            // Playlist delay
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TDY");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TDLY");
            if (frame != null)
                textEditorControl_PlaylistDelay.PropertyValue = frame.Text;
            frame = null;
            // Original album/Movie/Show title
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TOT");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TOAL");
            if (frame != null)
                textEditorControl_OriginalAlbum.PropertyValue = frame.Text;
            frame = null;
            // Original artist(s)/performer(s)
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TOA");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TOPE");
            if (frame != null)
                textEditorControl_OriginalArtists.PropertyValue = frame.Text;
            frame = null;
            // Original Lyricist(s)/text writer(s)
            if (v2.TagVersion.Major == 2)
                frame = (TextFrame)v2.GetFrameLoaded("TOL");
            else
                frame = (TextFrame)v2.GetFrameLoaded("TOLY");
            if (frame != null)
                textEditorControl_OriginalLyricist.PropertyValue = frame.Text;
            frame = null;
            // Original release year
            if (v2.TagVersion.Major == 2)
            {
                dateControl_OriginalYear.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TOR");

            }
            else if (v2.TagVersion.Major == 3)
            {
                dateControl_OriginalYear.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TORY");
            }
            else// no Original release year in version 4
            {
                dateControl_OriginalYear.PropertyValue = DateTime.Now;
                dateControl_OriginalYear.Enabled = false;
                frame = null;
            }
            if (frame != null)
                dateControl_OriginalYear.PropertyValue =
                    new DateTime(ParseIntValue(frame.Text), DateTime.Now.Month, DateTime.Now.Day);
            /*None v2 frames*/
            frame = null;
            // File owner/licensee
            if (v2.TagVersion.Major == 2)
            {
                frame = null;
                textEditorControl_FileOwner.Enabled = false;
                textEditorControl_FileOwner.PropertyValue = "N/A";
            }
            else// v3+4
            {
                frame = (TextFrame)v2.GetFrameLoaded("TOWN");
                textEditorControl_FileOwner.Enabled = true;
            }

            if (frame != null)
                textEditorControl_FileOwner.PropertyValue = frame.Text;
            frame = null;
            // Internet radio station name
            if (v2.TagVersion.Major == 2)
            {
                frame = null;
                textEditorControl_InternetTadioStationName.Enabled = false;
                textEditorControl_InternetTadioStationName.PropertyValue = "N/A";
            }
            else// v3+4
            {
                frame = (TextFrame)v2.GetFrameLoaded("TRSN");
                textEditorControl_InternetTadioStationName.Enabled = true;
            }

            if (frame != null)
                textEditorControl_InternetTadioStationName.PropertyValue = frame.Text;
            frame = null;
            // Internet radio station owner
            if (v2.TagVersion.Major == 2)
            {
                frame = null;
                textEditorControl_InternetRadioStationOwner.Enabled = false;
                textEditorControl_InternetRadioStationOwner.PropertyValue = "N/A";
            }
            else// v3+4
            {
                frame = (TextFrame)v2.GetFrameLoaded("TRSO");
                textEditorControl_InternetRadioStationOwner.Enabled = true;
            }

            if (frame != null)
                textEditorControl_InternetRadioStationOwner.PropertyValue = frame.Text;

            /*v4 only frames*/
            frame = null;
            // Set subtitle
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TSST");
                textEditorControl_SetSubtitle.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_SetSubtitle.Enabled = false;
                textEditorControl_SetSubtitle.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_SetSubtitle.PropertyValue = frame.Text;
            frame = null;
            // Musician credits list
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TMCL");
                textEditorControl_MusicianCreditsList.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_MusicianCreditsList.Enabled = false;
                textEditorControl_MusicianCreditsList.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_MusicianCreditsList.PropertyValue = frame.Text;
            frame = null;
            // Involved people list
            if (v2.TagVersion.Major == 4)
            {
                textEditorControl1_InvolvedPeopleList.Enabled = true;
                frame = (TextFrame)v2.GetFrameLoaded("TIPL");
            }
            else// v2+3
            {
                frame = null;
                textEditorControl1_InvolvedPeopleList.Enabled = false;
                textEditorControl1_InvolvedPeopleList.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl1_InvolvedPeopleList.PropertyValue = frame.Text;
            frame = null;
            // Mood
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TMOO");
                textEditorControl_Mood.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_Mood.Enabled = false;
                textEditorControl_Mood.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_Mood.PropertyValue = frame.Text;
            frame = null;
            // Produced notice
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TPRO");
                textEditorControl_ProducedNotice.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_ProducedNotice.Enabled = false;
                textEditorControl_ProducedNotice.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_ProducedNotice.PropertyValue = frame.Text;
            frame = null;
            // Encoding time
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TDEN");
                dateControl_EncodingTime.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                dateControl_EncodingTime.Enabled = false;
                dateControl_EncodingTime.PropertyValue = DateTime.Now;
            }

            if (frame != null)
                dateControl_EncodingTime.PropertyValue = GetFromTimeStamp(frame.Text);
            frame = null;
            // Original release time
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TDOR");
                dateControl_OriginalReleaseTime.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                dateControl_OriginalReleaseTime.Enabled = false;
                dateControl_OriginalReleaseTime.PropertyValue = DateTime.Now;
            }

            if (frame != null)
                dateControl_OriginalReleaseTime.PropertyValue = GetFromTimeStamp(frame.Text);
            frame = null;
            // Recording time
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TDRC");
                dateControl_RecordingTime.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                dateControl_RecordingTime.Enabled = false;
                dateControl_RecordingTime.PropertyValue = DateTime.Now;
            }

            if (frame != null)
                dateControl_RecordingTime.PropertyValue = GetFromTimeStamp(frame.Text);
            frame = null;
            // Release time
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TDRL");
                dateControl_ReleaseTime.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                dateControl_ReleaseTime.Enabled = false;
                dateControl_ReleaseTime.PropertyValue = DateTime.Now;
            }

            if (frame != null)
                dateControl_ReleaseTime.PropertyValue = GetFromTimeStamp(frame.Text);
            frame = null;
            // Tagging time
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TDTG");
                dateControl_TaggingTime.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                dateControl_TaggingTime.Enabled = false;
                dateControl_TaggingTime.PropertyValue = DateTime.Now;
            }

            if (frame != null)
                dateControl_TaggingTime.PropertyValue = GetFromTimeStamp(frame.Text);
            frame = null;
            // Album sort order
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TSOA");
                textEditorControl_AlbumSortOrder.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_AlbumSortOrder.Enabled = false;
                textEditorControl_AlbumSortOrder.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_AlbumSortOrder.PropertyValue = frame.Text;
            frame = null;
            // Performer sort order
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TSOP");
                textEditorControl_PerformerSortOrder.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_PerformerSortOrder.Enabled = false;
                textEditorControl_PerformerSortOrder.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_PerformerSortOrder.PropertyValue = frame.Text;
            frame = null;
            // Title sort order
            if (v2.TagVersion.Major == 4)
            {
                frame = (TextFrame)v2.GetFrameLoaded("TSOT");
                textEditorControl_TitleSortOrder.Enabled = true;
            }
            else// v2+3
            {
                frame = null;
                textEditorControl_TitleSortOrder.Enabled = false;
                textEditorControl_TitleSortOrder.PropertyValue = "N/A";
            }

            if (frame != null)
                textEditorControl_TitleSortOrder.PropertyValue = frame.Text;
            // use defined
            dataGridView1.Rows.Clear();
            foreach (ID3TagFrame frm in v2.Frames)
            {
                if (frm is UserDefinedTextInformationFrame)
                {
                    UserDefinedTextInformationFrame textDefined = (UserDefinedTextInformationFrame)frm;
                    dataGridView1.Rows.Add(new object[] { textDefined.Description, textDefined.Text });
                }
            }
        }
        /// <summary>
        /// Save current fields to id3v2 object (just add frames, no file save !!).
        /// </summary>
        /// <param name="id3v2">The ID3v2 object (should be loaded already)</param>
        public void SaveFramesToID3V2(ID3v2 id3v2)
        {  
            EnableControls();
            // save frames
            SaveFrame(id3v2, "TT2", "TIT2", "TIT2", "Title/Songname/Content description", textEditorControl_title.PropertyValue);
            SaveFrame(id3v2, "TP1", "TPE1", "TPE1", "Lead artist(s)/Lead performer(s)/Soloist(s)/Performing group", comboBoxControl_leadArtist.PropertyValue);
            SaveFrame(id3v2, "TAL", "TALB", "TALB", "Album/Movie/Show title", comboBoxControl_album.PropertyValue);
            SaveFrame(id3v2, "TRK", "TRCK", "TRCK", "Track number/Position in set", textEditorControl_track.PropertyValue);
            SaveFrame(id3v2, "TYE", "TYER", "", "Year", dateControl_year.PropertyValue.Year.ToString());
            SaveFrame(id3v2, "TCO", "TCON", "TCON", "Content type", comboBoxControl_genre.PropertyValue);
            SaveFrame(id3v2, "TCM", "TCOM", "TCOM", "Composer(s)", textEditorControl_Composers.PropertyValue);
            SaveFrame(id3v2, "TXT", "TEXT", "TEXT", "Lyricist(s)/text writer(s)", textEditorControl_Lyricist.PropertyValue);
            SaveFrame(id3v2, "TPA", "TPOS", "TPOS", "Part of a set", textEditorControl_partOfSet.PropertyValue);
            SaveFrame(id3v2, "TDA", "TDAT", "", "Date", dateControl_date.PropertyValue.Day.ToString("D2") +
                dateControl_date.PropertyValue.Month.ToString("D2"));
            SaveFrame(id3v2, "TIM", "TIME", "", "Time", dateControl_Time.PropertyValue.Hour.ToString("D2") +
                dateControl_Time.PropertyValue.Minute.ToString("D2"));
            SaveFrame(id3v2, "TT1", "TIT1", "TIT1", "Content group description", textEditorControl_ContentGroupDescription.PropertyValue);
            SaveFrame(id3v2, "TP2", "TPE2", "TPE2", "Band/Orchestra/Accompaniment", textEditorControl_Band.PropertyValue);
            SaveFrame(id3v2, "TP3", "TPE3", "TPE3", "Conductor", textEditorControl_Conductor.PropertyValue);
            SaveFrame(id3v2, "TP4", "TPE4", "TPE4", "Interpreted, remixed, or otherwise modified by", textEditorControl_Interpreted.PropertyValue);
            SaveFrame(id3v2, "TPB", "TPUB", "TPUB", "Publisher", textEditorControl_Publisher.PropertyValue);
            SaveFrame(id3v2, "TCR", "TCOP", "TCOP", "Copyright message", textEditorControl_CopyrightMessage.PropertyValue);
            SaveFrame(id3v2, "TT3", "TIT3", "TIT3", "Subtitle/Description refinement", textEditorControl_SubtitleDescriptionRefinement.PropertyValue);
            SaveFrame(id3v2, "TRD", "TRDA", "", "Recording dates", textEditorControl_RecordingDates.PropertyValue);
            SaveFrame(id3v2, "TOF", "TOFN", "TOFN", "Original filename", textEditorControl_OriginalFilename.PropertyValue);
            SaveFrame(id3v2, "TLE", "TLEN", "TLEN", "Length", textEditorControl_Length.PropertyValue);
            SaveFrame(id3v2, "TSI", "TSIZ", "", "Size", textEditorControl_Size.PropertyValue);
            SaveFrame(id3v2, "TEN", "TENC", "TENC", "Encoded by", textEditorControl_EncodedBy.PropertyValue);
            SaveFrame(id3v2, "TBP", "TBPM", "TBPM", "BPM", textEditorControl_BPM.PropertyValue);
            SaveFrame(id3v2, "TLA", "TLAN", "TLAN", "Language(s)", ID3FrameConsts.GetLanguageID(comboBoxControl_language.PropertyValue));
            SaveFrame(id3v2, "TRC", "TSRC", "TSRC", "ISRC", textEditorControl_ISRC.PropertyValue);
            SaveFrame(id3v2, "TMT", "TMED", "TMED", "Media type", ID3FrameConsts.GetMediaTypeID(comboBoxControl_MediaType.PropertyValue));
            SaveFrame(id3v2, "TFT", "TFLT", "TFLT", "File type", ID3FrameConsts.GetFileTypeID(comboBoxControl_FileType.PropertyValue));
            SaveFrame(id3v2, "TSS", "TSSE", "TSSE", "Software/hardware and settings used for encoding", textEditorControl_Software.PropertyValue);
            SaveFrame(id3v2, "TKE", "TKEY", "TKEY", "Initial key", ID3FrameConsts.GetTKeyValue(comboBoxControl_InitialKey.PropertyValue));
            SaveFrame(id3v2, "TDY", "TDLY", "TDLY", "Playlist delay", textEditorControl_PlaylistDelay.PropertyValue);
            SaveFrame(id3v2, "TOT", "TOAL", "TOAL", "Original album/Movie/Show title", textEditorControl_OriginalAlbum.PropertyValue);
            SaveFrame(id3v2, "TOA", "TOPE", "TOPE", "Original artist(s)/performer(s)", textEditorControl_OriginalArtists.PropertyValue);
            SaveFrame(id3v2, "TOL", "TOLY", "TOLY", "Original Lyricist(s)/text writer(s)", textEditorControl_OriginalLyricist.PropertyValue);
            SaveFrame(id3v2, "TOR", "TORY", "", "Original release year", dateControl_OriginalYear.PropertyValue.Year.ToString());
            SaveFrame(id3v2, "", "TOWN", "TOWN", "File owner/licensee", textEditorControl_FileOwner.PropertyValue);
            SaveFrame(id3v2, "", "TRSN", "TRSN", "Internet radio station name", textEditorControl_InternetTadioStationName.PropertyValue);
            SaveFrame(id3v2, "", "TRSO", "TRSO", "Internet radio station owner", textEditorControl_InternetRadioStationOwner.PropertyValue);
            SaveFrame(id3v2, "", "", "TSST", "Set subtitle", textEditorControl_SetSubtitle.PropertyValue);
            SaveFrame(id3v2, "", "", "TMCL", "Musician credits list", textEditorControl_MusicianCreditsList.PropertyValue);
            SaveFrame(id3v2, "", "", "TMOO", "Mood", textEditorControl_Mood.PropertyValue);
            SaveFrame(id3v2, "", "", "TPRO", "Produced notice", textEditorControl_ProducedNotice.PropertyValue);
            SaveFrame(id3v2, "", "", "TDEN", "Encoding time", GetTimeStampValue(dateControl_EncodingTime.PropertyValue));
            SaveFrame(id3v2, "", "", "TDOR", "Original release time", GetTimeStampValue(dateControl_OriginalReleaseTime.PropertyValue));
            SaveFrame(id3v2, "", "", "TDRC", "Recording time", GetTimeStampValue(dateControl_RecordingTime.PropertyValue));
            SaveFrame(id3v2, "", "", "TDRL", "Release time", GetTimeStampValue(dateControl_ReleaseTime.PropertyValue));
            SaveFrame(id3v2, "", "", "TDTG", "Tagging time", GetTimeStampValue(dateControl_TaggingTime.PropertyValue));
            SaveFrame(id3v2, "", "", "TSOA", "Album sort order", textEditorControl_AlbumSortOrder.PropertyValue);
            SaveFrame(id3v2, "", "", "TSOP", "Performer sort order", textEditorControl_PerformerSortOrder.PropertyValue);
            SaveFrame(id3v2, "", "", "TSOT", "Title sort order", textEditorControl_TitleSortOrder.PropertyValue);
            SaveFrame(id3v2, "", "", "TIPL", "Involved people list", textEditorControl1_InvolvedPeopleList.PropertyValue);
            // user defined text information
            id3v2.RemoveFrameAll("TXX");
            id3v2.RemoveFrameAll("TXXX");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null &&
                    dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    UserDefinedTextInformationFrame frame = (UserDefinedTextInformationFrame)FramesManager.GetFrame(id3v2.TagVersion,
                        typeof(UserDefinedTextInformationFrame));
                    frame.Description = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    frame.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    id3v2.Frames.Add(frame);
                }
            }

        }
        private void SaveFrame(ID3v2 id3v2, string v2ID, string v3ID, string v4ID, string frameName, string value)
        {
            switch (id3v2.TagVersion.Major)
            {
                case 2:
                    //check id
                    if (v2ID != "")
                    {
                        if (value != "")// add it or edit it
                        {
                            TextFrame Tframe = (TextFrame)id3v2.GetFrameLoaded(v2ID);
                            if (Tframe != null)
                                Tframe.Text = value;
                            else//create new
                            {
                                Tframe = new TextFrame(v2ID, frameName, null, 0);
                                Tframe.Text = value;
                                id3v2.Frames.Add(Tframe);
                            }
                        }
                        else//remove it
                        {
                            id3v2.RemoveFrame(v2ID);
                        }
                    }
                    break;
                case 3:
                    //check id
                    if (v3ID != "")
                    {
                        if (value != "")// add it or edit it
                        {
                            TextFrame Tframe = (TextFrame)id3v2.GetFrameLoaded(v3ID);
                            if (Tframe != null)
                                Tframe.Text = value;
                            else//create new
                            {
                                Tframe = new TextFrame(v3ID, frameName, null, 0);
                                Tframe.Text = value;
                                id3v2.Frames.Add(Tframe);
                            }
                        }
                        else//remove it
                        {
                            id3v2.RemoveFrame(v3ID);
                        }
                    }
                    break;
                case 4:
                    //check id
                    if (v4ID != "")
                    {
                        if (value != "")// add it or edit it
                        {
                            TextFrame Tframe = (TextFrame)id3v2.GetFrameLoaded(v4ID);
                            if (Tframe != null)
                                Tframe.Text = value;
                            else//create new
                            {
                                Tframe = new TextFrame(v4ID, frameName, null, 0);
                                Tframe.Text = value;
                                id3v2.Frames.Add(Tframe);
                            }
                        }
                        else//remove it
                        {
                            id3v2.RemoveFrame(v4ID);
                        }
                    }
                    break;
            }
        }
        private void SaveChanges(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be saved at a time");
                return;
            }       
            // stop media and clear it
            OnClearMediaRequest();
            // load the original file. Success or not doesn't matter.
            ID3v2 v2 = new ID3v2();
            bool hadTag = v2.Load(files[0]) == Result.Success;

            // we need to make sure about version. If we are creating id3v2, use default version.
            if (!hadTag)
                v2.TagVersion = new ID3Version((byte)ID3TagSettings.ID3V2Version, 0);

            // set flags
            v2.Compression = false;
            v2.Experimental = false;
            if (ID3TagSettings.DropExtendedHeader)
                v2.ExtendedHeader = false;
            v2.Footer = ID3TagSettings.WriteFooter;
            v2.SavePadding = ID3TagSettings.KeepPadding;
            v2.Unsynchronisation = ID3TagSettings.UseUnsynchronisation;

            // save frames
            SaveFrame(v2, "TT2", "TIT2", "TIT2", "Title/Songname/Content description", textEditorControl_title.PropertyValue);
            SaveFrame(v2, "TP1", "TPE1", "TPE1", "Lead artist(s)/Lead performer(s)/Soloist(s)/Performing group", comboBoxControl_leadArtist.PropertyValue);
            SaveFrame(v2, "TAL", "TALB", "TALB", "Album/Movie/Show title", comboBoxControl_album.PropertyValue);
            SaveFrame(v2, "TRK", "TRCK", "TRCK", "Track number/Position in set", textEditorControl_track.PropertyValue);
            SaveFrame(v2, "TYE", "TYER", "", "Year", dateControl_year.PropertyValue.Year.ToString());
            SaveFrame(v2, "TCO", "TCON", "TCON", "Content type", comboBoxControl_genre.PropertyValue);
            SaveFrame(v2, "TCM", "TCOM", "TCOM", "Composer(s)", textEditorControl_Composers.PropertyValue);
            SaveFrame(v2, "TXT", "TEXT", "TEXT", "Lyricist(s)/text writer(s)", textEditorControl_Lyricist.PropertyValue);
            SaveFrame(v2, "TPA", "TPOS", "TPOS", "Part of a set", textEditorControl_partOfSet.PropertyValue);
            SaveFrame(v2, "TDA", "TDAT", "", "Date", dateControl_date.PropertyValue.Day.ToString("D2") +
                dateControl_date.PropertyValue.Month.ToString("D2"));
            SaveFrame(v2, "TIM", "TIME", "", "Time", dateControl_Time.PropertyValue.Hour.ToString("D2") +
                dateControl_Time.PropertyValue.Minute.ToString("D2"));
            SaveFrame(v2, "TT1", "TIT1", "TIT1", "Content group description", textEditorControl_ContentGroupDescription.PropertyValue);
            SaveFrame(v2, "TP2", "TPE2", "TPE2", "Band/Orchestra/Accompaniment", textEditorControl_Band.PropertyValue);
            SaveFrame(v2, "TP3", "TPE3", "TPE3", "Conductor", textEditorControl_Conductor.PropertyValue);
            SaveFrame(v2, "TP4", "TPE4", "TPE4", "Interpreted, remixed, or otherwise modified by", textEditorControl_Interpreted.PropertyValue);
            SaveFrame(v2, "TPB", "TPUB", "TPUB", "Publisher", textEditorControl_Publisher.PropertyValue);
            SaveFrame(v2, "TCR", "TCOP", "TCOP", "Copyright message", textEditorControl_CopyrightMessage.PropertyValue);
            SaveFrame(v2, "TT3", "TIT3", "TIT3", "Subtitle/Description refinement", textEditorControl_SubtitleDescriptionRefinement.PropertyValue);
            SaveFrame(v2, "TRD", "TRDA", "", "Recording dates", textEditorControl_RecordingDates.PropertyValue);
            SaveFrame(v2, "TOF", "TOFN", "TOFN", "Original filename", textEditorControl_OriginalFilename.PropertyValue);
            SaveFrame(v2, "TLE", "TLEN", "TLEN", "Length", textEditorControl_Length.PropertyValue);
            SaveFrame(v2, "TSI", "TSIZ", "", "Size", textEditorControl_Size.PropertyValue);
            SaveFrame(v2, "TEN", "TENC", "TENC", "Encoded by", textEditorControl_EncodedBy.PropertyValue);
            SaveFrame(v2, "TBP", "TBPM", "TBPM", "BPM", textEditorControl_BPM.PropertyValue);
            SaveFrame(v2, "TLA", "TLAN", "TLAN", "Language(s)", ID3FrameConsts.GetLanguageID(comboBoxControl_language.PropertyValue));
            SaveFrame(v2, "TRC", "TSRC", "TSRC", "ISRC", textEditorControl_ISRC.PropertyValue);
            SaveFrame(v2, "TMT", "TMED", "TMED", "Media type", ID3FrameConsts.GetMediaTypeID(comboBoxControl_MediaType.PropertyValue));
            SaveFrame(v2, "TFT", "TFLT", "TFLT", "File type", ID3FrameConsts.GetFileTypeID(comboBoxControl_FileType.PropertyValue));
            SaveFrame(v2, "TSS", "TSSE", "TSSE", "Software/hardware and settings used for encoding", textEditorControl_Software.PropertyValue);
            SaveFrame(v2, "TKE", "TKEY", "TKEY", "Initial key", ID3FrameConsts.GetTKeyValue(comboBoxControl_InitialKey.PropertyValue));
            SaveFrame(v2, "TDY", "TDLY", "TDLY", "Playlist delay", textEditorControl_PlaylistDelay.PropertyValue);
            SaveFrame(v2, "TOT", "TOAL", "TOAL", "Original album/Movie/Show title", textEditorControl_OriginalAlbum.PropertyValue);
            SaveFrame(v2, "TOA", "TOPE", "TOPE", "Original artist(s)/performer(s)", textEditorControl_OriginalArtists.PropertyValue);
            SaveFrame(v2, "TOL", "TOLY", "TOLY", "Original Lyricist(s)/text writer(s)", textEditorControl_OriginalLyricist.PropertyValue);
            SaveFrame(v2, "TOR", "TORY", "", "Original release year", dateControl_OriginalYear.PropertyValue.Year.ToString());
            SaveFrame(v2, "", "TOWN", "TOWN", "File owner/licensee", textEditorControl_FileOwner.PropertyValue);
            SaveFrame(v2, "", "TRSN", "TRSN", "Internet radio station name", textEditorControl_InternetTadioStationName.PropertyValue);
            SaveFrame(v2, "", "TRSO", "TRSO", "Internet radio station owner", textEditorControl_InternetRadioStationOwner.PropertyValue);
            SaveFrame(v2, "", "", "TSST", "Set subtitle", textEditorControl_SetSubtitle.PropertyValue);
            SaveFrame(v2, "", "", "TMCL", "Musician credits list", textEditorControl_MusicianCreditsList.PropertyValue);
            SaveFrame(v2, "", "", "TMOO", "Mood", textEditorControl_Mood.PropertyValue);
            SaveFrame(v2, "", "", "TPRO", "Produced notice", textEditorControl_ProducedNotice.PropertyValue);
            SaveFrame(v2, "", "", "TDEN", "Encoding time", GetTimeStampValue(dateControl_EncodingTime.PropertyValue));
            SaveFrame(v2, "", "", "TDOR", "Original release time", GetTimeStampValue(dateControl_OriginalReleaseTime.PropertyValue));
            SaveFrame(v2, "", "", "TDRC", "Recording time", GetTimeStampValue(dateControl_RecordingTime.PropertyValue));
            SaveFrame(v2, "", "", "TDRL", "Release time", GetTimeStampValue(dateControl_ReleaseTime.PropertyValue));
            SaveFrame(v2, "", "", "TDTG", "Tagging time", GetTimeStampValue(dateControl_TaggingTime.PropertyValue));
            SaveFrame(v2, "", "", "TSOA", "Album sort order", textEditorControl_AlbumSortOrder.PropertyValue);
            SaveFrame(v2, "", "", "TSOP", "Performer sort order", textEditorControl_PerformerSortOrder.PropertyValue);
            SaveFrame(v2, "", "", "TSOT", "Title sort order", textEditorControl_TitleSortOrder.PropertyValue);
            SaveFrame(v2, "", "", "TIPL", "Involved people list", textEditorControl1_InvolvedPeopleList.PropertyValue);
            // user defined text information
            v2.RemoveFrameAll("TXX");
            v2.RemoveFrameAll("TXXX");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null &&
                    dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    UserDefinedTextInformationFrame frame = (UserDefinedTextInformationFrame)FramesManager.GetFrame(v2.TagVersion,
                        typeof(UserDefinedTextInformationFrame));
                    frame.Description = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    frame.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    v2.Frames.Add(frame);
                }
            }
            // Add events
            v2.SaveStart += v2_SaveStart;
            v2.SaveFinished += v2_SaveFinished;
            v2.Progress += v2_Progress;
            // save !
            v2.Save(files[0]);

            OnUpdateRequired();

            // reload media
            OnReloadMediaRequest();
        }
        public void DeleteSelected()
        { 
       
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public StringCollection GenreMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string genre in comboBoxControl_genre.comboBox1.Items)
                    collection.Add(genre);

                return collection;
            }
            set
            {
                comboBoxControl_genre.comboBox1.Items.Clear();
                if (value != null)
                {
                    if (value.Count == 0)
                    {
                        foreach (string genre in ID3FrameConsts.Genres)
                            comboBoxControl_genre.comboBox1.Items.Add(genre);
                    }
                    else
                    {
                        foreach (string genre in value)
                            comboBoxControl_genre.comboBox1.Items.Add(genre);
                    }
                }
                else
                {
                    foreach (string genre in ID3FrameConsts.Genres)
                        comboBoxControl_genre.comboBox1.Items.Add(genre);
                }
            }
        }
        public StringCollection ArtistsMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string artist in comboBoxControl_leadArtist.comboBox1.Items)
                    collection.Add(artist);

                return collection;
            }
            set
            {
                comboBoxControl_leadArtist.comboBox1.Items.Clear();
                if (value != null)
                    foreach (string artist in value)
                        comboBoxControl_leadArtist.comboBox1.Items.Add(artist);
            }
        }
        public StringCollection AlbumsMemory
        {
            get
            {
                StringCollection collection = new StringCollection();

                foreach (string album in comboBoxControl_album.comboBox1.Items)
                    collection.Add(album);

                return collection;
            }
            set
            {
                comboBoxControl_album.comboBox1.Items.Clear();
                if (value != null)
                    foreach (string album in value)
                        comboBoxControl_album.comboBox1.Items.Add(album);
            }
        }

        private void comboBoxArtrists_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_leadArtist.PropertyValue == "<Varies>" ||
             comboBoxControl_leadArtist.PropertyValue == "")
                return;
            if (!comboBoxControl_leadArtist.comboBox1.Items.Contains(comboBoxControl_leadArtist.PropertyValue))
            {
                comboBoxControl_leadArtist.comboBox1.Items.Add(comboBoxControl_leadArtist.PropertyValue);
                OnMemoryUpdate();
            }
        }
        private void comboBoxAlbums_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_album.PropertyValue == "<Varies>" ||
          comboBoxControl_album.PropertyValue == "")
                return;
            if (!comboBoxControl_album.comboBox1.Items.Contains(comboBoxControl_album.PropertyValue))
            {
                comboBoxControl_album.comboBox1.Items.Add(comboBoxControl_album.PropertyValue);
                OnMemoryUpdate();
            }
        }
        private void comboBoxGenre_Validated(object sender, EventArgs e)
        {
            if (comboBoxControl_genre.PropertyValue == "<Varies>" ||
                   comboBoxControl_genre.PropertyValue == "")
                return;

            if (!comboBoxControl_genre.comboBox1.Items.Contains(comboBoxControl_genre.PropertyValue))
            {
                comboBoxControl_genre.comboBox1.Items.Add(comboBoxControl_genre.PropertyValue);
                OnMemoryUpdate();
            }
        }
        // fill from id3v1
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_title.PropertyValue = v1.Title;
                    comboBoxControl_leadArtist.PropertyValue = v1.Artist;
                    comboBoxControl_album.PropertyValue = v1.Album;
                    comboBoxControl_genre.PropertyValue = v1.Genre;
                    dateControl_year.PropertyValue = new DateTime(ParseIntValue(v1.Year), DateTime.Now.Month, DateTime.Now.Day);
                    textEditorControl_track.PropertyValue = v1.Track.ToString();
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }

        private void textEditorControl_title_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_title.PropertyValue = v1.Title;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        private void comboBoxControl_album_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_album.PropertyValue = v1.Album;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        private void textEditorControl_track_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    textEditorControl_track.PropertyValue = v1.Track.ToString();
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        private void comboBoxControl_leadArtist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_leadArtist.PropertyValue = v1.Artist;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        private void comboBoxControl_genre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    comboBoxControl_genre.PropertyValue = v1.Genre;
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        private void dateControl_year_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (files == null)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length == 0)
            {
                MessageBox.Show("No file selected.");
                return;
            }
            if (files.Length > 1)
            {
                MessageBox.Show("Only one file can be edited at a time");
                return;
            }
            if (files.Length == 1)
            {
                ID3v1 v1 = new ID3v1();
                if (v1.Load(files[0]) == Result.Success)
                {
                    dateControl_year.PropertyValue = new DateTime(ParseIntValue(v1.Year), DateTime.Now.Month, DateTime.Now.Day);
                }
                else
                {
                    MessageBox.Show("No id3v1 for this file.");
                }
            }
        }
        // reload
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ReloadFrames();
        }
        private void v2_Progress(object sender, ProgressArg e)
        {
            OnProgress(e.Status, e.Progress);
        }
        private void v2_SaveFinished(object sender, EventArgs e)
        {
            OnProgress("Saved.", 100);
            OnProgressFinish();
        }
        private void v2_SaveStart(object sender, EventArgs e)
        {
            OnProgressStart();
        }

        public override void SaveTag(ID3v2 v2)
        {
            SaveFramesToID3V2(v2);
        }
        public override void LoadTag(ID3v2 v2)
        {
            LoadFrames(v2);
        }
       
    }
}

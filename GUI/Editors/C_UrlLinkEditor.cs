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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_UrlLinkEditor : EditorControl
    {
        public C_UrlLinkEditor()
        {
            InitializeComponent();
            DisableControls();
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
        public override void ClearFields()
        {
            Label1.Text = "";
            textEditorControl_OfficialAudioFileWebpage.PropertyValue = "";
            textEditorControl_OfficialArtistPerformerWebpage.PropertyValue = "";
            textEditorControl_OfficialAudioSourceWebpage.PropertyValue = "";
            textEditorControl_CommercialInformation.PropertyValue = "";
            textEditorControl_CopyrightLegalInformation.PropertyValue = "";
            textEditorControl_PublishersOfficialWebpage.PropertyValue = "";
            textEditorControl_OfficialInternetRadioStationHomepage.PropertyValue = "";
            textEditorControl_Payment.PropertyValue = "";
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        private void ReloadFrames()
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
            textEditorControl_OfficialAudioFileWebpage.PropertyValue = LoadFrame(v2, "WAF", "WOAF", "WOAF");
            textEditorControl_OfficialArtistPerformerWebpage.PropertyValue = LoadFrame(v2, "WAR", "WOAR", "WOAR");
            textEditorControl_OfficialAudioSourceWebpage.PropertyValue = LoadFrame(v2, "WAS", "WOAS", "WOAS");
            textEditorControl_CommercialInformation.PropertyValue = LoadFrame(v2, "WCM", "WCOM", "WCOM");
            textEditorControl_CopyrightLegalInformation.PropertyValue = LoadFrame(v2, "WCP", "WCOP", "WCOP");
            textEditorControl_PublishersOfficialWebpage.PropertyValue = LoadFrame(v2, "WPB", "WPUB", "WPUB");
            if (v2.TagVersion.Major == 2)
            {
                textEditorControl_OfficialInternetRadioStationHomepage.Enabled = false;
                textEditorControl_OfficialInternetRadioStationHomepage.PropertyValue = "N/A";
            }
            else
            {
                textEditorControl_OfficialInternetRadioStationHomepage.Enabled = true;
                textEditorControl_OfficialInternetRadioStationHomepage.PropertyValue = LoadFrame(v2, "", "WORS", "WORS");
            } 
            if (v2.TagVersion.Major == 2)
            {
                textEditorControl_Payment.Enabled = false;
                textEditorControl_Payment.PropertyValue = "N/A";
            }
            else
            {
                textEditorControl_Payment.Enabled = true;
                textEditorControl_Payment.PropertyValue = LoadFrame(v2, "", "WPAY", "WPAY");
            }
            // use defined
            dataGridView_UserDefinedURLLinkFrames.Rows.Clear();
            foreach (ID3TagFrame frm in v2.Frames)
            {
                if (frm is UserDefinedURLLinkFrame)
                {
                    UserDefinedURLLinkFrame textDefined = (UserDefinedURLLinkFrame)frm;
                    dataGridView_UserDefinedURLLinkFrames.Rows.Add(new object[] { textDefined.Description, textDefined.URL });
                }
            }
        }
        public void SaveFramesToID3V2(ID3v2 id3v2)
        {
            SaveFrame(id3v2, "WAF", "WOAF", "WOAF", "Official audio file webpage", textEditorControl_OfficialAudioFileWebpage.PropertyValue);
            SaveFrame(id3v2, "WAR", "WOAR", "WOAR", "Official artist/performer webpage", textEditorControl_OfficialArtistPerformerWebpage.PropertyValue);
            SaveFrame(id3v2, "WAS", "WOAS", "WOAS", "Official audio source webpage", textEditorControl_OfficialAudioSourceWebpage.PropertyValue);
            SaveFrame(id3v2, "WCM", "WCOM", "WCOM", "Commercial information", textEditorControl_CommercialInformation.PropertyValue);
            SaveFrame(id3v2, "WCP", "WCOP", "WCOP", "Copyright/Legal information", textEditorControl_CopyrightLegalInformation.PropertyValue);
            SaveFrame(id3v2, "WPB", "WPUB", "WPUB", "Publishers official webpage", textEditorControl_PublishersOfficialWebpage.PropertyValue);
            SaveFrame(id3v2, "", "WORS", "WORS", "Official Internet radio station homepage", textEditorControl_OfficialInternetRadioStationHomepage.PropertyValue);
            SaveFrame(id3v2, "", "WPAY", "WPAY", "Payment", textEditorControl_Payment.PropertyValue);
            // user defined 
            id3v2.RemoveFrameAll("WXX");
            id3v2.RemoveFrameAll("WXXX");
            for (int i = 0; i < dataGridView_UserDefinedURLLinkFrames.Rows.Count; i++)
            {
                if (dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[0].Value != null &&
                    dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[1].Value != null)
                {
                    UserDefinedURLLinkFrame frame = (UserDefinedURLLinkFrame)FramesManager.GetFrame(id3v2.TagVersion,
                        typeof(UserDefinedURLLinkFrame));
                    frame.Description = dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[0].Value.ToString();
                    frame.URL = dataGridView_UserDefinedURLLinkFrames.Rows[i].Cells[1].Value.ToString();

                    id3v2.Frames.Add(frame);
                }
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

            SaveFramesToID3V2(v2);

            // Add events
            v2.SaveStart += v2_SaveStart;
            v2.SaveFinished += v2_SaveFinished;
            v2.Progress += v2_Progress;
            // save !
            v2.Save(files[0]);

            OnUpdateRequired();

            OnReloadMediaRequest();
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
                            URLLinkFrame Tframe = (URLLinkFrame)id3v2.GetFrameLoaded(v2ID);
                            if (Tframe != null)
                                Tframe.URL = value;
                            else//create new
                            {
                                Tframe = new URLLinkFrame(v2ID, frameName, null, 0);
                                Tframe.URL = value;
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
                            URLLinkFrame Tframe = (URLLinkFrame)id3v2.GetFrameLoaded(v3ID);
                            if (Tframe != null)
                                Tframe.URL = value;
                            else//create new
                            {
                                Tframe = new URLLinkFrame(v3ID, frameName, null, 0);
                                Tframe.URL = value;
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
                            URLLinkFrame Tframe = (URLLinkFrame)id3v2.GetFrameLoaded(v4ID);
                            if (Tframe != null)
                                Tframe.URL = value;
                            else//create new
                            {
                                Tframe = new URLLinkFrame(v4ID, frameName, null, 0);
                                Tframe.URL = value;
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
        private string LoadFrame(ID3v2 id3v2, string v2ID, string v3ID, string v4ID)
        {
            switch (id3v2.TagVersion.Major)
            {
                case 2:
                    if (v2ID != "")
                    {
                        URLLinkFrame Uframe = (URLLinkFrame)id3v2.GetFrameLoaded(v2ID);
                        if (Uframe != null)
                            return Uframe.URL;
                    }
                    break;
                case 3:
                    if (v3ID != "")
                    {
                        URLLinkFrame Uframe = (URLLinkFrame)id3v2.GetFrameLoaded(v3ID);
                        if (Uframe != null)
                            return Uframe.URL;
                    }
                    break;
                case 4:
                    if (v4ID != "")
                    {
                        URLLinkFrame Uframe = (URLLinkFrame)id3v2.GetFrameLoaded(v4ID);
                        if (Uframe != null)
                            return Uframe.URL;
                    }
                    break;
            } 
            return "";
        }
        public override void SaveTag(ID3v2 v2)
        {
            SaveFramesToID3V2(v2);
        }
        public override void LoadTag(ID3v2 v2)
        {
            LoadFrames(v2);
        }
        //reload
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
    }
}

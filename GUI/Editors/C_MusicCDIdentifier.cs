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
using System.IO;
using AHD.ID3;
using AHD.ID3.Types;
using AHD.ID3.Frames;
using AHD.ID3.Editor.Base;
namespace AHD.ID3.Editor.GUI
{
    public partial class C_MusicCDIdentifier : EditorControl
    {
        public C_MusicCDIdentifier()
        {
            InitializeComponent(); DisableControls();
        }
        private MusicCDIdentifierFrame frame;
        private void DisableControls()
        {
            richTextBox1.Enabled = toolStrip1.Enabled =  false;
            Label1.Text = "";
        }
        private void EnableControls()
        {
            richTextBox1.Enabled = toolStrip1.Enabled =  true;
            Label1.Text = "";
        }
        public override void DisableSaving()
        {
            base.DisableSaving();
            toolStripButton1.Enabled = false;
        }
        public override string[] SelectedFiles
        {
            get
            {
                return base.SelectedFiles;
            }
            set
            {
                base.SelectedFiles = value; ReloadFrames(null, null);
            }
        }
        public override void ClearFields()
        {
            richTextBox1.Text = "";
        }

        private void ReloadFrames(object sender, EventArgs e)
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

            if (v2.TagVersion.Major == 2)
                frame = (MusicCDIdentifierFrame)v2.GetFrameLoaded("MCI");
            else
                frame = (MusicCDIdentifierFrame)v2.GetFrameLoaded("MCDI");

            ViewData();
        }
        private void ViewData()
        {
            richTextBox1.Text = "";
            if (frame != null)
            {
                if (frame.Data.Length > 0)
                {
                    richTextBox1.Enabled = true;
                    string text = "";
                    for (int i = 0; i < frame.Data.Length; i++)
                    {
                        text += string.Format("{0:X}", frame.Data[i]);
                    }
                    richTextBox1.Text = text;
                }
                else
                    richTextBox1.Enabled = false;
            }
            else
                richTextBox1.Enabled = false;
        }
        public void SaveFramesToTag(ID3v2 v2)
        {

            // remove all comment frames
            v2.RemoveFrameAll("MCI");
            v2.RemoveFrameAll("MCDI");
            // add frames we have
            if (frame != null)
            {
                if (frame.Data.Length > 0)
                {
                    if (v2.TagVersion.Major == 2)
                        frame.ID = "MCI";
                    else
                        frame.ID = "MCDI";
                    v2.Frames.Add(frame);
                }
            }

        }
        public override void LoadTag(ID3v2 v2)
        {
            LoadFrames(v2);
        }
        public override void SaveTag(ID3v2 v2)
        {
            SaveFramesToTag(v2);
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
            //save frames
            SaveFramesToTag(v2);

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

        private void ChangeData(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files (*.*)|*.*";
            op.Title = "Add Music CD Identifier file";
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                FileInfo inf = new FileInfo(op.FileName);
                int size = (int)inf.Length;
                if (inf.Length > 804)
                {
                    if (MessageBox.Show("Only 804 bytes accepted, only 804 bytes of this file will be taken, do you want to proceed ?"
                        , "Add Music CD Identifier file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    size = 804;
                }
                else if (inf.Length == 0)
                {
                    MessageBox.Show("This file is empty !!");
                    return;
                }
                Stream str = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[size];
                str.Read(data, 0, size);
                str.Close();
                str.Dispose();
                frame = new MusicCDIdentifierFrame("MCDI", "Music CD identifier", data, 0);// id doesn't matter now..
              
                ViewData();
            }
        }

        private void ClearData(object sender, EventArgs e)
        {
            frame = new MusicCDIdentifierFrame("MCDI", "Music CD identifier", new byte [0], 0);
            ViewData();
        }
    }
}

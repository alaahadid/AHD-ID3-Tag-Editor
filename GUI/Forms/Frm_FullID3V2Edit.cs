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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_FullID3V2Edit : Form
    {
        public Frm_FullID3V2Edit(string[] files, StringCollection genreMemory, StringCollection artistsMemory, StringCollection albumsMemory)
        {
            this.genreMemory = genreMemory;
            this.artistsMemory = artistsMemory;
            this.albumsMemory = albumsMemory;
            this.files = files;
            InitializeComponent();
            textEditorControl1.textBox1.ReadOnly = true;
            InstallFrames();

            // view first file
            fileIndex = 0;
            EditFile();
            UpdateStatus();
            // select first edit control
            treeView1.SelectedNode = treeView1.Nodes[0];
            DisableSavingOnEditors();
        }
        private void InstallFrames()
        {
            treeView1.Nodes.Clear();
            // All text frames editor
            TreeNode tr = new TreeNode();
            tr.Text = "All text frames";
            tr.SelectedImageIndex = 0;
            tr.ImageIndex = 0;
            tr.Tag = new C_FullTextFramesEditor(genreMemory, artistsMemory, albumsMemory);
            treeView1.Nodes.Add(tr);

            // url links
            tr = new TreeNode();
            tr.Text = "URL Link";
            tr.SelectedImageIndex = 2;
            tr.ImageIndex = 2;
            tr.Tag = new C_UrlLinkEditor();
            treeView1.Nodes.Add(tr);

            // involved people
            tr = new TreeNode();
            tr.Text = "Involved people list";
            tr.SelectedImageIndex = 5;
            tr.ImageIndex = 5;
            tr.Tag = new C_InvolvedPeopleList();
            treeView1.Nodes.Add(tr);

            // comments
            tr = new TreeNode();
            tr.Text = "Comments";
            tr.SelectedImageIndex = 3;
            tr.ImageIndex = 3;
            tr.Tag = new C_CommentsEditor();
            treeView1.Nodes.Add(tr);

            // pictures
            tr = new TreeNode();
            tr.Text = "Attached pictures";
            tr.SelectedImageIndex = 1;
            tr.ImageIndex = 1;
            tr.Tag = new C_ImagesManager();
            treeView1.Nodes.Add(tr);

            // Popularimeter
            tr = new TreeNode();
            tr.Text = "Popularimeter";
            tr.SelectedImageIndex = 4;
            tr.ImageIndex = 4;
            tr.Tag = new C_Popularimeter();
            treeView1.Nodes.Add(tr);

            // Play counter
            tr = new TreeNode();
            tr.Text = "Play counter";
            tr.SelectedImageIndex = 11;
            tr.ImageIndex = 11;
            tr.Tag = new C_PlayCounter();
            treeView1.Nodes.Add(tr);

            // Unsychronised lyrics
            tr = new TreeNode();
            tr.Text = "Unsychronised lyrics";
            tr.SelectedImageIndex = 6;
            tr.ImageIndex = 6;
            tr.Tag = new C_UnsychronisedLyrics();
            treeView1.Nodes.Add(tr);

            // Synchronised lyrics
            tr = new TreeNode();
            tr.Text = "Synchronised lyrics";
            tr.SelectedImageIndex = 13;
            tr.ImageIndex = 13;
            tr.Tag = new C_SynchronisedLyrics();
            treeView1.Nodes.Add(tr);

            // Event timing codes
            tr = new TreeNode();
            tr.Text = "Event timing codes";
            tr.SelectedImageIndex = 12;
            tr.ImageIndex = 12;
            tr.Tag = new C_EventTimingCodes();
            treeView1.Nodes.Add(tr);

            // Unique file identifier
            tr = new TreeNode();
            tr.Text = "Unique file identifier";
            tr.SelectedImageIndex = 7;
            tr.ImageIndex = 7;
            tr.Tag = new C_UniqueFileIdentifier();
            treeView1.Nodes.Add(tr);

            // Unique file identifier
            tr = new TreeNode();
            tr.Text = "Music CD identifier";
            tr.SelectedImageIndex = 8;
            tr.ImageIndex = 8;
            tr.Tag = new C_MusicCDIdentifier();
            treeView1.Nodes.Add(tr);

            // General Encapsulated Object
            tr = new TreeNode();
            tr.Text = "General encapsulated object (attached file(s))";
            tr.SelectedImageIndex = 9;
            tr.ImageIndex = 9;
            tr.Tag = new C_GeneralEncapsulatedObject();
            treeView1.Nodes.Add(tr);

            // Commercial
            tr = new TreeNode();
            tr.Text = "Commercial";
            tr.SelectedImageIndex = 10;
            tr.ImageIndex = 10;
            tr.Tag = new C_Commercial();
            treeView1.Nodes.Add(tr);

            // TermsOfUseFrame
            tr = new TreeNode();
            tr.Text = "Terms of use";
            tr.SelectedImageIndex = 14;
            tr.ImageIndex = 14;
            tr.Tag = new C_TermsOfUseFrame();
            treeView1.Nodes.Add(tr);

            // Explorer
            tr = new TreeNode();
            tr.Text = "Tag explorer";
            tr.SelectedImageIndex = 15;
            tr.ImageIndex = 15;
            tr.Tag = new C_TagExplorer();
            treeView1.Nodes.Add(tr);
        }
        private int fileIndex = 0;
        private string[] files;
        private StringCollection genreMemory;
        private StringCollection artistsMemory;
        private StringCollection albumsMemory;
        private Dictionary<string, ID3v2> SavePndingList = new Dictionary<string, ID3v2>();

        private void AddToSavePendingList(string path, ID3v2 v2)
        {
            if (SavePndingList.ContainsKey(path))
                SavePndingList[path] = v2;
            else
                SavePndingList.Add(path, v2);
        }
        private ID3v2 GetID3V2Object(string path)
        {
            if (SavePndingList.ContainsKey(path))
                return SavePndingList[path];
            // not found in the save list, create new
            ID3v2 v2 = new ID3v2();
            v2.Load(path);
            return v2;
        }
        public void EditFile()
        {
            textEditorControl1.PropertyValue = files[fileIndex];
            // get it from the save list if found
            ID3v2 v2 = GetID3V2Object(files[fileIndex]);

            foreach (TreeNode tr in treeView1.Nodes)
            {
                ((EditorControl)tr.Tag).SetSelectedFile(files[fileIndex]);
                ((EditorControl)tr.Tag).ClearFields();
                ((EditorControl)tr.Tag).LoadTag(v2);
            }
            // add it to the save pending list
            AddToSavePendingList(files[fileIndex], v2);
        }
        private void SaveEditingToObject()
        {
            // get it from the save list if found
            ID3v2 v2 = GetID3V2Object(files[fileIndex]);
            foreach (TreeNode tr in treeView1.Nodes)
            {
                ((EditorControl)tr.Tag).SaveTag(v2);
            }
            // add it to the save pending list
            AddToSavePendingList(files[fileIndex], v2);
        }
        private void DisableSavingOnEditors()
        {
            foreach (TreeNode tr in treeView1.Nodes)
            {
                ((EditorControl)tr.Tag).DisableSaving();
            }
        }
        private void ClearMediaOfEditors()
        {
            foreach (TreeNode tr in treeView1.Nodes)
            {
                ((EditorControl)tr.Tag).ClearMedia();
            }
        }
        private void UpdateStatus()
        {
            button_previous.Enabled = fileIndex > 0;
            button_next.Enabled = fileIndex < files.Length - 1;
            label1.Text = "Edit " + (fileIndex + 1).ToString() + " of " + files.Length + " file(s), " + SavePndingList.Count + " pending to save.";
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            //view selection
            groupBox_frame.Controls.Clear();
            EditorControl control = (EditorControl)treeView1.SelectedNode.Tag;
            groupBox_frame.Controls.Add((EditorControl)treeView1.SelectedNode.Tag);
            groupBox_frame.Text = treeView1.SelectedNode.Text;
            control.Dock = DockStyle.Fill;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            SaveEditingToObject();
            fileIndex++;
            EditFile();
            UpdateStatus();
        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            SaveEditingToObject();
            fileIndex--;
            EditFile();
            UpdateStatus();
        }
        // save and close
        private void button1_Click(object sender, EventArgs e)
        {
            ClearMediaOfEditors();
            SaveEditingToObject();// just in case one file edited
            Frm_SavePending frm = new Frm_SavePending(SavePndingList);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearMediaOfEditors();
            Close();
        }

        private void Frm_FullID3V2Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearMediaOfEditors();
        }
    }
}

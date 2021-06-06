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
    public partial class Frm_FullEditV1 : Form
    {
        public Frm_FullEditV1(string[] files, StringCollection artistsMemory, StringCollection albumsMemory)
        {
            InitializeComponent();
            c_quickEditor = new C_QuickTagEditorV1(artistsMemory, albumsMemory);
            this.Controls.Add(c_quickEditor);
            c_quickEditor.Dock = DockStyle.Fill;
            c_quickEditor.BringToFront();

            this.artistsMemory = artistsMemory;
            this.albumsMemory = albumsMemory;
            this.files = files;
            textEditorControl1.textBox1.ReadOnly = true;

            // view first file
            fileIndex = 0;
            EditFile();
            UpdateStatus();
        }
        private C_QuickTagEditorV1 c_quickEditor;
        private int fileIndex = 0;
        private string[] files;
        private StringCollection artistsMemory;
        private StringCollection albumsMemory;
        private Dictionary<string, ID3v1> SavePndingList = new Dictionary<string, ID3v1>();

        private void AddToSavePendingList(string path, ID3v1 v1)
        {
            if (SavePndingList.ContainsKey(path))
                SavePndingList[path] = v1;
            else
                SavePndingList.Add(path, v1);
        }
        private ID3v1 GetID3V1Object(string path)
        {
            if (SavePndingList.ContainsKey(path))
                return SavePndingList[path];
            // not found in the save list, create new
            ID3v1 v1 = new ID3v1();
            v1.Load(path);
            return v1;
        }
        private void SaveEditingToObject()
        {
            // get it from the save list if found
            ID3v1 v1 = GetID3V1Object(files[fileIndex]);

            c_quickEditor.SaveTag(v1);

            // add it to the save pending list
            AddToSavePendingList(files[fileIndex], v1);
        }
        private void ClearMediaOfEditors()
        {
            c_quickEditor.ClearMedia();
        }
        public void EditFile()
        {
            textEditorControl1.PropertyValue = files[fileIndex];
            // get it from the save list if found
            ID3v1 v1 = GetID3V1Object(files[fileIndex]);

            c_quickEditor.SetSelectedFile(files[fileIndex]);
            c_quickEditor.ClearFields();
            c_quickEditor.LoadTag(v1);

            // add it to the save pending list
            AddToSavePendingList(files[fileIndex], v1);
        }
        private void UpdateStatus()
        {
            button_previous.Enabled = fileIndex > 0;
            button_next.Enabled = fileIndex < files.Length - 1;
            label1.Text = "Edit " + (fileIndex + 1).ToString() + " of " + files.Length + " file(s), " + SavePndingList.Count + " pending to save.";
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
        // save pending
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
            Close();
        }
    }
}

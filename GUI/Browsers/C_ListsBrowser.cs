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
using AHD.ID3.Editor.Base;

namespace AHD.ID3.Editor.GUI
{
    public partial class C_ListsBrowser : UserControl
    {
        public C_ListsBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raised when the user select a list
        /// </summary>
        public event EventHandler<ListSelectArgs> ListSelect;
        /// <summary>
        /// Raised when a list need to be added
        /// </summary>
        public event EventHandler<FileAddArgs> ListAddRequest;
        /// <summary>
        /// Refresh the lists collection
        /// </summary>
        /// <param name="db"></param>
        public void RefreshLists(BrowserDatabase db)
        {
            treeView1.Nodes.Clear();

            foreach (BList list in db.Lists)
            {
                TreeNode tr = new TreeNode();
                tr.Text = list.Name;
                tr.Tag = list;
                treeView1.Nodes.Add(tr);
            }
        }

        /// <summary>
        /// Get the currently slected list
        /// </summary>
        public BList SelectedList
        {
            get
            {
                if (treeView1.SelectedNode == null)
                    return null;
                return (BList)treeView1.SelectedNode.Tag;
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.Location);
                if (treeView1.SelectedNode == null)
                    return;

                if (ListSelect != null)
                {
                    ListSelect(this, new ListSelectArgs((BList)treeView1.SelectedNode.Tag));
                }
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
                List<string> addFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    if (Directory.Exists(files[i]))
                    {
                        addFiles.AddRange(Directory.GetFiles(files[i], "*", SearchOption.AllDirectories));
                    }
                }
                files.AddRange(addFiles);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".m3u")
                        if (ListAddRequest != null)
                            ListAddRequest(this, new FileAddArgs(file));
                }
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}

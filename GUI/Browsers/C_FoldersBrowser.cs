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
    public partial class C_FoldersBrowser : UserControl
    {
        public C_FoldersBrowser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Raised when a folder selected by the user
        /// </summary>
        public event EventHandler<FolderSelectArgs> FolderSelected;
        /// <summary>
        /// Raised when requesting a folder add
        /// </summary>
        public event EventHandler<FolderSelectArgs> FolderAddRequest;
        private bool isItemsDrag = false;
        /// <summary>
        /// Refresh folders of the database
        /// </summary>
        /// <param name="db">The database to browser folders for</param>
        public void RefreshFolders(BrowserDatabase db)
        {
            treeView.Nodes.Clear();
            foreach (BFolder folder in db.Folders)
            {
                TreeNodeBFolder tr = new TreeNodeBFolder();
                tr.BFolder = folder;
                tr.ImageIndex = 0;
                tr.SelectedImageIndex = 0;
                folder.RefreshFolders();
                tr.RefreshFolders(0, 0);
                treeView.Nodes.Add(tr);
            }
        }
        /// <summary>
        /// Refresh selected folder to update folder's content change.
        /// </summary>
        public void RefreshSelectedFolder()
        {
            if (treeView.SelectedNode != null)
            {
                ((TreeNodeBFolder)treeView.SelectedNode).BFolder.RefreshFolders();
                ((TreeNodeBFolder)treeView.SelectedNode).RefreshFolders(0, 0);
            }
        }
        /// <summary>
        /// Get currently selected folder in the list
        /// </summary>
        public BFolder SelectedFolder
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return null;
                return ((TreeNodeBFolder)treeView.SelectedNode).BFolder;
            }
        }
        /// <summary>
        /// Get if the user can delete selected folder
        /// </summary>
        public bool CanDeleteSelected
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return false;
                return (treeView.SelectedNode.Parent == null);
            }
        }
        private void treeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                if (treeView.SelectedNode == null)
                    return;

                if (FolderSelected != null)
                {
                    FolderSelected(this, new FolderSelectArgs(((TreeNodeBFolder)treeView.SelectedNode).BFolder));
                }
            }
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
                for (int i = 0; i < files.Count; i++)
                {
                    if (!Directory.Exists(files[i]))
                    {
                        files.RemoveAt(i);
                        i--;
                    }
                }

                foreach (string folder in files)
                {
                    BFolder fld = new BFolder(folder);// just add path, the main window should take care of refreshing ..

                    if (FolderAddRequest != null)
                        FolderAddRequest(this, new FolderSelectArgs(fld));
                }
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            if (isItemsDrag)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;

            isItemsDrag = true;
            string folder = ((TreeNodeBFolder)treeView.SelectedNode).BFolder.Path;
            DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { folder }),
                DragDropEffects.Copy | DragDropEffects.Move);
            isItemsDrag = false;
        }
    }
}

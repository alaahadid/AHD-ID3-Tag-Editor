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
 * 
 * Author email: mailto:alaahadidfreeware@gmail.com
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AHD.ID3.Editor.Base
{
    [Serializable()]
    public class BFolder
    {
        public BFolder()
        { }
        public BFolder(string path)
        { this.path = path; }

        private List<BFolder> folders = new List<BFolder>();
        private List<BFile> files = new List<BFile>();
        private string path = "";
        private bool cacheBuilt = false;

        //methods
        public void RefreshFolders()
        {
            folders = new List<BFolder>();
            string[] fldrs = Directory.GetDirectories(path);
            foreach (string fol in fldrs)
            {
                BFolder bfolder = new BFolder();
                bfolder.Path = fol;
                bfolder.RefreshFolders();
                folders.Add(bfolder);
            }
        }

        //Properties
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public List<BFolder> BFolders
        { get { return folders; } set { folders = value; } }
        public List<BFile> BFiles
        { get { return files; } set { files = value; } }
        public bool CacheBuilt
        { get { return cacheBuilt; } set { cacheBuilt = value; } }
    }
}

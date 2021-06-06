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
namespace AHD.ID3.Editor.Base
{
    [Serializable()]
    public class BrowserDatabase
    {
        private List<BFolder> folders = new List<BFolder>();
        private List<BList> lists = new List<BList>();

        /// <summary>
        /// Get or set the folders collection
        /// </summary>
        public List<BFolder> Folders
        { get { return folders; } set { folders = value; } }
        /// <summary>
        /// Get or set the lists collection
        /// </summary>
        public List<BList> Lists
        { get { return lists; } set { lists = value; } }
        /// <summary>
        /// Get if a folder exists in the folders collection
        /// </summary>
        /// <param name="folderPath">The folder path</param>
        /// <returns>True if folder exists otherwise false</returns>
        public bool IsFolderExist(string folderPath)
        {
            foreach (BFolder fldr in folders)
            {
                if (fldr.Path == folderPath)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get if a list exists in the lists collection
        /// </summary>
        /// <param name="name">The list name</param>
        /// <returns>True if list exists otherwise false</returns>
        public bool IsListExist(string name)
        {
            foreach (BList list in lists)
            {
                if (list.Name.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="name">The name of the list</param>
        /// <returns>The list if found otherwise null</returns>
        public BList GetList(string name)
        {
            foreach (BList list in lists)
            {
                if (list.Name.ToLower() == name.ToLower())
                    return list;
            }
            return null;
        }
    }
}
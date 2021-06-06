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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace AHD.ID3.Editor.Base
{
    public class BDatabaseManager
    {
        private BrowserDatabase bdatabase = new BrowserDatabase();
        private string filePath = "";

        public BrowserDatabase BrowserDatabase
        { get { return bdatabase; } set { bdatabase = value; } }

        public string FilePath
        { get { return filePath; } set { filePath = value; } }
        public bool Save()
        {
            return Save(this.filePath);
        }
        public bool Save(string fileName)
        {
            try
            {
                FileStream str = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(str, bdatabase);
                str.Close();
                filePath = fileName;
                return true;
            }
            catch { filePath = ""; }
            return false;
        }
        public bool Load()
        {
            return Load(this.filePath);
        }
        public bool Load(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    FileStream str = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryFormatter formatter = new BinaryFormatter();
                    bdatabase = (BrowserDatabase)formatter.Deserialize(str);
                    str.Close();
                    filePath = fileName;
                    return true;
                }
            }
            catch { filePath = ""; }
            return false;
        }
    }
}

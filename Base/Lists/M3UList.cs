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
using System.Collections.Generic;

namespace AHD.ID3.Editor.Base
{
    public class M3UList
    {
        /// <summary>
        /// Raised when a progress starts
        /// </summary>
        public event EventHandler ProgressStart;
        /// <summary>
        /// Raised when a progress finishes
        /// </summary>
        public event EventHandler ProgressFinished;
        /// <summary>
        /// Raised in progress
        /// </summary>
        public event EventHandler<ProgressArgs> Progress;
        public void OnProgressStart()
        { if (ProgressStart != null)ProgressStart(this, new EventArgs()); }
        public void OnProgressFinish()
        { if (ProgressFinished != null)ProgressFinished(this, new EventArgs()); }
        public void OnProgress(string status, int complete)
        { if (Progress != null)Progress(this, new ProgressArgs(complete, status)); }

        /// <summary>
        /// Save a M3U list
        /// </summary>
        /// <param name="filePath">The complete path where to save</param>
        /// <param name="files">The files list to save</param>
        public void Save(string filePath, string[] files)
        {
            OnProgressStart();

            StreamWriter stream = new StreamWriter(filePath);
            stream.WriteLine("#EXTM3U");
            int i = 0;
            foreach (string st in files)
            {
                stream.WriteLine(st);
                int x = (i * 100) / files.Length;
                OnProgress("Saving .. " + x + "%", x);
                i++;
            }

            OnProgress("Done.", 100);
            OnProgressFinish();

            stream.Close();
        }
        /// <summary>
        /// Load M3U list
        /// </summary>
        /// <param name="filePath">The complete path where to save</param>
        /// <returns>The file paths list loaded from file. Null if load failed</returns>
        public string[] Load(string filePath)
        {
            OnProgressStart();
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
                return null;
            if (lines[0] != "#EXTM3U")
                return null;

            List<string> files = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (!lines[i].StartsWith("#") && !lines[i].StartsWith("<") && !lines[i].Contains("?"))
                {
                    files.Add(lines[i]);
                }
                int x = (i * 100) / lines.Length;
                OnProgress("Loading file .. " + x + "%", x);
            }
            OnProgress("Done.", 100);
            OnProgressFinish();

            return files.ToArray();
        }
    }
}

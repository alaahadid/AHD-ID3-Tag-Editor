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

namespace AHD.ID3.Editor.Base
{
    [Serializable()]
    public class ColumnItem
    {
        public string ColumnID = "";
        public string ColumnName = "";
        public bool Visible = true;
        public int Width = 60;

        public static string[,] DEFAULTCOLUMNS
        {
            get
            {
                return new string[,]  {
          { "File Name",         "name" } ,
          { "Size",              "size" } ,
          { "Track",             "track" } ,
          { "Title",             "title" } ,
          { "Rating",            "rating" } ,
          { "Artist",            "artist" } ,
          { "Album",             "album" } ,
          { "Year",              "year" } ,
          { "Genre",             "genre" } ,
          { "Comment",           "comment" } ,
          { "Path",              "path" } , 
                                      };
            }
        }

        public static bool IsDefaultColumn(string id)
        {
            for (int i = 0; i < DEFAULTCOLUMNS.Length / 2; i++)
            {
                if (DEFAULTCOLUMNS[i, 1] == id)
                    return true;
            }
            return false;
        }
    }
}

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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHD.ID3.Editor.Base
{
    [Serializable()]
    public class ColumnsManager
    {
        private List<ColumnItem> columns = new List<ColumnItem>();
        /// <summary>
        /// Get or set the columns collection
        /// </summary>
        public List<ColumnItem> Columns
        { get { return this.columns; } set { this.columns = value; } }

        /// <summary>
        /// Use this at first program start
        /// </summary>
        public void BuildDefaultCollection()
        {
            columns = new List<ColumnItem>();
            for (int i = 0; i < ColumnItem.DEFAULTCOLUMNS.Length / 2; i++)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnName = ColumnItem.DEFAULTCOLUMNS[i, 0];
                item.ColumnID = ColumnItem.DEFAULTCOLUMNS[i, 1];
                if (ColumnItem.DEFAULTCOLUMNS[i, 1] == "name")
                    item.Width = 160;
                else if (ColumnItem.DEFAULTCOLUMNS[i, 1] == "path")
                    item.Width = 250;
                else if (ColumnItem.DEFAULTCOLUMNS[i, 1] == "rating")
                    item.Width = 90;
                else
                    item.Width = 60;
                item.Visible = true;
                columns.Add(item);
            }
            // Add some misc invisible columns
            ColumnItem item1 = new ColumnItem();
            item1.ColumnName = "ID3 Tag version";
            item1.ColumnID = "id3";
            item1.Width = 60;
            item1.Visible = false;
            columns.Add(item1);
        }
    }
}

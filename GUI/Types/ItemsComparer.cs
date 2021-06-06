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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLV;

namespace AHD.ID3.Editor.GUI
{
    /// <summary>
    /// The items comparer class
    /// </summary>
    class ItemsComparer : IComparer<ManagedListViewItem>
    {
        /// <summary>
        /// The items comparer class for comparing Managed ListView items via column id.
        /// </summary>
        /// <param name="AtoZ">True= A to Z sort, False=Z to A sort</param>
        /// <param name="subitemId">The column id of the subitem.</param>
        public ItemsComparer(bool AtoZ, string subitemId)
        {
            this.AtoZ = AtoZ;
            this.subitemId = subitemId;
        }

        private bool AtoZ = true;
        private string subitemId = "";

        /// <summary>
        /// Compare 2 items debending on subitem
        /// </summary>
        /// <param name="x">The first item</param>
        /// <param name="y">The second item</param>
        /// <returns>Compare result.</returns>
        public int Compare(ManagedListViewItem x, ManagedListViewItem y)
        {
            if (x.GetSubItemByID(subitemId) != null && y.GetSubItemByID(subitemId) != null)
            {
                if (subitemId != "rating")
                {
                    if (AtoZ)
                        return (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.GetSubItemByID(subitemId).Text, y.GetSubItemByID(subitemId).Text);
                    else
                        return (-1 * (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.GetSubItemByID(subitemId).Text, y.GetSubItemByID(subitemId).Text));
                }
                else
                {
                    return (((ManagedListViewRatingSubItem)x.GetSubItemByID(subitemId)).Rating
                        - ((ManagedListViewRatingSubItem)y.GetSubItemByID(subitemId)).Rating) * (AtoZ ? 1 : -1);
                }
            }
            return -1;
        }
    }
}

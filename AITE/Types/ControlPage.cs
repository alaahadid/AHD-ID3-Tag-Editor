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
using System.Threading.Tasks;

namespace AHD.ID3.Editor
{
    /// <summary>
    /// A control page
    /// </summary>
    [Serializable()]
    public class ControlPage
    {
        private ControlLocation location = ControlLocation.TopLeft;
        private ControlType type = ControlType.None;
        private string name = "";
        private bool visible = true;

        /// <summary>
        /// Get or set the control location
        /// </summary>
        public ControlLocation Location
        { get { return location; } set { location = value; } }
        /// <summary>
        /// Get or set the control type
        /// </summary>
        public ControlType Type
        { get { return type; } set { type = value; } }
        /// <summary>
        /// Get or set the control name
        /// </summary>
        public string Name
        { get { return name; } set { name = value; } }
        /// <summary>
        /// Get or set if this control is visible
        /// </summary>
        public bool Visible
        { get { return visible; } set { visible = value; } }
    }
}

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
using System.Drawing;

namespace AHD.ID3.Editor
{ 
    [Serializable()]
    public class ToolBar
    {
        private string name = "Main";
        private ToolBarType type = ToolBarType.Main;
        private ToolBarLocation location = ToolBarLocation.Top;
        private Point position = new Point(0, 0);
        private bool visible = true;

        public string Name
        { get { return name; } set { name = value; } }
        public ToolBarType Type
        { get { return type; } set { type = value; } }
        public ToolBarLocation Location
        { get { return location; } set { location = value; } }
        public Point Position
        { get { return position; } set { position = value; } }
        public bool Visible
        { get { return visible; } set { visible = value; } }
    }
}

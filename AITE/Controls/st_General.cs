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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHD.ID3.Editor
{
    public partial class st_General : SettingsControl
    {
        public st_General()
        {
            InitializeComponent();

            comboBox_doubleClickAction.SelectedIndex = Program.Settings.DoubleClickActionIndex;
            checkBox_mediaPlayerAutostart.Checked = Program.Settings.MediaPlayerAutoStart;
        }
        public override string ToString()
        {
            return "General";
        }
        public override void SaveSettings()
        {
            Program.Settings.DoubleClickActionIndex = comboBox_doubleClickAction.SelectedIndex;
            Program.Settings.MediaPlayerAutoStart = checkBox_mediaPlayerAutostart.Checked;
        }
        public override void DefaultSettings()
        {
            checkBox_mediaPlayerAutostart.Checked = false;
            comboBox_doubleClickAction.SelectedIndex = 2;
        }
    }
}

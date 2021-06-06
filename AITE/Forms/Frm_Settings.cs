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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace AHD.ID3.Editor
{
    public partial class Frm_Settings : Form
    {
        public Frm_Settings()
        {
            InitializeComponent();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type tp in types)
            {
                if (tp.IsSubclassOf(typeof(SettingsControl)))
                {
                    controls.Add(Activator.CreateInstance(tp) as SettingsControl);
                }
            }
            controls.Sort(new SettingsControlComparer(true));
            foreach (SettingsControl control in controls)
                listBox1.Items.Add(control.ToString());
            listBox1.SelectedIndex = 0;
        }
        private List<SettingsControl> controls = new List<SettingsControl>();

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SettingsControl control = controls[listBox1.SelectedIndex];
            control.Location = new Point(0, 0);
            string test = control.ToString();
            panel1.Controls.Add(control);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // save and apply
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (SettingsControl control in controls)
                control.SaveSettings();
            Program.Settings.Save();
            Close();
        }
        // default all
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (SettingsControl control in controls)
                control.DefaultSettings();
        }
        //default
        private void button3_Click(object sender, EventArgs e)
        {
            controls[listBox1.SelectedIndex].DefaultSettings();
        }
    }
}

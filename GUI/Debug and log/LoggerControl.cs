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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHD.ID3.Editor.GUI
{
    public partial class LoggerControl : UserControl
    {
        public LoggerControl()
        {
            InitializeComponent();
        }

        private void UpdateVscroll()
        {
            if (!this.InvokeRequired)
            {
                this.UpdateVscroll1();
            }
            else
            {
                this.Invoke(new Action(UpdateVscroll1));
            }
        }
        private void UpdateVscroll1()
        {
            if (logPanel1.StringHeight < logPanel1.Height)
            {
                vScrollBar1.Maximum = 1;
                vScrollBar1.Value = 0;
                vScrollBar1.Enabled = false;
                logPanel1.ScrollOffset = 0;
            }
            else
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Maximum = logPanel1.StringHeight - logPanel1.Height + 40;
                vScrollBar1.Value = vScrollBar1.Maximum - 1;
                logPanel1.ScrollOffset = vScrollBar1.Value;
            }
            logPanel1.Invalidate();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            logPanel1.ScrollOffset = vScrollBar1.Value;
            logPanel1.Invalidate();
        }
        private void LoggerControl_Resize(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void logPanel1_DebugLinesUpdated(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        // save log
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "Text (*.txt)|*.txt";
            sav.FileName = "log.txt";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                List<string> lines = new List<string>();
                foreach (DebugLine line in logPanel1.debugLines)
                    lines.Add(line.Text);
                System.IO.File.WriteAllLines(sav.FileName, lines.ToArray());
            }
        }
        // clear log
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            logPanel1.debugLines = new List<DebugLine>();
            logPanel1.Invalidate();
        }
    }
}

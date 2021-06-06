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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHD.ID3.Editor.GUI
{
    public partial class Frm_SavePending : Form
    {
        public Frm_SavePending(Dictionary<string, ID3v2> SavePndingListV2)
        {
            isV1 = false;
            this.SavePndingListV2 = SavePndingListV2;
            InitializeComponent();
        }
        public Frm_SavePending(Dictionary<string, ID3v1> SavePndingListV1)
        {
            isV1 = true;
            this.SavePndingListV1 = SavePndingListV1;
            InitializeComponent();
        }
        private int progress1 = 0;
        private int progress2 = 0;
        private string status1 = "Saving 0 of 0";
        private string status2 = "Saving...";
        private bool done = false;
        private bool isV1 = false;

        private Thread mainThread;
        private Dictionary<string, ID3v2> SavePndingListV2;
        private Dictionary<string, ID3v1> SavePndingListV1;
        private void PROGRESSV1()
        {
            int i = 0;
            foreach (string path in SavePndingListV1.Keys)
            {
                progress1 = (i * 100) / SavePndingListV1.Count;
                status1 = "Saving " + (i + 1).ToString() + " of " + SavePndingListV1.Count + " .." + progress1 + "%";
                SavePndingListV1[path].Progress += Frm_SavePending_Progress;
                SavePndingListV1[path].Save(path);

                i++;
            }
            done = true;
        }
        private void PROGRESSV2()
        {
            int i = 0;
            foreach (string path in SavePndingListV2.Keys)
            {
                progress1 = (i * 100) / SavePndingListV2.Count;
                status1 = "Saving " + (i + 1).ToString() + " of " + SavePndingListV2.Count + " .." + progress1 + "%";
                SavePndingListV2[path].Progress += Frm_SavePending_Progress;
                SavePndingListV2[path].Save(path);

                i++;
            } 
            done = true;
        }
        void Frm_SavePending_Progress(object sender, ProgressArg e)
        {
            status2 = e.Status;
            progress2 = e.Progress;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_status1.Text = status1;
            label_status2.Text = status2;
            progressBar1.Value = progress1;
            progressBar2.Value = progress2;

            if (done)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void Frm_SavePending_Shown(object sender, EventArgs e)
        {
            timer1.Start();
            if (!isV1)
                mainThread = new Thread(new ThreadStart(PROGRESSV2));
            else
                mainThread = new Thread(new ThreadStart(PROGRESSV1));
            mainThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_SavePending_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void Frm_SavePending_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!done)
            {
                if (mainThread != null)
                {
                    if (mainThread.IsAlive)
                    {
                        if (MessageBox.Show("Are you sure ?", "Cancel saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == System.Windows.Forms.DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            mainThread.Abort();
                        }
                    }
                }
            }
        }
    }
}

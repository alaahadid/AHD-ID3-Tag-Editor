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
    public partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            InitializeComponent();
        }

        private int rating = 0;

        /// <summary>
        /// Get or set the rating. 0=no rating, 5=top rating.
        /// </summary>
        public int Rating
        { get { return rating; } set { rating = value; ViewRating(); pictureBox2.Image = null; } }
        /// <summary>
        /// Raised when the user changes the rating.
        /// </summary>
        public event EventHandler RatingChanged;

        private void ViewRating()
        {
            switch (rating)
            {
                case 0: pictureBox1.Image = Properties.Resources.noneRating; break;
                case 1: pictureBox1.Image = Properties.Resources.star_1; break;
                case 2: pictureBox1.Image = Properties.Resources.star_2; break;
                case 3: pictureBox1.Image = Properties.Resources.star_3; break;
                case 4: pictureBox1.Image = Properties.Resources.star_4; break;
                case 5: pictureBox1.Image = Properties.Resources.star_5; break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int prec = (e.X * 100) / pictureBox1.Width;

            if (prec <= 20)
                pictureBox1.Image = Properties.Resources.star_1;
            else if (prec <= 40)
                pictureBox1.Image = Properties.Resources.star_2;
            else if (prec <= 60)
                pictureBox1.Image = Properties.Resources.star_3;
            else if (prec <= 80)
                pictureBox1.Image = Properties.Resources.star_4;
            else if (prec > 80)
                pictureBox1.Image = Properties.Resources.star_5;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ViewRating();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.unrateactive;
            pictureBox1.Image = Properties.Resources.noneRating;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            ViewRating();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int prec = (e.X * 100) / pictureBox1.Width;

            if (prec <= 20)
                rating = 1;
            else if (prec <= 40)
                rating = 2;
            else if (prec <= 60)
                rating = 3;
            else if (prec <= 80)
                rating = 4;
            else if (prec > 80)
                rating = 5;

            if (RatingChanged != null)
                RatingChanged(this, new EventArgs());

            ViewRating();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rating = 0;
            if (RatingChanged != null)
                RatingChanged(this, new EventArgs());
            ViewRating();
        }
    }
}

/* This file is part of AHD ID3 Tag Editor (AITE)
 * A program that edit and create ID3 Tag.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
namespace AHD.ID3.Editor.GUI
{
    public class TimeChangedArgs : EventArgs
    {
        double oldTime = 0;
        double newTime = 0;
        public TimeChangedArgs(double oldTime, double newTime)
        {
            this.oldTime = oldTime;
            this.newTime = newTime;
        }

        public double OldTime
        { get { return oldTime; } }
        public double NewTime
        { get { return newTime; } }
    }
}

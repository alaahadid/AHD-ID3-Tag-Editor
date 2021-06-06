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
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace AHD.ID3.Editor.Base
{
    public sealed class DirectMediaPlayer
    {
        // TODO: direct-show media player, disable the subtitle view filter during playtime.
        private FilterGraph mediaDS;
        private IMediaPosition mediaPos;
        private IVideoWindow mediaVid;
        private IMediaControl mediaCon;
        private IBasicAudio mediaS;
        private bool initialized;

        private void DisposeMedia()
        {
            if (!initialized) return;
            // Dispose objects
            Marshal.ReleaseComObject(mediaDS); mediaDS = null;
            Marshal.ReleaseComObject(mediaCon); mediaCon = null;
            Marshal.ReleaseComObject(mediaPos); mediaPos = null;
            Marshal.ReleaseComObject(mediaVid); mediaVid = null;
            Marshal.ReleaseComObject(mediaS); mediaS = null;

            GC.Collect();
            initialized = false;
        }
        /// <summary>
        /// Load media file
        /// </summary>
        /// <param name="filePath">The complete media file path</param>
        public void LoadFile(string filePath)
        {
            if (initialized)
            {
                DisposeMedia();
            }

            mediaDS = new FilterGraph();
            mediaCon = (IMediaControl)mediaDS;
            mediaCon.RenderFile(filePath);
            mediaPos = (IMediaPosition)mediaDS;
            mediaVid = (IVideoWindow)mediaDS;
            mediaS = (IBasicAudio)mediaDS;

            initialized = true;
        }
        /// <summary>
        /// Set the media surface (where to render video)
        /// </summary>
        /// <param name="handle">The video control handle</param>
        public void SetVideoSurface(IntPtr handle, int width, int height)
        {
            if (mediaVid != null)
            {
                try
                {
                    IntPtr owner = IntPtr.Zero;
                    mediaVid.get_Owner(out owner);
                    if (owner != handle)
                    {
                        mediaVid.put_Owner(handle);
                    }
                    mediaVid.SetWindowPosition(0, 0, width, height);
                    mediaVid.put_WindowStyle(WindowStyle.Child);
                }
                catch { }
            }
        }
        /// <summary>
        /// Clear media file.
        /// </summary>
        public void ClearMedia()
        {
            // TODO: clear media player
            Stop();
            DisposeMedia();
        }
        /// <summary>
        /// Play media
        /// </summary>
        public void Play()
        {
            if (mediaCon != null)
                mediaCon.Run();
        }
        /// <summary>
        /// Pause media
        /// </summary>
        public void Pause()
        {
            if (mediaCon != null)
                mediaCon.Pause();
        }
        /// <summary>
        /// Stop media.
        /// </summary>
        public void Stop()
        {
            if (mediaCon != null)
            {
                mediaCon.Stop();
                Position = 0;
            }
        }
        /// <summary>
        /// Mute/UnMute
        /// </summary>
        public void Mute()
        {
        }
        // Properties
        /// <summary>
        /// Get the media duration.
        /// </summary>
        public double Duration
        {
            get
            {
                double v = 0;
                if (mediaPos != null)
                {
                    try { mediaPos.get_Duration(out v); }
                    catch { }
                }
                return v;
            }
        }
        /// <summary>
        /// Get or set current media position
        /// </summary>
        public double Position
        {
            get
            {
                double v = 0;
                if (mediaPos != null)
                    mediaPos.get_CurrentPosition(out v);
                return v;
            }
            set
            {
                if (value < 0)
                    return;
                if (mediaPos != null)
                {
                    mediaPos.put_CurrentPosition(value);
                    if (PositionChanged != null)
                        PositionChanged(null, new EventArgs());
                }
            }
        }
        /// <summary>
        /// Get current status
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                FilterState st = FilterState.Stopped;
                if (mediaCon != null)
                    mediaCon.GetState(2, out st);
                return st == FilterState.Running;
            }
        }
        public int Volume
        {
            get
            {
                int v = 0;
                if (mediaS != null)
                {
                    mediaS.get_Volume(out v);
                }
                return (v / 35) + 100;
            }
            set
            {
                if (mediaS != null)
                {
                    if (value == 0)
                        mediaS.put_Volume(-10000);
                    else
                        mediaS.put_Volume((value - 100) * 35);
                }
            }
        }
        public bool Initialized
        {
            get { return initialized; }
        }
        // Events
        /// <summary>
        /// Raised when the user changes the media play position
        /// </summary>
        public event EventHandler PositionChanged;
    }
}

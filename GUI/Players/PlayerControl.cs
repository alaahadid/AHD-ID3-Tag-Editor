using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AHD.ID3.Editor.Base;
using AHD.SM.ASMP;

namespace AHD.ID3.Editor.GUI
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }
        private bool isMuted;
        private bool isPlaying;
        private bool isChangingTime;
        private double advanceTime = 0.500;
        private bool forward_down;
        private bool rewind_down;
        private bool ready = false;
        private DirectMediaPlayer directPlayer;
        /// <summary>
        /// Get or set the direct media player object
        /// </summary>
        public DirectMediaPlayer DirectMediaPlayer
        {
            get { return directPlayer; }
            set
            {
                directPlayer = value;
                // Clear all
                ready = false;
                label_time.Text = label_duration.Text = "00:00:00.000";
                mediaSeeker1.MediaDuration = 100;
                button_play.Image = Properties.Resources.control_play;
                // Setup new
                if (directPlayer != null)
                {
                    if (directPlayer.Initialized)
                    {
                        label_duration.Text = TimeFormatConvertor.To_TimeSpan_Milli(directPlayer.Duration);
                        mediaSeeker1.MediaDuration = directPlayer.Duration;
                        ready = true;
                    }
                }
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            if (!ready)
                return;
            if (directPlayer.IsPlaying)
                directPlayer.Pause();
            else
                directPlayer.Play();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!ready)
                return;
            label_time.Text = TimeFormatConvertor.To_TimeSpan_Milli(directPlayer.Position);
            if (directPlayer.IsPlaying != isPlaying)
            {
                isPlaying = directPlayer.IsPlaying;
                if (isPlaying)
                {
                    button_play.Image = Properties.Resources.control_pause;
                }
                else
                {
                    button_play.Image = Properties.Resources.control_play;
                }
            }
            if (!isChangingTime)
                mediaSeeker1.TimePosition = directPlayer.Position;

            // Fast forward / Rewind
            if (forward_down)
            {
                double pos = directPlayer.Position;
                directPlayer.Position = pos + advanceTime;
            }
            if (rewind_down)
            {
                double pos = directPlayer.Position;
                if (pos - advanceTime > 0)
                    directPlayer.Position = pos - advanceTime;
            }
        }
        private void mediaSeeker1_TimeChangeRequest(object sender, TimeChangeArgs e)
        {
            if (!ready)
                return;
            isChangingTime = true;
            if (e.NewTime >= 0 && e.NewTime <= directPlayer.Duration)
                directPlayer.Position = e.NewTime;

            isChangingTime = false;
        }
        private void button_rwd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                rewind_down = true;
        }
        private void button_rwd_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                rewind_down = false;
        }
        private void button_fwd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                forward_down = true;
        }
        private void button_fwd_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                forward_down = false;
        }
        private void trackBar_volume_Scroll(object sender, EventArgs e)
        {
            DirectMediaPlayer.Volume = trackBar_volume.Value;
            toolTip1.SetToolTip(trackBar_volume, "Volume: " + trackBar_volume.Value + "%");
        }
        private void button_mute_Click(object sender, EventArgs e)
        {
            if (!isMuted)
            {
                isMuted = true;
                DirectMediaPlayer.Volume = 0;
                button_mute.Image = Properties.Resources.sound_mute;
                toolTip1.SetToolTip(button_mute, "Enable sound");
            }
            else
            {
                isMuted = false;
                DirectMediaPlayer.Volume = trackBar_volume.Value;
                button_mute.Image = Properties.Resources.sound;
                toolTip1.SetToolTip(button_mute, "Mute");
            }
        }
    }
}

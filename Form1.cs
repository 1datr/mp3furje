using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;
using NAudio.FileFormats.Mp3;

namespace mp3furje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mp3-файл (*.mp3)|*.mp3";
            ofd.DefaultExt = "mp3";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = ofd.OpenFile();

                //Загружаем файл  прочесываем по фреймам                
                NAudio.Wave.Mp3FileReader mp3reader = new Mp3FileReader(ofd.FileName);
                Mp3Frame frame;
                int framecount = 0;
                while ((frame = mp3reader.ReadNextFrame()) != null)
                {
                    framecount++;
                }
               // DmoMp3FrameDecompressor dmfd=new DmoMp3FrameDecompressor(
                tsFrameCount.Text = framecount.ToString() + " frames found";
                
            }
        }
    }
}

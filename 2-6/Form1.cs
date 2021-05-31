using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_6
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool hold = false;
        int x, y, r = 100,a = 3,b = 3;
        Pen pen = new Pen(Color.Blue);
        public Form1()
        {
            InitializeComponent();

            g = Graphics.FromHwnd(panel1.Handle);

            x = panel1.Width / 2;
            y = panel1.Height / 2;
            pen.Width = 10;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            hold = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            hold = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            pen.Color = color.Color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
            panel1.Refresh();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            a = trackBar3.Value;
            panel1.Refresh();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            b = trackBar4.Value;
            panel1.Refresh();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            r = trackBar2.Value;
            panel1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboBox1.SelectedIndex;
            switch (idx)
            {
                case 0:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case 1:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
                case 2:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    break;
                case 3:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    break;
                case 4:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    break;
                    
            }
            panel1.Refresh();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!hold) return;
            x = e.Location.X;
            y = e.Location.Y;
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {           
            g.DrawEllipse(pen, x-r, y-r, r*a, r*b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rasterization
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        Point p1;
        Point p2;
        Button whichP;
        int pointSize = 4;

        public Form1()
        {
            InitializeComponent();
            comboBoxA.Enabled = false;
            comboBoxT.Enabled = false;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        private void drawLine()
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0, yy = 0;
            if (p1.X <= p2.X)
            {
                x1 = p1.X;
                x2 = p2.X;
                y1 = p1.Y;
                y2 = p2.Y;
            }
            else
            {
                x1 = p2.X;
                x2 = p1.X;
                y1 = p2.Y;
                y2 = p1.Y;
            }
            int dx = x2 - x1;
            int dy = y2 - y1;

            int d = 2 * dy - dx; // initial value of d
            int dE = 2 * dy; // increment used when moving to E
            int dNE = 2 * (dy - dx); // increment used when movint to NE
            int x = x1, y = y1;
            bmp.SetPixel(x, y, Color.Black);
            while (x < x2)
            {
                if (d < 0) // move to E
                {
                    d += dE;
                    x++;
                }
                else // move to NE
                {
                    d += dNE;
                    x++;
                    y++;
                }
                bmp.SetPixel(x, y, Color.Black);
            }
        }

        private void drawCircle()
        {
            int R = (int)Math.Sqrt((p1.X - p2.X)* (p1.X - p2.X) + (p1.Y - p2.Y)*(p1.Y - p2.Y));

            int d = 1 - R;
            int x = 0;
            int y = R;

            try { bmp.SetPixel(p1.X + R, p1.Y, Color.Black); } catch { }
            try { bmp.SetPixel(p1.X - R, p1.Y, Color.Black); } catch { }
            try { bmp.SetPixel(p1.X, p1.Y + R, Color.Black); } catch { }
            try { bmp.SetPixel(p1.X, p1.Y - R, Color.Black); } catch { }
            while (y > x)
            {
                if (d < 0)
                    d += 2 * x + 3;
                else
                {
                    d += 2 * x - 2 * y + 5;
                    --y;
                }
                ++x;

                try{ bmp.SetPixel(p1.X + x, p1.Y + y, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X + y, p1.Y + x, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X + y, p1.Y - x, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X + x, p1.Y - y, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X - x, p1.Y - y, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X - y, p1.Y - x, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X - y, p1.Y + x, Color.Black); } catch { }
                try{ bmp.SetPixel(p1.X - x, p1.Y + y, Color.Black); } catch { }
            }
        }

        private void drawThickLine(int thickness)
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            if (Math.Abs(p2.X - p1.X) >= Math.Abs(p2.Y - p1.Y))
            {
                if (p1.X <= p2.X)
                {
                    x1 = p1.X;
                    x2 = p2.X;
                    y1 = p1.Y;
                    y2 = p2.Y;
                }
                else
                {
                    x1 = p2.X;
                    x2 = p1.X;
                    y1 = p2.Y;
                    y2 = p1.Y;
                }

                float dy = y2 - y1;
                float dx = x2 - x1;
                float m = dy / dx;
                float y = y1;
                for (int x = x1; x <= x2; ++x)
                {
                    bmp.SetPixel(x, (int)y, Color.Black);
                    for (int i = 1; i <= thickness / 2; i++)
                    {
                        bmp.SetPixel(x, (int)y + i, Color.Black);
                        bmp.SetPixel(x, (int)y - i, Color.Black);
                    }
                    y += m;
                }
            }
            else
            {
                if (p1.Y <= p2.Y)
                {
                    x1 = p1.X;
                    x2 = p2.X;
                    y1 = p1.Y;
                    y2 = p2.Y;
                }
                else
                {
                    x1 = p2.X;
                    x2 = p1.X;
                    y1 = p2.Y;
                    y2 = p1.Y;
                }

                float dy = y2 - y1;
                float dx = x2 - x1;
                float m = dx / dy;
                float x = x1;
                for (int y = y1; y <= y2; ++y)
                {
                    bmp.SetPixel((int)x, y, Color.Black);
                    for (int i = 1; i <= thickness / 2; i++)
                    {
                        bmp.SetPixel((int)x + i, y, Color.Black);
                        bmp.SetPixel((int)x - i, y, Color.Black);
                    }
                    x += m;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = bmp;
        }

        public void SetPixel(SolidBrush brush, Graphics grp, int x, int y, Color color)
        {
            brush.Color = color;
            grp.FillRectangle(brush, x, y, 2, 2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (whichP == button1)
                {
                    grp.DrawEllipse(Pens.White, p1.X - pointSize / 2, p1.Y - pointSize / 2, pointSize, pointSize);
                    grp.FillEllipse(new SolidBrush(Color.White), p1.X - pointSize / 2, p1.Y - pointSize / 2, pointSize, pointSize);
                    p1 = new Point(e.X, e.Y);
                    grp.DrawEllipse(Pens.Red, p1.X - pointSize / 2, p1.Y - pointSize / 2, pointSize, pointSize);
                    grp.FillEllipse(new SolidBrush(Color.Red), p1.X - pointSize / 2, p1.Y - pointSize / 2, pointSize, pointSize);
                }
                else
                {
                    if (whichP == button2)
                    {
                        grp.DrawEllipse(Pens.White, p2.X - pointSize / 2, p2.Y - pointSize / 2, pointSize, pointSize);
                        grp.FillEllipse(new SolidBrush(Color.White), p2.X - pointSize / 2, p2.Y - pointSize / 2, pointSize, pointSize);
                        p2 = new Point(e.X, e.Y);
                        grp.DrawEllipse(Pens.Red, p2.X - pointSize / 2, p2.Y - pointSize / 2, pointSize, pointSize);
                        grp.FillEllipse(new SolidBrush(Color.Red), p2.X - pointSize / 2, p2.Y - pointSize / 2, pointSize, pointSize);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;

            p1 = new Point();
            p2 = new Point();
            whichP = null;
        }

        private void antiAlButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxA.Enabled = true;
            comboBoxT.Enabled = false;
        }

        private void tLineButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxA.Enabled = false;
            comboBoxT.Enabled = true;
        }

        private void CircleButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxA.Enabled = false;
            comboBoxT.Enabled = false;
        }

        private void LineButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxA.Enabled = false;
            comboBoxT.Enabled = false;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(LineButton.Checked)
            {
                drawLine();
            }
            if (CircleButton.Checked)
            {
                drawCircle();
            }
            if (antiAlButton.Checked)
            {
                
            }
            if (tLineButton.Checked)
            {
                drawThickLine(Int32.Parse(comboBoxT.Text));
            }

            p1 = new Point();
            p2 = new Point();
            whichP = null;

            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            whichP = button1;
            button1.BackColor = Color.HotPink;

            if (p2.IsEmpty) button2.BackColor = Color.Silver;
            else button2.BackColor = Color.PaleGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            whichP = button2;
            button2.BackColor = Color.HotPink;

            if (p1.IsEmpty) button1.BackColor = Color.Silver;
            else button1.BackColor = Color.PaleGreen;
        }
        
    }
}


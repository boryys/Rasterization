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

        private void drawLine(int thickness)
        {
            int x1 = p1.X, x2 = p2.X, y1 = p1.Y, y2 = p2.Y;

            int d, dx, dy, dE, dNE, xi, yi;
            int x = x1, y = y1;
            
            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }
            
            if (y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }
           
            bmp.SetPixel(x, y, Color.Black);

            if (dx > dy)
            {
                d = dy * 2 - dx;
                dE = dy * 2;
                dNE = (dy - dx) * 2;
                
                while (x != x2)
                {
                    if (d < 0)
                    {
                        d += dE;
                        x += xi;
                    }
                    else
                    {
                        d += dNE;
                        x += xi;
                        y += yi;
                    }
                    bmp.SetPixel(x, y, Color.Black);
                    for (int i = 1; i <= thickness / 2; i++)
                    {
                        bmp.SetPixel(x, y + i, Color.Black);
                        bmp.SetPixel(x, y - i, Color.Black);
                    }
                }
            }

            else
            {
                d = dx * 2 - dy;
                dE = dx * 2;
                dNE = (dx - dy) * 2;
                
                while (y != y2)
                {
                    if (d < 0)
                    {
                        d += dE;
                        y += yi;
                    }
                    else
                    {
                        d += dNE;
                        x += xi;
                        y += yi;
                    }
                    bmp.SetPixel(x, y, Color.Black);
                    for (int i = 1; i <= thickness / 2; i++)
                    {
                        bmp.SetPixel(x + i, y, Color.Black);
                        bmp.SetPixel(x - i, y, Color.Black);
                    }
                }
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

        double cov(double d, double r)
        {
            if (d <= r) return (0.5 - ((d * Math.Sqrt(r * r - d * d)) / (Math.PI * r * r)) - (1 / (Math.PI * Math.Asin(d / r))));
            else return 0;
        }

        double coverage(double thickness, double distance)
        {
            double c;

            if(thickness <= distance)
            {
                c = cov(distance - thickness/2, 0.5);
            }
            else
            {
                c = 1 - cov(distance - thickness/2, 0.5);
            }

            return c;
        }

        double IntensifyPixel(int x, int y, double thickness, double distance)
        {
            double cov = coverage(thickness, distance);
            if (cov > 0)
            {

                double c = cov * 255;
                if (c > 255) c = 255;
                if (c < 0) c = 0;
                bmp.SetPixel(x, y, Color.FromArgb((int)c, (int)c, (int)c));
            }
            return cov;
        }
        
        void ThickAntialiasedLine(float thickness)
        {
            int x1 = p1.X, x2 = p2.X, y1 = p1.Y, y2 = p2.Y;

            int d, dx, dy, dE, dNE, xi, yi;
            int x = x1, y = y1;

            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }

            if (y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }

            if(dx > dy)
            {
                d = dy * 2 - dx;
                dE = dy * 2;
                dNE = (dy - dx) * 2;

                int two_v_dx = 0;
                double invDenom = 1 / (2 * Math.Sqrt(dx * dx + dy * dy));
                double two_dx_invDenom = 2 * dx * invDenom;

                bmp.SetPixel(x, y, Color.Black);

                double c = IntensifyPixel(x, y, thickness, 0);
                for (int i = 1; IntensifyPixel(x, y + i, thickness, i * two_dx_invDenom) > 0; ++i) ;
                for (int i = 1; IntensifyPixel(x, y - i, thickness, i * two_dx_invDenom) > 0; ++i) ;

                while (x != x2)
                {
                    x += xi;
                    if (d < 0) 
                    {
                        two_v_dx = d + dx;
                        d += dE;
                    }
                    else
                    {
                        two_v_dx = d - dx;
                        d += dNE;
                        y += yi;
                    }

                    bmp.SetPixel(x, y, Color.Black);

                    IntensifyPixel(x, y, thickness, two_v_dx * invDenom);
                    for (int i = 1; IntensifyPixel(x, y + i, thickness, i * two_dx_invDenom - two_v_dx * invDenom) > 0; ++i) ;
                    for (int i = 1; IntensifyPixel(x, y - i, thickness, i * two_dx_invDenom + two_v_dx * invDenom) > 0; ++i) ;
                }
            }
            else
            {
                d = dx * 2 - dy;
                dE = dx * 2;
                dNE = (dx - dy) * 2;

                int two_v_dy = 0;
                double invDenom = 1 / (2 * Math.Sqrt(dx * dx + dy * dy));
                double two_dy_invDenom = 2 * dy * invDenom;

                bmp.SetPixel(x, y, Color.Black);

                double c = IntensifyPixel(x, y, thickness, 0);
                for (int i = 1; IntensifyPixel(x + i, y, thickness, i * two_dy_invDenom) > 0; ++i) ;
                for (int i = 1; IntensifyPixel(x - i, y, thickness, i * two_dy_invDenom) > 0; ++i) ;

                while (y != y2)
                {
                    y += yi;
                    if (d < 0)
                    {
                        two_v_dy = d + dy;
                        d += dE;
                    }
                    else
                    {
                        two_v_dy = d - dy;
                        d += dNE;
                        x += xi;
                    }

                    bmp.SetPixel(x, y, Color.Black);

                    IntensifyPixel(x, y, thickness, two_v_dy * invDenom);
                    for (int i = 1; IntensifyPixel(x + i, y, thickness, i * two_dy_invDenom - two_v_dy * invDenom) > 0; ++i) ;
                    for (int i = 1; IntensifyPixel(x - i, y, thickness, i * two_dy_invDenom + two_v_dy * invDenom) > 0; ++i) ;
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
                drawLine(1);
            }
            if (CircleButton.Checked)
            {
                drawCircle();
            }
            if (antiAlButton.Checked)
            {
                ThickAntialiasedLine(Int32.Parse(comboBoxA.Text));
            }
            if (tLineButton.Checked)
            {
                drawLine(Int32.Parse(comboBoxT.Text));
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


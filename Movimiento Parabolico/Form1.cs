using System;
using System.Windows.Forms;

namespace Movimiento_Parabolico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double x;
        double y;
        double g;
        double vx;
        double vy;
        double x0;
        double y0;
        double t = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            do
            {
                x = x0 + vx * t;
                y = y0 + vy * t - 0.5 * g * t * t;
                double vy_t = vy - g * t;

                if (y < 0)
                {
                    timer1.Stop();
                    break;
                }

                dataGridView1.Rows.Add(t.ToString("0.00"), x.ToString("0.00"), y.ToString("0.00"), vx.ToString("0.00"), vy_t.ToString("0.00"));
                chart1.Series[0].Points.AddXY(x, y);
                chart1.Series[1].Points.AddXY(x, y);

                t += 0.1;
            }
            while (true);

        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            double v0 = double.Parse(textv0.Text);
            double theta = double.Parse(texttheta.Text) * Math.PI / 180; 
            x = double.Parse(textx0.Text);
            y = double.Parse(texty0.Text);
            g = double.Parse(textg.Text.Replace('.',','));
            
            vx = v0 * Math.Cos(theta);
            vy = v0 * Math.Sin(theta);
            x0 = x;
            y0 = y;

            dataGridView1.Rows.Clear();

            dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            timer1.Enabled = true;
        }

    }
}


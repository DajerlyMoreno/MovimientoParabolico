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

        private void btnSimular_Click(object sender, EventArgs e)
        {
            double v0 = double.Parse(textv0.Text);
            double theta = double.Parse(texttheta.Text) * Math.PI / 180; 
            double x = double.Parse(textx0.Text);
            double y = double.Parse(texty0.Text);
            double g = double.Parse(textg.Text.Replace('.',','));
            
            double t = 0;
            double vx = v0 * Math.Cos(theta);
            double vy = v0 * Math.Sin(theta);
            double x0 = x;
            double y0 = y;

            dataGridView1.Rows.Clear();
            chart1.Series.Clear();

            dataGridView1.Rows.Clear();
            //chart1.Series["Trayectoria"].Points.Clear();
            //chart1.Series[1].Points.Clear();

            do
            {
                x = x0 + vx * t;
                y = y0 + vy * t - 0.5 * g * t * t;
                double vy_t = vy - g * t;

                if (y < 0)
                {

                    break;
                }

                dataGridView1.Rows.Add(t.ToString("0.00"), x.ToString("0.00"), y.ToString("0.00"), vx.ToString("0.00"), vy_t.ToString("0.00"));
                //chart1.Series["Trayectoria"].Points.AddXY(x, y);
                //chart1.Series["Series2"].Points.AddXY(x, y);

                t += 0.1;
            }
            while (true);
        }
    }
}


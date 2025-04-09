using System;
using System.Drawing;
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

        //Variables para la animación
        int altura;
        double escala = 10;
        int offsetY = 20;

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = x0 + vx * t;
            y = y0 + vy * t - 0.5 * g * t * t;
            double vy_t = vy - g * t;

            if (y < 0)
            {
                timer1.Stop();

                textTV.Text = "";
                textAlturaMax.Text = "";
                textDesplazamiento.Text = "";

                resultados();

                return;
            }

            dataGridView1.Rows.Add(t.ToString("0.00"), x.ToString("0.00"), y.ToString("0.00"), vx.ToString("0.00"), vy_t.ToString("0.00"));

            chart1.Series[0].Points.AddXY(x, y);


            //Animacion del movimiento
            int xPixel = Convert.ToInt32(x * 18);
            int yPixel = Math.Min(altura - Convert.ToInt32(y * escala) - offsetY, areaSimulacion.Height - masa.Height);

            if (xPixel >= 0 && xPixel <= areaSimulacion.Width - masa.Width && yPixel >= 0 && yPixel <= areaSimulacion.Height - masa.Height)
            {
                masa.Location = new Point(xPixel, yPixel);
            }

            t += 0.1;
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

            t = 0;

            altura = areaSimulacion.Height;

            dataGridView1.Rows.Clear();

            dataGridView1.Rows.Clear();
            chart1.Series[0].Points.Clear();

            areaSimulacion.Controls.Add(masa);

            masa.Location = new Point(Convert.ToInt32(x0 * escala), Math.Min(altura - Convert.ToInt32(y0 * escala) - offsetY, areaSimulacion.Height - masa.Height));

            timer1.Enabled = true;

        }

        private void resultados()
        {
            double alturaMaxima = double.MinValue;
            double desplazamientoHorizontal = 0;
            string tiempoVuelo = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow fila = dataGridView1.Rows[i];

                if (fila.IsNewRow || fila.Cells[0].Value == null || fila.Cells[1].Value == null || fila.Cells[2].Value == null)
                    continue;

                double xVal = Convert.ToDouble(fila.Cells[1].Value);
                double yVal = Convert.ToDouble(fila.Cells[2].Value);

                if (yVal > alturaMaxima)
                    alturaMaxima = yVal;

                desplazamientoHorizontal = xVal;
                tiempoVuelo = fila.Cells[0].Value.ToString();
            }

            textTV.Text = tiempoVuelo + " s";
            textAlturaMax.Text = alturaMaxima.ToString("0.00") + " m";
            textDesplazamiento.Text = desplazamientoHorizontal.ToString("0.00") + " m";
        }
    }
}


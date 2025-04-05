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
            // Obtener valores desde los cuadros de texto
            double v0 = double.Parse(textv0.Text);
            double theta = double.Parse(texttheta.Text) * Math.PI / 180; // Convertir a radianes
            double x = double.Parse(textx0.Text);
            double y = double.Parse(texty0.Text);
            double g = double.Parse(textg.Text);
            double dt = 1;

            // Inicializar variables
            double t = 0;
            double vx = v0 * Math.Cos(theta);
            double vy = v0 * Math.Sin(theta);
            double x0 = x;
            double y0 = y;

            // Limpiar tabla y gráfica
            dataGridView1.Rows.Clear();
            chart1.Series.Clear();
            chart1.Series.Add("Trayectoria");
            chart1.Series["Trayectoria"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Bucle de simulación
            dataGridView1.Rows.Clear();
            chart1.Series["Trayectoria"].Points.Clear();
            do
            {
                

                x = x0 + vx * t;
                y = y0 + vy * t - 0.5 * g * t * t;
                double vy_t = vy - g * t;

                if (y < 0) break; // cuando toca el suelo, terminar

                dataGridView1.Rows.Add(t, x, y, vx, vy_t);
                chart1.Series["Trayectoria"].Points.AddXY(x, y);

                t += 1;
            }
            while (true);
        }
        // Permitir actualización de la UI
    }
}


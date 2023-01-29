using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Построение_графиков_и_диаграмм
{
    public class Brower
    {
        private String name;// поля класса
        private Int16 count;
        private Double square;
        private Double density;

        public Brower(String name, Int16 count, Double square) // конструктор
        {
            this.name = name;
            this.count = count;
            this.square = square;
            this.density = 0.0;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int16 Count
        {
            get { return count; }
            set { count = value; }
        }
        public Double Square
        {
            get { return square; }
            set { square = value; }
        }
        public Double Density
        {
            get { return density; }
        }

        public static void Alldensity(Brower[] Z)
        {
            try
            {
                for (int i = 0; i < Z.Length; i++)
                {
                    Z[i].density = Z[i].count / Z[i].square;
                }
            }
            catch
            {
                throw new Exception("Массив не инициализирован.");
            }

        }

        public static void Show(Brower[] Z, DataGridView dgv, Chart chart)
        {
            dgv.ColumnCount = 4;
            dgv.RowCount = Z.Length;
            dgv.Columns[0].Name = "Название";
            dgv.Columns[1].Name = "Площадь";
            dgv.Columns[2].Name = "Население";
            dgv.Columns[2].Name = "Плотность";
            Alldensity(Z);
            for (int i = 0; i < Z.Length; i++)
            {
                dgv.Rows[i].Cells[0].Value = Z[i].name;
                dgv.Rows[i].Cells[1].Value = Z[i].count;
                dgv.Rows[i].Cells[2].Value = Z[i].square;
                dgv.Rows[i].Cells[3].Value = Z[i].density;
                if (Z[i].density!=double.NaN)
                {
                    //chart.Series.Clear();
                    chart.BackColor = Color.Gray;
                    chart.BackSecondaryColor = Color.WhiteSmoke;
                    chart.BackGradientStyle = GradientStyle.DiagonalRight;
                    chart.BorderlineDashStyle = ChartDashStyle.Solid;
                    chart.BorderlineColor = Color.Gray;
                    chart.BorderSkin.SkinStyle = BorderSkinStyle.None;

                    // Форматировать область диаграммы.
                    chart.ChartAreas[0].BackColor = Color.White;
                    chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                    
                    

                    chart.Series["Плотность"].Points.AddXY(Z[i].name, Z[i].density);
                    
                    chart.AlignDataPointsByAxisLabel();
                    chart.ChartAreas[0].AxisX.Interval = 1;
                    
                }
                
            }
            
        }
    }

}

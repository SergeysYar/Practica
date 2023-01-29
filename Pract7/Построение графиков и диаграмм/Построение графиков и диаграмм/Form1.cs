using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Построение_графиков_и_диаграмм
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
        Brower[] arrBrower = new Brower[18];
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (true)
            {
                if (arrBrower[i].Name==comboBox1.Text)
                {
                    arrBrower[i].Count = short.Parse(textBox2.Text);
                    arrBrower[i].Square = Convert.ToDouble(textBox1.Text);
                    break;
                }
                i++;
            }
            Brower.Show(arrBrower,dataGridView1,chart1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //chart1.Series["Плотность"].Points.AddXY(0, 0);
            string[] Text = new[] { "Адмиралтейский", "Василеостровский", 
                "Выборгский","Калининский","Кировский","Колпинский",
                "Красногвардейский","Красносельский","Кронштадтский",
                "Курортный","Московский","Невский","Петроградский",
                "Петродворцовый","Приморский","Пушкинский","Фрунзенский","Центральный" };
            for (int i = 0; i < arrBrower.Length; i++)
            {
                //arrBrower[i].Name = Text[i];
                arrBrower[i] = new Brower(Text[i], 0, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)//сохранить
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            SaveToFile(arrBrower, filename);
        }

        private void button3_Click(object sender, EventArgs e)//загрузить
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;
            OpenToFile(filename,dataGridView1,chart1);
        }
        public static void SaveToFile( Brower[] Z, string File_Name)
        {
            try
            {
                StreamWriter sw = new StreamWriter(File_Name, false, Encoding.GetEncoding(1251));
                sw.WriteLine("Санкт-Петербург");
                sw.WriteLine(Z.Length);
                for (int i = 0; i < Z.Length; i++)
                {
                    sw.WriteLine(Z[i].Name);
                    sw.WriteLine(Z[i].Square);
                    sw.WriteLine(Z[i].Count);
                    sw.WriteLine(Z[i].Density);
                }
                sw.Close();
            }
            catch
            {
                throw new Exception("Ошибка доступа к файлу.");
            }
        }
        public static void OpenToFile( string File_Name, DataGridView dgv, Chart chart)
        {
            try
            {
                var fs = new FileStream(File_Name, FileMode.Open);
                var sr = new StreamReader(fs, System.Text.Encoding.Default);
                string s = null;
                s = sr.ReadToEnd();
                string[] arr = s.Split('\n');
                Brower[] arrBrower = new Brower[18];
                int j = 0;
                for (int i = 2; i < arr.Length-1; i+=4)
                {
                    arrBrower[j] = new Brower(arr[i], short.Parse(arr[i+1]), Convert.ToDouble(arr[i + 2]));
                    j++;
                }
                fs.Close();
                sr.Close();
                Brower.Show(arrBrower, dgv, chart);
                
            }
            catch
            {
                throw new Exception("Ошибка доступа к файлу.");
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //chart1.Series["Плотность"].Points.AddXY(0, 0);
        }
    }
}

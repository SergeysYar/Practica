using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Обработка_двумерного_массива
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int nH = Convert.ToInt32(numericUpDown1.Value);
            int nW = Convert.ToInt32(numericUpDown2.Value);
            for (int i = 0; i < nH; i++)
            {
                dataGridView1.Columns.Add("Column1", i.ToString());
                for (int j = 0; j < nW; j++)
                {
                    if (i==0)
                    {
                        dataGridView1.Rows.Add();
                    }
                    if (radioButton1.Checked)
                    {
                        dataGridView1[i,j].Value = 0;
                    }
                    else
                    if (radioButton2.Checked)
                    {
                        dataGridView1[i,j].Value = rnd.Next(-5, 5);
                    }
                }
            }
        }
        /// <summary>
        /// Кнопка "Вывести"- заполнение массивов.
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.ColumnCount;
            int m = dataGridView1.RowCount;
            int[,] A = new int[n, m];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        A[i,j] = Convert.ToInt32(dataGridView1[i, j].Value);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            try
            {
                string result = NullCounter.TextResult(A);
                label3.Text = "Наименьшее количество нулей: \n" + result;
                string[] arr = result.Split();
                for (int i = 0; i < arr.Length; i++)
                {
                    dataGridView1.Columns[Convert.ToInt32(arr[i])].DefaultCellStyle.BackColor = Color.Yellow;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        /// <summary>
        /// Кнопка "Вычислить"- запускает метод подсчёта и вывода столбца с меньшим количеством нулей
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Обработка_одномерных_массивов
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод обработки события загрузки формы.
        /// </summary>
        /// <param name="sender">указатель на форму</param>
        /// <param name="e">доп.аргумент</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //int n = Convert.ToInt32(numericUpDown1.Value);
            //for (int i = 0; i < n; i++)
            //{
            //    dataGridView1.Columns[i].Name = i.ToString();
            //    if (radioButton1.Checked)
            //        dataGridView1.Rows[0].Cells[i].Value = 0;
            //    else
            //        dataGridView1.Rows[0].Cells[i].Value = rnd.Next(-100, 100);

            //}
        }
        /// <summary>
        /// Кнопка "Вычислить"- запускает метод вычисления среднего значения положительных элементов.
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.ColumnCount;
            int[] A = new int[n]; // Выделение памяти под массив.
           
            try
            {
                for (int i = 0; i < n; i++)
                {
                    A[i] = Convert.ToInt32(dataGridView1[0,i].Value);
                    // Значения из таблицы помещаем в массив.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                int[] arr = MyArray.BalancedArray(A);
                for (int i = 0; i < arr.Length; i++)
                {
                    dataGridView1.Columns.Add("Column1", i.ToString());
                    dataGridView1.Rows[0].Cells[i].Value = arr[i];
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Кнопка "Вычислить"- запускает метод вычисления среднего значения положительных элементов.
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            for (int i = 0; i < n; i++)
            {
                
                if (radioButton1.Checked)
                {
                    dataGridView1.Columns.Add("Column1", i.ToString());
                    dataGridView1.Rows[0].Cells[i].Value = 0; 
                }    
                   
                else
                if(radioButton2.Checked)
                {
                    dataGridView1.Columns.Add("Column1", i.ToString());
                    dataGridView1[0,i].Value = rnd.Next(-100, 100);
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

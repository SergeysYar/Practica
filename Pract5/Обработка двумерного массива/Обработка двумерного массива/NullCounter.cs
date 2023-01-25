using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обработка_двумерного_массива
{
    public class NullCounter
    {
        /// <summary>
        /// Метод вычисляет столбец с минимальным количеством нулей 
        /// </summary>
        /// <param name="arr">Исходный двумерный массив</param>
        /// <returns>Возвращает строку со значениями</returns>
        public static string TextResult(int[,] arr)
        {
            string result="";
            int buffer = int.MaxValue;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int nullCount = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j]==0)
                    {
                        nullCount++;
                    }
                    
                }
                if (nullCount < buffer)
                {
                    buffer = nullCount;
                    result = Convert.ToString(i) + " ";
                }
                else
                if (nullCount == buffer)
                {
                    buffer = nullCount;
                    result += Convert.ToString(i) + " ";
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обработка_одномерных_массивов
{
    public class MyArray
    {
        /// <summary>
        /// Метод вычисляет количество четных и количество нечетных по значениям элементов массива
        /// </summary>
        /// <param name="arr">Исходный одномерный массив</param>
        /// <returns>Возвращает дополненный массив</returns>
        public static int[] BalancedArray(int[] arr)
        {
            int even,odd;
            even = 0;
            odd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }
            int count;
            if (even > odd)
            {
                count = even - odd;
                int[] arrNew = new int[arr.Length + count];
                for (int i = 0; i < arrNew.Length; i++)
                {
                    if (i < count)
                    {
                        arrNew[i] = 1;
                    }
                    else
                    {
                        arrNew[i] = arr[i - count];
                    }
                }
                return arrNew;
            }
            else
                if (even < odd)
            {
                count = odd - even;
                int[] arrNew = new int[arr.Length + count];
                for (int i = 0; i < arrNew.Length; i++)
                {
                    if (i < count)
                    {
                        arrNew[i] = 2;
                    }
                    else
                    {
                        arrNew[i] = arr[i - count];
                    }
                }
                return arrNew;
            }
            else
            {
                return arr;
            }

        }
    }
}

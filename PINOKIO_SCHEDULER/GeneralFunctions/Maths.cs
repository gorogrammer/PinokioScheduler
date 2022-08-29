using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINOKIO_SCHEDULER.GeneralFunctions
{
    class Maths
    {
        public static float Average(int[] array, float count)
        {
            int sum = 0;
            float average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != Int32.MaxValue)
                {
                    sum = sum + array[i];
                }
                else
                {
                    count--;
                }


            }
            average = sum / count;
            return average;
        }
        public static int MinIndex(int[] array)
        {
            int min = array[0];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }

            }
            return index;
        }
        public static int Near(int[] array, double p)
        {
            double tmp = 0f;
            double min = Int32.MaxValue;
            double near = 0f;
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
               
                if (Abs(array[i] - p) < min)
                {
                    min = Abs(array[i] - p); //최소값 알고리즘
                    near = array[i]; //최종적으로 가까운 값
                    index = i;
                }

            }
            //Debug.Log ("Near: " + near.ToString ());
            return index;
        }

        public static double Abs(double p)
        {
            return (p < 0) ? -p : p;
        }
    }

}

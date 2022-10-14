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
        public static int MaxQuant(Dictionary<int, int> dic)
        {
            int max = 0;
            foreach (KeyValuePair<int, int> pair in dic)
            {
                if (max < pair.Value)
                    max = pair.Value;
            }

            return max;
        }

        public static int MinQuant(Dictionary<int, int> dic)
        {
            int max = 0;
            foreach (KeyValuePair<int, int> pair in dic)
            {
                if (max < pair.Value)
                    max = pair.Value;
            }

            return max;
        }
        public static int Normal_Random(int seed, double mean, double std)
        {
            Random sd = new Random();
            sd.Next(1, 3000);

            Random rand = new Random((Guid.NewGuid().GetHashCode() * sd.Next() * (int)DateTime.Now.Millisecond + seed) % (seed + sd.Next())); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            if (randStdNormal < 0)
                randStdNormal = randStdNormal * -1;

            double randNormal =
                         mean + std * randStdNormal; //random normal(mean,stdDev^2)


            return Convert.ToInt32(randNormal);
        }
        public static double RandomDue(int seed, int max, double tight, int min, int maxProcess, int A)
        {
            Random sds = new Random();
            sds.Next(1, 3000);
            double value = 0;
            Random sd = new Random((Guid.NewGuid().GetHashCode() * sds.Next() * (int)DateTime.Now.Millisecond + seed) % (seed + sds.Next()));
            value = Convert.ToInt32(sd.Next(0, A)) * tight;

            return value + min;
        }
    }

}

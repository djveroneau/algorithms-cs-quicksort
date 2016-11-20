using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = {11, 14, 2, 33, 9, 24, 7, 17, 21, 10, 4, 28};
            int[] sortedData = null;

            sortedData = QuickSortFcn(data);
            foreach( int n in sortedData )
                Console.WriteLine(n);
            Console.ReadKey();
        }

        static int[] QuickSortFcn(int[] data)
        {
            int pivotIndex = data.Length / 2;
            int pivotValue = data[pivotIndex];

            if (data.Length == 1)
                return data;

            // Put the pivot all the way on the left.
            data = Swap(data, pivotIndex, 0);
            pivotIndex = 0;

            int i = 1;
            int j = (data.Length - 1);

            while (true)
            {
                while (data[i] <= pivotValue && i < (data.Length-1))
                {
                    i++;
                    continue;
                }

                while (data[j] >= pivotValue && j > 1)
                {
                    j--;
                    continue;
                }

                if (i < j)
                    data = Swap(data, i, j);
                else
                {
                    data = Swap(data, pivotIndex, j);
                    pivotIndex = j;
                    break;
                }
            }

            if (data.Length > 3)
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();

                for (int n = 0; n < pivotIndex; n++)
                    left.Add(data[n]);
                for (int m = (data.Length - 1); m > pivotIndex; m--)
                    right.Add(data[m]);

                left = QuickSortFcn(left);
                right = QuickSortFcn(right);

                left.Add(pivotValue);
                data = left.Union(right).ToArray();
            }

            return data;
        }

        // Helper function to handle lists.
        static List<int> QuickSortFcn(List<int> data)
        {
            int[] arrayData = data.ToArray();

            arrayData = QuickSortFcn(arrayData);

            data = arrayData.ToList<int>();

            return data;
        }

        static int[] Swap(int[] array, int curPos, int newPos)
        {
            int temp = array[newPos];

            array[newPos] = array[curPos];
            array[curPos] = temp;

            return array;
        }
    }


}

using System;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            DList<int> x = new DList<int>(1);
            x.Add(x.Size - 1, 4);
            x.Add(x.Size - 1, 8);
            x.Add(x.Size - 1, 1);
            x.Add(x.Size - 1, 7);
            x.Add(x.Size - 1, 3);
            x.Add(x.Size - 1, 6);
            x.Add(x.Size - 1, 7);
            x.Add(x.Size - 1, 5);
            x.Add(x.Size - 1, 4);
            x.Add(x.Size - 1, 3);
            x.Add(x.Size - 1, 1);
            x.Add(x.Size - 1, 3);
            x.Add(x.Size - 1, 3);
            x.Add(x.Size - 1, 2);
            x.Add(x.Size - 1, 7);
            x.Add(x.Size - 1, 3);
            x.Add(x.Size - 1, 4);
            x.Add(x.Size - 1, 7);


            using (StreamWriter Write = new StreamWriter("QuickSort.txt"))
            {
                Write.WriteLine('\n');
                Write.WriteLine("Before QuickSort and DelDouble - \n");
                for (int i = 0; i < x.Size; i++)
                {
                    Write.Write($"{x[i]}   ");
                }

                Write.WriteLine('\n');
                Write.WriteLine("After QuickSort - \n");
                QuickSort(x, 0, x.Size - 1);

                for (int i = 0; i < x.Size; i++)
                {
                    Write.Write($"{x[i]}   ");
                }

                Write.WriteLine('\n');
                Write.WriteLine("After DelDouble - \n");
                DelDouble(ref x);

                for (int i = 0; i < x.Size; i++)
                {
                    Write.Write($"{x[i]}   ");
                }
            }

            Console.ReadKey();
        }


        /// <summary>
        /// Удаление дубликатов в списке list.
        /// </summary>
        static void DelDouble(ref DList<int> list)
        {
            int item, index;

            for (int i = 0; i < list.Size; i++)
            {
                item = list[i];
                for (int j = i + 1; j < list.Size; j++)
                {
                    index = j;
                    while (true)
                        if (item == list[index])
                        {
                            list.Del(j);
                            if (index == list.Size) break;
                        }
                        else break;
                }
            }

        }

        /// <summary>
        /// Быстрая сортировка связного списка.
        /// </summary>
        static void QuickSort(DList<int> list, int low, int high)
        {
            void Swap(int index1, int index2)
            {
                int t = list[index1];
                list[index1] = list[index2];
                list[index2] = t;
            }

            if (high - low <= 0) return;
            else if(high - low == 1)
            {
                if (list[high] < list[low]) Swap(high, low);
                return;
            }

            int up, down;
            int middle = (high + low) / 2;
            int center = list[middle];
            Swap(middle, low);
            up = low + 1;
            down = high;

            do
            {
                while (up <= down && list[up] <= center) up++;

                while (list[down] > center) down--;

                if (up < down) Swap(up, down);
            }
            while (up < down);

            list[low] = list[down];
            list[down] = center;
            

            if (low < down - 1) QuickSort(list, low, down - 1);

            if (down + 1 < high) QuickSort(list, down + 1, high);
        }
    }
}

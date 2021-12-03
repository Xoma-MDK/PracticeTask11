using System;

namespace PracticeTask11
{
    internal class Program
    {
        //Быстрая сортировка
        static void quickSort(int[] numbers, int left, int right)
        {
            int pivot; // разрешающий элемент
            int l_hold = left; //левая граница
            int r_hold = right; // правая граница
            pivot = numbers[left];
            while (left < right) // пока границы не сомкнутся
            {
                while ((numbers[right] >= pivot) && (left < right))
                    right--; // сдвигаем правую границу пока элемент [right] больше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[left] = numbers[right]; // перемещаем элемент [right] на место разрешающего
                    left++; // сдвигаем левую границу вправо
                }
                while ((numbers[left] <= pivot) && (left < right))
                    left++; // сдвигаем левую границу пока элемент [left] меньше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[right] = numbers[left]; // перемещаем элемент [left] на место [right]
                    right--; // сдвигаем правую границу вправо
                }
            }
            numbers[left] = pivot; // ставим разрешающий элемент на место
            pivot = left;
            left = l_hold;
            right = r_hold;
            if (left < pivot) // Рекурсивно вызываем сортировку для левой и правой части массива
                quickSort(numbers, left, pivot - 1);
            if (right > pivot)
                quickSort(numbers, pivot + 1, right);
        }
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка вставками
        static int[] insertionSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Введите количество элементов: ");
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(-999,999);
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Начинаю быструю сортировку...");
            DateTime start = DateTime.Now;
            quickSort(array, 0, N-1);
            TimeSpan timeTaken = DateTime.Now - start;
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < N; i++)
            {
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Затраченное время на сортировку в милисекундах = " + timeTaken.Milliseconds);
            Console.WriteLine("Генерирую новый массив...");
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(-999, 999);
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Начинаю сортировку методом вставки...");
            DateTime start2 = DateTime.Now;
            array = insertionSort(array);
            TimeSpan timeTaken2 = DateTime.Now - start2;
            Console.WriteLine("Массив после сортировки");
            for (int i = 0; i < N; i++)
            {
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Затраченное время на сортировку в милисекундах = " + timeTaken2.Milliseconds);

        }
    }
}

using System;

namespace PracticeTask11
{
    internal class Program
    {
        //Быстрая сортировка
        private static int[] quickSort(int[] array, int minIndex, int maxIndex)
        {
            //если индексы схлопнулись, то возвращаем массив
            if (minIndex >= maxIndex)
            {
                return array;
            }
            //выбираем индекс разрешающего элемента
            int pivotIndex = getPivotIndex(array, minIndex, maxIndex);
            //вызываем рекурсию сортировки левой части массива до пивота
            quickSort(array, minIndex, pivotIndex - 1);
            //вызываем рекурсию сортировки правой части массива от пивота
            quickSort(array, pivotIndex + 1, maxIndex);
            //возвращаем массив
            return array;
        }

        private static int getPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            //изначально объявляем индекс пивота
            int pivot = minIndex - 1;
            //перебераем индексы массива
            for (int i = minIndex; i <= maxIndex; i++)
            {
                //если элемент меньше последнего элемента, то увеличиваем пивот и меняем местами элемент под номером пивота и элемент цикла
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            //увеличиваем пивот
            pivot++;
            //меняем элемент пивота с последним
            Swap(ref array[pivot], ref array[maxIndex]);
            //возвращаем пивот
            return pivot;
        }
        //метод обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //метод сортировки вставками
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
        //метод бинарного поиска
        static int binarySearch(int[] array, int searchedValue, int left, int right)
        {
            //пока не сошлись границы массива
            while (left <= right)
            {
                //индекс среднего элемента
                var middle = (left + right) / 2;
                if (searchedValue == array[middle])
                {
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    //сужаем рабочую зону массива с правой стороны
                    right = middle - 1;
                }
                else
                {
                    //сужаем рабочую зону массива с левой стороны
                    left = middle + 1;
                }
            }
            //ничего не нашли
            return -1;
        }
        static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
        }
        static int[] deleteInArray(int[] array, int indexToDeleteStart, int indexToDeleteStop)
        {
            //объявляем новый массив
            var output = new int[array.Length - (indexToDeleteStop - indexToDeleteStart)];
            //объявляем счетчик
            int counter = 0;
            //перебераем исходный массив
            for (int i = 0; i < array.Length; i++)
            {
                //если индекс массива попал в диапозон удаления пропускаем шаг цикла
                if (i >= indexToDeleteStart && i <= indexToDeleteStop) continue;
                //записываем в новый массив элемент из старого
                output[counter] = array[i];
                //прибавляем 1 к счетчику
                counter++;
            }
            //возвращаем урезанныц массив
            return output;
        }
            static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Введите количество элементов: ");
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-999,999);
                Console.Write($" {array[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Начинаю быструю сортировку...");
            DateTime start = DateTime.Now;
            array = quickSort(array, 0, array.Length - 1);
            TimeSpan timeTaken = DateTime.Now - start;
            Console.WriteLine("Массив после сортировки");
            printArray(array);
            Console.WriteLine("Затраченное время на сортировку в милисекундах = " + timeTaken.Milliseconds);
            Console.WriteLine("Генерирую новый массив...");
            for (int i = 0; i < array.Length; i++)
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
            printArray(array);
            Console.WriteLine("Затраченное время на сортировку в милисекундах = " + timeTaken2.Milliseconds);
            Console.Write("Введите индекс начала удаления: ");
            int startDeleteIndex = int.Parse(Console.ReadLine());
            Console.Write("Введите количество удаляемых элементов: ");
            int count = int.Parse(Console.ReadLine());
            array = deleteInArray(array, startDeleteIndex, startDeleteIndex + count);
            printArray(array);
            Console.Write("Введите запрашиваемый элемент: ");
            int requiredElement = int.Parse(Console.ReadLine());
            int resultOfSearch = binarySearch(array,requiredElement, 0, array.Length - 1);
            if(resultOfSearch == -1)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент {requiredElement} найден под индексом {resultOfSearch}");
            }
        }
    }
}
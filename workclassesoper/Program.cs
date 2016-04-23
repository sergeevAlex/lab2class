using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace classString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);
            Console.WriteLine("Задайте левую границу первого массива");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Задайте правую границу первого массива");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Задайте левую границу второго массива");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Задайте правую границу второго массива");
            int d = int.Parse(Console.ReadLine());
            
            MyArray arr = new MyArray(a, b);
            MyArray arr2 = new MyArray(c, d);

            for (int i = arr.FirstIndex; i < arr.LastElemPos; i++)
            {
                arr[i] = "строка массива " + i;
            }
            for (int i = arr2.FirstIndex; i < arr2.LastElemPos; i++)
            {
                arr2[i] = "строка массива " + i;
            }
            Console.WriteLine("Все элементы первого массива");
            for (int i = arr.FirstIndex; i < arr.LastElemPos; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine();
            Console.WriteLine("Все элементы второго массива");
            for (int i = arr2.FirstIndex; i < arr2.LastElemPos; i++)
            {
                Console.WriteLine(arr2[i]);
            }


            Console.WriteLine();

            MyArray concatArr = MyArray.Concat(arr, arr2);
            Console.WriteLine("Объединенный массив");

            for (int i = concatArr.FirstIndex; i < concatArr.LastElemPos; i++)
            {
                Console.WriteLine(concatArr[i]);
            }
            Console.WriteLine();

            MyArray MergeArr = MyArray.Merge(arr, arr2);

            Console.WriteLine("объединенный массив с уникальными элементами");

            for (int i = MergeArr.FirstIndex; i < MergeArr.LastElemPos; i++)
            {
                Console.WriteLine(MergeArr[i]);
            }
            
            Console.WriteLine();
            Console.WriteLine("Введите индекс строки первого массива к которой вы хотите обратиться: ");
            int ind = int.Parse(Console.ReadLine());
            Console.WriteLine("Строка: {0}", arr[ind]);  //обращение к строке массива
            Console.WriteLine();



            // **границы задавать + по индексу обращение

            Console.ReadLine();

        }
    }
}
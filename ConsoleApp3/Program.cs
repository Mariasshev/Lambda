using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    delegate int[] Multiples(int[] arr);
    class MyArr
    {
        private int[] arr;
        public int[] GetArr() { return arr; }

        public MyArr() { 
            arr = new int[10]; 

            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-5, 10);
            }
        }
        public MyArr(int len)
        {
            arr = new int[len];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-5, 10);
            }
        }

        public void ShowArr()
        {
            Console.WriteLine("Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(" ");
        }

        public static void Main(string[] args)
        {
            MyArr myArr = new MyArr(10);
            myArr.ShowArr();

            Console.WriteLine("Числа кратные 7 (количество): " + myArr.GetArr().Where(num => num % 7 == 0).Count());
            Console.WriteLine("Положительные числа (количество): " + myArr.GetArr().Where(num => num > 0).Count());
            Console.WriteLine("Уникальные отрицательные числа: " + string.Join(", ", myArr.GetArr().Where(num => num < 0)));


        }

    }
}

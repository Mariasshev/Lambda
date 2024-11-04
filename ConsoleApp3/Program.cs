using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
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
        
        public static string[] SplitIntoWords(string text)
        {
            int count = 0;
            for(int i = 0; i <  text.Length; i++)
            {
                if(text[i] == ' ' || text[i] == '!' || text[i] == ',' || text[i] == '.')
                {
                    count++;
                }
            }
            string[] words = new string[count];
            int count2 = 0;
            string current = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || text[i] == '!' || text[i] == ',' || text[i] == '.')
                {
                    words[count2] = current.ToLower();
                    current = "";
                    count2++;
                }
                else
                {
                    current += text[i];
                }
            }
            return words;
        }
        public static void Main(string[] args)
        {
            MyArr myArr = new MyArr(10);
            myArr.ShowArr();

            Console.WriteLine("Числа кратные 7 (количество): " + myArr.GetArr().Where(num => num % 7 == 0).Count());
            Console.WriteLine("Положительные числа (количество): " + myArr.GetArr().Where(num => num > 0).Count());

            var uniqueNegativeNumbers = myArr.GetArr()
                .Where(num => num < 0)               
                .GroupBy(num => num)                
                .Where(group => group.Count() == 1)  
                .Select(group => group.Key);        

            Console.WriteLine("Уникальные отрицательные числа: " + string.Join(", ", uniqueNegativeNumbers));

            string text = "Hello World! So happy to see all of you!";
            string[] words = SplitIntoWords(text);
            Console.WriteLine("Слова в строке:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            string needWord = "To";

            bool result = words.Any(word => needWord.ToLower() == word);
            Console.WriteLine("Поиск слова " + needWord + ": " + result);

        }

    }
}

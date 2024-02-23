using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestMonitoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int counter = 0;

                Console.WriteLine("Введите следующие данные, подвердите ввод данных клавишей enter:\n1) Полный путь для считывания файла\n2) Путь для выходного файла\n\nНапример: C:\\EXPORT\\pl_cards_4.txt");
                string path = Console.ReadLine();
                string path1 = Console.ReadLine();

                Console.WriteLine("Начало обработки. При завершении программа закроется автоматически.");

                counter = iteration(path, path1);

                while (counter > 0)
                {
                    counter = iteration(path1, path1);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Обнаружена ошибка {e}. Если у вас есть вопросы, сделайте скриншот этого окна, проверьте данные, подающиеся на вход программы и обратитесь в ОСПОРБ. ");
            }
        }

        static int iteration (string path, string path1, int counter = 0)
        {
            IEnumerable<string> text = File.ReadLines(path, Encoding.GetEncoding(1251));
            List<string> output = new List<string>();
            string strOutput = "";


            foreach (string str in text)
            {
                int num = str.Split(';').Length;
                if (num > 14)
                {
                    int index = str.LastIndexOf(';') - 1;

                    StringBuilder sb = new StringBuilder(str);
                    sb[str.LastIndexOf(';', index)] = ',';
                    strOutput = sb.ToString();
                    output.Add(strOutput);
                    counter++;
                }
                else
                output.Add(str);
            }
            File.WriteAllLines(path1, output, Encoding.GetEncoding(1251));
            return counter;
        }


    }

}

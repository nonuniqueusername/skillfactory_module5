using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintUserInfo(GetUser());
        }

        static void PrintUserInfo((string name, string lastName, int age, string[] petNames, string[] favColors) user)
        {
            Console.WriteLine($"Имя: {user.name}");
            Console.WriteLine($"Фамилия: {user.lastName}");
            Console.WriteLine($"Возраст: {user.age}");
            if (user.petNames.Length > 0)
            {
                Console.WriteLine($"Питомцы:");
                foreach(string pet in user.petNames)
                {
                    Console.WriteLine($"\t{pet}");
                }
            }
            if (user.favColors.Length > 0)
            {
                Console.WriteLine($"Любимые цвета:");
                foreach (string color in user.favColors)
                {
                    Console.WriteLine($"\t{color}");
                }
            }
        }

        static private (string name, string lastName, int age, string[] petNames, string[] favColors) GetUser()
        {
            (string name, string lastName, int age, string[] petNames, string[] favColors) User;
            string parseHelper;

            do
            {
                Console.WriteLine("Введите имя:");
                User.name = Console.ReadLine();
            } while (User.name.Length == 0);

            do
            {
                Console.WriteLine("Введите фамилию:");
                User.lastName = Console.ReadLine();
            } while (User.lastName.Length == 0);

            do
            {
                Console.WriteLine("Введите возраст:");
                parseHelper = Console.ReadLine();
            } while (CheckNum(parseHelper, out User.age));

            int petsCount;
            do
            {
                Console.WriteLine("Введите количество питомцев:");
                parseHelper = Console.ReadLine();
            } while (CheckNum(parseHelper, out petsCount));
            if (petsCount > 0)
            {
                User.petNames = GetPetNames(petsCount);
            }
            else
            {
                User.petNames = new string[0];
            }

            int favColorsCount;
            do
            {
                Console.WriteLine("Введите количество любимых цветов:");
                parseHelper = Console.ReadLine();
            } while (CheckNum(parseHelper, out favColorsCount));
            if (favColorsCount > 0)
            {
                User.favColors = GetColorNames(favColorsCount);
            }
            else
            {
                User.favColors = new string[0];
            }

            return User;

        }

        static string[] GetPetNames(int num)
        {
            string wut = "питомца";
            return GetNames(num, wut);
        }

        static string[] GetColorNames(int num)
        {
            string wut = "цвета";
            return GetNames(num, wut);
        }

        static string[] GetNames(int num, string wut)
        {
            string[] names = new string[num];
            for (int i = 0; i < num; i++)
            {
                do
                {
                    Console.WriteLine($"Введите название {wut} #{i + 1}");
                    names[i] = Console.ReadLine();
                }while (names[i].Length == 0);
            }
            return names;
        }

        static bool CheckNum(string num, out int parsedNum)
        {
            if (int.TryParse(num, out int inum))
            {
                if (inum >= 0)
                {
                    parsedNum = inum;
                    return false;
                }
            }
            parsedNum = 0;
            return true; 
        }
    }
}
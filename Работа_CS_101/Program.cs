using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Работа_CS_101
{
    enum emp
    {
        manager = 1,
        grunt = 10,
        contractor = 100,
        VP = 99
    }

    struct sfoo
    {
        public int x;
    }

    class cfoo
    {
        public int x = 100;
    }

    class Person
    {
        public string name = "";
        public string ssn = ""; // Номер соц страхования
        public byte age = 1;

        public Person() { }

        public Person(string n, string s, byte a)
        {
            name = n;
            ssn = s;
            age = a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name = " + this.name);
            sb.Append("ssn = " + this.ssn);
            sb.Append("age = " + this.age);

            return sb.ToString();
        }

        public override bool Equals(object o)
        {
            Person temp = (Person)o;
            bool eq = temp.name == this.name;
            eq &= temp.ssn == this.ssn;
            eq &= temp.age == this.age;
            if (eq) { return true; }
            else { return false; }
        }

        public override int GetHashCode()
        {
            return ssn.GetHashCode();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //arguments(args);
            //dialog();
            //SharpArrays();
            //operationArrays();
            //SharpStrings();
            //SharpEnums();
            //SharpSAC();
            //SharpObject();
            SharpObjectOverride();

        }


        static void arguments(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }

            foreach (string arg in args)
            {
                Console.Write(arg);
            }

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Parametr {0} is {1}", i, args[i]);
            }
        }

        static void dialog()
        {
            Console.Write("Как вас называть?");

            string s = Console.ReadLine();

            Console.WriteLine("Привет, {0}", s);

            Console.Write("Сколько вам лет?");

            s = Console.ReadLine();

            Console.WriteLine("Вам {0} лет", s);
        }

        static void SharpArrays()
        {
            // Размер массива
            const int size = 5;
            int[,] matrix = new int[size, size];

            // Заполняем массив
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = j + (i * size);
                }
            }

            // Выводим массив
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine(matrix[i, j] + "\t");
                }
            }

            // Ломанный массив
            int[][] M = new int[size][];

            // Заполняем массив
            for (int i = 0; i < M.Length; i++)
            {
                M[i] = new int[i + 1];
            }

            // Выводим массив
            for (int i = 0; i < size; i++)
            {
                Console.Write("Строка {0} : {1}:\t", i, M[i].Length);
                for (int j = 0; j < M[i].Length; j++)
                {
                    Console.Write(M[i][j] + "");
                }
                Console.WriteLine();
            }

        }

        static void operationArrays()
        {
            string[] N = new string[] { "123", "456", "189", "1849", "1893", "1893" };
            for (int i = 0; i < N.Length; i++) { Console.WriteLine(N[i]); }

            // Поиск элемента
            int index = Array.BinarySearch(N, "456");
            Console.WriteLine("Найден элемент {0}", index);

            // Разворачиваем массив
            Array.Reverse(N);

            // Сортируем массив
            Array.Sort(N);

            // Очистим 2 элемента
            Array.Clear(N, 1, 2);

            for (int i = 0; i < N.Length; i++)
            {
                Console.WriteLine(N[i]);
            }
        }

        static void SharpStrings()
        {
            Console.WriteLine("C format: {0:C}", 99989.987);
            Console.WriteLine("D9 format: {0:D9}", 99999);
            Console.WriteLine("E format: {0:E}", 99999.76543);
            Console.WriteLine("F format: {0:F3}", 99999.9999);
            Console.WriteLine("N format: {0:N}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);

            string s = String.Format("На счету {0:C}", 99999);
            Console.WriteLine(s);

            object[] stuff = { "Hi", 2.9, 1, "there", "83" };
            Console.WriteLine("stuff: {0}, {1}, {2}, {3}, {4}", stuff);

            System.String strObj = "test;";
            string s1 = "TEST";

            // Сравниваем значения строк
            if (s1 == strObj)
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Not same");
            }

            // Конкатенация
            string newstr = strObj + s1;
            Console.WriteLine(newstr);

            // Индексатор для доступа к отдельному символу строки
            for (int i = 0; i < s1.Length; i++)
            {
                Console.WriteLine("Char {0} is {1}", i, s1[i]);
            }

            string a, b, c;
            a = "Приминение \"Кавычек\"";
            Console.WriteLine(a);

            System.String fixeds = "string-String";
            string uppers = fixeds.ToUpper();

            Console.WriteLine(fixeds);
            Console.WriteLine(uppers);

            // StringBuilder для работы со строкой без создания копий
            StringBuilder buff = new StringBuilder("Буфер строки");
            buff.Append(", который вырос");
            Console.WriteLine(buff);

            // Получаем string из StringBuilder
            string e = buff.ToString().ToUpper();
            Console.WriteLine(e);
        }

        static void SharpEnums()
        {
            emp bill = new emp();

            // Тип данных пересечения
            Console.WriteLine(Enum.GetUnderlyingType(typeof(emp)));

            // Информация о переменной перечисления
            Console.WriteLine("bill - {0}", Enum.Format(typeof(emp), bill, "G"));
            Console.WriteLine("bill - {0}", Enum.Format(typeof(emp), bill, "X"));
            Console.WriteLine("bill - {0}", Enum.Format(typeof(emp), bill, "d"));

            // Информация об элементах перечисления
            Array a = Enum.GetValues(typeof(emp));
            Console.WriteLine("элементов {0}.", a.Length);

            int i = 0;
            foreach (emp emp in a) 
            {
                Console.WriteLine("Название эдемента {0} - {1}", i++, Enum.Format(typeof(emp), emp, "G"));
            }

            // Определяет наличие элемента перечисления
            if (Enum.IsDefined(typeof(emp), "VP1"))
            {
                Console.WriteLine("Существует.");
            }
            else
            {
                Console.WriteLine("Не существует такого слова в перечислении emp.");
            }
        }

        static void SharpSAC()
        {
            sfoo s1;
            s1.x = 100;

            // Копия типа
            sfoo s2 = s1;

            // Выводим структуру s1 и s2
            Console.WriteLine("s1.x = {0} s2.x = {1}", s1.x, s2.x);

            // Изменим s2
            s2.x = 555;

            Console.WriteLine("s1.x = {0} s2.x = {1}", s1.x, s2.x);

            cfoo c1 = new cfoo();

            // Копия типа
            cfoo c2 = c1;

            Console.WriteLine("c1.x = {0} c2.x = {1}", c1.x, c2.x);

            c2.x = 555;

            Console.WriteLine("c1.x = {0} c2.x = {1}", c1.x, c2.x);
        }

        static void SharpObject()
        {
            int i = 128;
            Console.WriteLine("{0}", i.ToString());
            Console.WriteLine("{0}", 256.ToString());
            Console.WriteLine("{0}", 256.GetTypeCode());
            Console.WriteLine("{0}", i.GetType());
            Console.WriteLine("{0}", i.GetTypeCode());
            Console.WriteLine("{0}", int.MinValue);
            Console.WriteLine("{0}", int.MaxValue);

            Program p1 = new Program();

            // Информация об объекте
            Console.WriteLine("To string: {0}", p1.ToString());
            Console.WriteLine("HashCode: {0}", p1.GetHashCode());
            Console.WriteLine("Type: {0}", p1.GetType());

            Program p2 = p1;

            if (p1.Equals(p2))
            {
                Console.WriteLine("Оба экземпляра указываю на одну и ту же область памяти!");
            }
        }

        static void SharpObjectOverride()
        {
            Person p1 = new Person("Fred", "222-222-2222", 98);
            Person p2 = new Person("Fred", "222-222-2222", 98);

            if (p1.Equals(p2) && p1.GetHashCode() == p2.GetHashCode())
            {
                Console.WriteLine("P1 и P2 одинаковые");
            }
            else { Console.WriteLine("P1 и P2 разные"); }

            p2.age = 2;

            if (p1.Equals(p2) && p1.GetHashCode() == p2.GetHashCode())
            {
                Console.WriteLine("P1 и P2 одинаковые");
            }
            else { Console.WriteLine("P1 и P2 разные"); }

            Console.WriteLine(p1.ToString());

        }




    }
}

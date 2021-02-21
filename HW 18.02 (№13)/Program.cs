using System;
using System.Threading;
using System.Threading.Tasks;

namespace HW_18._02___13_
{
    class Program
    {
        static Random rand = new Random();

        // характеристики
        static char AsciiCharacter
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    // возвращает число
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    // маленькая буква
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    // заглавная буква
                    return (char)('A' + rand.Next(27));
                else
                    // any ascii character // Любой символ
                    return (char)(rand.Next(32, 255));
            }
        }


        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WindowLeft = Console.WindowTop = 0;
            //Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            //Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;

            //Console.CursorVisible = false;

            //int width, height;
            //// установить массив начальных значений y
            //int[] y;

            //// ширина была 209, высота 81
            //// настроить экран и начальные условия y
            //Initialize(out width, out height, out y);

            //// сделать матричный эффект
            //// в каждом цикле все y увеличиваются на 1
            //while (true)
            //    UpdateAllColumns(width, height, y);
            // Матрица
            //--------------------------------------------------------------------------------------------------------------------------------

            //Асинхронность
            Task task = new Task(Display);
            task.Start();

            Console.WriteLine("Завершение метода Main");


            //Параллельное программирование:
            //Task task1 = new Task(() => Console.WriteLine("Task1 выполнен"));
            //task1.Start();
            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 выполнин"));
            //Task task3 = Task.Run(() => Console.WriteLine("Task3 выполнин"));





            //Многопоточность
            //Создаем новый поток
            //Thread thread = new Thread(new ThreadStart(multithreaded));
            //thread.Start();
            //for (int i = 1; i < 5; i++)
            //{
            //    Console.WriteLine("Основной поток");
            //    Console.WriteLine(i * i);
            //    Thread.Sleep(400);
            //}

            Console.ReadLine();
        }


        //Асинхронность
        static void Display()
        {
            Console.WriteLine("Начало работы метода Display");

            Console.WriteLine("Завершение работы метода Display");
        }


        //Многопоточность
        public static void multithreaded()
        {
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("Второй поток");
                Console.WriteLine(i * i);
                Thread.Sleep(500);
            }
        }



        // Матрица
        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;
            // рисует 3 символа в каждом столбце x каждый раз 
            // темно-зеленый, светло-зеленый и пробел

            // y - позиция на экране
            // y [x] увеличивается на 1 каждый раз, поэтому каждый цикл делает то же самое, но уменьшает значение y на 1
            for (x = 0; x < width; ++x)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);

                // темно-зеленый символ - на 2 позиции выше ярко-зеленого символа
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                Console.Write(AsciiCharacter);

                // пробел - на 20 позиций над ярко-зеленым символом
                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');

                // инкримент y
                y[x] = inScreenYPosition(y[x] + 1, height);
            }
        }

        // Имеет дело с тем, что происходит, когда позиция y находится за пределами экрана
        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }


        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            // начальные y позиции ярко-зеленых символов
            y = new int[width];

            Console.Clear();

            for (int x = 0; x < width; ++x)
            {
                // получает случайное число
                y[x] = rand.Next(height);
            }
        }
    }
}

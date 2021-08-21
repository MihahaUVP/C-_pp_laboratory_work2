using System;
using System.Threading;
namespace pp_lab2
{
    class Program
    {
        
        private string[] array;
        static void Main(string[] args)
        {
            for(int i = 0; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
            Console.ReadLine();
        }
    }
    class Reader
    {
        static Semaphore sem = new Semaphore(1,1);
        Thread myThread;
        int count = 3;
        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читающий {i.ToString()}";
            myThread.Start();
        }
        public void Read()
        {
            while (count>0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в  библиотеку");
                Console.WriteLine($"{Thread.CurrentThread.Name} совершает акт чтения");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} заканчивает своё пребывание в доме мудрости");
                sem.Release();
                count--;
                Thread.Sleep(1000);
            }
        }
    }
}

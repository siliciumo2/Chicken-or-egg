using System;
using System.Threading;

class ChickenAndEgg
{
    static readonly object lockObject = new object();
    static bool eggSaidLast = false;

    public static void ChickenThread()
    {
        lock (lockObject)
        {
            Console.WriteLine("Курица");
            eggSaidLast = false;
        }
    }

    public static void EggThread()
    {
        lock (lockObject)
        {
            Console.WriteLine("Яйцо");
            eggSaidLast = true;
        }
    }

    static void Main(string[] args)
    {
        Thread chickenThread = new Thread(ChickenThread);
        Thread eggThread = new Thread(EggThread);

        chickenThread.Start();
        eggThread.Start();

        chickenThread.Join();
        eggThread.Join();

        if (eggSaidLast)
        {
            Console.WriteLine("Ответ: Сначала появилось яйцо.");
        }
        else
        {
            Console.WriteLine("Ответ: Сначала пояявилась курица.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int count = 0;
            TowerOfHanoiConsole th = new TowerOfHanoiConsole();
            Console.WriteLine(th);
            do
            {
                if (th.SuperOerator(rnd.Next(th.NrOfOperators))!=null)
                {
                    count++;
                    Console.WriteLine(th);
                }
            } while (!th.IsGoalState());
            Console.WriteLine("Number of steps {0}", count);
            Console.WriteLine("\nProblem solved!");
            Console.ReadLine();
        }
       
    }
}

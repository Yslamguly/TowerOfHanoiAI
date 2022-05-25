using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;


namespace TestConsole
{
    class TowerOfHanoiConsole : AbstractState
    {
        private static Stack<int>[] towers = new Stack<int>[3];
        public static int N { get; private set; }

        public TowerOfHanoiConsole() : this(3)
        {
            
        }
        public TowerOfHanoiConsole(int numberOfRings)
        {
            TowerOfHanoiConsole.N = numberOfRings;
            towers[0] = new Stack<int>();
            towers[1] = new Stack<int>();
            towers[2] = new Stack<int>();
            //Push disks into stack
            for (int i = numberOfRings; i > 0; i--)
            {
                towers[0].Push(i);
            }
        }

        public override bool IsGoalState()
        {
            if(towers[2].Count == N)
            {
                for (int i = 0; i < N; i++)
                {
                    if (towers[2].ElementAt(i) == i)
                    {
                        continue;
                    }
                }
                return true;
            }
            return false;
        }

        public override bool IsState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < towers[i].Count-1; j++)
                {
                    if (towers[i].ElementAt(j) > towers[i].ElementAt(j + 1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public TowerOfHanoiConsole Move(int fromStack, int toStack)
        {
            if (!IsOperator(fromStack, toStack)) { return null; }

            int currentRing = towers[fromStack].Pop();
            towers[toStack].Push(currentRing);

            if (IsState()) { return this; }

            currentRing = towers[toStack].Pop();
            towers[fromStack].Push(currentRing);

            return null;
        }
        private bool IsOperator(int fromStack, int toStack)
        {
            if(towers[fromStack].Count > 0)
            {
                if (towers[toStack].Count > 0)
                {
                    if (towers[fromStack].Peek() == towers[toStack].Peek())
                    {
                        return false;
                    }
                    //if the top element of fromStack is greater than topElement of toStack
                    if (towers[fromStack].Peek() > towers[toStack].Peek())
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public TowerOfHanoiConsole SuperOerator(int i)
        {
            switch (i)
            {
                case 0: return Move(0, 1);
                case 1: return Move(0, 2);
                case 2: return Move(1, 0);
                case 3: return Move(1, 2);
                case 4: return Move(2, 0);
                case 5: return Move(2, 1);
                default: return null;
            }
        }
        public int NrOfOperators
        {
            get { return 6; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  A  |  B  |  C");
            sb.AppendLine("---------------");
            for (int i = 0; i < N; i++)
            {
                string d1 = " ", d2 = " ", d3 = " ";
                try
                {
                    d1 = towers[0].ElementAt(i).ToString();
                }
                catch (Exception e)
                {
                }
                try
                {
                    d2 = towers[1].ElementAt(i).ToString();
                }
                catch (Exception e)
                {
                }
                try
                {
                    d3 = towers[2].ElementAt(i).ToString();
                }
                catch (Exception e)
                {
                }
                sb.AppendLine("  " + d1 + "  |  " + d2 + "  |  " + d3);
            }
            sb.AppendLine();
            return sb.ToString();

        }
    }
}
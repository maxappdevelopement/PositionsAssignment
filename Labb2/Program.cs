using System;
using System.IO;

namespace Labb2
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            SortedPosList list3 = new SortedPosList();
            SortedPosList list4 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");


            list3.Add(new Position(1, 10));
            list3.Add(new Position(2, 2));
            list3.Add(new Position(3, 6));
            list3.Add(new Position(2, 3));

            list4.Add(new Position(3, 7));
            list4.Add(new Position(1, 2));
            list4.Add(new Position(3, 6));
            list4.Add(new Position(2, 3));
            Console.WriteLine(list3-list4);
        }


    }
}

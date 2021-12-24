using System;

namespace work
{
    class Program
    {
        public static Node<int> StayInOrder(Node<int> list, int num) // 1.A
        {
            if (list.GetValue() >= num) { return new Node<int>(num, list); }
            Node<int> temp = list;
            while (temp.HasNext())
            {
                if (num < temp.GetNext().GetValue() && num >= temp.GetValue())
                {
                    temp.SetNext(new Node<int>(num, temp.GetNext()));
                    return list;
                }
                temp = temp.GetNext();
            }
            temp.SetNext(new Node<int>(num));
            return list;
        }
        public static Node<int> BuildOrderList() //1.B
        {
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == -999) { return null; }
            Node<int> list = new Node<int>(userInput);
            while (true)
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput == -999) { return list; }
                list = StayInOrder(list, userInput);
            }
        }

        static void Main(string[] args)
        {
            Node<int> list = BuildOrderList();
            Console.WriteLine(list); // שיניתי את ToString שתדפיס את כל הרשימה
            /*  O(n^2) סיבוכיות זמן הריצה של הפעולה הינה 
            משום שאנו עוברים באמצעות לולאה עד שהמשתמש מכניס -999 ובכל פעם שהוא לא מכניס אז אנו מעלים
            את גודל הרשימה בעוד איבר בכך שאנו עוברים אליה שוב
            לכן על כל n אנו עוברים עוד n פעמים  */

        }
    }
}

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

        public static Node<Polinom> SumPolinoms(Node<Polinom> polinom1, Node<Polinom> polinom2) // 2.B
        {
            Node<Polinom> temp1, temp2, result, first;
            temp1 = polinom1;
            temp2 = polinom2;
            first = result = new Node<Polinom>(new Polinom(0, 0));
            while (temp1 != null && temp2 != null)
            {
                if (temp1.GetValue().GetPower() == temp2.GetValue().GetPower())
                {
                    result.SetNext(new Node<Polinom>(new Polinom(temp1.GetValue().GetFactor() + temp2.GetValue().GetFactor(), temp1.GetValue().GetPower())));
                    temp1 = temp1.GetNext();
                    temp2 = temp2.GetNext();
                }
                else if (temp1.GetValue().GetPower() < temp2.GetValue().GetPower())
                {
                    result.SetNext(new Node<Polinom>(temp2.GetValue()));
                    temp2 = temp2.GetNext();
                }
                else
                {
                    result.SetNext(new Node<Polinom>(temp1.GetValue()));
                    temp1 = temp1.GetNext();
                }
                result = result.GetNext();
            }
            while (temp1 != null)
            {
                result.SetNext(new Node<Polinom>(temp1.GetValue()));
                temp1 = temp1.GetNext();
                result = result.GetNext();
            }
            while (temp2 != null)
            {
                result.SetNext(new Node<Polinom>(temp2.GetValue()));
                temp2 = temp2.GetNext();
                result = result.GetNext();
            }
            return first.GetNext();
        }

        public static Node<Polinom> BuildPolinom() // 2.C
        {
            Node<Polinom> output, list;
            list = output = new Node<Polinom>(new Polinom(0, 0));
            while (true)
            {
                Console.Write("Enter factorial: ");
                int factorial = int.Parse(Console.ReadLine());
                if (factorial == -999) { return output.GetNext(); }
                Console.Write("Enter power: ");
                int power = int.Parse(Console.ReadLine());
                list.SetNext(new Node<Polinom>(new Polinom(factorial, power)));
                list = list.GetNext();
            }
        }

        public static bool Q3(BinNode<int> list) // 3.A
        {
            BinNode<int> last;
            int length = 1;
            while (list.HasRight()) { list = list.GetRight(); }
            int sum = list.GetValue();
            last = list;
            while (list.HasLeft()) { length++; list = list.GetLeft(); }
            sum += list.GetValue();
            for (int i = 0; i < length / 2; i++)
            {
                if (list.GetValue() + last.GetValue() != sum) { return false; }
                list = list.GetRight();
                last = last.GetLeft();
            }
            if (length % 2 != 0) { if (list.GetValue() != sum) { return false; } }
            return true;
        }

        static void Main(string[] args)
        {
            // 1.C
            Node<int> list = BuildOrderList();
            Console.WriteLine(list); // שיניתי את ToString שתדפיס את כל הרשימה


            // 1.D
            /*  O(n^2) סיבוכיות זמן הריצה של הפעולה הינה 
            כש-n הוא כמות הפעמים שהקליטה מהמשתמש אינה -999
            משום שאנו עוברים באמצעות לולאה עד שהמשתמש מכניס -999 ובכל פעם שהוא לא מכניס אז אנו מעלים
            את גודל הרשימה בעוד איבר בכך שאנו עוברים אליה שוב
            לכן על כל n אנו עוברים עוד n פעמים  */


            // 2.D
            Node<Polinom> polinom1 = BuildPolinom();
            Node<Polinom> polinom2 = BuildPolinom();
            Console.WriteLine(polinom1 + " | " + polinom2);
            var result = SumPolinoms(polinom1, polinom2);
            Console.WriteLine(result);


            // 2.E
            /*  O(n) סיבוכיות זמן הריצה של הפונקציה הינה
            כש-n הוא גודל הרשימה היותר גדולה מבין השניים
            נגיד ונציב n כגודל הרשימה הגדולה יותר ו m כגודל הרשימה הקטנה יותר
            אנו עוברים בלולאה הראשונה m פעמים
            ואז בלולאות האחרות אנו עוברים עוד n פעמים פחות m פעמים
            לכן בסך הכל הפונקציה מבצעת n פעולות  */


            // 3.B
            /*   סיבוכיות זמן הריצה של הפונקציה הינה O(n)
            כש-n הוא מספר האיברים במערך
            משום שבכל מהלך ריצת הפונקציה אנו עוברים על הרשימה,
            פעם משמאל לימין ופעם מימין לשמאל,
            ופעם משני קצוותיה עד אמצע הרשימה
            התוכנית תלויה בגודל הרשימה וככל שהיא
            גדולה יותר ככה היא תרוץ יותר זמן   */
        }
    }
}

using System;

namespace work
{
    class Program
    {
        public static Node<int> StayInOrder(Node<int> list, int num)
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
    }
}

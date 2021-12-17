using System.Collections.Generic;

namespace work
{
    class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public T GetValue()
        {
            return this.value;
        }
        public void SetValue(T val)
        {
            this.value = val;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            return this.next == null;
        }
        public override string ToString()
        {
            string str = $"[ ";
            Node<T> temp = this;
            while (temp.HasNext())
            {
                str += temp.GetValue() + ", ";
                temp = temp.GetNext();
            }
            str += temp.GetValue() + " ]";
            return str;
        }
    }
}
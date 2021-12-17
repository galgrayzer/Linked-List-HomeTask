using System.Collections.Generic;

namespace work
{
    class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(params T[] args)
        {
            this.value = default(T);
            this.next = null;
            foreach (var item in args)
            {
                this.Append(item);
            }
        }
        public void Append(T item)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T))) { this.value = item; }
            else
            {
                Node<T> temp, first;
                first = temp = this;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new Node<T>(item);
                this.value = first.value;
                this.next = first.next;
            }
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
    }
}
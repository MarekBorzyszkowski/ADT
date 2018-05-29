using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTList
{
    public class ADTList<T>
    {
        public class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Data { get; set; }
            public Node(T t)
            {
                Next = null;
                Data = t;
                Previous = null;
            }
        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }
        public ADTList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public ADTList<T> AddLast(T t)
        {
            Node n = new Node(t);
            Node pom = this.Tail;
            n.Previous = this.Tail;
            this.Tail = n;
            if (this.Head == null)
                this.Head = n;
            else
                pom.Next = this.Tail;
            this.Count++;
            return this;
        }
        public ADTList<T> AddFirst(T t)
        {
            Node n = new Node(t);
            Node pom = this.Head;
            n.Next = this.Head;
            this.Head = n;
            if (this.Tail == null)
                this.Tail = n;
            else
                pom.Previous = this.Head;
            this.Count++;
            return this;
        }
        public ADTList<T> DeleteLast()
        {
            if (this.Count > 1)
            {
                this.Tail = Tail.Previous;
                this.Tail.Next = null;
                this.Count--;
            }
            else if (this.Count == 1)
            {
                this.Tail = null;
                this.Head = null;
                this.Count--;
            }
            return this;
        }
        public ADTList<T> DeleteFirst()
        {
            if (this.Count > 1)
            {
                this.Head = Head.Next;
                this.Head.Previous = null;
                this.Count--;
            }
            else if (this.Count == 1)
            {
                this.Head = null;
                this.Tail = null;
                this.Count--;
            }
            return this;
        }
        public Node FindNode(T t)
        {
            Node n = this.Head;
            bool found = false;

            while(n != null && ! found)
                if (n.Data.Equals(t))
                    found = true;
                else
                    n = n.Next;
            return (found ? n : null);
         }
        public ADTList<T> DeleteSelected(T t)
        {
            Node n = FindNode(t);
            if (n == null) return this;
            else
            {
                if (n == this.Tail)
                {
                    DeleteLast();
                    return this;
                }
                if (n == this.Head)
                {
                    DeleteFirst();
                    return this;
                }
                n.Previous.Next = n.Next;
                n.Next.Previous = n.Previous;
                n = null;
                this.Count--;
                return this;
            }
        }
        public Node FindMinimum(IComparer<T> comp) {
            Node pomMin = this.Head;
            Node pom = this.Head;

            while (pom != null)
            {
                if (comp.Compare(pom.Data, pomMin.Data) < 0)
                    pomMin = pom;
                pom = pom.Next;
            }
            return pomMin;
        }
        public void printList() {
            Node pom = this.Head;
            while (pom != null)
            {
                Console.Write(pom.Data.ToString() + " ");
                pom = pom.Next;
            }
        }
    }
}

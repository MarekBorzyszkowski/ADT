using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTList {
    public class ADTSortedList<T> : ADTList<T> where T : IComparable {
        public Node FindMinimum() {
            return this.Head;
        }

        public ADTSortedList<T> InsertSorted(T t) {
            Node pom = this.Head;
            Node n = new ADTList<T>.Node(t);
            ADTSortedList<T> result = null;

            if (pom == null)
            {
                result = this.AddFirst(t) as ADTSortedList<T>;
            }
            else
            {
                while (pom != null)
                {
                    if (n.Data.CompareTo(pom.Data) < 0)
                    {
                        n.Next = pom;
                        n.Previous = pom.Previous;
                        pom.Previous = n;
                        if (n.Previous != null)
                            n.Previous.Next = n;
                        else
                            this.Head = n;
                        this.Count++;
                        result = this;
                        break;
                    }
                    else
                    {
                        pom = pom.Next;
                    }
                }

                if (pom == null)
                {
                    result = this.AddLast(t) as ADTSortedList<T>;
                }
            }
            return result;
        }
        public bool isSorted() {
            bool localSorted(Node n) {
                if (n == null)
                    return true;
                else if (localSorted(n.Next))
                    if (n.Next == null)
                        return true;
                    else
                        return n.Data.CompareTo(n.Next.Data) < 0;
                else
                    return false;
            }
            return localSorted(this.Head);
        }
        public void Sort() {
            ADTSortedList<T> newList;
            if (!this.isSorted())
            {
                Node pom = this.Head;
                if (pom != null)
                {
                    newList = new ADTSortedList<T>();
                    while (pom != null)
                    {
                        newList = newList.InsertSorted(pom.Data);
                        pom = pom.Next;
                    }
                    this.Head = newList.Head;
                    this.Tail = newList.Tail;
                    this.Count = newList.Count;
                }
            }
        }
    }
}

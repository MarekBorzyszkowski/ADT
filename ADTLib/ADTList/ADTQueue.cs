using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADTList {
    public class ADTQueue<T> {
        ADTList<T> elements;

        public ADTQueue() {
            elements = new ADTList<T>();
        }
        // wstawianie na koniec kolejki
        public ADTQueue<T> Enqueue(T el) {
            elements.AddLast(el);
            return this;
        }
        // pobieranie i usuwanie z poczatku kolejki
        public T Dequeue() {
            if (elements.Head == null)
                throw new EmptyQueueException();
            T result = elements.Head.Data;
            elements.DeleteFirst();
            return result;
        }
        // pobieranie bez usuwania z poczatku kolejki
        public T Peek() {
            if (elements.Head == null)
                throw new EmptyQueueException();
            return elements.Head.Data;
        }
        public bool Contains(T t) {
            if (elements.FindNode(t) != null)
                return true;
            else
                return false;
        }
    }
    public class EmptyQueueException : Exception{}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Stack
{
    internal class Stack<T>
    {
    /******************************************************************
     * 어댑터 패턴 (Adapter) : 디자인 패턴의 종류
     * 
     * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환 (기능연결)
     ******************************************************************/

        private List<T> container;
        public Stack()
        {
            container = new List<T>();
        }

        public int Count { get { return container.Count; } }
        public void Push(T item) 
        {
            container.Add(item);
        }
        public T Pop()
        {
            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return item;
        }
    }
}

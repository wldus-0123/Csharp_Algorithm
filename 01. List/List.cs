using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class List<T>
    {
        private const int DefaultCapacity = 4;      // 기본값 설정 상수로 해서 누가 바꾸지 못하게함

        private T[] items;  // 일반화 배열 만들기
        private int count;  // 크기

        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public List(int capacity)
        {
            items = new T[capacity];  // capacity만큼의 크기를 가진 배열을 만들겠다
            count = 0;
        }
        public int Capacity { get { return items.Length; } } // 크기 = 현재 만들어진 배열의 길이
        public int Count { get {return count; } }
        public bool IsFull { get { return count == items.Length; } }
        public T this[int index] 
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (IsFull) // 가득 차 있을 때 -> 더 큰 배열을 만들어서 기존의 배열을 복사
                Grow(); // 배열크기 늘려서 채운다
            items[count++] = item;
        }

        public void Insert(int index, T item)
        {
            // 예외처리가 필요함 : 크기를 벗어나게 중간에 끼워넣는것은 불가능
            if (index < 0 || index > Count) // index가 0보다 작거나, 크기를 벗어나는 경우 하면 안됨
                throw new ArgumentOutOfRangeException("index"); // 'Argument가 index를 벗어났다' 라는 뜻

            if (IsFull)
                Grow();
            Array.Copy(items, index, items, index + 1, count - index); // items의 index부터, items의 index+1으로 count-index만큼 복사
            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            // 예외처리가 필요함 : 크기를 벗어나게 중간에 빼는 것은 불가능
            if (index < 0 || index >= Count) // index가 0보다 작거나, 크기를 벗어나는 경우 하면 안됨
                throw new ArgumentOutOfRangeException("index"); // 'Argument가 index를 벗어났다' 라는 뜻

            count--;
            Array.Copy(items, index + 1, items, index, count - index);
        }

        public int IndexOf(T item)
        {
            for(int i= 0; i < count; i++)
            {
                if(item.Equals(items[i]))       // 모든 자료형의 주소값이 같은지 다른지 구분하는 함수, '=='는 값을 비교해서 안되는 자료형들이 있어서
                {
                    return i;
                }
            }
            return -1;
        }



        private void Grow()     
        {
            // 더 큰 배열 생성하기
            T[] newitems = new T[items.Length*2];

            // 새로운 배열에 기존의 데이터 복사
            Array.Copy(items, newitems, items.Length);  //(복사할곳,옮길곳,크기)

            // 기본 배열 대신 새로운 배열을 사용
            items = newitems;
        }
    }
}

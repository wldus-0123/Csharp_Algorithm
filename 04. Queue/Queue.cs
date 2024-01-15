using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04._Queue
{
    public  class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head; // 맨 앞 위치
        private int tail; // 맨 뒤 위치
        private int count;

        public Queue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow(); // 꽉 차있으면 배열 용량 늘리기
            }

            array[tail] =  item;    //tail 자리에 item 넣기
            // tail = (tail + 1) % array.Length; 로도 표현이 가능함
            tail++;                 // tail 뒤로 한 칸 옮기기
            if(tail == array.Length) // 마지막 칸에 있을 떄 맨 앞으로 보내는 과정
            {
                tail = 0;
            }
            count++;
        }

        public T Dequeue()
        {
            if (count == 0) // 하나도 없을 때는 꺼낼 수 없음
                throw new InvalidOperationException();  // 예외처리

            T item = array[head];
            head++;
            if(head == array.Length)
            {
                head = 0;       // 헤드가 배열을 벗어나면 앞으로 다시 돌아와야함
            }
            count--;
            return item;
        }

        public bool IsFull()        // 꽉 차있는 경우 판정해줘야함
        {
            if(head > tail)
            {
                return head == tail + 1;        //head가 tail 바로 앞에 있을 때
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        private void Grow() // 배열 용량 늘리기
        {
            T[] newArray = new T[array.Length * 2]; // 1. 새로운 배열 생성

            // 2. 새로운 배열에 기존 배열의 데이터 복사
            if(head < tail) //head가 tail보다 앞에 있는데 꽉찬경우
            {
                Array.Copy(array, head, newArray, 0, tail); // 복사할 배열, 어디부터복사할건지, 어디에 복사할건지, 시작 인덱스, 얼마나(크기)복사할건지
            }
            else
            {
                Array.Copy(array, 0, newArray, array.Length - tail, tail);
            }
            array = newArray;   // 3. 기존의 배열을 새로운 배열로 대체
            head = 0;           // 4. head(맨처음으로)와 tail(데이터의 갯수만큼)의 위치 선정
            tail = count;
        }
    }
}

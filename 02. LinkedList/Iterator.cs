using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
    /*******************************************************************
    * 반복기 (Iterator)
    * 
    * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
    * C# 대부분의 자료구조는 반복기를 포함
    * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
    *******************************************************************/
    internal class Iterator
    {
        void Main1()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }

            for (int i = 0; i < linkedList.Count; i++)  // list와 같은 방법으로 반복문 만들 수 없음
            {
                Console.Write($"{linkedList[i]} ");  // error : 연결리스트는 index 기반이 없기 때문
            }

            // 연결리스트의 반복문 만드는 방법 : 자료구조 내 데이터를 순회하기 위해 자료구조 내부구조를 이용해야함
            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next) // 먼저 첫번째 노드를 가져오고, 계속 옆의 노드를 불러오도록 구성
            {
                Console.Write($"{node.Value} ");
            }

            foreach (int element in list)
            // 처음~끝 하나하나 반복하는 반복문인 foreach를 사용하면 훨씬 수월하다 : index 없어도 되니까
            {
                Console.Write($"{element} ");
            }

            foreach (int element in linkedList)
            {
                Console.Write($"{element} ");
            }

            foreach (int element in Func()) // IEnumerable 요소가 있는 기능이기 때문에 foreach문 사용이 가능함
            {
                Console.Write($"{element} ");
            }

            
        }

        public static float Average(IEnumerable<int> container)
        {
            float average = 0;
            int count = 0;
            foreach(int value in container)
            {
                average += value;
                count++;
            }
            return average / count;
        }
        
        public static IEnumerable<int> Func()
        {
            yield return 10;
            yield return 20;
            yield return 30;
            yield return 40;
        }
    }
}


// +) IEnumerable : 반복이 가능하게 하는 인터페이스..? : 반복자 : C#의 모든 자료구조는 이걸 지원함

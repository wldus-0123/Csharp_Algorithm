﻿namespace _06._Heap
{
    internal class Program
    {
        /*************************************************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 *************************************************************************************/
        // <힙 구현>
        // 힙은 노드들이 트리의 왼쪽부터 채운 완전이진트리를 구조를 가지며
        // 부모 노드가 두 자식노드보다 우선순위가 높은 값을 위치시킴
        // 힙 상태를 만족하는 경우 가장 최상단 노드가 모든 노드 중 우선순위가 가장 높음
        // 자식노트들의 위치 순서는 무관 : 부모노드보다 크기만/작기만 하면 되기 때문에
        //
        //               2
        //       ┌───────┴───────┐
        //       8               52
        //   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92
        // ┌─┴─┐   ┌─┘
        // 17  43  52


        // <힙 노드 삽입>
        // 1. 힙의 최고 깊이, 최우측에 새 노드를 추가 (가장 아랫쪽에 일단 추가)
        //
        //               2
        //       ┌───────┴───────┐
        //       8               52
        //   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92
        // ┌─┴─┐   ┌─┴─┐
        // 17  43  52 (7)
        //
        // 2. 삽입한 노드와 부모 노드를 비교하여 우선순위가 더 높은 경우 교체 (부모노드랑 비교 후 더 작으면 부모랑 자리 바꿈)
        //
        //               2                               2                               2
        //       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐
        //       8               52              8               52             (7)              52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92      13     (7)      67      92      13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐
        // 17  43  52 (7)                  17  43  52  37                  17  43  52  37
        //
        // 3. 더이상 교체되지 않을때까지 과정을 반복 (상승작업 반복)
        //
        //               2                               2
        //       ┌───────┴───────┐               ┌───────┴───────┐
        //      (7)              52              7               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐
        // 17  43  52  37                  17  43  52  37


        // <힙 노드 삭제>
        // 1. 최상단의 노드와 최우측 노드를 교체한 뒤 최우측 노드를 삭제
        //
        //              (2)                             (37)                           (37)
        //       ┌───────┴───────┐               ┌───────┴───────┐              ┌───────┴───────┐
        //       7               52              7               52             7               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>  ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92     13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐                  ┌─┴─┐   ┌─┘
        // 17  43  52 (37)                 17  43  52 (2)                 17  43  52
        //
        // 2. 교체된 노드와 두 자식 노드를 비교하여 우선순위가 더 높은 노드와 교체
        //
        //              (37)                             7                               7
        //       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐
        //       7               52             (37)             52              8               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92      13     (37)     67      92
        // ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘
        // 17  43  52                      17  43  52                      17  43  52
        //
        // 3. 더이상 교체되지 않을때까지 과정을 반복 (하강작업 반복)
        //
        //               7                               7
        //       ┌───────┴───────┐               ┌───────┴───────┐
        //       8               52              8               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13     (37)     67      92      13      37      67      92
        // ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘
        // 17  43  52                      17  43  52


        // <힙 구현>
        // 힙의 완전이진트리 특징의 경우 배열을 통해서 구현하기 좋음 ; 비어있는 곳 없이 사용하는 것이 가장 효율적임
        // 노드의 위치를 배열에 순서대로 저장 (위 -> 아래, 왼쪽 -> 오른쪽)
        // 노드가 위치한 인덱스에 연산을 진행하여 노드 이동이 가능
        // 
        // 부모로 이동        : (index - 1) / 2
        // 왼쪽자식으로 이동   : 2 * index + 1
        // 오른쪽자식으로 이동 : 2 * index + 2
        //
        //        0
        //    ┌───┴───┐
        //    1       2       ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        //  ┌─┴─┐   ┌─┴─┐ =>  │0│1│2│3│4│5│6│7│8│9│
        //  3   4   5   6     └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        // ┌┴┐ ┌┘
        // 7 8 9

        static void Main(string[] args)
        {
            // 우선순위대로 처리해야할 때 : 우선순위 큐 (PriorityQueue) - 힙으로 구현됨
            // PriorityQueue<요소,우선순위 정할 기준>
            PriorityQueue<string, int> aa = new PriorityQueue<string, int>();
            aa.Enqueue("감기",5);
            aa.Enqueue("타박상", 8);
            aa.Enqueue("심장마비", 1);

            // 내림차순으로 표현할 때는 int 우선순위 * -1 을 적용하여 사용한다
            aa.Enqueue("감기", -5);
            aa.Enqueue("타박상", -8);      // 그럼 얘가 처음으로 나옴
            aa.Enqueue("심장마비", -1);     // 얘가 마지막으로 나옴

            //일반 queue의 경우 들어온 순서부터 차례대로 처리할 것
            //priority queue의 경우 기준에 따라 우선순위대로 처리할 것

            while (aa.Count > 0)
            {
                Console.WriteLine(aa.Dequeue());
            }
        }
    }
}

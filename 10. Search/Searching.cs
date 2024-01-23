using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Search
{
    internal class Searching
    {

        // 1. 순차 탐색 - 선형자료구조에서만 가능
        // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
        // 시간복잡도 = O(n)
        public static int SequentialSearch<T>(IList<T> list, T item) where T : notnull // T자리에 null아닌거만 넣어라
        {
            for(int i = 0; i<list.Count; i++ )
            {
                if (list[i].Equals(item)) { return i; }
            }
            return -1;
        }


        // 2. 이진탐색 - 선형자료구조에서만 가능
        // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
        // 단, 이진탐색은 정렬이 되어 있는 자료에만 올바른 결과를 도출한다
        // 시간복잡도 = O(logn)
        public static int BinarySearch<T>(IList<T>list, T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                int compare = list[mid].CompareTo(item);

                if (compare < 0) // item이 더 클 때
                {
                    low = mid + 1;
                }
                else if (compare > 0) //item이 더 작을 때
                {
                    high = mid - 1;
                }
                else // item이랑 mid랑 같을 때
                {
                    return mid;
                }
            }

            return -1; // 없을 때

        }


        // 3. 깊이 우선 탐색 ( Depth - First Search )
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 분기의 탐색을 마쳤을 때 다음 분기를 탐색
        // 스택을 통해 구현
        public static void DFS(bool[,]graph, int start, out bool[] visited, out int[] parents) // out 탐색가능여부 / 부모노드
        {
            visited = new bool[graph.GetLength(0)]; // GetLength(0)은 행의 개수, Getlength(1)은 열의 개수      
            parents = new int[graph.GetLength(0)];

            for(int i = 0; i < graph.GetLength(0); i++ ) // 초기셋팅
            {
                visited[i] = false;
                parents[i] = -1;
            }
            SearchNode(graph, start, visited, parents);
        }

        public static void SearchNode(bool[,] graph, int start, bool[]visited, int[] parents)
        {
            visited[start] = true; // 방문완료
            for(int i = 0; i < graph.GetLength(0);i++) // 전부 탐색
            {
                if (graph[start, i] && !visited[i]) // 연결되어 있는 정점이면서, 방문한적이 없는 정점
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);  // 방문한적 없는 애들 싹 돌기
                }
            }
        }


        // 4. 너비 우선 탐색 ( Breadth - First Search ) : 최단경로 보장
        // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
        // 다음 깊이의 분기들을 탐색
        // 큐를 통해 탐색
        public static void BFS(bool[,]graph, int start, out bool[]visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)]; // GetLength(0)은 행의 개수, Getlength(1)은 열의 개수      
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++) // 초기셋팅
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while(queue.Count>0)
            {
                int next = queue.Dequeue();
                for (int i = 0; i < graph.GetLength(0); i++) // 전부 탐색
                {
                    if (graph[next, i] && !visited[i]) // 연결되어 있는 정점이면서, 방문한적이 없는 정점
                    {
                        visited[i] = true;
                        parents[i] = next;
                        queue.Enqueue(i);  // 방문한적 없는 애들 싹 돌기
                    }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 우선순위 큐 : C#은 기본적으로 최소힙으로 구현되어 있음
    public class PriorityQueue<Telement, TPriority> where TPriority : IComparable<TPriority>
    {
        private struct Node
        {
            public Telement element;
            public TPriority priority;

            public Node(Telement element, TPriority priority)
            {
                this.element = element; 
                this.priority = priority;
            }
        }

        private List<Node> nodes;       // 배열로 구현

        public PriorityQueue()
        {
            nodes = new List<Node>();
        }

        public void Enqueue(Telement element, TPriority priority)
        {
            Node newNode = new Node(element, priority); // 새로운 노드 만들기
            nodes.Add(newNode); // 가장 마지막 자리에 새로운 노드 넣기
            int index = nodes.Count - 1; // 총 길이 - 1 = 새 노드가 들어가는 인덱스
            while (index > 0)
            {
                // 최상단에 들어가기 전까지 반복
                int parentIndex = (index - 1) / 2;  // 부모 인덱스 값 구하기
                Node parentNode = nodes[parentIndex];

                if (newNode.priority.CompareTo(parentNode.priority) < 0) // 새로운노드랑 부모노드 비교했을 때 새로운노드가 작으면 -1 반환 크면 1반환 같으면 0반환
                {
                    // 교체해서 상승하기
                    nodes[index] = parentNode; // 아래로 부모노드 끌어내림
                    nodes[parentIndex] = newNode; // 원래 부모노드 자리에 새로운 노드 넣기
                    index = parentIndex; // 인덱스 값 현재 있는 곳으로 변경
                }
                else
                {
                    break; // 새로운노드값이 더 크면 굳이 더 올라갈 필요없음
                }

            }
        }

        public Telement Dequeue()
        {
            Node rootNode = nodes[0];   // 최상단 노드

            // 제거작업
            Node lastNode = nodes[nodes.Count-1]; // 가장 마지막에 있는 노드
            nodes[0] = lastNode; // 첫번째 자리에 마지막 노드 넣어줌
            nodes.RemoveAt(nodes.Count - 1); // 마지막 자리에 있는 노드 삭제

            int index = 0;
            while (index < nodes.Count)
            {
                // 하강작업 진행 : 왼,오 비교해서 더 작은쪽으로 내려가게 해야함
                int leftIndex = 2 * index + 1; // 왼쪽놈 인덱스값
                int rightIndex = 2 * index + 2; // 오른쪽놈 인덱스값

                if(rightIndex < nodes.Count)    //자식이 둘 다 있는 경우
                {
                    int lessIndex;
                    if (nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0) // 왼 오 우선순위 비교해서 왼이 작으면
                    {
                        lessIndex = leftIndex; // 더 작은거 왼쪽임
                    }
                    else
                    {
                        lessIndex = rightIndex; // 더 작은거 오른쪽임
                    }

                    Node lessNode = nodes[lessIndex]; // lessNode에 더 작은 애 값 넣어주기
                    if (nodes[index].priority.CompareTo(nodes[lessIndex].priority) > 0)
                    {
                        nodes[lessIndex] = lastNode;
                        nodes[index] = lessNode;
                        index = lessIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (leftIndex < nodes.Count)   //자식이 하나만 있는 경우
                {
                    Node leftNode = nodes[leftIndex]; // leftNode 노드 만들어서 값 넣기
                    if (nodes[index].priority.CompareTo(nodes[leftIndex].priority)>0) // 비교하는 노드가 왼쪽노드보다 큰 경우
                    {
                        nodes[leftIndex] = lastNode;    // 현재 왼쪽노드 자리에 기준 노드값 넣기
                        nodes[index] = leftNode;        // 왼쪽노드 위로 올리기
                        index = leftIndex;              // 기준노드 인덱스번호 원래 왼족자리 인덱스번호로 바꾸기

                    }
                    else
                    {
                        break;
                    }
                }
                else    //자식이 없는 경우 : 더 내려갈 필요가 없음
                {
                    break;
                }


            }

            return rootNode.element;

        }
    }
}

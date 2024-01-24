using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortesPath
{
    internal class Dijkstra
    {
        const int INF = 99999; // 단절되어있어용

        public static void ShortestPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            int size = graph.GetLength(0); // graph. GetLength(0) = graph의 행 크기 (정점 갯수)
            visited = new bool[size]; // 방문 여부 체크
            distance = new int[size]; // 정점에서부터의 거리
            parents = new int[size];  // 바로 윗 경로

            for(int i = 0; i < size; i++)  // 초기 셋팅
            {
                visited[i] = false; // 방문한 적 없어용
                distance[i] = INF;  // 거리 무한대 상태입니당 ( 얼마나 걸리는지 아직 몰라요 )
                parents[i] = -1; // 바로 윗 경로도 아직 몰라요
            }

            distance[start] = 0; // 시작지점 ~ 시작지점 거리를 0으로 설정

            for(int i = 0; i < size; i++)  //  0번 정점부터 마지막 정점까지 1번씩 싹 돌기 ?
            {
                
                // 1. 방문하지 않은 정점 중 가장 거리가 가까운 정점 선택

                int next = -1; // 다음에 방문할 정점: -1은 없다는 뜻
                int minDistance = INF; // 현시점 최소거리 ( 아직 모르므로 무한대로 표시 )

                for(int j = 0; j < size; j++) 
                {
                    if (distance[j] < minDistance && !visited[j]) // 거리가 더 짧으면서, 방문하지 않은 정점일 경우
                    {
                        next = j; 
                        minDistance = distance[j];  
                    }
                }

                if (next < 0) // 찾을만한 정점이 없을 때 
                    break;

                

                // 2. 직접 연결된 거리보다 거쳐서 더 짧아지는 경우 갱신

                for(int j = 0; j<size; j++)
                {
                    //  distance[j] : 목적지까지 직접 연결된 거리
                    //  distance[next] : 탐색중인 정점까지의 거리
                    //  graph[next, j] : 탐색중인 정점부터 목적지까지의 거리
                    if (distance[j] > distance[next] + graph[next, j]) 
                    {
                        distance[j] = distance[next] + graph[next, j];
                        parents[j] = next;
                    }
                }
                visited[next] = true; // 걍 방문만하고 끝? visited : true / distance: 0 / parent -1 
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12__PathFinding
{
    internal class Astar
    {
        // < A* 알고리즘 >
        // 시작지점, 끝 지점이 지정되어 있음
        // 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색 알고리즘
        // 경로 탐색의 우선순위를 두고 유망한 해(예상 가중치가 가장 낮은 애)부터 우선적으로 탐색

        // 탐색 정점 선정 기준 (작을수록 좋음, 경로에 따라 달라짐) = f (총 예상 거리) 
        // f = g(실제 이동거리) + h(예상 남은 거리 : 장애물 무시)

        // h = 휴리스틱 : 최상의 경로를 추정하는 순위값. 경로탐색 효율을 결정하는 요소
        // (측정방식 - 맨허튼 방식 : 직선(+10)이동만 가능 or 유클리드 방식 : 대각선(+14)이동도 가능)

        const int CostStraight = 10; // 직선 비용
        const int CostDiagonal = 14; // 대각선 비용

        static Point[] Direction =
        { 
            // 탐색할 방향
            
            new Point(0, +1), // 상
            new Point(0, -1), // 하
            new Point(-1, 0), // 좌
            new Point(1, 0),  // 우
            new Point(-1, 1),  // 좌상
            new Point(-1, -1),  // 좌하
            new Point(1, 1),  // 우상
            new Point(1, -1),  // 우하
        };

        public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path) // 타일맵, 시작지점, 도착지점 -> 경로 반환
        {
            // 사전셋팅
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];      // (x,y) 좌표를 가지고 있는 노드들의 2차원 배열 생성

            bool[,] visited = new bool[ySize, xSize];        // 방문여부 체크

            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>(); // 가장 좋은 후보를 빠르게 가져오기 위해서 우선순위 큐 사용 : 다음 탐색할 노드 찾기


            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, new Point(), 0, Heruistic(end, start)); // 위치, 부모, g값, h값
            nodes[startNode.pos.y, startNode.pos.x] = startNode;  
            nextPointPQ.Enqueue(startNode, startNode.f); // 우선순위 큐에 시작점 넣어주기 (우선순위 기준 : f값이 작을수록 먼저 출력됨)

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점을 꺼내기 : f가 가장 낮은 정점
                ASNode nextNode = nextPointPQ.Dequeue(); // 우선순위 큐에서 꺼내주기

                // 2. 탐색한 정점은 방문표시
                visited[nextNode.pos.y, nextNode.pos.x] = true; // 탐색한 좌표 탐색 완료로 표시해주기!
                
                // 3. 탐색할 정점이 도착지인 경우 -> 도착했다고 판단해서 경로를 반환 (종료)
                if(nextNode.pos.x == end.x && nextNode.pos.y == end.y) // 탐색한 좌표와 목적지의 좌표가 일치할 때
                {
                    path = new List<Point>(); // 경로 리스트 생성
                    Point point = end;        // 목적지 좌표 저장

                    while((point.x == start.x && point.y == start.y) == false) // 도착 ~ 시작까지 역순으로 경로 추적
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);
                    path.Reverse(); // 현재 도착~시작의 경로이므로 뒤집어서 시작~도착의 경로로 바꿔줌
                    return true; 
                }

                // 4. 탐색한 정점 주변의 정점의 점수 계산 - 이동할 수 있는지 판단
                for(int i = 0; i < Direction.Length; i++)  // 방향 싹다 탐색
                {
                    int x = nextNode.pos.x + Direction[i].x;
                    int y = nextNode.pos.y + Direction[i].y;

                    // 4-1. 점수계산을 하면 안되는 경우는 제외
                    // 맵을 벗어나는 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점인 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 탐색한 정점일 경우
                    else if (visited[y, x])
                        continue;
                    // 대각선으로 이동이 불가능한 지역인 경우
                    else if (i >= 4 && tileMap[y, nextNode.pos.x] == false && tileMap[nextNode.pos.y, x] == false) 
                        // 둘 다 막혀있을 경우임, || 로 바꿀 경우 하나라도 막혀있으면 대각선으로 이동 못함
                        continue;

                    // 4-2. 점수를 계산한 정점 만들기
                    int g = nextNode.g + i < 4 ? CostStraight : CostDiagonal;
                    int h = Heruistic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);

                    // 4-3. 정점이 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y,x] == null || nodes[y,x].f > newNode.f)
                    // 점수 계산을 하지 않은 정점이거나, 새로운 정점의 f 가중치가 더 낮은 경우
                    {
                        nodes[y,x]= newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false; // 경로를 못찾았을 때
        }

        public static int Heruistic(Point start, Point end)
        {
            // 가로로 가야하는 횟수
            int xSize = Math.Abs(start.x - end.x); // start.x ? end.x ? start.x - end.x : end.x - start.x;
            // 세로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);


            // 맨하튼 거리 : 직선을 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            // return CostStraight * (int)Math.Sqrt(xSize * xSize +ySize * ySize);

            // 타일맵 유클리드 거리 : 직선과 대각선을 통해 이동하는 거리
            int straightCount = Math.Abs(xSize - ySize);                 // 직선 갯수
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;  // 대각선 갯수
            return CostStraight * straightCount + CostDiagonal * diagonalCount; // (직선갯수 * 비용(10)) + (대각선갯수 * 비용(14))

            
        }

        public class ASNode
        {
            public Point pos;       // 정점의 위치
            public Point parent;    // 이 정점을 탐색한 정점

            public int f;   // 총 예상거리 f = g + h
            public int g;   // 지금까지 이동한 거리 g, 지금까지 경로상의 누적가중치
            public int h;   // 휴리스틱 h, 앞으로 예상되는 목표까지의 추정경로 가중치 (장애물 고려하지 않음)

            public ASNode(Point pos, Point parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.f = g + h;
                this.g = g;
                this.h = h;
            }
        }
    }

    public struct Point  // 정점 좌표
    {
        public int x;
        public int y;

        public Point(int x, int y )
        {
            this.x = x; 
            this.y = y;
        }

        public static bool operator == ( Point left, Point right ) // == : X값 y값 모두 같으면 같다
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Point left, Point right)    // != : X값 y값 모두 다르면 다르다
        {
            return left.x != right.x && left.y != right.y;
        }
    }
}

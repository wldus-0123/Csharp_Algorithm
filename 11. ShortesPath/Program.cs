namespace _11._ShortesPath
{
    internal class Program
    {
        /********************************************************************
        * 데이크스트라 알고리즘 (Dijkstra Algorithm)
        * 
        * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
        * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후, (가장 가까운 정점 찾기)
        * 해당 노드를 거쳐 다른 노드로 가는 비용 계산 (최단거리로 갱신해주기)
        ********************************************************************/

        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph = new int[18, 18]
            {
                {0, 6, 6, INF, INF, INF, INF, 7, INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
                {6, 0, INF, INF, INF, 9, INF, INF, INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
                {6, INF, 0, 7, INF, INF, 8, INF, INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
                {INF, INF, 7, 0, INF, INF, 8, INF, INF,INF,INF,INF,INF,INF,INF,INF,INF,3},
                {INF, INF, INF, INF, 0, 2, INF, 7, 8,INF,INF,INF,INF,INF,INF,INF,INF,INF},
                {INF, 9, INF, INF, 2, 0, 1, INF, INF,2,INF,INF,INF,INF,INF,INF,INF,INF},
                {INF, INF, 8, 8, INF, 1, 0, INF, INF,2,8,INF,INF,INF,INF,INF,INF,INF},
                {7, INF, INF, INF, 7, INF, INF, 0, 4,INF,INF,5,INF,INF,5,INF,INF,INF},
                {INF, INF, INF, INF, 8, INF, INF, 4, 0, 3,INF,INF,4,INF,INF,INF,INF,INF},
                {INF, INF, INF, INF, INF, 2, 2, INF, 3,0 ,5,INF,1,INF,INF,INF,INF,INF}, //9
                {INF, INF, INF, INF, INF, INF, 8, INF, INF,5,0,INF,INF,INF,INF,INF,INF,7},
                {INF, INF, INF, INF, INF, INF, INF, 5, INF,INF,INF,0,INF,INF,3,INF,INF,INF},
                {INF, INF, INF, INF, INF, INF, INF, INF, 4,1,INF,INF,0,INF,INF,4,7,INF},
                {INF, INF, INF, INF, INF, INF, INF, INF, INF,INF,INF,INF,INF,0,INF,INF,1,INF},
                {INF, INF, INF, INF, INF, INF, INF, 5, INF,INF,INF,3,INF,INF,0,2,INF,INF},
                {INF, INF, INF, INF, INF, INF, INF, INF, INF,INF,INF,INF,4,INF,2,0,3,6},
                {INF, INF, INF, INF, INF, INF, INF, INF, INF,INF,INF,INF,7,1,INF,3,0,INF},
                {INF, INF, INF, 3, INF, INF, INF, INF, INF,INF,7,INF,INF,INF,INF,6,INF,0},
            };

            Dijkstra.ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);

        }
    }
}

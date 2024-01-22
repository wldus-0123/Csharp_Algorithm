using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    internal class Greedy
    {
        // 탐욕 알고리즘 : 문제를 해결하는데 사용되는 근시안적 방법 (뒷일 생각안하고 걍 함)
        // 문제를 직면한 당시에 당장 최적인 답을 선택하는 과정을 반복 ( 걍 눈앞에 있는거 해보고 되는거 나오면 답으로 낸다는거임? )
        // 단, 반드시 최적의 해를 구해준다는 보장이 없음 - 쓸 수 있을 때가 있고 못 쓸 때가 있음
        // +) 우선순위큐는 거의 탐욕 알고리즘이라는데 먼소린지 모르겟움 : 우선순위 큐가 빌때까지 알고리즘 진행하는 경우가 많음

        // 예시 - 자판기 거스름돈
        
        void CoinMachine(int money)
        {
            int[] coinType = { 500, 100, 50, 10, 5, 1 };
            foreach(int coin in coinType) 
            {
                while(money <= coin)
                {
                    Console.WriteLine($"{coin} 코인 배출");
                    money -= coin;
                }
            }
        }
    }
}

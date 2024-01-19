using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    internal class DivideAndConquer
    {
        // 분할정복 : 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
        // 분할을 통해서 해결하기 쉬운 작은 문제로 나눔 -> 정복한 후 병합하는 과정

        // 예시 : 거듭제곱
        int Pow(int x, int n)  // O(logn)의 시간복잡도
        {
            if (n == 1)
            {
                return x;
            }

            int result = Pow(x, n / 2); // 아래 식이랑 똑같은 의미인데 이건 홀수 감안 안했다함
            return result * result;

            /*
            if (n % 2 == 0)
            {
                return Pow(x * x, n / 2);
            }
            else
            {
                return Pow(x * x, n / 2) * x;
            } */
        }

    }
}

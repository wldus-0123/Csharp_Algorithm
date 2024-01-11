﻿namespace _00._Algorithm
{
    internal class Program
    {
        /**********************************************************************************
         * 알고리즘 (Algorithm) : 문제를 풀기위한 보편적인 해결방법 / 순서
         * 
         * 문제를 해결하기 위해 정해진 진행절차나 방법
         * 컴퓨터에서 알고리즘은 어떠한 행동을 하기 위해서 만들어진 프로그램명령어의 집합
         **********************************************************************************/

        // < 알고리즘 조건>
        // 입력(0개 이상), 출력(최소 1개 이상의 결과), 명확성(모호x), 유한성(무한x), 효과성(실행가능성)

        /**********************************************************************************************
         * 자료구조 (DataStructure) : 데이터를 효율적으로 활용하기 위한 방법 및 수단
         * 
         * 프로그래밍에서 데이터를 효율적인 접근 및 수정을 가능케 하는 자료의 조직, 관리, 저장을 의미
         * 데이터 값의 모임, 또 데이터 간의 관계, 그리고 데이터에 적용할 수 있는 함수나 명령을 의미
         **********************************************************************************************/

        // < 자료구조의 형태 >
        //1. 선형구조 : 자료 간 관계가 1:1 - 배열, 연결리스트, 스택, 큐, 덱
        //2. 비선형구조 : 자료 간 관계가 1 : 다 / 다 : 다 - 트리, 그래프


        /***************************************************************************
        * 알고리즘 성능
        * 
        * 효율적인 문제해결을 위해선 알고리즘의 성능을 판단할 수 있는 기준이 필요 (어떤 상황에 뭐가 빠른지)
        * 상황에 따라 적합한 알고리즘을 선택할 수 있도록 하는 기준
        ***************************************************************************/

        // < 알고리즘 평가 기준 > : 시간 / 공간
        // 컴퓨터에서 알고리즘과 자료구조의 평가는 시간과 공간 두 자원을 얼마나 소모하는지가 효율성의 중점이다
        // 일반적으로 시간을 위해 공간이 희생되는 경우가 많음
        // 시간 복잡도: 알고리즘의 시간적 자원 소모량
        // 공간 복잡도: 알고리즘의 공간적 자원 소모량


        // <Big - O 표기법 >
        // 알고리즘의 복잡도를 나타내는 접근표기법 ( = 사실상 연산횟수) : 대략적 판단기준
        // 데이터 증가량에 따른 시간 증가량을 계산
        // 가장 높은 차수의 계수와 나머지 모든 항을 제거하고 표기
        // 알고리즘의 대략적인 효율을 파악할 수 있는 수단
        
        //ex. n을 n번 더하는 3가지 방법
        int Case1(int n)
        {
            int sum = 0;
            sum = n * n;
            return sum;
        }
        int Case2(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += n;
            return sum;
        }
        int Case3(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sum++;
            return sum;
        }

        // 입력값       Case1	    Case2   	   Case3
        // n = 1            1           1              1
        // n = 10           1          10            100
        // n = 100          1         100         10,000
        // n = 1000         1        1000      1,000,000
        // Big-O		 O(1)	     O(n)   	   O(n²)        ( 괄호 안 : 연산이 몇 번 수행되는지 )

        //ex. O(n+3) -> 가장 높은 차수의 계수를 제외하고는 무시함

        // < 수행 시간 분석 >
        // 알고리즘의 성능은 상황에 따라 수행 시간이 달라짐
        // 수행 시간을 분석하는 경우 평균의 상황과 최악의 상황을 기준으로 평가함
        // 최선의 상황의 경우 알고리즘의 성능을 분석하는 수단으로 적합하지 않음 (운빨)

        int FindIndex(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++) // 전체 반복하면서 한개씩 비교해서 찾기
            {
                if (array[i] == value)
                    return i;
            }
            return -1;
        }
        // 최선   평균   최악
        // O(1)   O(n)   O(n)

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
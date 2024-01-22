namespace _08._DesignTechnique
{
    internal class Program
    {
        /*******************************************************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
		 * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
		 ********************************************************************************************/

        // 재귀(REcursion) : 어떠한 것을 정의할 때 자기 자신을 참조하는 것
        // ( 함수 정의 시 본인을 이용하여 표현 )
        
        // 재귀함수의 조건 - 조건 해당안하면 사용 못함
        // 1. 함수 내용 중 자기자신함수를 다시 호출해야 함 ( 함수 내에서 본인이름 사용할 수 있음)
        // 2. 종료조건이 있어야 함 ; 없으면 무한 도르마무 - 스택 오버플로우 발생

        // (사용 예시)
        // Factorial (x! = x * (x-1)) : 정수를 1이 될 때까지 차감하며 곱한 값
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1


        int Factorial(int x)
        {
            if (x == 1)
                return 1;  // 여기서는 얘가 종료조건임
            else
                return x * Factorial(x - 1);  // 지가 지 호출 가능
        }


        // 예시 - 폴더삭제 ( 백트래킹 기법 )
        void RemoveDir(Directory directory)
        {
            foreach(Directory dir in directory.childDir)
            {
                RemoveDir(dir);
            }
            Console.WriteLine("폴더 내 파일 모두 삭제");
        }

        struct Directory
        {
            public List<Directory> childDir;    
        }

        static void Main(string[] args)
        {
            // 연속합

            int[] values = { 10, -4, 3, 1, 5, 6, -35, 12, 21, -1 };
            int max = int.MinValue;

            // ex) [2,4] : 2~4 더한값
            int[,]result = new int[values.Length, values.Length];

            for(int i = 0; i<values.Length; i++)
            {
                result[i, i] = values[i];
                if(max < values[i])
                {
                    max = values[i];
                }
            }

            for(int start = 0; start < values.Length; start++)
            {
                for(int end = start; end<values.Length; end++)
                {
                    result[start, end] = result[start, end - 1] + values[end];
                    if (max < result[start, end])
                    {
                        max = result[start, end];
                    }
                }
            }
           
        }
    }
}

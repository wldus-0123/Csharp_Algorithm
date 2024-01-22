using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort
{
    internal class Sorting
    {
        // 1. 선택 정렬
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬하는 기법
        // 선택된 값을 해당 자리에 있는 값과 자리 변경하여 정렬함
        // 시간복잡도 -  O(n²) : 2중반복이라서 
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O

        public static void SelectionSort(IList<int> list, int start, int end)  // IList : 배열, 리스트 모두 적용하고 싶을 때 사용하는 클래스
        {
            for(int i = start; i <= end; i++) // 처음부터 끝까지 반복
            {
                int minIndex = i; // 가장작은 값의 위치는 i로 고정
                for(int j = i + 1; j <= end; j++) //다음값과 비교하여 제일 작은 값 위치 확인
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j; // 더 작은 값을 발견했을 때, 최솟값 변경
                    }
                }
                Swap(list, i, minIndex); // 제일 작은값의 위치를 순서대로 위치변경
            }
        }




        // 2. 삽입정렬
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬하는 방식
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(IList<int> list, int start, int end)
        {
            for(int i = start; i <= end; i++)
            {
                for(int j =i; j >=1; j--)  // 뒤에서부터 비교하면서 자리 찾기
                {
                    if (list[j - 1] < list[j])  // 앞자리 친구랑 비교했는데 내가 더 클 때
                    {
                        break; // 끝냄 걍 지 자리에 있음
                    }
                    Swap(list, j - 1, j); // 앞자리 친구랑 비교했는데 내가 더 작으면 걔랑 위치 변경
                }
            }
        }


        // 3. 버블정렬
        // 서로 인접한 데이터를 비교하여 정렬 ( 큰 데이터 먼저 뒤에 쌓임 )
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for(int i = start; i<=end-1; i++)  // 처음부터 끝나기 직전까지 진행
            {
                for(int j = start; j < end - start; j++)
                {
                    if (list[j] > list[j + 1]) // 뒤에 친구랑 나랑 비교했는데 내가 더 클 때
                    {
                        Swap(list, j, j + 1); // 뒤에 친구랑 나랑 위치변경
                    }
                }
            }
        }


        // 탐색시간 줄여주기 위해서 다른 방법을 찾아보기 : 정렬에서 분할정복을 해보쟈

        // 4. 병합정렬 : 먼 소린지 몰겠음
        // 데이터를 2분할하여 정렬 후 합병하는 방식
        // 시간복잡도 : O(nlogn)
        // 공간복잡도 : O(n)
        // (단점 : 데이터 갯수만큼의 추가적인 메모리가 필요함 (추가저장소가 필요함))
        
        public static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end)  // 하나일 때는 안함
                return;

            int mid = (start + end) / 2;        // 중간값 구하기
            MergeSort(list, start, mid);        // 반분할 1
            MergeSort(list, mid+1, end);        // 반분할 2
            Merge(list, start, mid, end);       // 정렬해서 합치기
        }

        public static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();  // 임시 저장소 생성
            // 가장 앞서있는 데이터끼리 비교하기
            int leftINdex = start;
            int rightIndex = mid+1;

            while(leftINdex<=mid && rightIndex <= end)
            {
                if (list[leftINdex] < list[rightIndex])  // 왼쪽 값이 오른쪽 값보다 작을 때
                {
                    sortedList.Add(list[leftINdex]);  
                    leftINdex++;
                }
                else
                {
                    sortedList.Add(list[rightIndex]);
                    rightIndex++;
                }
            }

            if(leftINdex>mid)  //왼쪽이 먼저 빈 경우
            {
                for(int i = rightIndex; i<=end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else // 오른쪽이 먼저 빈 경우
            {
                for(int i = leftINdex; i<=mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            for(int i = 0; i < sortedList.Count; i++)
            {
                list[start+i] = sortedList[i];
            }
        }


        // 5. 퀵 정렬
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 보통 피벗은 맨 앞의 것으로 선정하나 랜덤으로 선정해도 상관 ㄴ
        // 시간복잡도 = 평균: O(nlogn) / 최악 : O(n²)
        // 공간복잡도 = O(1)
        // (단점: 최악의 경우 (피벗이 최소값 / 최대값) 시간복잡도가 O(n²))

        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = start; // 피벗 위치 선정
            int left = pivot + 1; //left는 피벗 다음위치로 선정
            int right = end; // right는 맨 끝으로 선정

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left<right) // left가 pivot보다 작은 한 계속 이동
                {
                    left++;
                }
                while (list[right] > list[pivot] && left <=right) // right가 pivot보다 큰 한 계속 이동
                {
                    right--;
                }

                if(left < right)  // 엇갈리지 않았을 경우
                {
                    Swap(list, left, right);
                }
                else // 엇갈렸을 경우
                {
                    Swap(list, pivot, right);
                    break;
                }
            }

            QuickSort(list, start, right - 1); // pivot 기준 작은 애들끼리 정렬
            QuickSort(list, right + 1, end); // pivot 기준 큰 애들끼리 정렬
        }


        // 6. 힙 정렬 : 레지스트 친화력이 낮다..? 캐시메모리?
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 시간복잡도 = O(nlogn)
        // 공간복잡도 = O(1)
        // 

        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }


        // 퀵 정렬 VS 힙 정렬 : 이론상은 힙정렬이 더빠르지만 실제로는 퀵정렬이 더 빠름
        // 왜? : 캐쉬 적중률 ( 퀵 정렬 : 연속적인 메모리 사용 / 힙 정렬 : 연속적이지 않은 메모리 사용 - 캐시메모리의 효율적 사용이 불가능 )


        // C# 정렬 = IntroSort 인트로 정렬 < .Sort();>
        // 하이브리드 정렬 : 정렬하다가 상황보고 더 적합한 방식 선택 (퀵 정렬, 힙 정렬, 삽입 정렬을 섞어서 사용)
        // 퀵 정렬로 시작 -> 최악의 상황에 가까워질 경우 -> 힙 정렬로 전환 -> 데이터가 특정 임계치(16) 미만일 경우 -> 삽입정렬로 전환
        // (갯수가 적을 때는 삽입정렬이 더 빠를 수도 있음)


        public static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}

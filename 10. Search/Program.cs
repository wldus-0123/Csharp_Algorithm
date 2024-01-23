namespace _10._Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 순차탐색
            int[] array = new int[] { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };

            int indexOf = Array.IndexOf(array, 2);
            int result = Searching.SequentialSearch(array, 5);
            Console.WriteLine($"순차탐색 결과 위치 : {indexOf}");
            Console.WriteLine($"구현한 결과 위치 : {result}");

            // 이진탐색 : 정렬이 되어있어야만 찾을 수 있음 (정렬 안되어있으면 제대로된 값 안나옴)
            Console.WriteLine("정렬 전");
            int binarySearch;
            int result2;
            binarySearch = Array.BinarySearch(array, 2);
            result2 = Searching.BinarySearch(array, 2);
            Console.WriteLine($"정렬 전 이진탐색 결과 : {binarySearch}");
            Console.WriteLine($"정렬 전 이진탐색 결과 : {result2}");

            Array.Sort(array);

            Console.WriteLine("정렬 후");
            binarySearch = Array.BinarySearch(array, 2);
            result2 = Searching.BinarySearch(array, 2);
            Console.WriteLine($"정렬 후 이진탐색 결과 : {binarySearch}");
            Console.WriteLine($"정렬 후 이진탐색 결과 : {result2}");
        }
    }
}

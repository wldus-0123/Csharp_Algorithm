using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<Tkey,TValue> where Tkey : IEquatable<Tkey>   // IEquatable 비교하는 놈이랑 같냐
    {
        private const int DefaultCapacity = 1000; // 기본 테이블 크기 (소수인게 좋음)

        private struct Entry
        {
            public enum State { None, Using, Deleted } // 열거형으로 해당 엔트리가 사용O,X, 지워진 것인지 상태 확인할 수 있게

            public State state;
            public Tkey key;
            public TValue value;
        }

        private Entry[] table; // key값과 value를 함께 저장할 수 있는 배열 생성
        private int usedCount; // 몇개있는지

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];     // 기본테이블 크기의 배열 생성
            usedCount = 0;                              //  현재 테이블 내 데이터 갯수
        }

        public TValue this[Tkey key]
        {
            get
            {
                if(Find(key,out int index))
                {
                    return table[index].value;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            set
            {
                if(Find(key, out int index))
                {
                    table[index].value = value;
                }
                else
                {
                    Add(key, value);
                }

            }
        }
        public void Add(Tkey key, TValue value) // Add 구현
        {
            if(Find(key, out int index)) // key 값으로 있는지 먼저 확인
            {
                throw new InvalidOperationException("Already exist key");
            }
            else
            {
                if(usedCount > table.Length * 0.7f)  // 용량이 70퍼정도 차면 리해싱 ㄱㄱ
                {
                    ReHashing();
                }

                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
                usedCount++;
            }
        }

        public bool Remove(Tkey key)
        {
            if(Find(key, out int index))
            {
                table[index].state = Entry.State.Deleted;
                return true;
            }
            else
            {
                return false;  // 못찾았어요
            }
        }

        public bool ContainsKey(Tkey key)  // key가 테이블 안에 있나요???
        {
            if(Find(key, out int index)) // 있슴다
            {
                return true;
            }
            else // 없슴다
            {
                return false;
            }
        }

        private bool Find(Tkey key, out int index)
        {
            index = Hash(key);  //key값을 해싱해서 index로 변환

            for(int i = 0; i < table.Length; i++)
            {
                if (table[index].state == Entry.State.None) // 자리가 비어있는 경우
                {
                    return false;
                }
                else if (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))  // key 값이 index에 들어있는 key 값이랑 동일한한 경우
                    {
                        return true; // 찾았당
                    }
                    else
                    {
                        // 다음칸으로 이동
                        index = Hash2(index);
                    }

                }
                else // if(table[index].state == Entry.State.Deleted) 어떤 데이터가 이미 지워진 자리일 때
                {
                    // 다음칸으로 이동
                    index = Hash2(index);
                }
            }

            index = -1;
            throw new InvalidOperationException();
            
        }

        private int Hash(Tkey key)  // 해시함수 생성 
        {
            return Math.Abs(key.GetHashCode() % table.Length);  
            // GetHashCode 는 음수도 포함되어있어서 절대값으로 바꿔줘야함
        }

        private int Hash2(int index)
        {
            // 선형탐사
            return(index+1)%table.Length;

            // 제곱탐사랑 이중해싱도 있음
        }

        private void ReHashing()
        {
            Entry[] oldTable = table;
            table = new Entry[table.Length*2];
            usedCount = 0;

            for(int i = 0; i < oldTable.Length; i++)
            {
                Entry entry = oldTable[i];
                if(entry.state == Entry.State.Using)  // 전부 순회해서 다시 해싱 후 집어넣기
                {
                    Add(entry.key, entry.value);
                }
            } 
        }
    }
}

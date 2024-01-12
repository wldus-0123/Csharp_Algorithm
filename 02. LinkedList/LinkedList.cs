using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Datastructure
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get {return count; } }


        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if(count == 0)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(head, newNode);
            }
            
            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T>node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (count == 0)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeAfter(tail, newNode);
            }
 
            return newNode;

        }

        public LinkedListNode<T> AddAfter(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            InsertNodeAfter(head, newNode);
            return newNode;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(LinkedListNode<T> node)
        {
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            RemoveNode(head);
        }

        public void RemoveLast()
        {
            RemoveNode(tail);
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> node = head;
            if (value == null)
            {
                while (node != null)
                {
                    if (null == node.Value)
                        return node;
                    else
                        node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    if (value.Equals(node.Value))
                        return node;
                    else
                        node = node.next;
                }
            }

            return null;
        }
        private void InsertNodeBefore(LinkedListNode<T>node, LinkedListNode<T> newNode)
        {


            // 1. newNode의 next를 node로
            newNode.next = node;

            // 2. newNode의 prev를 node의 prev로
            newNode.prev = node.prev;  // prevNode가 없는 경우는 null로 표시됨


            if (node == head) // 3-1. node의 prev가 없을 때 (next가 head일 때) head를 newNode로
            {
                head = newNode;  // 새로운 노드를 head로 설정해주기
            }
            else // 3-2. node의 prev가 있을 때 next를 newNode로
            {
                node.prev.next = newNode;
            }

            // 4. node의 prev를 newNode로
            node.prev = newNode;

            count++;
        }

        public void InsertNodeAfter(LinkedListNode<T>node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;
            newNode.next = node.next;

            if (node == tail)
            {
                tail = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }

            node.next = newNode;

            count++;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            head = newNode;
            tail = newNode;
            count++;
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }
    }

    public class LinkedListNode<T>
    {
        private T value;

        public LinkedListNode<T> prev; // 참조변수
        public LinkedListNode<T> next; // 참조변수

        public LinkedListNode(T value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
        }

        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }

        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get {  return next; } }
        public T Value { get { return value; } set { this.value = value; } }

    }
}

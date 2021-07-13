using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class LinkedLists
    {
        public void AddFirst(int item)
        {
            Node node = NodeMaker(item);

            if (CheckEmpty(_first))
            {
                InitializeSingleNode(item);
            }
            else
            {
                node.Next = _first;
                _first = node;
            }
        }

        public void AddLast(int item)
        {
            Node node = NodeMaker(item);

            if (CheckEmpty(_first))
            {
                InitializeSingleNode(item);
            }
            else
            {
                _last.Next = node;
                _last = node;
            }
        }

        public void DeleteFirst()
        {
            if (CheckEmpty(_first))
                throw new InvalidOperationException();
            if (_first == _last)
            {
                _first = _last = null;
                return;
            }
            Node temp = _first.Next;
            _first.Next = null;
            _first = temp;
        }

        public void DeleteLast()
        {
            if (CheckEmpty(_first))
                throw new InvalidOperationException();

            if (_first == _last)
            {
                _first = _last = null;
                return;
            }

            Node previous = PreviousNode(_last);
            _last = previous;
            _last.Next = null;
        }

        public void Remove(int item)
        {
            if (CheckEmpty(_first))
                throw new InvalidOperationException();

            if (_first == _last)
            {
                _first = _last = null;
                return;
            }

            if (item == _first.Value)
            {
                DeleteFirst();
                return;
            }

            if (item == _last.Value)
            {
                DeleteLast();
                return;
            }

            Node current = _first;
            while (!CheckEmpty(current))
            {
                if (current.Value == item)
                {
                    Node previous = PreviousNode(current);
                    previous.Next = current.Next;
                }

                current = current.Next;
            }
        }

        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(int item)
        {
            Node current = _first;
            int count = 0;

            while (!CheckEmpty(current))
            {
                if (current.Value == item) 
                    return count;
                count++;
                current = current.Next;
            }
            return -1;
        }

        public int GetNodeAt(int index)
        {
            if (index < 0)
                throw new ArgumentException("Invalid Argument supplied : Index can't be negative.");

            if (CheckEmpty(_first))
                throw new InvalidOperationException();

            Node current = _first;
            int value = current.Value;
            while (!CheckEmpty(current))
            {
                if (index == IndexOf(value) + 1)
                    return value;
                current = current.Next;
            }

            return value;
        }

        public int Count()
        {
            if (CheckEmpty(_first)) return 0;

            Node current = _first;
            int counter = 0;
            while (!CheckEmpty(current))
            {
                counter++;
                current = current.Next;
            }

            return counter;
        }

        public void Reverse()
        {
            Node previous = _first;
            Node current = _first.Next;
            while (!CheckEmpty(current))
            {
                Node next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _last = _first;
            _last.Next = null;
            _first = previous;
        }

        public int[] GetItems()
        {
            Node current = _first;
            List<int> container = new List<int>();
            
            while (!CheckEmpty(current))
            {
                container.Add(current.Value);
                current = current.Next;
            }

            return container.ToArray();
        }

        // Implementation details
        // Contains private data & methods of this class
        // Editing them might result some breaking changes

        private class Node
        {
            public readonly int Value;
            public Node Next;

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node _first;
        private Node _last;

        private static Node NodeMaker(int item)
        {
            Node node = new Node(item);
            return node;
        }

        private static bool CheckEmpty(Node node)
        {
            return node == null;
        }

        private void InitializeSingleNode(int item)
        {
            _first = _last = NodeMaker(item);
        }

        private Node PreviousNode(Node node)
        {
            if (CheckEmpty(_first) || node == _first)
                throw new InvalidOperationException();
            
            Node current = _first;
            while (!CheckEmpty(current))
            {
                if (current.Next == node) return current;
                current = current.Next;
            }

            return null;
        }
    }
}
using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{
    [Serializable, KnownType(typeof(ExampleClass))]
    public class ExampleClass { /* ... */ }
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        private int _count = 0;

        public SLL()
        {
            this.Head = null;
        }


        public void Add(User value, int index)
        {
            // create new node
            Node freshNode = new Node();

            // Assign value to new node
            freshNode.Value = value;

            Node node = Head;

            if (index == 0)
            {
                node = freshNode;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;                    
                }
                node.Next = freshNode;
            }           

            // increment Count
            _count++;
        }

        public void AddFirst(User value)
        {
            // create new node
            Node freshNode = new Node();

            // Assign value to new node
            freshNode.Value = value;

            // create variable (old head node) and adding node at head
            Node oldHead = Head;

            // Assign head to new node
            Head = freshNode;

            // assign next to old head node 
            Head.Next = oldHead;

            // increment Count
            _count++;
        }

        public void AddLast(User value)
        {
            // create new node
            Node freshNode = new Node();

            // Assign value to new node
            freshNode.Value = value;

            if (Head == null)
            {
                Head = freshNode;
            }
            else
            {
                Node node = Head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = freshNode;
            }

            // increment Count
            _count++;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(User value)
        {
            // create new node
            Node freshNode = new Node();
            Node node = Head;

            // Assign value to new node
            freshNode.Value = value;

            // check if the value is not null and return true
            if (node.Value == freshNode.Value)
            {
                return true;
            }
            else
            {
                while (node.Next != null && node.Next.Next != null)
                {
                    node = node.Next;
                }
                if (node.Value == freshNode.Value)
                {
                    return true;
                }
            }
            return false;

        }

        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node.Value;
        }

        public int IndexOf(User value)
        {
            Node freshNode = new Node();
            freshNode.Value = value;
            Node node = Head;

            while (node.Value != null)
            {
                int i = 0;
                if (node.Value == freshNode.Value)
                {
                    return i;
                }               
                while (node.Next.Value != freshNode.Value)
                {
                    node = node.Next;
                    i++;
                }
                return i+1;                
            }
            return -1;
        }

        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(int index)
        {
            Node node = Head;
            Node nodeJunk = new Node();
            for (int i = 0; i < index - 1; i++) 
            {
                node = node.Next;

            }
            nodeJunk.Value = node.Next.Value;
            node.Next = node.Next.Next;
            nodeJunk.Next = null;

            _count--;
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                _count--;
            }
            else
            {
                throw new Exception("Can Not Remove");
            }
            
        }

        public void RemoveLast()
        {
            if (Head != null)
            {
                Node node = Head;
                while (node.Next != null && node.Next.Next != null)
                {
                    node = node.Next;
                }

                node.Next = null;
                _count--;
            }
            else
            {
                throw new Exception("Can Not Remove");
            }
        }

        public void Replace(User value, int index)
        {
            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            node.Value = value;
            
        }

        //Reverse the order of the nodes in the linked list.
        public void Reverse()
        {
            // create variable to hold how long the list is (Don't need to move the last thing on the list so -1)
            int i = Count() - 1;
            int ii = Count() - 1;

            //loop through the list adding things in reverse order (instead of replacing so we don't lose values)
            while (i > 0) 
            {                                
                this.AddLast(GetValue(i));
                                
                i--;
            }
            
            //removing the first part of this list until when was at the end becomes the new Head
            while (ii > 0)
            {
                this.RemoveFirst();

                ii--;
            }
            
        }
    }
}

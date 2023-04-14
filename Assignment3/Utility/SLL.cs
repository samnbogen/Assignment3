using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{
    [Serializable, KnownType(typeof(User))]
    
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

            //
            Node oldnode = new Node();

            if (index == 0)
            {
                //if node is being added to the Head
                Head = freshNode;
                Head.Next = node;
            }
            else
            {
                //looping through to find the index
                for (int i = 0; i < index -1; i++)
                {
                    node = node.Next;                    
                }
                //assign the node in the position we want to move to as oldnode
                oldnode = node.Next;    

                //move freshnode into that spot
                node.Next = freshNode;

                //tell freshnode to point to oldnode
                node.Next.Next = oldnode;
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
            bool found = false;
            // check if the Head value is the same and returns true
            while (node != null)
            {
                if (node.Value.Id == freshNode.Value.Id)
                {
                    found = true;
                }
                node = node.Next;
            }            
            return found;                        
        }

        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            Node node = Head;
            //loops through the nodes untill it finds the one one at the right index
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            //returns the value of the found node
            return node.Value;
        }

        public int IndexOf(User value)
        {
            Node freshNode = new Node();
            freshNode.Value = value;
            Node node = Head;

            while (node.Value != null)
            {
                int i = 1;
                if (node.Value == freshNode.Value)
                {
                    //returns the value of Head node as 1
                    return i;
                }               
                while (node.Next.Value != freshNode.Value)
                {
                    node = node.Next;
                    i++;
                }
                //returns the index of the found node
                return i;                
            }
            return -1;
        }

        public bool IsEmpty()
        {
            //checks if the list in empty
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

            //create node to delete
            Node nodeJunk = new Node();

            //find the node at index
            for (int i = 0; i < index - 1; i++) 
            {
                node = node.Next;
            }
            //get the value to delete
            nodeJunk.Value = node.Next.Value;

            //move the nodes over
            node.Next = node.Next.Next;

            //junk the node by cutting the connection
            nodeJunk.Next = null;

            //decrease count
            _count--;
        }

        public void RemoveFirst()
        {
            //if the list is there
            if (Head != null)
            {
                Node oldhead = Head;
                //reassign Head
                Head = Head.Next;

                oldhead.Next = null;
                oldhead = null;

                //lower the count
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
                Node junknode = new Node();
                Node node = Head;
                //find the node before the last one
                while (node.Next != null && node.Next.Next != null)
                {
                    node = node.Next;
                }
                //tell the second last node to break up with the last node
                junknode = node.Next;
                node.Next = null;
                junknode = null;

                //lower the count!!!
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

            //finding the index 
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            //check if the node has a value
            if (node == null)
            {
                throw new Exception("Nothing is there");
            }
            else
            {
                //reassigning the value to the node at index
                node.Value = value;
            }                       
        }

        //Reverse the order of the nodes in the linked list.
        public void Reverse()
        {
            // create variable to hold how long the list is (Don't need to move the last thing on the list so -1)
            int i = Count() -1;
            int ii = Count();

            //loop through the list adding things in reverse order (instead of replacing so we don't lose values)
            while (i >= 0) 
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

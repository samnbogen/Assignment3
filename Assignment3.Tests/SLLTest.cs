using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    internal class SLLTest
    {
        private SLL users;

        [SetUp] 
        public void Setup()
        {
            users = new SLL();

            users.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

        }

        [TearDown]
        public void TearDown() 
        { 
            users.Clear();

            Assert.AreEqual(null, users.Head);
        }

        [Test]
        public void TestPrepend()
        {
            User user = new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44");
            users.AddFirst(user);
            
            //assert that count is 5
            Assert.AreEqual(5, users.Count());

            //Assert Jane Doe is the new Head
            Assert.AreEqual("Jane Doe", users.Head.Value.Name);
            Assert.AreEqual(1, users.IndexOf(user));

            //Assert Joe Blow moved over
            Assert.AreEqual("Joe Blow", users.Head.Next.Value.Name);
        }

        [Test]
        public void TestPostPend()
        {
            User user = new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44");
            users.AddLast(user);

            //Assert the list count went up
            Assert.AreEqual(5, users.Count());

            //check the Jane Doe got added to the end
            Node node = users.Head;
            while (node.Next != null)
            {
            node = node.Next;            
            }
            Assert.AreEqual("Jane Doe", node.Value.Name);

            //assert that Jane Doe has the proper index
            Assert.AreEqual(4, users.IndexOf(user));   
                        
        }

        [Test]
        public void InsertAtIndex()
        {
            users.Add(new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44"), 1);

            //assert that count is 5
            Assert.AreEqual(5, users.Count());

            //Assert list has Jane Doe at the right location      
            Assert.AreEqual("Jane Doe", users.Head.Next.Value.Name);

            //Assert Joe Schmoe moved into the third spot
            Assert.AreEqual("Joe Schmoe", users.Head.Next.Next.Value.Name);

            //Add Bob Vance as the Head
            users.Add(new User(5, "Bob Vance", "BobVance@refrigeration.com", "IloveCold"), 0);

            //Assert count is now 6!!!
            Assert.AreEqual(6, users.Count());

            //Assert Bob Vance is now at the Head
            Assert.AreEqual("Bob Vance", users.Head.Value.Name);

            //Assert Jan Doe moved
            Assert.AreEqual("Jane Doe", users.Head.Next.Next.Value.Name);
        }

        [Test]
        public void Replaced()
        {
            users.Replace(new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44"), 1);

            //assert that count is 4
            Assert.AreEqual(4, users.Count());

            //Assert list has Jane Doe       
            Assert.AreEqual("Jane Doe", users.Head.Next.Value.Name);
                        
        }

        [Test]
        public void DeleteFirst()
        {
            users.RemoveFirst();

            //assert that count is 3
            Assert.AreEqual(3, users.Count());

            //Assert list has Joe Schmoe as the Head now
            Assert.AreEqual("Joe Schmoe", users.Head.Value.Name);

            //assert the list no longer has Joe Blow
            User user = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.IsFalse(users.Contains(user));
        }

        [Test]
        public void DeleteLast()
        {
            users.RemoveLast();

            //assert that count is 3
            Assert.AreEqual(3, users.Count());

            //Assert the end of the list is now Colonel Sanders
            Node node = users.Head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            Assert.AreEqual("Colonel Sanders", node.Value.Name);
                        
            Assert.AreEqual("Joe Blow", users.Head.Value.Name);


            //check that the list no longer has Ronald McDonald
            User user = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            Assert.IsFalse(users.Contains(user));
            
        }

        [Test]
        public void DeleteMiddle()
        {
            users.Remove(1);

            //assert that count is 3
            Assert.AreEqual(3, users.Count());

            //Assert list has Colonel Sanders moved from the third node into the second node
            Assert.AreEqual("Colonel Sanders", users.Head.Next.Value.Name);

        }

        [Test]
        public void Find()
        {
            User user = (new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            User user2 = (new User(1, "Joe Blow", "jblow@gmail.com", "password"));

            //assert list has certain users
            Assert.IsTrue(users.Contains(user));
            Assert.IsTrue(users.Contains(user2));
            
        }

        [Test]
        public void ReverseOrder()
        {
            users.Reverse();

            //assert that count is 4
            Assert.AreEqual(4, users.Count());

            //Assert list has Ronald McDonald is now the head
            Assert.AreEqual("Ronald McDonald", users.Head.Value.Name);

            //Assert Colonel Sanders is in the second spot
            Assert.AreEqual("Colonel Sanders", users.Head.Next.Value.Name);
            
            //check that Joe Blow in now at the end
            Node node = users.Head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            Assert.AreEqual("Joe Blow", node.Value.Name);
        }
    }
}

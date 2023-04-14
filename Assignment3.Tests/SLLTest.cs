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
            users.AddFirst(new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44"));

            //assert that count is 5
            Assert.AreEqual(5, users.Count());

            //Assert Jane Doe is the new Head
            Assert.AreEqual("Jane Doe", users.Head.Value.Name);
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
            
            Assert.AreEqual(user, users.GetValue(users.IndexOf(user)));
        }

        [Test]
        public void InsertAtIndex()
        {
            users.Add(new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44"), 1);

            //assert that count is 5
            Assert.AreEqual(5, users.Count());

            //Assert list has Jane Doe at the right location      
            Assert.AreEqual("Jane Doe", users.Head.Next.Value.Name);
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
            Assert.IsTrue(users.Contains(user2));
            Assert.IsTrue(users.Contains(user));
        }

        [Test]
        public void ReverseOrder()
        {
            users.Reverse();

            //assert that count is 4
            Assert.AreEqual(4, users.Count());

            //Assert list has Ronald McDonald is now the head
            Assert.AreEqual("Ronald McDonald", users.Head.Value.Name);
        }
    }
}

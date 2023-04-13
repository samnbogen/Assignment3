﻿using Assignment3.Utility;
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
        }

        [Test]
        public void TestPrepend()
        {            
            //assert that count is 4
            Assert.AreEqual(4, users.Count());

            //Assert list has Joe Blow
            Assert.AreEqual("Joe Blow", users.Head.Value.Name);
        }

        [Test]
        public void TestPostPend()
        {
            User user = new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44");
            users.AddLast(user);


            Assert.AreEqual(5, users.Count());

            Node node = users.Head;
            while (node.Next != null)
            {
            node = node.Next;            
            }
            Assert.AreEqual("Jane Doe", node.Value.Name);

            Assert.AreEqual(4, users.IndexOf(user));     
        }

        [Test]
        public void InsertAtIndex()
        {
            users.Add(new User(5, "Jane Doe", "JaneDoe@outlook.com", "ilovedogs44"), 1);

            //assert that count is 5
            Assert.AreEqual(5, users.Count());

            //Assert list has Jane Doe       
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

            //Assert list has Joe Schmoe
            Assert.AreEqual("Joe Schmoe", users.Head.Value.Name);
        }

        [Test]
        public void DeleteLast()
        {
            users.RemoveLast();

            //assert that count is 3
            Assert.AreEqual(3, users.Count());

            //Assert list has Jane Doe
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
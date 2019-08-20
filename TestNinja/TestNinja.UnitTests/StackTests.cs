using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack _stack;
        
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack();
        }

        [Test]
        public void Push_ArgIsNull_ThrowNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_ArgIsValid_AddTheObjectToTheStack()
        {
            _stack.Push("abc");
            
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
    }
}
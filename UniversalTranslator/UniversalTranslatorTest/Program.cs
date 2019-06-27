using NUnit.Framework;
using UniversalTranslator;
using System;

namespace UniversalTranslatorTest
{
    [TestFixture]
    class Program
    {

        [Test]
        public void Invalid_missing_Column()
        {

            string[] push = { "105", "f" };
            Temperature test1 = new Temperature();

            Assert.Throws<InvalidOperationException>(() => test1.Valid(push));
        }
        [Test]
        public void Invalid_column_of_more()
        {

            string[] push = { "105", "f", "c", "c" };
            Temperature test1 = new Temperature();

            Assert.Throws<InvalidOperationException>(() => test1.Valid(push));
        }
        [Test]
        public void third_parameter_is_not_an_accepted_value()
        {

            string[] push = { "105", "f", "wr" };
            Temperature test1 = new Temperature();

            Assert.Throws<System.InvalidOperationException>(() => test1.Valid(push));
        }

        [Test]
        public void second_parameter_is_not_an_accepted_value()
        {

            string[] push = { "105", "x", "f"};
            Temperature test1 = new Temperature();

            Assert.Throws<System.InvalidOperationException>(() => test1.Valid(push));
        }
        [Test]
        public void first_parameter_is_not_a_number()
        {

            string[] push = { "x", "f", "Z" };
            Temperature test1 = new Temperature();

            Assert.Throws<System.InvalidOperationException>(() => test1.Valid(push));
        }
    }
}

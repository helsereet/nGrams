using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

//            Assert.That(result, Is.InstanceOf<NotFound>());
            Assert.That(result, Is.TypeOf<NotFound>());
        }
    }
}
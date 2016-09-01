using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TA.WebServices.Controllers;
using System.Collections.Generic;
using TA.Data;

namespace TA.WebServices.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
            var result = controller.GetOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

    }
}

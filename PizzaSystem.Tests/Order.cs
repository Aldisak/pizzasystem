using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaSystem.Application.Controllers;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace Tests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private OrderController _orderController = null!;
        private Mock<IService<Order>> _orderServiceMock = null!;

        [SetUp]
        public void Setup()
        {
            _orderServiceMock = new Mock<IService<Order>>();
            _orderController  = new OrderController(_orderServiceMock.Object);
        }
        
        [Test]
        public void Get_ValidId_ReturnsOkResult()
        {
            // Arrange
            var orderId = new Guid("dda5943e-ea9d-47f6-87c3-23eac318763a");
            var order   = GenerateOrder();
            _orderServiceMock.Setup(service => service.Get(order.Id)).Returns(order);

            // Act
            var result = _orderController.Get(id: orderId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(order));
            _orderServiceMock.Verify(service => service.Get(order.Id), Times.Once);
        }

        [Test]
        public void Update_ValidOrder_ReturnsOkResult()
        {
            // Arrange
            var order = GenerateOrder();
            _orderServiceMock.Setup(service => service.Update(order));

            // Act
            var result = _orderController.Update(order) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(order));
            _orderServiceMock.Verify(service => service.Update(order), Times.Once);
        }
        
        [Test]
        public void Delete_ValidId_ReturnsOkResult()
        {
            // Arrange
            var orderId = new Guid("dda5943e-ea9d-47f6-87c3-23eac318763a");
            var order   = GenerateOrder();
            _orderServiceMock.Setup(service => service.Delete(order.Id)).Returns(order.Id);

            // Act
            var result = _orderController.Delete(id: orderId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(order.Id));
            _orderServiceMock.Verify(service => service.Delete(order.Id), Times.Once);
        }
        
        [Test]
        public void GetAll_ReturnsOkResult()
        {
            // Arrange
            var orders = new List<Order> {GenerateOrder()};
            _orderServiceMock.Setup(service => service.GetAll()).Returns(orders);

            // Act
            var result = _orderController.GetAll() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(orders));
            _orderServiceMock.Verify(service => service.GetAll(), Times.Once);
        }

        private static Order GenerateOrder()
        {
            return new Order
            {
                Id         = (Id<Order>) new Guid("dda5943e-ea9d-47f6-87c3-23eac318763a"),
                OrderItems = new List<OrderItem>(),
                CustomerContact = new CustomerContact
                {
                    CustomerName = new CustomerName {FirstName = "Aleš", LastName = "Matějka"},
                    PhoneNumber  = new Phone {CountryCode      = "+420", Number   = 722007626},
                    Address = new Address
                    {
                        Street = "Vršovická", Number = "7/27", City = "Praha", State = "Česká republika", ZipCode = "10100"
                    }
                },
                Total = 1500,
                OrderDetails = new OrderDetails
                {
                    Status       = 0, 
                    DeliveryType = 0, 
                    CreatedAt    = new DateTime(2021, 06, 10, 19, 23, 47),
                    UpdatedAt    = new DateTime(2021, 07, 10, 19, 23, 47)
                }
            };
        }
    }
}

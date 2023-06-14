using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaSystem.Application.Controllers;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace Tests.Application
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
        public async Task Get_ValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedOrder = GenerateOrder();
            _orderServiceMock.Setup(service => service.Get(expectedOrder.Id))
                             .ReturnsAsync(expectedOrder);

            // Act
            var result = await _orderController.Get(expectedOrder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(expectedOrder));
        }

        [Test]
        public async Task Add_ValidOrder_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var       orderToAdd = GenerateOrder();
            var       addedOrder = GenerateAnotherOrder();
        
            _orderServiceMock.Setup(service => service.Add(orderToAdd))
                             .ReturnsAsync(addedOrder);

            // Act
            var result = await _orderController.Add(orderToAdd.Id, orderToAdd);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdAtActionResult = result;
            Assert.Multiple(() =>
            {
                Assert.That(createdAtActionResult.ActionName, Is.EqualTo(nameof(OrderController.Get)));
                Assert.That(createdAtActionResult.RouteValues!["id"], Is.EqualTo(addedOrder.Id));
                Assert.That(createdAtActionResult.Value, Is.EqualTo(addedOrder));
            });
        }

        [Test]
        public async Task Update_ValidOrder_ReturnsUpdatedOrder()
        {
            // Arrange
            var       updatedOrder = GenerateOrder();
            _orderServiceMock.Setup(service => service.Update(updatedOrder))
                             .ReturnsAsync(updatedOrder);

            // Act
            var result = await _orderController.Update(updatedOrder.Id, updatedOrder);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(updatedOrder));
        }
        
        [Test]
        public async Task Delete_ValidId_ReturnsDeletedOrder()
        {
            // Arrange
            var       deletedOrder = GenerateOrder();
            _orderServiceMock.Setup(service => service.Delete(deletedOrder.Id))
                             .ReturnsAsync(deletedOrder);

            // Act
            var result = await _orderController.Delete(deletedOrder.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(deletedOrder));
        }
        
        [Test]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var orders = new List<Order> {GenerateOrder()};
            _orderServiceMock.Setup(service => service.GetAll()).ReturnsAsync(orders);

            // Act
            var result = await _orderController.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(orders));
            _orderServiceMock.Verify(service => service.GetAll(), Times.Once);
        }

        private static Order GenerateOrder()
        {
            return new Order
            {
                Id         = 1,
                OrderItems = new List<OrderItem>(),
                CustomerContact = CustomerContact(),
                Total = 1500,
                OrderDetails = OrderDetails()
            };

            CustomerContact CustomerContact()
            {
                return new CustomerContact
                {
                    CustomerName = new CustomerName {FirstName = "Aleš", LastName = "Matějka"},
                    PhoneNumber  = new Phone {CountryCode      = "+420", Number   = 722007626},
                    Address = new Address
                    {
                        Street  = "Vršovická", HouseNumber = "7/27", City = "Praha", State = "Česká republika",
                        ZipCode = "10100"
                    }
                };
            }
            OrderDetails OrderDetails()
            {
                return new OrderDetails
                {
                    Status       = OrderStatus.Pending,
                    DeliveryType = DeliveryType.Delivery,
                    CreatedAt    = new DateTime(2021, 06, 10, 19, 23, 47),
                    UpdatedAt    = new DateTime(2021, 07, 10, 19, 23, 47)
                };
            }
        }

        private static Order GenerateAnotherOrder()
        {
            return new Order
            {
                Id         = 2,
                OrderItems = new List<OrderItem>(),
                CustomerContact = CustomerContact(),
                Total = 1300,
                OrderDetails = OrderDetails()
            };

            CustomerContact CustomerContact()
            {
                return new CustomerContact
                {
                    CustomerName = new CustomerName {FirstName = "Milan", LastName = "Hruška"},
                    PhoneNumber  = new Phone {CountryCode      = "+420", Number   = 606125169},
                    Address = new Address
                    {
                        Street  = "Gruzínská", HouseNumber = "17", City = "Praha", State = "Česká republika",
                        ZipCode = "10100"
                    }
                };
            }
            OrderDetails OrderDetails()
            {
                return new OrderDetails
                {
                    Status       = OrderStatus.Pending, 
                    DeliveryType = DeliveryType.TakeAway, 
                    CreatedAt    = new DateTime(2021, 04, 10, 19, 23, 47),
                    UpdatedAt    = new DateTime(2021, 04, 10, 20, 23, 47)
                };
            }
        }
    }
}

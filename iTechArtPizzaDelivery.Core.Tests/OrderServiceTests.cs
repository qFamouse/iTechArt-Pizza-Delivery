using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Core.Services.Shopping;
using Moq;
using Xunit;

namespace iTechArtPizzaDelivery.Core.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock = new();
        private readonly Mock<IDeliveryRepository> _deliveryRepositoryMock = new();
        private readonly Mock<IPromocodeRepository> _promocodeRepositoryMock = new();
        private readonly Mock<IPromocodeValidationService> _promocodeValidationServiceMock = new();
        private readonly Mock<IOrderValidationService> _orderValidationServiceMock = new();
        private readonly Mock<IIdentityService> _identityServiceMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        private OrderService InitializeOrderService()
        {
            return new OrderService(_orderRepositoryMock.Object, _paymentRepositoryMock.Object,
                _deliveryRepositoryMock.Object, _promocodeRepositoryMock.Object,
                _promocodeValidationServiceMock.Object, _orderValidationServiceMock.Object,
                _identityServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetUserDetailAsync_OrderNotNull_ReturnOrder()
        {
            #region Arrange

            _identityServiceMock.Setup(service => service.Id).Returns(1);

            var order = new Order();

            _orderRepositoryMock.Setup(repo => repo.GetDetailByQueryAsync(
                It.Is<OrderQuery>(oq => oq.Status == (short)Status.InProgress && oq.UserId == _identityServiceMock.Object.Id)).Result)
                .Returns(order);

            var orderService = InitializeOrderService();

            #endregion

            #region Act

            var result = orderService.GetDetailByUserAsync().Result;

            #endregion

            #region Assert

            Assert.NotNull(result);

            #endregion
        }

        [Fact]
        public async void GetUserDetailAsync_OrderIsNull_ThrowHttpStatusCodeException()
        {
            #region Arrange

            _identityServiceMock.Setup(service => service.Id).Returns(1);

            _orderRepositoryMock.Setup(repo => repo.GetDetailByQueryAsync(
                It.IsAny<OrderQuery>())).ReturnsAsync((Order)null);

            var orderService = InitializeOrderService();

            #endregion

            #region Act

            var result = orderService.GetDetailByUserAsync();

            #endregion

            #region Assert

            await Assert.ThrowsAsync<HttpStatusCodeException>(() => result);

            #endregion
        }
    }
}

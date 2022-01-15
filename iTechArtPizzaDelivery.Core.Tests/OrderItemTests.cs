using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;
using iTechArtPizzaDelivery.Core.Services.Shopping;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using Xunit;

namespace iTechArtPizzaDelivery.Core.Tests
{
    public class OrderItemTests
    {
        private readonly Mock<IOrderItemRepository> _orderItemRepositoryMock = new();
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
        private readonly Mock<IPizzaSizeRepository> _pizzaSizeRepositoryMock = new();
        private readonly Mock<IIdentityService> _identityServiceMock = new();
        private readonly Mock<IOrderValidationService> _orderValidationServiceMock = new();
        private readonly Mock<IOrderItemValidationService> _orderItemValidationServiceMock = new();

        private OrderItemService InitializeOrderItemService()
        {
            return new OrderItemService(_orderItemRepositoryMock.Object, _orderRepositoryMock.Object,
                _pizzaSizeRepositoryMock.Object, _identityServiceMock.Object,
                _orderValidationServiceMock.Object, _orderItemValidationServiceMock.Object);
        }

        [Fact]
        public async void InsertAsync_PizzaIsNull_ThrowException()
        {
            #region Arrange

            _pizzaSizeRepositoryMock.Setup(repo => repo.GetDetailByIdAsync(
                It.IsAny<Int32>())).ReturnsAsync((PizzaSize)null);

            var orderItemService = InitializeOrderItemService();

            #endregion

            #region Act

            var result = orderItemService.InsertAsync(new OrderItemInsertRequest()
            {
                PizzaSizesId = 1,
                Quantity = 1
            });

            #endregion

            #region Assert

            await Assert.ThrowsAsync<HttpStatusCodeException>(() => result);

            #endregion
        }

        [Fact]
        public void InsertAsync_PizzaAlreadyInOrder_AddingQuantityToItem()
        {
            #region Arrange

            var request = new OrderItemInsertRequest()
            {
                PizzaSizesId = 1,
                Quantity = 1
            };

            var pizzaIngredients = new List<PizzaIngredient>()
            {
                new PizzaIngredient() { Ingredient = new Ingredient()}
            };

            var pizzaSize = new PizzaSize()
            {
                Id = 1,
                PizzaIngredients = pizzaIngredients,
            };

            var orderItem = new OrderItem()
            {
                PizzaSizeId = 1,
                PizzaSize = pizzaSize,
                Quantity = 1
            };

            var orderItems = new List<OrderItem>()
            {
                orderItem
            };

            var order = new Order()
            {
                OrderItems = orderItems
            };

            _pizzaSizeRepositoryMock.Setup(repo => repo.GetDetailByIdAsync(
                It.IsAny<Int32>()).Result).Returns(pizzaSize);

            _orderRepositoryMock.Setup(repo => repo.GetDetailByQueryAsync(
                It.IsAny<OrderQuery>()).Result).Returns(order);

            _orderItemRepositoryMock.Setup(repo => repo.GetDetailByIdAsync(
                It.IsAny<Int32>()).Result).Returns(orderItem);

            var orderItemService = InitializeOrderItemService();

            #endregion

            #region Act

            var result = orderItemService.InsertAsync(request).Result;

            #endregion

            #region Assert

            Assert.Equal(2, result.Quantity);

            #endregion
        }

        [Fact]
        public void UpdateAsync_OrderItemSetQuantity_UpdatingOrderItem()
        {
            #region Arrange

            var request = new OrderItemUpdateRequest()
            {
                Quantity = 2
            };

            var pizzaIngredients = new List<PizzaIngredient>()
            {
                new PizzaIngredient() { Ingredient = new Ingredient()}
            };

            var pizzaSize = new PizzaSize()
            {
                Id = 1,
                PizzaIngredients = pizzaIngredients,
            };

            var orderItem = new OrderItem()
            {
                PizzaSizeId = 1,
                PizzaSize = pizzaSize,
                Quantity = 1
            };

            var orderItems = new List<OrderItem>()
            {
                orderItem
            };

            var order = new Order()
            {
                OrderItems = orderItems
            };

            _orderRepositoryMock.Setup(repo => repo.GetDetailByQueryAsync(
                It.IsAny<OrderQuery>()).Result).Returns(order);

            _orderItemRepositoryMock.Setup(repo => repo.GetDetailByIdAsync(
                It.IsAny<Int32>()).Result).Returns(orderItem);

            var orderItemService = InitializeOrderItemService();

            #endregion

            #region Act

            var result = orderItemService.UpdateByIdAsync(pizzaSize.Id, request).Result;

            #endregion

            #region Assert

            Assert.Equal(2, result.Quantity);

            #endregion
        }

        [Fact]
        public async void UpdateAsync_OrderItemIsNull_ThrowException()
        {
            #region Arrange

            _orderItemRepositoryMock.Setup(repo => repo.GetDetailByIdAsync(
                It.IsAny<Int32>())).ReturnsAsync((OrderItem) null);

            var orderItemService = InitializeOrderItemService();

            #endregion

            #region Act

            var result = orderItemService.UpdateByIdAsync(1, null);

            #endregion

            #region Assert

            await Assert.ThrowsAsync<HttpStatusCodeException>(() => result);

            #endregion
        }
    }
}
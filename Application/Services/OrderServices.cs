using Application.Repositories;
using Application.ViewModels.Order;
using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderServices : IHelpersServices<OrderViewModel>
    {
        private readonly OrderRepository _orderRepository;
        private readonly ClientRepository _clientRepository;
        public OrderServices(ApplicationContext dbContext)
        {
            _orderRepository = new(dbContext);
            _clientRepository = new(dbContext);
        }
        public async Task<OrderViewModel> Add(OrderViewModel vm)
        {
            Order order = new();
            order.DeliveryDate = vm.DeliveryDate;
            order.ClientId = vm.ClientId;
            order.ProductId = vm.ProductId;
            order.Amout = vm.Amout;

            order = await _orderRepository.AddAsync(order);

            OrderViewModel svm = new();
            svm.Id = order.Id;
            svm.DeliveryDate = order.DeliveryDate;
            svm.ClientId = order.ClientId;
            svm.ProductId = order.ProductId;
            svm.Amout = order.Amout;

            return svm;
        }

        public async Task Delete(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            await _orderRepository.DeleteAsync(order);
        }

        public async Task<List<OrderViewModel>> GetAllViewModel()
        {
            var orderList = await _orderRepository.GetAllWithIncludeAsync(new List<string> { "Product" });

            return orderList.Select(order => new OrderViewModel
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                ProductId = order.ProductId,
                ProductName = order.Product.ProductName,
                Price = order.Product.Price,
                Amout = order.Amout,
                ClientName = _clientRepository.GetClientName(order.ClientId),
                ClientDirection = _clientRepository.GetClientDirection(order.ClientId)
            }).ToList();
        }

        public async Task<List<OrderViewModel>> GetAllViewModelWithFilters(FilterOrderViewModel filter)
        {
            var orderList = await _orderRepository.GetAllWithIncludeAsync(new List<string> { "Product" });

            var listViewModels = orderList.Select(order => new OrderViewModel
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                ProductId = order.ProductId,
                ProductName = order.Product.ProductName,
                Price = order.Product.Price,
                Amout = order.Amout,
                ClientName = _clientRepository.GetClientName(order.ClientId),
                ClientDirection = _clientRepository.GetClientDirection(order.ClientId)
            }).ToList();

            if(filter.ProductId != null)
            {
                listViewModels = listViewModels.Where(order => order.ProductId == filter.ProductId.Value).ToList();
            }

            return listViewModels;
        }

        public async Task<OrderViewModel> GetByIdViewModel(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            OrderViewModel vm = new();

            vm.Id = order.Id;
            vm.DeliveryDate = order.DeliveryDate;
            vm.ProductId = order.ProductId;
            vm.ClientId = order.ClientId;
            vm.Amout = order.Amout;

            return vm;
        }

        public async Task Update(OrderViewModel vm)
        {
            var order = await _orderRepository.GetByIdAsync(vm.Id);

            order.Id = vm.Id;
            order.DeliveryDate = vm.DeliveryDate;
            order.ProductId = vm.ProductId;
            order.ClientId = vm.ClientId;
            order.Amout = vm.Amout;

            await _orderRepository.UpdateAsync(order);
        }
    }
}

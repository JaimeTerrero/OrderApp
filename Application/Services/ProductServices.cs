using Application.Repositories;
using Application.ViewModels.Product;
using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductServices : IHelpersServices<ProductViewModel>
    {
        private readonly ProductRepository _productRepository;
        public ProductServices(ApplicationContext dbContext)
        {
            _productRepository = new(dbContext);
        }
        public async Task<ProductViewModel> Add(ProductViewModel vm)
        {
            Product product = new();
            product.ProductName = vm.ProductName;
            product.Price = vm.Price;

            product = await _productRepository.AddAsync(product);

            ProductViewModel spvm = new();
            spvm.Id = product.Id;
            spvm.ProductName = product.ProductName;
            spvm.Price = product.Price;

            return spvm;
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<ProductViewModel>> GetAllViewModel()
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Orders" });

            return productList.Select(product => new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price
            }).ToList();
        }

        public async Task<ProductViewModel> GetByIdViewModel(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            ProductViewModel vm = new();
            vm.Id = product.Id;
            vm.ProductName = product.ProductName;
            vm.Price = product.Price;

            return vm;
        }

        public async Task Update(ProductViewModel vm)
        {
            var product = await _productRepository.GetByIdAsync(vm.Id);

            product.Id = vm.Id;
            product.ProductName = vm.ProductName;
            product.Price = vm.Price;

            await _productRepository.UpdateAsync(product);
        }
    }
}

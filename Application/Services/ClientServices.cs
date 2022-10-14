using Application.Repositories;
using Application.ViewModels.Client;
using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientServices : IHelpersServices<SaveClientViewModel, ClientViewModel>
    {
        private readonly ClientRepository _clientRepository;
        public ClientServices(ApplicationContext dbContext)
        {
            _clientRepository = new(dbContext);
        }
        public async Task<SaveClientViewModel> Add(SaveClientViewModel vm)
        {
            Client client = new();
            client.ClientName = vm.ClientName;

            client = await _clientRepository.AddAsync(client);

            SaveClientViewModel scvm = new();
            scvm.Id = client.Id;
            scvm.ClientName = client.ClientName;

            return scvm;
        }

        public async Task Delete(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            await _clientRepository.DeleteAsync(client);
        }

        public async Task<List<ClientViewModel>> GetAllViewModel()
        {
            var clientList = await _clientRepository.GetAllWithIncludeAsync(new List<string> { "Orders" });

            return clientList.Select(client => new ClientViewModel
            {
                Id = client.Id,
                ClientName = client.ClientName
            }).ToList();
        }

        public async Task<SaveClientViewModel> GetByIdViewModel(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            SaveClientViewModel vm = new();
            vm.Id = client.Id;
            vm.ClientName = client.ClientName;

            return vm;
        }

        public async Task Update(SaveClientViewModel vm)
        {
            var client = await _clientRepository.GetByIdAsync(vm.Id);

            client.Id = vm.Id;
            client.ClientName = vm.ClientName;

            await _clientRepository.UpdateAsync(client);
        }
    }
}

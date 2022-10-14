using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IHelpersServices<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<SaveViewModel> Add(SaveViewModel vm);
        Task<SaveViewModel> GetByIdViewModel(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task Update(SaveViewModel vm);
        Task Delete(int id);
    }
}

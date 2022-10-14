using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IHelpersServices<ViewModel>
        where ViewModel : class
    {
        Task<ViewModel> Add(ViewModel vm);
        Task<ViewModel> GetByIdViewModel(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task Update(ViewModel vm);
        Task Delete(int id);
    }
}

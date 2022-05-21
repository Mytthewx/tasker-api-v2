using System.Collections.Generic;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models.ViewModel;

namespace TaskerAPI.Services.Interfaces
{
    public interface ICostService
    {
        IEnumerable<CostViewModel> GetAll();
        CostViewModel Get(int id);
        Task<int> Create(CostViewModel cost);
        bool Delete(int id);
        Cost Update(int id, CostViewModel costUpdate);
    }
}

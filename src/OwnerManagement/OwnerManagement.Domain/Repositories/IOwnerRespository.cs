using OwnerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Repositories
{
    public interface IOwnerRespository
    {
        Task<List<Owner>> GetAllAsync();
        Task AddAsync(Owner owner);
        void DeleteAsync(Owner owner);
        void UpdateAsync(Owner owner);
    }
}

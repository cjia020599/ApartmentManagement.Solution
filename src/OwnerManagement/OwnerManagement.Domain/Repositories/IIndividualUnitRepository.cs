using OwnerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Repositories
{
    public interface IIndividualUnitRepository
    {
        Task<List<IndividualUnit>> GetAllAsync();
        Task AddAsync(IndividualUnit individualUnit);
        void UpdateAsync(IndividualUnit individualUnit);
        void DeleteAsync(IndividualUnit individualUnit);
        Task<bool> ExistsByIdAsync(Guid individualUnitId, CancellationToken cancellationToken);
    }
}

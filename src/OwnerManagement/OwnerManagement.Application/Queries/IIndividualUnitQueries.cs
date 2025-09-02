using OwnerManagement.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Application.Queries
{
    public interface IIndividualUnitQueries
    {
        public Task<List<IndividualUnitResponse>> GetAllIndividualUnitsAsync(CancellationToken cancellationToken);
        public Task<IndividualUnitResponse?> GetIndividualUnitByIdAsync(Guid individualUnitId, CancellationToken cancellationToken);
    }
}

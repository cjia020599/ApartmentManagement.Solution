using OwnerManagement.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<List<OwnerResponse>> GetAllOwnersAsync(CancellationToken cancellationToken);

    }
}

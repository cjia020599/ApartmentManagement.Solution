using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Repositories
{
    public interface IUnitOFWork
    {
        IOwnerRespository Owners { get; }
        IIndividualUnitRepository IndividualUnits { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);

    }
}

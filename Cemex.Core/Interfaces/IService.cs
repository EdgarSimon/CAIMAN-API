using System.Threading.Tasks;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cemex.Core.Interfaces
{
    public interface IService<T>
    {
        PageList<T> Get(PaginationQuery filter);
    }
}
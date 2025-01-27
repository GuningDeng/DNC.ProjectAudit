using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);
        Task<T> GetById(int id);
        Task<T> Create(T newEntity);
        T Update(T modifiedEntity);
        void Delete(T entity);

    }
}

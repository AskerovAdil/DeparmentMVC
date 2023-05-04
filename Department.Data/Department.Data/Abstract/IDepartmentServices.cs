using ApplicationCore.Models;
using Management.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Abstract
{
    public interface IDepartmentServices
    {
        public IEnumerable<Department> GetAll();
        public ServiceResponse<Department> GetSingle(Guid id);
        public ServiceResponse<Department> GetSingle(Guid id, params Expression<Func<Department, object>>[] includeProperties);
        public void Commit();
        public ServiceResponse<Department> Add(Department entity, params Expression<Func<Department, object>>[] includes);
        public ServiceResponse DeleteWhere(Expression<Func<Department, bool>> predicate);
        public ServiceResponse<Department> Update(Department entity);

    }
}

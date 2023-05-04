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
	public interface IEmployeesServices
	{
		public IEnumerable<Employee> GetAll();
		public ServiceResponse<Employee> GetSingle(Decimal id);
		public ServiceResponse<Employee> GetSingle(Decimal id, params Expression<Func<Employee, object>>[] includeProperties);
		public void Commit();
		public ServiceResponse<Employee> Add(Employee entity, params Expression<Func<Employee, object>>[] includes);
		public ServiceResponse DeleteWhere(Expression<Func<Employee, bool>> predicate);
		public ServiceResponse<Employee> Update(Employee entity);

	}
}

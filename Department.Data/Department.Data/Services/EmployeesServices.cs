using ApplicationCore.Data;
using ApplicationCore.Models;
using Management.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Management.Data.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private ApplicationDbContext _context;
        public EmployeesServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Employee> GetAll()
        {
            return _context.Empoyee.AsEnumerable();
        }
        public ServiceResponse<Employee> GetSingle(Decimal id)
        {
            var result = _context.Set<Employee>().SingleOrDefault(x => x.ID == id);

            if (result != null)
            {
                return ServiceResponse<Employee>.OkResponse(result);
            }
            return ServiceResponse<Employee>.BadResponse("Внутренняя ошибка!");
        }

        public ServiceResponse<Employee> GetSingle(Decimal id, params Expression<Func<Employee, object>>[] includeProperties)
        {
            IQueryable<Employee> query = _context.Set<Employee>();
            try
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return ServiceResponse<Employee>.OkResponse(query.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception e)
            {
                return ServiceResponse<Employee>.BadResponse(e.Message);
            }

        }

        public IEnumerable<Employee> AllIncluding(params Expression<Func<Employee, object>>[] includeProperties)
        {
            try
            {
                IQueryable<Employee> responseObj = _context.Set<Employee>();

                foreach (Expression<Func<Employee, object>> include in includeProperties)
                {
                    responseObj = responseObj.Include(include);
                }

                //List<T> retObj =  responseObj.ToList();

                return responseObj.AsEnumerable();
            }
            catch (Exception e)
            {
                return null;
            }

        }





        public void Commit()
        {
            _context.SaveChanges();
        }



        public ServiceResponse<Employee> Add(Employee entity, params Expression<Func<Employee, object>>[] includes)
        {
            try
            {
                _context.Empoyee.Add(entity);
                Commit();
                return ServiceResponse<Employee>.OkResponse(entity);
            }
            catch(Exception e)
            {
                return ServiceResponse<Employee>.BadResponse("Внутренняя ошибка!");
            }
        }


        public void Delete(Employee entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Employee>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public ServiceResponse DeleteWhere(Expression<Func<Employee, bool>> predicate)
        {
            IEnumerable<Employee> entities = _context.Set<Employee>().Where(predicate);
            try
            {
                foreach (var entity in entities)
                {
                    _context.Entry<Employee>(entity).State = EntityState.Deleted;
                }
                Commit();
                return ServiceResponse.OkResponse;
            }
            catch
            {
                return ServiceResponse.BadResponse("Не удалось удалить запись");
            }


        }

        public ServiceResponse<Employee> Update(Employee entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Update(entity);
                dbEntityEntry.State = EntityState.Modified;

                /*EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified;*/



                Commit();
                return ServiceResponse<Employee>.OkResponse(entity);
            }
            catch (Exception e)
            {
                return ServiceResponse<Employee>.BadResponse(e.Message);
            }


        }


        public IEnumerable<Employee> FindBy(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Employee> GetSingle(Expression<Func<Employee, bool>> predicate)
        {
            IEnumerable<Employee> entities = _context.Set<Employee>().Where(predicate);

            if (entities != null)
            {
                return ServiceResponse<Employee>.OkResponse(entities.First());
            }

            return ServiceResponse<Employee>.BadResponse("Внутренняя ошибка!");
        }

        public ServiceResponse<Employee> GetSingle(Expression<Func<Employee, bool>> predicate, params Expression<Func<Employee, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }



    }
}

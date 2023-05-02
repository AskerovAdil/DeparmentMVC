using ApplicationCore.Data;
using Management.Data.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace Management.Data.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private ApplicationDbContext _context;
        public DepartmentServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.AsEnumerable();
        }
        public ServiceResponse<Department> GetSingle(int id)
        {
            var result = _context.Set<Department>().SingleOrDefault(x => x.ID == id);

            if (result != null)
            {
                return ServiceResponse<Department>.OkResponse(result);
            }
            return ServiceResponse<Department>.BadResponse("Внутренняя ошибка!");
        }

        public ServiceResponse<Department> GetSingle(int id, params Expression<Func<Department, object>>[] includeProperties)
        {
            IQueryable<Department> query = _context.Set<Department>();
            try
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return ServiceResponse<Department>.OkResponse(query.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception e)
            {
                return ServiceResponse<Department>.BadResponse(e.Message);
            }

        }

        public IEnumerable<Department> AllIncluding(params Expression<Func<Department, object>>[] includeProperties)
        {
            try
            {
                IQueryable<Department> responseObj = _context.Set<Department>();

                foreach (Expression<Func<Department, object>> include in includeProperties)
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



        public ServiceResponse<Department> Add(Department entity, params Expression<Func<Department, object>>[] includes)
        {
            try
            {
                _context.Set<Department>().Add(entity);
                Commit();
                return ServiceResponse<Department>.OkResponse(entity);
            }
            catch
            {
                return ServiceResponse<Department>.BadResponse("Внутренняя ошибка!");
            }
        }


        public void Delete(Department entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<Department>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public ServiceResponse DeleteWhere(Expression<Func<Department, bool>> predicate)
        {
            IEnumerable<Department> entities = _context.Set<Department>().Where(predicate);
            try
            {
                foreach (var entity in entities)
                {
                    _context.Entry<Department>(entity).State = EntityState.Deleted;
                }
                Commit();
                return ServiceResponse.OkResponse;
            }
            catch
            {
                return ServiceResponse.BadResponse("Не удалось удалить запись");
            }


        }

        public ServiceResponse<Department> Update(Department entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _context.Update(entity);
                dbEntityEntry.State = EntityState.Modified;

                /*EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified;*/



                Commit();
                return ServiceResponse<Department>.OkResponse(entity);
            }
            catch (Exception e)
            {
                return ServiceResponse<Department>.BadResponse(e.Message);
            }


        }


        public IEnumerable<Department> FindBy(Expression<Func<Department, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Department> GetSingle(Expression<Func<Department, bool>> predicate)
        {
            IEnumerable<Department> entities = _context.Set<Department>().Where(predicate);

            if (entities != null)
            {
                return ServiceResponse<Department>.OkResponse(entities.First());
            }

            return ServiceResponse<Department>.BadResponse("Внутренняя ошибка!");
        }

        public ServiceResponse<Department> GetSingle(Expression<Func<Department, bool>> predicate, params Expression<Func<Department, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }






    }
}

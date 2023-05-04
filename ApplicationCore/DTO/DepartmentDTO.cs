using ApplicationCore.Models;

namespace Management.Core.DTO
{
	public class DepartmentDTO
	{
		public DepartmentDTO(Department selectDepartment, IEnumerable<Department> departments)
		{
			SelectDepartment = selectDepartment;
			Departments = departments;
		}

		public Department SelectDepartment { get; set; }	
		public IEnumerable<Department> Departments { get;set; }
	}
}

using System;
namespace ORMDapper
{
	public interface IDepartmentRepository
	{
		public IEnumerable<Department> GetAllDepartments();
		public void InsertDepartment(string newDepartmentName);
	}
}


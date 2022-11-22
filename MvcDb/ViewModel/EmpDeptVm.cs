namespace MvcDb.ViewModel
{
	public class EmpDeptVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Salary { get; set; } //int? is a nullable type - can accept null values
		public int Bonus { get; set; }
		public string DeptName { get; set; }
		public string Location { get; set; }
		public string Color { get; set; }
	}
}

namespace DNC.ProjectAudit.EmployeeClient.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public DateTime DOJ { get; set; }
        public bool IsActive { get; set; }
    }
}

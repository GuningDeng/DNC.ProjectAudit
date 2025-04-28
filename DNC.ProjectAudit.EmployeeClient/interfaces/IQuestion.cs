namespace DNC.ProjectAudit.EmployeeClient.interfaces
{
    public interface IQuestion
    {
        string QuestionText { get; set; }
        string AnswerText { get; set; }
        int Id { get; set; }
    }
}

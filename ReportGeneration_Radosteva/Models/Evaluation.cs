namespace ReportGeneration_Radosteva.Models
{
    public class Evaluation
    {
        public Evaluation(int id, int idWork, int idStudent, string value, string lateness)
        {
            Id = id;
            IdWork = idWork;
            IdStudent = idStudent;
            Value = value;
            Lateness = lateness;
        }

        public int Id { get; set; }
        public int IdWork { get; set; }
        public int IdStudent { get; set; }
        public string Value { get; set; }
        public string Lateness { get; set; }
    }
}

namespace DevJobs.API.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicantName, string applicantEmail, int idJobVacancy)
        {
            this.ApplicantName = applicantName;
            this.ApplicantEmail = applicantEmail;
            this.IdJobVacancy = idJobVacancy;

        }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public int IdJobVacancy { get; set; }
    }
}
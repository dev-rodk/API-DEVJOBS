namespace DevJobs.API.Controllers
{
    using DevJobs.API.Models;
    using DevJobs.API.Persistance;
    using Microsoft.AspNetCore.Mvc;
    using DevJobs.API.Entities;

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;
        public JobApplicationsController(DevJobsContext context) => _context = context;

        //POST api/job-vacancies/4/applications
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var JobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
            if (JobVacancy is null) return NotFound();

            var JobApplication = new JobApplication(model.applicantEmail, model.applicantEmail, id);

            JobVacancy.Applications.Add(JobApplication);

            return NoContent();
        }
    }
}
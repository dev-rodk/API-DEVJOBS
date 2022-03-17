namespace DevJobs.API.Controllers

{
    using DevJobs.API.Models;
    using DevJobs.API.Persistance;
    using Microsoft.AspNetCore.Mvc;
    using DevJobs.API.Entities;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobVacanciesController(DevJobsContext context) => _context = context;


        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _context.JobVacancies;
            return Ok(jobVacancies);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllById(int id)
        {
            var JobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

            if (JobVacancy is null) return NotFound();
            return Ok(JobVacancy);
        }


        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(model.Title, model.Description, model.Company, model.isRemote, model.salaryRange);
            _context.JobVacancies.Add(jobVacancy);

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var JobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

            if (JobVacancy is null) return NotFound();
            
            JobVacancy.Update(model.Title, model.Description);
            return NoContent();
        }
    }
}
using _01_NexoraiQuery.Contract.ProjectModal;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectQuery _projectQuery;

        public ProjectController(IProjectQuery projectQuery)
        {
            _projectQuery = projectQuery;
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(long id)
        {
            var project = _projectQuery.GetProjectById(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }
    }
}

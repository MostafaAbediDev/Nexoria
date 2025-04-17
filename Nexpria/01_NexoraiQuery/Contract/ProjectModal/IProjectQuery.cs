using _01_NexoraiQuery.Contract.PortFolio;

namespace _01_NexoraiQuery.Contract.ProjectModal
{
    public interface IProjectQuery
    {
        ProjectQueryModel GetProjectById(long id);
    }
}

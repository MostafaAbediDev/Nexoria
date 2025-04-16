using _0_Framework.Application;

namespace PortFolioManagement.Application.Contracts.About
{
    public interface IAboutApplication
    {
        OperationResult Create(CreateAbout command);
        OperationResult Edit(EditAbout command);
        EditAbout GetDetails(long id);
        AboutViewModel GetAbout();
    }
}

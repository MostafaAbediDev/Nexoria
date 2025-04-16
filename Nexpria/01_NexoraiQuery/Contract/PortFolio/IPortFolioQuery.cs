namespace _01_NexoraiQuery.Contract.PortFolio
{
    public interface IPortFolioQuery
    {
        List<PortFolioQueryModel> GetPortFolios();
        //PortFolioQueryModel GetProjects(string slug);

    }
}

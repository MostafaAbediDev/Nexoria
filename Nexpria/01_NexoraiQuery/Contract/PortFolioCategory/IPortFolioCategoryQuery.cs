namespace _01_NexoraiQuery.Contract.PortFolioCategory
{
    public interface IPortFolioCategoryQuery
    {
        List<PortFolioCategoryQueryModel> GetPortFolioCategories();
        List<PortFolioCategoryQueryModel> GetPortFolioCategoriesWithPortFolios();
        //PortFolioCategoryQueryModel GetPortFolioCategoryWithPortFolio();
    }
}

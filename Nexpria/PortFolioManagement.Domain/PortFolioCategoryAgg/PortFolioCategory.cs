using _0_FrameWork.Domain;
using PortFolioManagement.Domain.PortFolioAgg;

namespace PortFolioManagement.Domain.PortFolioCategoryAgg
{
    public class PortFolioCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        //public string Picture { get; private set; }
        //public string PictureAlt { get; private set; }
        //public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        //public bool IsRemoved { get; private set; }

        public List<PortFolio> PortFolios { get; private set; }

        public PortFolioCategory()
        {
            PortFolios = new List<PortFolio>();
        }

        public PortFolioCategory(string name, string description, string keywords, 
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            //Picture = picture;
            //PictureAlt = pictureAlt;
            //PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            //IsRemoved = false;
        }

        public void Edit(string name, string description, string keywords,
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            //Picture = picture;
            //PictureAlt = pictureAlt;
            //PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}

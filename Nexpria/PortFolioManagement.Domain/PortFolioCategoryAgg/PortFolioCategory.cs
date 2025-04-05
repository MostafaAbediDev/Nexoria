using _0_FrameWork.Domain;
using PortFolioManagement.Domain.PortFolioAgg;

namespace PortFolioManagement.Domain.PortFolioCategoryAgg
{
    public class PortFolioCategory : EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Icon { get; private set; }
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

        public PortFolioCategory(string name, string shortdescription, string icon, string keywords, 
            string metaDescription, string slug)
        {
            Name = name;
            ShortDescription = shortdescription;
            Icon = icon;
            //PictureAlt = pictureAlt;
            //PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = shortdescription;
            Slug = slug;
            //IsRemoved = false;
        }

        public void Edit(string name, string shortdescription, string icon, string keywords,
            string metaDescription, string slug)
        {
            Name = name;
            ShortDescription = shortdescription;
            Icon = icon;
            //PictureAlt = pictureAlt;
            //PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = shortdescription;
            Slug = slug;
        }
    }
}

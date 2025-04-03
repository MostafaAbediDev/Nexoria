using _0_FrameWork.Domain;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Domain.PortFolioAgg
{
    public class PortFolio : EntityBase
    {
        public string Title  { get; private set; }
        public string Picture { get; private set; }
        public string PictuteAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string ShortDescrioption { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public PortFolioCategory Category { get; private set; }
        public bool IsRemoved { get; private set; }

        public PortFolio(string title, string picture, string pictuteAlt,
            string pictureTitle, long categoryId, string shortDescrioption, string description, 
            string slug, string keywords, string metaDescription)
        {
            Title = title;
            Picture = picture;
            PictuteAlt = pictuteAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            ShortDescrioption = shortDescrioption;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsRemoved = true;
        }

        public void Edit(string title, string picture, string pictuteAlt,
            string pictureTitle, long categoryId, string shortDescrioption, string description, 
            string slug, string keywords, string metaDescription)
        {
            Title = title;
            Picture = picture;
            PictuteAlt = pictuteAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            ShortDescrioption = shortDescrioption;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void Removed()
        {
            IsRemoved = true;
        }
        public void NotReoved()
        {
            IsRemoved = false;
        }
    }
}

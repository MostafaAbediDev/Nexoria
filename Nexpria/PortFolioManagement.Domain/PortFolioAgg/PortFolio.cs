﻿using _0_FrameWork.Domain;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Domain.PortFolioAgg
{
    public class PortFolio : EntityBase
    {
        public string Title  { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string ShortDescrioption { get; private set; }
        public string Description { get; private set; }
        public string Client { get; private set; }
        public string Timeline { get; private set; }
        public string Services { get; private set; }
        public string Results { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public PortFolioCategory Category { get; private set; }
        public bool IsRemoved { get; private set; }

        public PortFolio(string title, string picture, string pictureAlt,
            string pictureTitle, long categoryId, string shortDescrioption, string description, 
            string client, string timeline, string services, string results, string slug, 
            string keywords, string metaDescription)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            ShortDescrioption = shortDescrioption;
            Description = description;
            Client = client;
            Timeline = timeline;
            Services = services;
            Results = results;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsRemoved = true;
            
        }

        public void Edit(string title, string picture, string pictureAlt,string pictureTitle, 
            long categoryId, string shortDescrioption, string description, string client, 
            string timeline, string services, string results,
            string slug, string keywords, string metaDescription)
        {
            Title = title;

            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            ShortDescrioption = shortDescrioption;
            Description = description;
            Client = client; 
            Timeline = timeline;
            Services = services;
            Results = results;
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

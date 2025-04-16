using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
using System.ComponentModel.DataAnnotations;

namespace PortFolioManagement.Application.Contracts.PortFolio
{
    public class CreatePortFolio
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        [FileExtentionLimitation(new string[] {".jpeg", ".jpg", ".png"}, ErrorMessage = ValidationMessages.InValidFileFormat)]
        [MaxFileSize( 3 * 1024 * 1024,  ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Timeline { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        public long CategoryId { get; set; }
        public List<PortFolioCategoryViewModel> Categories { get; set; }
    }
}

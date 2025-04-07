using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace PortFolioManagement.Application.Contracts.Hero
{
    public class CreateHero
    {
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string BtnText1 { get; set; }
        public string BtnText2 { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
    }
}

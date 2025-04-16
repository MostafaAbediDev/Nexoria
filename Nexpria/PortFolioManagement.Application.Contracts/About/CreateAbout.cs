using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace PortFolioManagement.Application.Contracts.About
{
    public class CreateAbout
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public long ProjectsCompleted { get; set; }
        public long HappyClients { get; set; }
        public long YearsExperience { get; set; }

        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}

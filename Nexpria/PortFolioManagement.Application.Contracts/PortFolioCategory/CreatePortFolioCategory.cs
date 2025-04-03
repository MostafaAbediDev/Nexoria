using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public class CreatePortFolioCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Picture { get; set; }
        //public string PictureAlt { get; set; }
        //public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        //public bool IsRemoved { get; set; }
    }
}

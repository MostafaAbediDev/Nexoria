using _0_FrameWork.Domain;

namespace PortFolioManagement.Domain.HeroAgg
{
    public class Hero : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Text { get; private set; }
        public string BtnText1 { get; private set; }
        public string BtnText2 { get; private set; }
        public string Link1 { get; private set; }
        public string Link2 { get; private set; }

        public Hero(string picture, string pictureAlt, 
            string pictureTitle, string heading, string text, 
            string btnText1, string btnText2, string link1, string link2)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Text = text;
            BtnText1 = btnText1;
            BtnText2 = btnText2;
            Link1 = link1;
            Link2 = link2;
        }

        public void Edit(string picture, string pictureAlt,
            string pictureTitle, string heading, string text,
            string btnText1, string btnText2, string link1, string link2)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Text = text;
            BtnText1 = btnText1;
            BtnText2 = btnText2;
            Link1 = link1;
            Link2 = link2;
        }
    }
}

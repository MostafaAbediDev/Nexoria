﻿using System.Net.Sockets;

namespace _01_NexoraiQuery.Contract.Hero
{
    public class HeroQueryModel
    {
        public string Picture { get; set; }
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

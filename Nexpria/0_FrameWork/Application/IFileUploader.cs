﻿using Microsoft.AspNetCore.Http;

namespace _0_FrameWork.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file , string path);
    }
}

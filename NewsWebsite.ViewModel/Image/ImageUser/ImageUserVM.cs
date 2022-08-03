using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.Image.ImageUser
{
    public class ImageUserVM
    {
        public Guid IdUser { get; set; }
        public string ImagePath { get; set; }
    }
}

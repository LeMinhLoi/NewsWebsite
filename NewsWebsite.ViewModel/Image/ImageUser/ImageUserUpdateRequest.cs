using Microsoft.AspNetCore.Http;
using System;

namespace NewsWebsite.ViewModel.Image.ImageUser
{
    public class ImageUserUpdateRequest
    {
        public Guid Id { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

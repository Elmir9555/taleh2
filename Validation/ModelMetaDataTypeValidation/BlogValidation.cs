using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class BlogValidation
    {
        [Required(ErrorMessage ="Title hissesini bos kecmeyin.")]
        public string Title { get; set; }
       
        public string Image { get; set; }
        [Required(ErrorMessage = "Photo'nu bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class AdvertValidation
    {
        [Required(ErrorMessage ="Photo'nu bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}

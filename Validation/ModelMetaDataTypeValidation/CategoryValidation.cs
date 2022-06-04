using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class CategoryValidation
    {
        [Key]   
        [Required(ErrorMessage ="Name'i bos kecmeyin.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Photo'nu bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}

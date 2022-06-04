using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class OwnerValidation
    {
        [Required(ErrorMessage ="Fullname hissesini bos kecmeyin.")]
        [MaxLength(35,ErrorMessage ="Max 35 simvol ola biler.")]
        public string Fullname { get; set; }
        
        public string Image { get; set; }
        [Required(ErrorMessage = "Photo'nu bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}

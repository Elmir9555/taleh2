using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class ProductValidation
    {
        [Required(ErrorMessage ="Name hissesini bos kecmeyin.")]
        [MaxLength(20, ErrorMessage ="Max 20 simvol ola biler.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price hissesini bos kecmeyin.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Count hissesini bos kecmeyin.")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Photo hissesini bos kecmeyin.")]
        public IFormFile Photo { get; set; }

     
    }
}

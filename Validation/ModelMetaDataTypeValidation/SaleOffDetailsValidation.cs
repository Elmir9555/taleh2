using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class SaleOffDetailsValidation
    {
        [Required(ErrorMessage = "Description hissesini bos kecmeyin.")]
        [MaxLength(2500, ErrorMessage = "Max 2500 simvol ola biler.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Weight hissesini bos kecmeyin.")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "StarCount hissesini bos kecmeyin.")]
        public int StarCount { get; set; }
        [Required(ErrorMessage = "Availability hissesini bos kecmeyin.")]
        public bool Availability { get; set; }
        [Required(ErrorMessage = "Photo'nu bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}

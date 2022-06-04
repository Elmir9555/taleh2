using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class ProductDetailsValidation
    {
        [Required(ErrorMessage = "Description hissesini bos kecmeyin.")]
        [MaxLength(2500,ErrorMessage ="Max 2500 simvol ola biler.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Weight hissesini bos kecmeyin.")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "StarCount hissesini bos kecmeyin.")]
        public int StarCount { get; set; }

    }
}

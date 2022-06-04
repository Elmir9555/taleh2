using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class BlogDetailsValidation
    {
        [Required(ErrorMessage = "Description hissesini bos kecmeyin.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Categoryname hissesini bos kecmeyin.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Tags hissesini bos kecmeyin.")]
        public string Tags { get; set; }
    }
}

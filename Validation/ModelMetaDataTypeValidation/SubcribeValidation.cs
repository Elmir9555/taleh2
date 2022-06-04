using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class SubcribeValidation
    {
        [Required(ErrorMessage ="Email hissesini bos kecmeyin.")]
        [EmailAddress(ErrorMessage ="Email formatinda yazi daxil edin.!")]
        public string Email { get; set; }
    }
}

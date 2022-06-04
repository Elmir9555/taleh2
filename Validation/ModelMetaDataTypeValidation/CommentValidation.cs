using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class CommentValidation
    {
        [Required(ErrorMessage ="Message hissesini bos kecmeyin.")]
        [MaxLength(1500,ErrorMessage ="Max 1500 simvol ola biler.")]
        public string Message { get; set; }
    }
}

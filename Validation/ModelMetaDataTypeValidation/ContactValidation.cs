using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLahiye.Validation.ModelMetaDataTypeValidation
{
    public class ContactValidation
    {
        [Required(ErrorMessage ="Email hissesini bos kecmeyin.")]
        [EmailAddress(ErrorMessage ="Email formatinda simvol daxil edin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adress hissesini bos kecmeyin.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "OpenTime hissesini bos kecmeyin.")]
        public string OpenTime { get; set; }
        [Required(ErrorMessage = "Phone hissesini bos kecmeyin.")]
        [MaxLength(15,ErrorMessage ="Max 15 simvol ola biler.")]
        public string Phone { get; set; }
    }
}

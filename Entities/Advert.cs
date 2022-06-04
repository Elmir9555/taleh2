using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(AdvertValidation))]
    public class Advert : BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}

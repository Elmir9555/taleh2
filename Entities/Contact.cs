using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(ContactValidation))]
    public class Contact : BaseEntity
    {
        public string Email { get; set; }
        public string Adress { get; set; }
        public string OpenTime { get; set; }
        public string Phone { get; set; }

    }
}

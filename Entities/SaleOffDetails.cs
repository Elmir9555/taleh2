using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(SaleOffDetailsValidation))]
    public class SaleOffDetails : BaseEntity
    {
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public bool Availability { get; set; }
        public int StarCount { get; set; }


        public int SaleOffId { get; set; }

        //Relation Property

        public SaleOff SaleOff { get; set; }
    }
}

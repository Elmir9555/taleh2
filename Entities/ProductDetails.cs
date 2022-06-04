using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(ProductDetailsValidation))]
    public class ProductDetails : BaseEntity
    {
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int StarCount { get; set; }
        public bool Availability { get; set; }

        public int ProductId { get; set; }

        //Relation Property

        public Product Product { get; set; }
    }
}

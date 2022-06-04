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
    [ModelMetadataType(typeof(ProductValidation))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


        public int CategoryId { get; set; }

        //Relation Property

        public Category Category { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}

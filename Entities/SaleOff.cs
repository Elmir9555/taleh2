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
    [ModelMetadataType(typeof(SaleOffValidation))]
    public class SaleOff : BaseEntity
    {
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        

        //Relation Property
        
        public List<Comment> Comments { get; set; }
        public SaleOffDetails SaleOffDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(CommentValidation))]
    public class Comment : BaseEntity
    {
        public string Message { get; set; }

        public int BlogId { get; set; }
        public int SaleOffId { get; set; }

        //Relation Property

        public Blog Blog { get; set; }
        public SaleOff SaleOff { get; set; }

    }
}

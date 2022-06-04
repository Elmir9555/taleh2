using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Entities
{
    [ModelMetadataType(typeof(BlogDetailsValidation))]
    public class BlogDetails : BaseEntity
    {
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Tags { get; set; }

        public int BlogId { get; set; }

        //Relation Property

        public Blog Blog { get; set; }
    }
}

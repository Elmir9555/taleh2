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
    [ModelMetadataType(typeof(BlogValidation))]
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public int OwnerId { get; set; }

        //Relation Property

        public List<Comment> Comments { get; set; }
        public Owner Owner { get; set; }
        public BlogDetails BlogDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("products")]
    public class Product
    {
        [Column("id",TypeName ="INT")]
       public int Id{get;set;}
       [Column("name",TypeName ="VARCHAR(20)")]
        public string Name{get;set;}="";
       [Column("brand",TypeName ="VARCHAR(255)")]
        public string Brand{get;set;}="";
       [Column("category",TypeName ="VARCHAR(255)")]
        public string Category{get;set;}="";
        [Column("price")]
        [Precision(16,2)]
        public double Price{get;set;}
       [Column("description",TypeName ="VARCHAR(100)")]
        public string Description{get;set;}="";
       [Column("create_at")]
        public DateTime CreateAt{get;set;}
    }
}
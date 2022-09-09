using RestAPI.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    // Referência da tabela no BD
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launchDate")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}

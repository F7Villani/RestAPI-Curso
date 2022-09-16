using RestAPI.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Data.VO
{
    public class BookVO
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}

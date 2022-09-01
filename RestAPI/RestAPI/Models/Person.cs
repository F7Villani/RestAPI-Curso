using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    // Referência da tabela no BD
    [Table("people")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
    }
}

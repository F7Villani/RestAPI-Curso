using RestAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    // Referência da tabela no BD
    [Table("people")]
    public class Person : BaseEntity
    {

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        public bool IsEmpty()
        {
            bool isEmpty = false;

            if(FirstName == null && LastName == null && Address == null && Gender == null)
                isEmpty = true;

            return isEmpty;
        }
    }
}

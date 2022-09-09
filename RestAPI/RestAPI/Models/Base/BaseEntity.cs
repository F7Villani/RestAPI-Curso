using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}

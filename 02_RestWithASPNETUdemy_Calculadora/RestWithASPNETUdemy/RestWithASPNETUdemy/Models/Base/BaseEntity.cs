using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}

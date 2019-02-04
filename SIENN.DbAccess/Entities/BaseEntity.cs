using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.DbAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public long Id { get; set; }

        [Column(Order = 98)]
        public DateTime CreateDateTime { get; set; }

        [Column(Order = 99)]
        public DateTime ModifyDateTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Web.Api.Data.Models
{
    public class Artist : IPersistentObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
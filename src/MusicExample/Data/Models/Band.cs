using System.ComponentModel.DataAnnotations;

namespace Music.Web.Api.Data.Models
{
    public class Band : IPersistentObject
    {
        public string Name { get; set; }

        [Key] public int Id { get; set; }
    }
}
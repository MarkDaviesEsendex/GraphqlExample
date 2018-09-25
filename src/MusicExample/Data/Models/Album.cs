using System.ComponentModel.DataAnnotations;

namespace Music.Web.Api.Data.Models
{
    public class Album : IPersistentObject
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
    }
}
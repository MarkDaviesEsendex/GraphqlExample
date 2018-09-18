using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Models
{
    public class Band : IPersistentObject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
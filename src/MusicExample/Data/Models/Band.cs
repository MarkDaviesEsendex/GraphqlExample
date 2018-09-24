using System.ComponentModel.DataAnnotations;
using UserApi.Data.Models;

namespace Music.Web.Api.Data.Models
{
    public class Band : IPersistentObject
    {
        public string Name { get; set; }

        [Key] public int Id { get; set; }
    }
}
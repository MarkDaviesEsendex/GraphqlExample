using System.ComponentModel.DataAnnotations;
using Music.Web.Api.Data.Models;

namespace UserApi.Data.Models
{
    public class Artist : IPersistentObject
    {
        public string Name { get; set; }

        [Key] public int Id { get; set; }
    }
}
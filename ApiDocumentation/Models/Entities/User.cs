using System.ComponentModel.DataAnnotations;

namespace ApiDocumentation.Models.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

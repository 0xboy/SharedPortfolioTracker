using System.ComponentModel.DataAnnotations;

namespace TracKing.Infrastructure.Aggregate
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public double Share { get; set; }

    }
}

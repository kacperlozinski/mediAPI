
using System.ComponentModel.DataAnnotations;

namespace medAPI.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}

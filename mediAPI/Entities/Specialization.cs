using System.ComponentModel.DataAnnotations;

namespace medAPI.Entities
{
    public class Specialization
    {
        [Key]
        public int SpecId   { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /* public virtual Doctors Doctors { get; set; }*/

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}

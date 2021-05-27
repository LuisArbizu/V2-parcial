using System.ComponentModel.DataAnnotations;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.Entities.Users;

namespace Parcial02PM.Entities.Reservations
{
    public class Reservation
    {
        

        [Key]public int IdR { get; set; }
        public string DateTime {get;set;}
        
        public virtual User User {get; set; }
        public virtual Speciality Speciality {get; set; }
        
    }
}
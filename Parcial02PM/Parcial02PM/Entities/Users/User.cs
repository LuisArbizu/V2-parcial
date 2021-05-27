using System.ComponentModel.DataAnnotations;
using Parcial02PM.Entities.Questions;

namespace Parcial02PM.Entities.Users
{
    public class User
    {
        

        [Key]public int CardId { get; set; }
        public string FullName { get; set; }
        public string Password {get;set;}
        public string Answer { get; set; }
        

        public virtual Question Question {get; set; }
    }
}
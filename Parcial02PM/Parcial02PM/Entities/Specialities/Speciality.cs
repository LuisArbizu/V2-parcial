﻿using System.ComponentModel.DataAnnotations;

namespace Parcial02PM.Entities.Specialities
{
    public class Speciality
    {
        [Key]public int IdS { get; set; }
        public string S { get; set; }
    }
}
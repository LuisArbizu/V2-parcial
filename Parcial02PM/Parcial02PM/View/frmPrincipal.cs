using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Parcial02PM.Context;
using Parcial02PM.Entities.Reservations;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.Entities.Users;


namespace Parcial02PM.View
{
    public partial class FrmPrincipal : Form
    {
        public virtual User User {get; set; }
        public FrmPrincipal(User result)
        {
            InitializeComponent();
            this.User = User;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var db = new ClinicContext();
            cmbSpecialities.DataSource = db.Specialities.ToList();
            cmbSpecialities.DisplayMember = "S";
            cmbSpecialities.ValueMember = "IdS"; 
            
            var listaUsers = db.Users
                .Include(u=> u.Question)
                .OrderBy(c => c.CardId)
                .ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User uref = User;
            
            Speciality sref = (Speciality) cmbSpecialities.SelectedItem;

            var db = new ClinicContext();
            Speciality sbdd = db.Set<Speciality>()
                .SingleOrDefault((s => s.IdS == sref.IdS));
            
            User ubdd = db.Set<User>()
                .SingleOrDefault((u => u.CardId == uref.CardId));

            Reservation r = new Reservation(ubdd, sbdd);
            db.Add(r);
            db.SaveChanges();
            
            
            MessageBox.Show(text: "Reservacion Hecha!", caption: "Clinica UCA",
                MessageBoxButtons.OK, MessageBoxIcon.Information);   
            this.Hide();
        }
    }
}

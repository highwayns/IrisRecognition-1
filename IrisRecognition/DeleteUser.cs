﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRecognition
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        IrisDatabaseDataContext db = new IrisDatabaseDataContext();

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Person p = db.Persons.First(person => person.PersonID == Convert.ToInt32(textBox1.Text));
            db.Persons.DeleteOnSubmit(p);
            db.SubmitChanges();
        }
    }
}
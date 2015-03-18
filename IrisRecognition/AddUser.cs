﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace IrisRecognition
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        IrisDatabaseDataContext db = new IrisDatabaseDataContext();

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.PersonID = '9';
            p.ID = Convert.ToString('1');
            p.LName = Convert.ToString('2');
            //Iris_Image newIrisImage = new Iris_Image();
            //newIrisImage.ImageID = textBox1.Text;

            //ImageConverter converter = new ImageConverter();
            //byte[] img = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));
            //newIrisImage.ImagePattern = (img);

            //newIrisImage.PersonID = Convert.ToInt32(textBox2.Text);
            db.Persons.InsertOnSubmit(p);
            db.SubmitChanges();
            Iris_Image ii = new Iris_Image();
            ii.ImageID = Convert.ToString('1');
            ii.PersonID = '5';
            
            ImageConverter converter = new ImageConverter();
            byte[] img = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));

            ii.ImagePattern = img;
            db.Iris_Images.InsertOnSubmit(ii);
            db.SubmitChanges();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Iris_Image ii = db.Iris_Images.First(i => i.ImageID == "1");


            //one way
            //idon'tknowwhatiamdoing
            //var bytes = ii.ImagePattern;
            //byte[] trueBytes = bytes.ToArray();
            //if (trueBytes != null)
            //{
            //    using (var ms = new MemoryStream(trueBytes))
            //    {
            //        using (var image = Image.FromStream(ms))
            //        {
            //            pictureBox2.Image = (Image)image.Clone();
            //        }
            //    }
            //}


            //otherway
            MemoryStream mss = new MemoryStream(ii.ImagePattern.ToArray());
            Image img = Image.FromStream(mss);
            

            //doesn't work
            //
            //ImageConverter converter = new ImageConverter();
            //Image img  = (Image)converter.ConvertTo(ii.ImagePattern, typeof(Image));

            pictureBox2.Image = img;
        }
    }
}
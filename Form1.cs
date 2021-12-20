using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer1
{
    public partial class Form1 : Form
    {
        private readonly StudentBusiness studentBusiness = new StudentBusiness();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            List<Student> students = studentBusiness.GetAllStudents();
            listBoxStudent.Items.Clear();

            foreach(Student s in students)
            {
                listBoxStudent.Items.Add(s.Id + ". " + s.Name + "(" + s.IndexNumber + ") - " + s.AverageMark);
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Name = textBoxName.Text;
            s.IndexNumber = textBoxIndexNumber.Text;
            s.AverageMark = Convert.ToDecimal(textBoxAverageMark.Text);

            if (studentBusiness.InsertStudent(s))
            {
                RefreshData();
                textBoxName.Text = string.Empty;
                textBoxIndexNumber.Text = string.Empty;
                textBoxAverageMark.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}

using company.control;
using System;
using System.Data;

namespace emp_presentation
{
    public partial class Form1 : Form
    {
        Emp person;
        public Form1()
        {
            InitializeComponent();

            start();



        }

        private void start()
        {
            comboBox1.DataSource = Control_emp.get_all();
            comboBox1.DisplayMember = "fname";
            comboBox1.ValueMember = "ssn";
            dataGridView1.DataSource = Control_emp.get_all();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            var ssn = comboBox1.SelectedValue.ToString();

            dataGridView1.DataSource = Control_emp.getbyid1(ssn);

            person = Control_emp.getbyid(ssn);

            txtId.Text = person.Ssn;
            txtId.Enabled = false;
            txtFName.Text = person.Fname;
            txtLName.Text = person.Lname;
            txtAddress.Text = person.Address;


        }

        private void Update_Click(object sender, EventArgs e)
        {


            person.Ssn =  txtId.Text;
            txtId.Enabled = false;
            person.Fname= txtFName.Text ;
            person.Lname=  txtLName.Text;
            person.Address = txtAddress.Text;
            Control_emp.update(person);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Control_emp.delete(person.Ssn);

        }
    }
}
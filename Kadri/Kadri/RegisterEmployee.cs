using HRApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadri
{
    public partial class RegisterEmployee : Form
    {
        private EmployeeService service = new EmployeeService();
        public RegisterEmployee()
        {
            InitializeComponent();
        }
      private void button1_Click(object sender, EventArgs e)

        {
            string errorMessage;

            int departmentId;
            if (!int.TryParse(textBox3.Text, out departmentId))
            {
                label7.Text = "ID отдела должен быть числом.";
                label7.ForeColor = Color.Red;
                return;
            }

            bool result = service.RegisterEmployee(
                textBox1.Text,
                dateTimePicker1.Value,
                textBox2.Text,
                departmentId,
                dateTimePicker2.Value,
                textBox4.Text,
                out errorMessage
            );

            if (result)
            {
                label7.Text = "Сотрудник успешно зарегистрирован!";
                label7.ForeColor = Color.Green;
                ClearForm();
            }
            else
            {
                label7.Text = errorMessage;
                label7.ForeColor = Color.Red;
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}

using System.Drawing;
using System.Windows.Forms;
using System;

namespace Kadri
{
    partial class MainHRForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnRegisterEmployee;
        private Button btnViewEmployees;
        private Button btnDeleteEmployee;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRegisterEmployee = new Button();
            this.btnViewEmployees = new Button();
            this.btnDeleteEmployee = new Button();
            this.label1 = new Label();

            // MainHRForm
            this.Text = "Кадровый учет";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            // label1
            this.label1.Text = "Кадровый учет";
            this.label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.label1.Location = new Point(120, 20);
            this.label1.Size = new Size(200, 30);

            // btnRegisterEmployee
            this.btnRegisterEmployee.Text = "Добавить сотрудника";
            this.btnRegisterEmployee.Location = new Point(100, 80);
            this.btnRegisterEmployee.Size = new Size(200, 40);
            this.btnRegisterEmployee.Click += new EventHandler(this.btnRegisterEmployee_Click);

            // btnViewEmployees
            this.btnViewEmployees.Text = "Просмотр сотрудников";
            this.btnViewEmployees.Location = new Point(100, 140);
            this.btnViewEmployees.Size = new Size(200, 40);
            this.btnViewEmployees.Click += new EventHandler(this.btnViewEmployees_Click);

            // btnDeleteEmployee
            this.btnDeleteEmployee.Text = "Удалить сотрудника";
            this.btnDeleteEmployee.Location = new Point(100, 200);
            this.btnDeleteEmployee.Size = new Size(200, 40);
            this.btnDeleteEmployee.Click += new EventHandler(this.btnDeleteEmployee_Click);

            this.Controls.AddRange(new Control[] {
            this.label1,
            this.btnRegisterEmployee,
            this.btnViewEmployees,
            this.btnDeleteEmployee
        });
        }
    }
}
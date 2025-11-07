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
            this.btnRegisterEmployee = new System.Windows.Forms.Button();
            this.btnViewEmployees = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegisterEmployee
            // 
            this.btnRegisterEmployee.Location = new System.Drawing.Point(217, 53);
            this.btnRegisterEmployee.Name = "btnRegisterEmployee";
            this.btnRegisterEmployee.Size = new System.Drawing.Size(200, 40);
            this.btnRegisterEmployee.TabIndex = 1;
            this.btnRegisterEmployee.Text = "Добавить сотрудника";
            this.btnRegisterEmployee.Click += new System.EventHandler(this.btnRegisterEmployee_Click);
            // 
            // btnViewEmployees
            // 
            this.btnViewEmployees.Location = new System.Drawing.Point(11, 53);
            this.btnViewEmployees.Name = "btnViewEmployees";
            this.btnViewEmployees.Size = new System.Drawing.Size(200, 40);
            this.btnViewEmployees.TabIndex = 2;
            this.btnViewEmployees.Text = "Просмотр сотрудников";
            this.btnViewEmployees.Click += new System.EventHandler(this.btnViewEmployees_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(423, 53);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(200, 40);
            this.btnDeleteEmployee.TabIndex = 3;
            this.btnDeleteEmployee.Text = "Удалить сотрудника";
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(217, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кадровый учет";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 222);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MainHRForm
            // 
            this.ClientSize = new System.Drawing.Size(632, 340);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegisterEmployee);
            this.Controls.Add(this.btnViewEmployees);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Name = "MainHRForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кадровый учет";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dataGridView1;
    }
}
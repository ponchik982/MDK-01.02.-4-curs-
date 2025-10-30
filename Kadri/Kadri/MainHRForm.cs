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
    public partial class MainHRForm : Form
    {
        public MainHRForm()
        {
            InitializeComponent();
        }

        // Добавляем недостающие методы-обработчики
        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterEmployee();
            registerForm.ShowDialog();
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            // Временно закомментируем, пока не создана форма
            // var viewForm = new ViewEmployeesForm();
            // viewForm.ShowDialog();
            MessageBox.Show("Функция просмотра сотрудников в разработке", "Информация");
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Временно закомментируем, пока не создана форма
            // var deleteForm = new DeleteEmployeeForm();
            // deleteForm.ShowDialog();
            MessageBox.Show("Функция удаления сотрудников в разработке", "Информация");
        }
    }
}

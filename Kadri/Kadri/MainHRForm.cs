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
    public partial class MainHRForm : Form
    {
        private EmployeeService service = new EmployeeService();

        public MainHRForm()
        {
            InitializeComponent();
            LoadEmployees(); // Загружаем данные при запуске формы
        }

        // Метод для загрузки сотрудников в DataGridView
        private void LoadEmployees()
        {
            try
            {
                var employees = service.GetAllEmployees();
                dataGridView1.DataSource = employees;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].HeaderText = "ID";
                    dataGridView1.Columns["LastName"].HeaderText = "Фамилия";
                    dataGridView1.Columns["FirstName"].HeaderText = "Имя";
                    dataGridView1.Columns["MiddleName"].HeaderText = "Отчество";
                    dataGridView1.Columns["FullName"].HeaderText = "Полное ФИО";
                    dataGridView1.Columns["BirthDate"].HeaderText = "Дата рождения";
                    dataGridView1.Columns["Position"].HeaderText = "Должность";
                    dataGridView1.Columns["DepartmentId"].HeaderText = "ID отдела";
                    dataGridView1.Columns["HireDate"].HeaderText = "Дата приема";
                    dataGridView1.Columns["EmploymentType"].HeaderText = "Тип занятости";

                    dataGridView1.Columns["BirthDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dataGridView1.Columns["HireDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // В методе удаления обновляем получение имени
        private void DeleteEmployee(int employeeId, string employeeName)
        {
            try
            {
                string errorMessage;
                bool success = service.DeleteEmployee(employeeId, out errorMessage);

                if (success)
                {
                    MessageBox.Show(
                        $"Сотрудник {employeeName} успешно удален!",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadEmployees();
                }
                else
                {
                    MessageBox.Show(
                        $"Ошибка при удалении: {errorMessage}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при удалении сотрудника: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Обновите метод добавления сотрудника
        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterEmployee();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем DataGridView после добавления нового сотрудника
                LoadEmployees();
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Этот метод может использоваться для обработки кликов по ячейкам
            // Например, если у вас есть кнопки в ячейках
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Ваша логика обработки клика
            }
        }

        // Добавьте кнопку обновления данных
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        // Остальные ваши методы...
        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            // Теперь можно убрать заглушку, так как данные отображаются в DataGridView
            MessageBox.Show("Данные сотрудников отображаются в таблице выше", "Информация");
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

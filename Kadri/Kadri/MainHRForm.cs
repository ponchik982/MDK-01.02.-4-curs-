using HRApp;
using HRApp.Services;
using System;
using System.Windows.Forms;

namespace Kadri
{
    public partial class MainHRForm : Form
    {
        private EmployeeService service = new EmployeeService();

        public MainHRForm()
        {
            InitializeComponent();
            this.dataGridView1.DataError += dataGridView1_DataError;
            // Убираем все сложные настройки из конструктора
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = service.GetAllEmployees();

                // Минимальные настройки колонок
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].Visible = false; // Скрываем ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка");
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var employee = selectedRow.DataBoundItem as Employee;

            if (employee == null)
            {
                MessageBox.Show("Не удалось получить данные сотрудника");
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить сотрудника {employee.FullName}?\nЭто действие необратимо.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string errorMessage;
                    bool success = service.DeleteEmployee(employee.Id, out errorMessage);

                    if (success)
                    {
                        MessageBox.Show($"Сотрудник {employee.FullName} успешно удален!", "Успех");
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при удалении: {errorMessage}", "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterEmployee();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данные сотрудников отображаются в таблице выше", "Информация");
        }

        // Обработчик ошибок DataGridView
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Игнорируем ошибки DataGridView
            e.ThrowException = false;
        }

        // Простой обработчик клика
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ничего не делаем
        }

    }
}
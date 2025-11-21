using HRApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kadri
{
    public partial class RegisterEmployee : Form
    {
        private EmployeeService service = new EmployeeService();

        public RegisterEmployee()
        {
            InitializeComponent();
            this.button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string errorMessage;
            int departmentId = int.Parse(textBoxDepartmentId.Text);

            bool result = service.RegisterEmployee(
                textBoxLastName.Text.Trim(),      // Фамилия
                textBoxFirstName.Text.Trim(),     // Имя
                textBoxMiddleName.Text.Trim(),    // Отчество
                dateTimePickerBirthDate.Value,    // Дата рождения
                textBoxPosition.Text.Trim(),      // Должность
                departmentId,                     // ID отдела
                dateTimePickerHireDate.Value,     // Дата приема
                textBoxEmploymentType.Text.Trim(), // Тип занятости
                out errorMessage
            );

            if (result)
            {
                labelResult.Text = "Сотрудник успешно зарегистрирован!";
                labelResult.ForeColor = Color.Green;
                ClearForm();

                Timer timer = new Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) => {
                    timer.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };
                timer.Start();
            }
            else
            {
                labelResult.Text = errorMessage;
                labelResult.ForeColor = Color.Red;
            }
        }

        private bool ValidateInput()
        {
            // Проверка фамилии
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                ShowError("Введите фамилию сотрудника");
                return false;
            }

            // Проверка имени
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                ShowError("Введите имя сотрудника");
                return false;
            }

            // Отчество может быть пустым - не проверяем

            // Проверка должности
            if (string.IsNullOrWhiteSpace(textBoxPosition.Text))
            {
                ShowError("Введите должность");
                return false;
            }

            // Проверка ID отдела
            if (!int.TryParse(textBoxDepartmentId.Text, out int departmentId) || departmentId <= 0)
            {
                ShowError("ID отдела должен быть положительным числом");
                return false;
            }

            // Проверка типа занятости
            if (string.IsNullOrWhiteSpace(textBoxEmploymentType.Text))
            {
                ShowError("Введите тип занятости");
                return false;
            }

            // Проверка даты рождения (не может быть в будущем)
            if (dateTimePickerBirthDate.Value > DateTime.Now)
            {
                ShowError("Дата рождения не может быть в будущем");
                return false;
            }

            // Проверка даты приема (не может быть раньше даты рождения)
            if (dateTimePickerHireDate.Value < dateTimePickerBirthDate.Value)
            {
                ShowError("Дата приема не может быть раньше даты рождения");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            labelResult.Text = message;
            labelResult.ForeColor = Color.Red;
        }

        private void ClearForm()
        {
            textBoxLastName.Clear();
            textBoxFirstName.Clear();
            textBoxMiddleName.Clear();
            textBoxPosition.Clear();
            textBoxDepartmentId.Clear();
            textBoxEmploymentType.Clear();
            dateTimePickerBirthDate.Value = DateTime.Now;
            dateTimePickerHireDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
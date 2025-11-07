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
            int departmentId = int.Parse(textBox3.Text);

            bool result = service.RegisterEmployee(
                textBox1.Text.Trim(),
                dateTimePicker1.Value,
                textBox2.Text.Trim(),
                departmentId,
                dateTimePicker2.Value,
                textBox4.Text.Trim(),
                out errorMessage
            );

            if (result)
            {
                label7.Text = "Сотрудник успешно зарегистрирован!";
                label7.ForeColor = Color.Green;
                ClearForm();

                // Автоматическое закрытие формы через 2 секунды
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
                label7.Text = errorMessage;
                label7.ForeColor = Color.Red;
            }
        }

        private bool ValidateInput()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ShowError("Введите ФИО сотрудника");
                return false;
            }

            // Проверка должности
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ShowError("Введите должность");
                return false;
            }

            // Проверка ID отдела
            if (!int.TryParse(textBox3.Text, out int departmentId) || departmentId <= 0)
            {
                ShowError("ID отдела должен быть положительным числом");
                return false;
            }

            // Проверка даты рождения (не может быть в будущем)
            if (dateTimePicker1.Value > DateTime.Now)
            {
                ShowError("Дата рождения не может быть в будущем");
                return false;
            }

            // Проверка даты приема (не может быть раньше даты рождения)
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                ShowError("Дата приема не может быть раньше даты рождения");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            label7.Text = message;
            label7.ForeColor = Color.Red;
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

        // Добавьте кнопку отмены
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
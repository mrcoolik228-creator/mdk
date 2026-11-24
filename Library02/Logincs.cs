using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library02
{
    public partial class Logincs : Form
    {
        public Logincs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginInput = textBox1.Text.Trim(); // Имя Фамилия
            string passwordInput = textBox2.Text.Trim(); // Номер_телефона

            if (string.IsNullOrEmpty(loginInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Вход для администратора
            if (loginInput == "admin" && passwordInput == "admin")
            {
                this.Hide();
                mainAdmin adminForm = new mainAdmin();
                adminForm.ShowDialog();
                this.Close();
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";

            // Запрашиваем id_Читателя, имя и фамилию
            string query = "SELECT id_Читателя FROM Читатели WHERE (Имя & ' ' & Фамилия) = ? AND Номер_телефона = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", loginInput);
                    command.Parameters.AddWithValue("?", passwordInput);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // --- ГЛАВНОЕ ИЗМЕНЕНИЕ ---
                            // Сохраняем ID читателя в глобальную переменную!
                            GlobalData.CurrentReaderId = Convert.ToInt32(result);

                            this.Hide();
                            mainBasic basicForm = new mainBasic(); // Твоя форма читателя
                            basicForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверное Имя Фамилия или Номер телефона!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка авторизации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Создаем экземпляр формы регистрации
            // Предполагаем, что класс формы регистрации называется register (как в заголовке окна)
            register registerForm = new register();

            // 2. Скрываем текущую форму входа (чтобы она не мешалась на заднем плане)
            this.Hide();

            // 3. Открываем форму регистрации как модальное окно
            registerForm.ShowDialog();

            // 4. Когда форма регистрации закроется (например, кнопкой «Выход» или после успешной регистрации),
            // код вернется сюда и снова покажет форму входа
            this.Show();
        }
    }
}

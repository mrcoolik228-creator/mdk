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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Проверяем совпадение номеров телефона (теперь они вместо пароля)
            if (textBox2.Text.Trim() != textBox3.Text.Trim())
            {
                MessageBox.Show("Введенные номера телефонов не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Извлекаем Имя и Фамилию из textBox1 (ожидаем ввод формата: "Иван Иванов")
            string fullName = textBox1.Text.Trim();
            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
            {
                MessageBox.Show("Пожалуйста, введите через пробел Имя и Фамилию (например: Иван Иванов)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string firstName = nameParts[0]; // Первое слово — Имя
            string lastName = nameParts[1];  // Второе слово — Фамилия
            string phoneNumber = textBox2.Text.Trim();

            // Путь к твоей основной базе данных
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";

            // Запрос 1: Проверяем, существует ли уже читатель с таким Именем и Фамилией
            string checkQuery = "SELECT COUNT(*) FROM Читатели WHERE Имя = ? AND Фамилия = ?";

            // Запрос 2: Получаем самый большой существующий номер читательского билета
            string maxTicketQuery = "SELECT MAX(Номер_чит_билета) FROM Читатели";

            // Запрос 3: Вставка нового читателя со всеми нужными полями
            string insertQuery = "INSERT INTO Читатели (Номер_чит_билета, Фамилия, Имя, Номер_телефона) VALUES (?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // --- ПРОВЕРКА НА СУЩЕСТВОВАНИЕ ТАКОГО ЖЕ ПОЛЬЗОВАТЕЛЯ ---
                    using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("?", firstName);
                        checkCommand.Parameters.AddWithValue("?", lastName);

                        int userExists = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (userExists > 0)
                        {
                            MessageBox.Show("Читатель с таким Именем и Фамилией уже зарегистрирован!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // --- АВТОГЕНЕРАЦИЯ НОМЕРА ЧИТАТЕЛЬСКОГО БИЛЕТА (MAX + 1) ---
                    int newTicketNumber = 1; // По умолчанию, если база пустая
                    using (OleDbCommand maxCommand = new OleDbCommand(maxTicketQuery, connection))
                    {
                        object maxResult = maxCommand.ExecuteScalar();
                        if (maxResult != null && maxResult != DBNull.Value)
                        {
                            newTicketNumber = Convert.ToInt32(maxResult) + 1;
                        }
                    }

                    // --- ДОБАВЛЕНИЕ НОВОГО ЧИТАТЕЛЯ В БАЗУ ---
                    using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                    {
                        // Передаем параметры СТРОГО по порядку знаков вопроса в insertQuery
                        insertCommand.Parameters.AddWithValue("?", newTicketNumber);
                        insertCommand.Parameters.AddWithValue("?", lastName);
                        insertCommand.Parameters.AddWithValue("?", firstName);
                        insertCommand.Parameters.AddWithValue("?", phoneNumber);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Регистрация успешно завершена!\n\nВаш сгенерированный Номер читательского билета: {newTicketNumber}\nИспользуйте связку 'Имя Фамилия' и номер телефона для входа.",
                                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Очищаем текстовые поля
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();

                            // Закрываем форму регистрации и возвращаемся на авторизацию
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось сохранить данные читателя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы с базой данных Библиотека: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

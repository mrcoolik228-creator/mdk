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
    public partial class bibliAdd : Form
    {
        public bibliAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, что все поля заполнены
            // Предполагаем: textBox1 - Фамилия, textBox2 - Имя, textBox3 - Номер телефона
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Укажи правильный путь к твоей базе данных с таблицей библиотекарей
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";

            // SQL-запрос добавления строки. Имена полей в квадратных скобках на случай пробелов или спецсимволов
            string query = "INSERT INTO [Библиотекари] ([Фамилия], [Имя], [Номер_телефона]) VALUES (?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Добавляем параметры СТРОГО в том порядке, в котором идут знаки "?" в запросе
                    command.Parameters.AddWithValue("?", textBox1.Text.Trim()); // Фамилия
                    command.Parameters.AddWithValue("?", textBox2.Text.Trim()); // Имя
                    command.Parameters.AddWithValue("?", textBox3.Text.Trim()); // Номер телефона

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Библиотекарь успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Закрываем форму добавления, чтобы вернуться к главной таблице
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка работы с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

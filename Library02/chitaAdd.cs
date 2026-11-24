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
    public partial class chitaAdd : Form
    {
        public chitaAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Проверяем заполнение всех полей
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ВНИМАНИЕ: Проверяем textBox4, так как номер билета теперь в нём
            if (!int.TryParse(textBox4.Text.Trim(), out int ticketNumber))
            {
                MessageBox.Show("Номер читательского билета должен состоять только из цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\2223\Library02\Library02\Библиотека.accdb;";

            // Порядок полей в запросе: 1. Номер_чит_билета, 2. Фамилия, 3. Имя, 4. Номер_телефона
            string query = "INSERT INTO [Читатели] ([Номер_чит_билета], [Фамилия], [Имя], [Номер_телефона]) VALUES (?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // ПЕРЕДАЕМ ПАРАМЕТРЫ СТРОГО В ПОРЯДКЕ СЛЕДОВАНИЯ ЗНАКОВ "?" В ЗАПРОСЕ:

                    // 1-й "?" — Номер_чит_билета (берем из textBox4 и передаем как Число)
                    command.Parameters.Add("?", OleDbType.Integer).Value = ticketNumber;

                    // 2-й "?" — Фамилия (предполагаем, что это textBox1 или textBox2, проверь по форме)
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox1.Text.Trim();

                    // 3-й "?" — Имя
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox2.Text.Trim();

                    // 4-й "?" — Номер_телефона
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox3.Text.Trim();

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Читатель успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Закрываем форму добавления
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

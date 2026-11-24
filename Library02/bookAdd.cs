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
    public partial class bookAdd : Form
    {
        public bookAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Проверяем заполнение всех 5 полей
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, что в Количество вбито число
            if (!int.TryParse(textBox5.Text.Trim(), out int count))
            {
                MessageBox.Show("Поле 'Кол-во' должно быть числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";
            string query = "INSERT INTO [Книги] ([Название_книги], [Автор], [Год_издания], [Жанр], [Кол-во]) VALUES (?, ?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox1.Text.Trim(); // Название_книги (Текст)
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox2.Text.Trim(); // Автор (Текст)
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox3.Text.Trim(); // Год_издания (Текст)
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = textBox4.Text.Trim(); // Жанр (Текст)
                    command.Parameters.Add("?", OleDbType.Integer).Value = count;                 // Кол-во (ЧИСЛО)

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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

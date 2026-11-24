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
    public partial class vidachiAdd : Form
    {
        public vidachiAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, что абсолютно все 5 полей заполнены текстом
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все 5 полей формы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Проверяем, что в поля для ID были введены именно числа
            if (!int.TryParse(textBox1.Text.Trim(), out int idBook) ||
                !int.TryParse(textBox2.Text.Trim(), out int idReader) ||
                !int.TryParse(textBox3.Text.Trim(), out int idBiblio))
            {
                MessageBox.Show("ID Книги, Читателя и Библиотекаря должны состоять только из цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем корректность ввода дат, так как в Access это тип "Дата/время"
            if (!DateTime.TryParse(textBox4.Text.Trim(), out DateTime dateVydachi) ||
                !DateTime.TryParse(textBox5.Text.Trim(), out DateTime srokVydachi))
            {
                MessageBox.Show("Неверный формат даты в полях выдачи/срока! Используйте формат ДД.ММ.ГГГГ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 3. ДОПОЛНИТЕЛЬНАЯ ПРОВЕРКА ОСТАТКА
                    string checkQuery = "SELECT [Кол-во] FROM [Книги] WHERE [id_Книги] = ?";
                    int currentCount = 0;

                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.Add("?", OleDbType.Integer).Value = idBook;

                        object res = checkCmd.ExecuteScalar();
                        if (res == null)
                        {
                            MessageBox.Show("Книга с таким ID не найдена в системе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        currentCount = Convert.ToInt32(res);

                        if (currentCount <= 0)
                        {
                            MessageBox.Show("Этой книги больше нет в наличии на складе!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 4. ОФОРМЛЯЕМ СДЕЛКУ (Используем транзакцию)
                        using (OleDbTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // А. Добавляем новую запись в таблицу [Выдачи]
                                // Для Access логическое поле передаем как OleDbType.Boolean со значением false, а даты как OleDbType.Date
                                string insertQuery = "INSERT INTO [Выдачи] ([id_Книги], [id_Читателя], [id_Библиотекаря], [Дата_выдачи], [Срок_выдачи], [Факт_возврата]) VALUES (?, ?, ?, ?, ?, ?)";
                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, connection, transaction))
                                {
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = idBook;
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = idReader;
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = idBiblio;
                                    insertCmd.Parameters.Add("?", OleDbType.Date).Value = dateVydachi;
                                    insertCmd.Parameters.Add("?", OleDbType.Date).Value = srokVydachi;
                                    insertCmd.Parameters.Add("?", OleDbType.Boolean).Value = false; // Ложь (книга еще не вернулась)
                                    insertCmd.ExecuteNonQuery();
                                }

                                // Б. Уменьшаем числовое поле [Кол-во] в таблице [Книги] на единицу
                                string updateBookQuery = "UPDATE [Книги] SET [Кол-во] = [Кол-во] - 1 WHERE [id_Книги] = ?";
                                using (OleDbCommand updateCmd = new OleDbCommand(updateBookQuery, connection, transaction))
                                {
                                    updateCmd.Parameters.Add("?", OleDbType.Integer).Value = idBook;
                                    updateCmd.ExecuteNonQuery();
                                }

                                // Если обе операции прошли без сбоев — сохраняем изменения в Access
                                transaction.Commit();

                                MessageBox.Show("Выдача успешно зарегистрирована! Остаток книги на складе уменьшен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Закрываем форму выдачи, чтобы вернуться на главную панель
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                // Если случилась ошибка — отменяем изменения в БД
                                transaction.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Критическая ошибка при работе с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

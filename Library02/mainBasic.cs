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
    public partial class mainBasic : Form
    {
        // --- ЕДИНЫЙ ПУТЬ К БАЗЕ ДЛЯ ВСЕГО ФАЙЛА ---
        // Проверь, что этот путь правильный!
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\library04\Library02\Library02\Библиотека.accdb;";

        public mainBasic()
        {
            InitializeComponent();
        }

        // Загрузка формы при старте
        private void mainBasic_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        // Загрузка всех книг в каталог
        private void LoadAllBooks()
        {
            string query = "SELECT * FROM [Книги]";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Привязываем данные к таблице
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true; // Включаем автосоздание колонок
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка "Забронировать книгу"
        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalData.CurrentReaderId == 0)
            {
                MessageBox.Show("Ошибка: Вы не авторизованы! Войдите в систему.", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            // Берем ID книги из первой колонки
            object idValue = dataGridView1.CurrentRow.Cells[0].Value;
            if (idValue == null || idValue == DBNull.Value || idValue.ToString() == "")
            {
                MessageBox.Show("Не удалось определить ID книги.", "Ошибка");
                return;
            }

            int idBook = Convert.ToInt32(idValue);

            string query = "INSERT INTO [Бронирование] ([id_Книги], [Дата_брони], [Статус], [id_Читателя]) VALUES (?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("?", OleDbType.Integer).Value = idBook;
                    command.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                    command.Parameters.Add("?", OleDbType.VarWChar).Value = "Забронирована";
                    command.Parameters.Add("?", OleDbType.Integer).Value = GlobalData.CurrentReaderId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Книга успешно забронирована!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при бронировании: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка "Мои брони"
        private void button3_Click(object sender, EventArgs e)
        {
            if (GlobalData.CurrentReaderId == 0)
            {
                MessageBox.Show("Вы не авторизованы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT Бронирование.[Id_Брони], 
                                    Книги.[Название_книги], 
                                    Бронирование.[Дата_брони], 
                                    Бронирование.[Статус] 
                             FROM [Бронирование] 
                             LEFT JOIN [Книги] ON Бронирование.[id_Книги] = Книги.[id_Книги]
                             WHERE Бронирование.[id_Читателя] = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("?", OleDbType.Integer).Value = GlobalData.CurrentReaderId;

                    try
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = dt;

                        if (dt.Rows.Count == 0)
                            MessageBox.Show("У вас пока нет забронированных книг.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки ваших броней: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка "Каталог" (возврат ко всем книгам)
        private void button4_Click(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }
    }
}
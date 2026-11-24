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
    public partial class mainAdmin : Form
    {
        public mainAdmin()
        {
            InitializeComponent();
        }

        private void mainAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Загружаем стандартные таблицы
                this.выдачиTableAdapter.Fill(this.библиотекаDataSet.Выдачи);
                this.читателиTableAdapter.Fill(this.библиотекаDataSet.Читатели);
                this.библиотекариTableAdapter.Fill(this.библиотекаDataSet.Библиотекари);
                this.книгиTableAdapter.Fill(this.библиотекаDataSet.Книги);

                // 2. Загружаем Брони с названиями книг (через SQL-запрос)
                LoadBookingsWithBookNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Предупреждение: База данных содержит некорректные значения. Ошибка: " + ex.Message,
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Отдельный метод для загрузки броней
        private void LoadBookingsWithBookNames()
        {
            // ВАЖНО: Проверь путь! Если база в папке bin\Debug, укажи просто "Библиотека.accdb"
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\library04\Library02\Library02\Библиотека.accdb;";

            // Правильный SQL для Access с JOIN трех таблиц (скобки обязательны!)
            string query = @"SELECT Бронирование.[Id_Брони], 
                                    Книги.[Название_книги], 
                                    Читатели.[Фамилия] & ' ' & Читатели.[Имя] AS [Читатель], 
                                    Бронирование.[Дата_брони], 
                                    Бронирование.[Статус] 
                             FROM ([Бронирование] 
                             LEFT JOIN [Книги] ON Бронирование.[id_Книги] = Книги.[id_Книги])
                             LEFT JOIN [Читатели] ON Бронирование.[id_Читателя] = Читатели.[id_Читателя]";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Привязываем к DataGridView на вкладке Брони (имя dataGridView5)
                    dataGridView5.DataSource = null;
                    dataGridView5.Columns.Clear();
                    dataGridView5.AutoGenerateColumns = true;
                    dataGridView5.DataSource = dt;
                    dataGridView5.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка SQL: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: // Вкладка "Библиотекари"
                    bibliAdd addBiblioForm = new bibliAdd();
                    addBiblioForm.ShowDialog();
                    break;
                case 1: // Вкладка "Книги"
                    bookAdd addBookForm = new bookAdd();
                    addBookForm.ShowDialog();
                    break;
                case 2: // Вкладка "Читатели"
                    chitaAdd addchitForm = new chitaAdd();
                    addchitForm.ShowDialog();
                    break;
                case 3: // Вкладка "Выдачи"
                    vidachiAdd addVidachiForm = new vidachiAdd();
                    addVidachiForm.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Неизвестная вкладка", "Ошибка");
                    return;
            }
            ОбновитьВообщеВсеТаблицыЖестко();
        }

        private void ОбновитьВообщеВсеТаблицыЖестко()
        {
            string connectionStringMain = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\library04\Library02\Library02\Библиотека.accdb;";
            string[] tables = { "Библиотекари", "Книги", "Читатели", "Выдачи" };

            using (OleDbConnection conn = new OleDbConnection(connectionStringMain))
            {
                try
                {
                    conn.Open();
                    for (int i = 0; i < tables.Length; i++)
                    {
                        string tableName = tables[i];
                        string selectQuery = $"SELECT * FROM [{tableName}]";

                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, conn))
                        {
                            System.Data.DataTable tempTable = new System.Data.DataTable();
                            adapter.Fill(tempTable);

                            if (tabControl1.TabPages.Count > i && tabControl1.TabPages[i] != null)
                            {
                                foreach (Control ctrl in tabControl1.TabPages[i].Controls)
                                {
                                    if (ctrl is DataGridView dgv)
                                    {
                                        dgv.DataSource = null;
                                        dgv.DataSource = tempTable;
                                        dgv.Refresh();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при жестком обновлении таблиц: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridView currentDGV = null;
            if (tabControl1.SelectedTab != null)
            {
                foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                {
                    if (ctrl is DataGridView dgv)
                    {
                        currentDGV = dgv;
                        break;
                    }
                }
            }
            if (currentDGV == null) return;
            if (currentDGV.CurrentRow == null || currentDGV.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите строку для удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Удалить выбранную запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            object idValue = currentDGV.CurrentRow.Cells[0].Value;
            if (idValue == null || idValue == DBNull.Value)
            {
                MessageBox.Show("Не удалось получить ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tableName = "";
            string idFieldNameInAccess = "";
            string selectQuery = "";

            switch (tabControl1.SelectedIndex)
            {
                case 0: tableName = "[Библиотекари]"; idFieldNameInAccess = "id_Библиотекаря"; selectQuery = "SELECT * FROM [Библиотекари]"; break;
                case 1: tableName = "[Книги]"; idFieldNameInAccess = "id_Книги"; selectQuery = "SELECT * FROM [Книги]"; break;
                case 2: tableName = "[Читатели]"; idFieldNameInAccess = "id_Читателя"; selectQuery = "SELECT * FROM [Читатели]"; break;
                case 3: tableName = "[Выдачи]"; idFieldNameInAccess = "id_Выдачи"; selectQuery = "SELECT * FROM [Выдачи]"; break;
                default: MessageBox.Show("Для этой вкладки удаление не настроено."); return;
            }

            string connectionStringMain = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\library04\Library02\Library02\Библиотека.accdb;";
            string deleteQuery = $"DELETE FROM {tableName} WHERE [{idFieldNameInAccess}] = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionStringMain))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(idValue);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, conn))
                            {
                                System.Data.DataTable tempTable = new System.Data.DataTable();
                                adapter.Fill(tempTable);
                                currentDGV.DataSource = tempTable;
                            }
                        }
                        else MessageBox.Show("Не удалось удалить.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView4.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                dataGridView4.EndEdit();
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                if (row.DataBoundItem is DataRowView rowView)
                {
                    int idVydachi = Convert.ToInt32(rowView["id_Выдачи"]);
                    int idBook = Convert.ToInt32(rowView["id_Книги"]);
                    bool currentUIStatus = Convert.ToBoolean(rowView["Факт_возврата"]);
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeadlyParkurKiller18\Desktop\library04\Library02\Library02\Библиотека.accdb;";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string checkStatusQuery = "SELECT [Факт_возврата] FROM [Выдачи] WHERE [Id_Выдачи] = ?";
                            bool dbStatus = false;
                            using (OleDbCommand checkCmd = new OleDbCommand(checkStatusQuery, connection))
                            {
                                checkCmd.Parameters.Add("?", OleDbType.Integer).Value = idVydachi;
                                object res = checkCmd.ExecuteScalar();
                                if (res != null) dbStatus = Convert.ToBoolean(res);
                            }

                            if (!dbStatus && currentUIStatus)
                            {
                                using (OleDbTransaction transaction = connection.BeginTransaction())
                                {
                                    try
                                    {
                                        string updateVydacha = "UPDATE [Выдачи] SET [Факт_возврата] = ? WHERE [Id_Выдачи] = ?";
                                        using (OleDbCommand cmd1 = new OleDbCommand(updateVydacha, connection, transaction))
                                        {
                                            cmd1.Parameters.Add("?", OleDbType.Boolean).Value = true;
                                            cmd1.Parameters.Add("?", OleDbType.Integer).Value = idVydachi;
                                            cmd1.ExecuteNonQuery();
                                        }
                                        string updateBook = "UPDATE [Книги] SET [Кол-во] = [Кол-во] + 1 WHERE [Id_Книги] = ?";
                                        using (OleDbCommand cmd2 = new OleDbCommand(updateBook, connection, transaction))
                                        {
                                            cmd2.Parameters.Add("?", OleDbType.Integer).Value = idBook;
                                            cmd2.ExecuteNonQuery();
                                        }
                                        transaction.Commit();
                                        MessageBox.Show("Книга возвращена! Количество +1.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ОбновитьВообщеВсеТаблицыЖестко();
                                    }
                                    catch
                                    {
                                        transaction.Rollback();
                                        throw;
                                    }
                                }
                            }
                            else if (dbStatus && !currentUIStatus)
                            {
                                MessageBox.Show("Книга уже возвращена ранее.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ОбновитьВообщеВсеТаблицыЖестко();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при возврате: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void mainAdmin_Activated(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadBookingsWithBookNames();
        }
    }
}
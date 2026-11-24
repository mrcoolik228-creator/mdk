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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Выдачи". При необходимости она может быть перемещена или удалена.
            this.выдачиTableAdapter.Fill(this.библиотекаDataSet.Выдачи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Читатели". При необходимости она может быть перемещена или удалена.
            this.читателиTableAdapter.Fill(this.библиотекаDataSet.Читатели);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Библиотекари". При необходимости она может быть перемещена или удалена.
            this.библиотекариTableAdapter.Fill(this.библиотекаDataSet.Библиотекари);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Книги". При необходимости она может быть перемещена или удалена.
            this.книгиTableAdapter.Fill(this.библиотекаDataSet.Книги);

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
                    return; // Выходим, если вкладка неизвестна, чтобы не запускать обновление
            }

            // ЭТА СТРОКА СРАБОТАЕТ ДЛЯ ВСЕХ ВКЛАДОК АВТОМАТИЧЕСКИ ПОСЛЕ ЗАКРЫТИЯ ЛЮБОЙ ФОРМЫ!
            ОбновитьАктивнуюТаблицу();
        }
        private void ОбновитьАктивнуюТаблицу()
        {
            string tableName = "";

            // 1. Определяем, из какой именно таблицы Access брать данные в зависимости от открытой вкладки
            switch (tabControl1.SelectedIndex)
            {
                case 0: tableName = "Библиотекари"; break;
                case 1: tableName = "Книги"; break;
                case 2: tableName = "Читатели"; break;
                case 3: tableName = "Выдачи"; break;
                default: return; // Если вкладка не поддерживает обновление, ничего не делаем
            }

            // 2. Наш новый относительный путь к базе данных
            string connectionStringMain = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";
            string selectQuery = $"SELECT * FROM [{tableName}]";

            using (OleDbConnection conn = new OleDbConnection(connectionStringMain))
            {
                try
                {
                    conn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, conn))
                    {
                        System.Data.DataTable tempTable = new System.Data.DataTable();
                        adapter.Fill(tempTable);

                        // 3. Автоматически ищем DataGridView на активной вкладке и подменяем данные
                        if (tabControl1.SelectedTab != null)
                        {
                            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                            {
                                if (ctrl is DataGridView dgv)
                                {
                                    dgv.DataSource = tempTable;
                                    break; // Таблицу нашли, обновили и выходим из цикла поиска
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка автоматического обновления таблицы [{tableName}]: " + ex.Message,
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. Автоматически ищем DataGridView на текущей активной вкладке
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

            // Если таблицу на вкладке не нашли, ничего не делаем
            if (currentDGV == null) return;

            // 2. Проверяем, выделил ли пользователь строку для удаления
            if (currentDGV.CurrentRow == null || currentDGV.CurrentRow.Index < 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Запрашиваем подтверждение
            DialogResult confirm = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // 4. Получаем значение ID из САМОЙ ПЕРВОЙ ЯЧЕЙКИ выделенной строки
            object idValue = currentDGV.CurrentRow.Cells[0].Value;
            if (idValue == null || idValue == DBNull.Value)
            {
                MessageBox.Show("Не удалось получить ID выбранной строки. Ячейка пуста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tableName = "";
            string idFieldNameInAccess = "";
            string selectQuery = "";

            // 5. ДИНАМИЧЕСКИ НАСТРАИВАЕМ ИМЕНА ПОЛЕЙ ДЛЯ КАЖДОЙ ВКЛАДКИ
            switch (tabControl1.SelectedIndex)
            {
                case 0: // Вкладка "Библиотекари"
                    tableName = "[Библиотекари]";
                    idFieldNameInAccess = "id_Библиотекаря";
                    selectQuery = "SELECT * FROM [Библиотекари]";
                    break;

                case 1: // Вкладка "Книги"
                    tableName = "[Книги]";
                    idFieldNameInAccess = "id_Книги"; // Убедись, что в Access поле называется именно так
                    selectQuery = "SELECT * FROM [Книги]";
                    break;

                case 2: // Вкладка "Читатели"
                    tableName = "[Читатели]";
                    idFieldNameInAccess = "id_Читателя"; // Убедись, что в Access поле называется именно так
                    selectQuery = "SELECT * FROM [Читатели]";
                    break;

                case 3: // Вкладка "Выдачи"
                    tableName = "[Выдачи]";
                    idFieldNameInAccess = "id_Выдачи"; // Убедись, что в Access поле называется именно так
                    selectQuery = "SELECT * FROM [Выдачи]";
                    break;

                default:
                    MessageBox.Show("Для этой вкладки удаление не настроено.");
                    return;
            }

            // 6. Подключаемся к базе данных (используем твой рабочий путь с одной парой точек)
            string connectionStringMain = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Библиотека.accdb;";
            string deleteQuery = $"DELETE FROM {tableName} WHERE [{idFieldNameInAccess}] = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionStringMain))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(deleteQuery, conn))
                    {
                        // Принудительно передаем ID как число
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(idValue);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 7. МГНОВЕННО ОБНОВЛЯЕМ ТАБЛИЦУ СВЕЖИМИ ДАННЫМИ
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, conn))
                            {
                                System.Data.DataTable tempTable = new System.Data.DataTable();
                                adapter.Fill(tempTable);
                                currentDGV.DataSource = tempTable;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить запись. Возможно, она уже удалена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

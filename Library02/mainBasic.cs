using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library02
{
    public partial class mainBasic : Form
    {
        public mainBasic()
        {
            InitializeComponent();
        }

        private void mainBasic_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Читатели". При необходимости она может быть перемещена или удалена.
            this.читателиTableAdapter.Fill(this.библиотекаDataSet.Читатели);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Книги". При необходимости она может быть перемещена или удалена.
            this.книгиTableAdapter.Fill(this.библиотекаDataSet.Книги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Выдачи". При необходимости она может быть перемещена или удалена.
            this.выдачиTableAdapter.Fill(this.библиотекаDataSet.Выдачи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "библиотекаDataSet.Библиотекари". При необходимости она может быть перемещена или удалена.
            this.библиотекариTableAdapter.Fill(this.библиотекаDataSet.Библиотекари);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

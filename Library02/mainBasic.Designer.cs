namespace Library02
{
    partial class mainBasic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.библиотекаDataSet = new Library02.БиблиотекаDataSet();
            this.библиотекариBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.библиотекариTableAdapter = new Library02.БиблиотекаDataSetTableAdapters.БиблиотекариTableAdapter();
            this.idБиблиотекаряDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номертелефонаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.выдачиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.выдачиTableAdapter = new Library02.БиблиотекаDataSetTableAdapters.ВыдачиTableAdapter();
            this.книгиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.книгиTableAdapter = new Library02.БиблиотекаDataSetTableAdapters.КнигиTableAdapter();
            this.idКнигиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название_книги = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Автор = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Год_издания = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Жанр = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.читателиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.читателиTableAdapter = new Library02.БиблиотекаDataSetTableAdapters.ЧитателиTableAdapter();
            this.idЧитателяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерчитбилетаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номертелефонаDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.idВыдачиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idКнигиDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idЧитателяDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idБиблиотекаряDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датавыдачиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сроквыдачиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фактвозвратаDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.библиотекаDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.библиотекариBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.выдачиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.читателиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Библеотекари";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Книги";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Читатели";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 365);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Выдачи";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idБиблиотекаряDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.номертелефонаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.библиотекариBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(755, 352);
            this.dataGridView1.TabIndex = 0;
            // 
            // библиотекаDataSet
            // 
            this.библиотекаDataSet.DataSetName = "БиблиотекаDataSet";
            this.библиотекаDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // библиотекариBindingSource
            // 
            this.библиотекариBindingSource.DataMember = "Библиотекари";
            this.библиотекариBindingSource.DataSource = this.библиотекаDataSet;
            // 
            // библиотекариTableAdapter
            // 
            this.библиотекариTableAdapter.ClearBeforeFill = true;
            // 
            // idБиблиотекаряDataGridViewTextBoxColumn
            // 
            this.idБиблиотекаряDataGridViewTextBoxColumn.DataPropertyName = "id_Библиотекаря";
            this.idБиблиотекаряDataGridViewTextBoxColumn.HeaderText = "id_Библиотекаря";
            this.idБиблиотекаряDataGridViewTextBoxColumn.Name = "idБиблиотекаряDataGridViewTextBoxColumn";
            // 
            // фамилияDataGridViewTextBoxColumn
            // 
            this.фамилияDataGridViewTextBoxColumn.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.Name = "фамилияDataGridViewTextBoxColumn";
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            // 
            // номертелефонаDataGridViewTextBoxColumn
            // 
            this.номертелефонаDataGridViewTextBoxColumn.DataPropertyName = "Номер_телефона";
            this.номертелефонаDataGridViewTextBoxColumn.HeaderText = "Номер_телефона";
            this.номертелефонаDataGridViewTextBoxColumn.Name = "номертелефонаDataGridViewTextBoxColumn";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idКнигиDataGridViewTextBoxColumn,
            this.Название_книги,
            this.Автор,
            this.Год_издания,
            this.Жанр,
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.книгиBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(756, 353);
            this.dataGridView2.TabIndex = 0;
            // 
            // выдачиBindingSource
            // 
            this.выдачиBindingSource.DataMember = "Выдачи";
            this.выдачиBindingSource.DataSource = this.библиотекаDataSet;
            // 
            // выдачиTableAdapter
            // 
            this.выдачиTableAdapter.ClearBeforeFill = true;
            // 
            // книгиBindingSource
            // 
            this.книгиBindingSource.DataMember = "Книги";
            this.книгиBindingSource.DataSource = this.библиотекаDataSet;
            // 
            // книгиTableAdapter
            // 
            this.книгиTableAdapter.ClearBeforeFill = true;
            // 
            // idКнигиDataGridViewTextBoxColumn
            // 
            this.idКнигиDataGridViewTextBoxColumn.DataPropertyName = "id_Книги";
            this.idКнигиDataGridViewTextBoxColumn.HeaderText = "id_Книги";
            this.idКнигиDataGridViewTextBoxColumn.Name = "idКнигиDataGridViewTextBoxColumn";
            // 
            // Название_книги
            // 
            this.Название_книги.DataPropertyName = "Название_книги";
            this.Название_книги.HeaderText = "Название_книги";
            this.Название_книги.Name = "Название_книги";
            // 
            // Автор
            // 
            this.Автор.DataPropertyName = "Автор";
            this.Автор.HeaderText = "Автор";
            this.Автор.Name = "Автор";
            // 
            // Год_издания
            // 
            this.Год_издания.DataPropertyName = "Год_издания";
            this.Год_издания.HeaderText = "Год_издания";
            this.Год_издания.Name = "Год_издания";
            // 
            // Жанр
            // 
            this.Жанр.DataPropertyName = "Жанр";
            this.Жанр.HeaderText = "Жанр";
            this.Жанр.Name = "Жанр";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Кол-во";
            this.dataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idЧитателяDataGridViewTextBoxColumn,
            this.номерчитбилетаDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn1,
            this.имяDataGridViewTextBoxColumn1,
            this.номертелефонаDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.читателиBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(6, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(756, 353);
            this.dataGridView3.TabIndex = 0;
            // 
            // читателиBindingSource
            // 
            this.читателиBindingSource.DataMember = "Читатели";
            this.читателиBindingSource.DataSource = this.библиотекаDataSet;
            // 
            // читателиTableAdapter
            // 
            this.читателиTableAdapter.ClearBeforeFill = true;
            // 
            // idЧитателяDataGridViewTextBoxColumn
            // 
            this.idЧитателяDataGridViewTextBoxColumn.DataPropertyName = "id_Читателя";
            this.idЧитателяDataGridViewTextBoxColumn.HeaderText = "id_Читателя";
            this.idЧитателяDataGridViewTextBoxColumn.Name = "idЧитателяDataGridViewTextBoxColumn";
            // 
            // номерчитбилетаDataGridViewTextBoxColumn
            // 
            this.номерчитбилетаDataGridViewTextBoxColumn.DataPropertyName = "Номер_чит_билета";
            this.номерчитбилетаDataGridViewTextBoxColumn.HeaderText = "Номер_чит_билета";
            this.номерчитбилетаDataGridViewTextBoxColumn.Name = "номерчитбилетаDataGridViewTextBoxColumn";
            // 
            // фамилияDataGridViewTextBoxColumn1
            // 
            this.фамилияDataGridViewTextBoxColumn1.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.Name = "фамилияDataGridViewTextBoxColumn1";
            // 
            // имяDataGridViewTextBoxColumn1
            // 
            this.имяDataGridViewTextBoxColumn1.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn1.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn1.Name = "имяDataGridViewTextBoxColumn1";
            // 
            // номертелефонаDataGridViewTextBoxColumn1
            // 
            this.номертелефонаDataGridViewTextBoxColumn1.DataPropertyName = "Номер_телефона";
            this.номертелефонаDataGridViewTextBoxColumn1.HeaderText = "Номер_телефона";
            this.номертелефонаDataGridViewTextBoxColumn1.Name = "номертелефонаDataGridViewTextBoxColumn1";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idВыдачиDataGridViewTextBoxColumn,
            this.idКнигиDataGridViewTextBoxColumn1,
            this.idЧитателяDataGridViewTextBoxColumn1,
            this.idБиблиотекаряDataGridViewTextBoxColumn1,
            this.датавыдачиDataGridViewTextBoxColumn,
            this.сроквыдачиDataGridViewTextBoxColumn,
            this.фактвозвратаDataGridViewCheckBoxColumn});
            this.dataGridView4.DataSource = this.выдачиBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(6, 6);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(756, 353);
            this.dataGridView4.TabIndex = 0;
            // 
            // idВыдачиDataGridViewTextBoxColumn
            // 
            this.idВыдачиDataGridViewTextBoxColumn.DataPropertyName = "id_Выдачи";
            this.idВыдачиDataGridViewTextBoxColumn.HeaderText = "id_Выдачи";
            this.idВыдачиDataGridViewTextBoxColumn.Name = "idВыдачиDataGridViewTextBoxColumn";
            // 
            // idКнигиDataGridViewTextBoxColumn1
            // 
            this.idКнигиDataGridViewTextBoxColumn1.DataPropertyName = "id_Книги";
            this.idКнигиDataGridViewTextBoxColumn1.HeaderText = "id_Книги";
            this.idКнигиDataGridViewTextBoxColumn1.Name = "idКнигиDataGridViewTextBoxColumn1";
            // 
            // idЧитателяDataGridViewTextBoxColumn1
            // 
            this.idЧитателяDataGridViewTextBoxColumn1.DataPropertyName = "id_Читателя";
            this.idЧитателяDataGridViewTextBoxColumn1.HeaderText = "id_Читателя";
            this.idЧитателяDataGridViewTextBoxColumn1.Name = "idЧитателяDataGridViewTextBoxColumn1";
            // 
            // idБиблиотекаряDataGridViewTextBoxColumn1
            // 
            this.idБиблиотекаряDataGridViewTextBoxColumn1.DataPropertyName = "id_Библиотекаря";
            this.idБиблиотекаряDataGridViewTextBoxColumn1.HeaderText = "id_Библиотекаря";
            this.idБиблиотекаряDataGridViewTextBoxColumn1.Name = "idБиблиотекаряDataGridViewTextBoxColumn1";
            // 
            // датавыдачиDataGridViewTextBoxColumn
            // 
            this.датавыдачиDataGridViewTextBoxColumn.DataPropertyName = "Дата_выдачи";
            this.датавыдачиDataGridViewTextBoxColumn.HeaderText = "Дата_выдачи";
            this.датавыдачиDataGridViewTextBoxColumn.Name = "датавыдачиDataGridViewTextBoxColumn";
            // 
            // сроквыдачиDataGridViewTextBoxColumn
            // 
            this.сроквыдачиDataGridViewTextBoxColumn.DataPropertyName = "Срок_выдачи";
            this.сроквыдачиDataGridViewTextBoxColumn.HeaderText = "Срок_выдачи";
            this.сроквыдачиDataGridViewTextBoxColumn.Name = "сроквыдачиDataGridViewTextBoxColumn";
            // 
            // фактвозвратаDataGridViewCheckBoxColumn
            // 
            this.фактвозвратаDataGridViewCheckBoxColumn.DataPropertyName = "Факт_возврата";
            this.фактвозвратаDataGridViewCheckBoxColumn.HeaderText = "Факт_возврата";
            this.фактвозвратаDataGridViewCheckBoxColumn.Name = "фактвозвратаDataGridViewCheckBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "mainBasic";
            this.Text = "mainBasic";
            this.Load += new System.EventHandler(this.mainBasic_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.библиотекаDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.библиотекариBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.выдачиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.читателиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private БиблиотекаDataSet библиотекаDataSet;
        private System.Windows.Forms.BindingSource библиотекариBindingSource;
        private БиблиотекаDataSetTableAdapters.БиблиотекариTableAdapter библиотекариTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idБиблиотекаряDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номертелефонаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource выдачиBindingSource;
        private БиблиотекаDataSetTableAdapters.ВыдачиTableAdapter выдачиTableAdapter;
        private System.Windows.Forms.BindingSource книгиBindingSource;
        private БиблиотекаDataSetTableAdapters.КнигиTableAdapter книгиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idКнигиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название_книги;
        private System.Windows.Forms.DataGridViewTextBoxColumn Автор;
        private System.Windows.Forms.DataGridViewTextBoxColumn Год_издания;
        private System.Windows.Forms.DataGridViewTextBoxColumn Жанр;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource читателиBindingSource;
        private БиблиотекаDataSetTableAdapters.ЧитателиTableAdapter читателиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idЧитателяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерчитбилетаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn номертелефонаDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idВыдачиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idКнигиDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idЧитателяDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idБиблиотекаряDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn датавыдачиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сроквыдачиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn фактвозвратаDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}
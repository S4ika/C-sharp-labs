﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmographyDB
{
    public partial class Clientele : Form
    {
        public Clientele()
        {
            InitializeComponent();
        }

        private void Clientele_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sQL_FilmographyDataSet.Clientele". При необходимости она может быть перемещена или удалена.
            this.clienteleTableAdapter.Fill(this.sQL_FilmographyDataSet.Clientele);

        }

        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.MainForm.Activate();
        }

        private void сохранитьИзмененияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = sQL_FilmographyDataSet.Clientele;//Записывает данные из DataGrid в DataSet
                clienteleTableAdapter.Update(sQL_FilmographyDataSet);//Обновляет БД
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void удалитьТекущуюЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrencyManager CurMan = (CurrencyManager)dataGridView1.BindingContext[dataGridView1.DataSource];
            if (CurMan.Count > 0)
            {
                CurMan.RemoveAt(CurMan.Position);
                clienteleTableAdapter.Update(sQL_FilmographyDataSet);
            }
        }

        private void выйтиИзПроектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

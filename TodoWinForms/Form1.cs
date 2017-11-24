using System.Windows.Forms;
using TodoLogic;

namespace TodoWinForms
{
    public partial class Form1 : Form
    {
        private TasksLogic logics;

        public Form1()
        {
            InitializeComponent();

            logics = new TasksLogic(@"C:\Users\GSIKHARULIDZE9\Downloads\task-school-master\data.json");
            dataGridView1.DataSource = logics.List();
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Id"].Value;
            var name = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Name"].Value;
            var complete = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Completed"].Value;
            logics.Edit(id.ToString(), name.ToString(),complete.ToString());
            dataGridView1.DataSource = logics.List();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                logics.Create(new Task { Name = textBox1.Text });
                dataGridView1.DataSource = logics.List();
                textBox1.Text = "";
            }
            if (e.KeyData == Keys.F5)
            {
                dataGridView1.DataSource = logics.List();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var row = dataGridView1.CurrentCell.RowIndex;
                var id = dataGridView1.Rows[row].Cells["TodosGrid_Id"].Value;
                logics.Delete(id.ToString());
                dataGridView1.DataSource = logics.List();
            }
        }
    }
}

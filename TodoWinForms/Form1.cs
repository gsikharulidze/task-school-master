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

            logics = new TasksLogic();
            dataGridView1.DataSource = logics.List();
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Id"].Value;
            var name = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Name"].Value;
            var complete = dataGridView1.Rows[e.RowIndex].Cells["TodosGrid_Completed"].Value;
            logics.Rename(id.ToString(), name.ToString(), complete.ToString());
            dataGridView1.DataSource = logics.List();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
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
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
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
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }
        //deletecompleted
        private void button5_Click(object sender, System.EventArgs e)
        {
            logics.DeleceComplete();
            dataGridView1.DataSource = logics.List();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }
        //all active
        private void button3_Click(object sender, System.EventArgs e)
        {
            logics.AllActive();
            dataGridView1.DataSource = logics.List();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }
        // all complete
        private void button4_Click(object sender, System.EventArgs e)
        {
            logics.AllComplete();
            dataGridView1.DataSource = logics.List();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }
        //listcomplete
        private void button2_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = logics.ListCompleted();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }

        //listactive
        private void button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = logics.ListActive();
            label1.Text = logics.ActiveTasks(0).ToString() + " Items left";
        }
    }
}

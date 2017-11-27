using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TodoLogic;

namespace TodoWinForms
{
    public partial class Form1 : Form
    {
        private TasksLogic logics;

        TodoDatabaseEntities db = new TodoDatabaseEntities();
        Tasks Taskstable = new Tasks();

        public Form1()
        {
            InitializeComponent();

            logics = new TasksLogic(@"C:\Users\GSIKHARULIDZE9\Desktop\task-school-master\data.json");
            List<Tasks> t = new List<Tasks>();

            // DataContext takes a path of a database for data connection

            label1.Text = logics.ActiveTask(0).ToString() + " Items left";
            dataGridView3.DataSource = logics.List();
            dataGridView3.CellEndEdit += DataGridView1_CellEndEdit;

        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView3.Rows[e.RowIndex].Cells[0].Value;
            var name = dataGridView3.Rows[e.RowIndex].Cells[1].Value;
            var complete = dataGridView3.Rows[e.RowIndex].Cells[2].Value;
            logics.Edit(id.ToString(), name.ToString(), complete.ToString());
            dataGridView3.DataSource = logics.List();
            label1.Text = logics.ActiveTask(0).ToString() + "Items left";


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                logics.Create(new Tasks { Name = textBox1.Text });
                // dataGridView1.DataSource = logics.List();
                List<Tasks> t = new List<Tasks>();
                textBox1.Text = "";
                dataGridView3.DataSource = logics.List();

            }
            if (e.KeyData == Keys.F5)
            {
                dataGridView3.DataSource = logics.List();
            }
            label1.Text = logics.ActiveTask(0).ToString() + "Items left";
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                var row = dataGridView3.CurrentCell.RowIndex;
                var id = dataGridView3.Rows[row].Cells[0].Value;
                logics.Delete(id.ToString());
                label1.Text = logics.ActiveTask(0).ToString() + "Items left";
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            logics.AllComplete();
            dataGridView3.DataSource = logics.List();
            label1.Text = logics.ActiveTask(0).ToString() + "Items left";
        }
        //list complete
        private void button4_Click(object sender, System.EventArgs e)
        {
            dataGridView3.DataSource = logics.ListCompletedTasks();
            dataGridView3.CellEndEdit += DataGridView1_CellEndEdit;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            logics.AllActive();
            dataGridView3.DataSource = logics.List();
            label1.Text = logics.ActiveTask(0).ToString() + "Items left";
        }
        //listactive
        private void button3_Click(object sender, System.EventArgs e)
        {
            dataGridView3.DataSource = logics.ListActiveTasks();
            dataGridView3.CellEndEdit += DataGridView1_CellEndEdit;
        }
    }
}

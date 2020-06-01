using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //check if column header was clicked
            //lastly fix the bug on context menu not showing when all columns are hidden
            if (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            { 
                //create a context menu
                ContextMenu menu = new ContextMenu();

                //add items on the menu
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    MenuItem item = new MenuItem();

                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;

                    //now lets add the event if the item was clicked
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;

                        //lets update the check
                        item.Checked = column.Visible;

                        //show the selection again
                        menu.Show(dataGridView1, e.Location);
                    };

                    menu.MenuItems.Add(item);
                }

                //show the menu
                menu.Show(dataGridView1, e.Location);
            }
        }
    }
}

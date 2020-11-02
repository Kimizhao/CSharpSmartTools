using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AToolPlus
{
    public partial class ItemForm : Form
    {
        private CommandItem item = null;
        public ItemForm()
        {
            InitializeComponent();
        }

        public ItemForm(object obj, ItemFormState state = ItemFormState.Edit)
        {
            InitializeComponent();

            item = (CommandItem)(obj);
            this.textBox1.Text = item.CommandName;
            this.textBox2.Text = item.Description;
            this.textBox3.Text = item.DelayMicroSeconds.ToString();
            this.textBox4.Text = item.Order.ToString();

            if (state == ItemFormState.Edit)
            {
                this.Text = "编辑";
            }
            else if(state == ItemFormState.Add)
            {
                this.Text = "新增";
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            item.CommandName = this.textBox1.Text;
            item.Description = this.textBox2.Text;
            item.DelayMicroSeconds = Convert.ToInt32(this.textBox3.Text);
            item.Order = Convert.ToInt32(this.textBox4.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {

            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {

            }
        }
    }
}

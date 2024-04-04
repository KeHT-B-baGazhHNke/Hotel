using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Form1 : Form
    {
        private List<DAL.Guest> _list;

        public Form1()
        {
            InitializeComponent();

            _list = new List<DAL.Guest>();
            bindingSource1.DataSource = _list;
            dataGridView1.AutoGenerateColumns = true;
        }

        //public void Time()
        //{
        //    toolStripTextBox2.Text = DateTime.Now.TimeOfDay.ToString();
        //}

        private void Clock(object sender, EventArgs e)
        {
            ClockTimer clock = new ClockTimer(d => toolStripLabel2.Text = ("              "+d.ToString("HH : mm : ss")+"              "));
            clock.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuestCard card = new GuestCard();
            card.ShowDialog();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            _list.Clear();
            List<DAL.Guest> list = DAL.SQLiteHelper.GetUsers();
            if(list != null && list.Count > 0)
            {
                _list.AddRange(list);
                bindingSource1.ResetBindings(false);
            }

        }
    }
}

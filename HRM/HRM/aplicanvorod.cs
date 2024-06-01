using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class aplicanvorod : Form
    {
        public aplicanvorod()
        {
            InitializeComponent();
        }
        Applicants ac = new Applicants();
        private void button1_Click(object sender, EventArgs e)
        {
          

            
                ac.Show();
                ac.TopMost = true;
                ac.TopMost = false;
            
        }
    }
}

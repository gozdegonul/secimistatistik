using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secimistatistik
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnvatandas_Click(object sender, EventArgs e)
        {
            vatandassayfa vs=new vatandassayfa();
            vs.Show();
            this.Hide();
        }

        private void btnkullanici_Click(object sender, EventArgs e)
        {
            verigiris gr = new verigiris(); 
            gr.Show();
            this.Hide();
        }
    }
}

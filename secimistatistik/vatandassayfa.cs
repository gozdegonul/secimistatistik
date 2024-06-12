using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace secimistatistik
{
    public partial class vatandassayfa : Form
    {
        public vatandassayfa()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=Gozde_Huawei;Initial Catalog=secim;Integrated Security=True");

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vatandassayfa_Load(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand gr = new SqlCommand("select SUM(APARTİ),SUM(BPARTİ),SUM(CPARTİ),SUM(DPARTİ),SUM(EPARTİ) FROM secimtablo", connect);
            SqlDataReader dr1 = gr.ExecuteReader();
            while (dr1.Read())
            {
                charttr.Series["Partiler"].Points.AddXY("A PARTİ", dr1[0]);
                charttr.Series["Partiler"].Points.AddXY("B PARTİ", dr1[1]);
                charttr.Series["Partiler"].Points.AddXY("C PARTİ", dr1[2]);
                charttr.Series["Partiler"].Points.AddXY("D PARTİ", dr1[3]);
                charttr.Series["Partiler"].Points.AddXY("E PARTİ", dr1[4]);
             
               

            }
            connect.Close();

            connect.Open();
            SqlCommand n = new SqlCommand("select SUM(İLCENÜFÜS) FROM secimtablo", connect);
            SqlDataReader r= n.ExecuteReader();
            while (r.Read())
            {
                lblkos.Text = r[0].ToString();
            }
            connect.Close();
            connect.Open();
           SqlCommand pb = new SqlCommand("select SUM(APARTİ),SUM(BPARTİ),SUM(CPARTİ),SUM(DPARTİ),SUM(EPARTİ),SUM(İLCENÜFÜS) FROM secimtablo", connect);
            SqlDataReader dr2 = pb.ExecuteReader();
            while (dr2.Read())
            {
                lblAoys.Text = dr2[0].ToString();
                lblBoys.Text = dr2[1].ToString();
                lblCoys.Text = dr2[2].ToString();
                lblDoys.Text = dr2[3].ToString();
                lblEoys.Text = dr2[4].ToString();

                int max = int.Parse(lblAoys.Text) + int.Parse(lblBoys.Text) + int.Parse(lblCoys.Text) + int.Parse(lblDoys.Text) + int.Parse(lblEoys.Text);


                pbA.Maximum = max;
                pbB.Maximum = max;
                pbC.Maximum = max;
                pbD.Maximum = max;
                pbE.Maximum = max;
             

                pbA.Value = int.Parse(lblAoys.Text);
                pbB.Value = int.Parse(lblBoys.Text);
                pbC.Value = int.Parse(lblCoys.Text);
                pbD.Value = int.Parse(lblDoys.Text);
                pbE.Value = int.Parse(lblEoys.Text);

                double ay = (int.Parse(lblAoys.Text))* 100 / max ;
                double by = (int.Parse(lblBoys.Text) * 100 / max) ;
                double cy = (int.Parse(lblCoys.Text) * 100 / max) ;
                double dy = (int.Parse(lblDoys.Text) * 100 / max);
                double ey = (int.Parse(lblEoys.Text) * 100 / max);

                lblAy.Text = "%" + ay.ToString();
                lblBy.Text = "%" + by.ToString();
                lblCy.Text = "%" + cy.ToString();
                lblDy.Text = "%" + dy.ToString();
                lblEy.Text = "%" + ey.ToString();

                int asy = max * 100 / int.Parse(dr2[5].ToString());
                lblasy.Text = "%" + asy.ToString();

                if(ay>by && ay>cy && ay>dy && ay > ey)
                {
                    lblkp.Text = "A Partisi";
                }
                if (by > ay && by > cy && by > dy && by > ey)
                {
                    lblkp.Text = "B Partisi";
                }
                if (cy > ay && cy > by && cy > dy && cy > ey)
                {
                    lblkp.Text = "C Partisi";
                }
                if (dy > ay && dy > by && dy > cy && dy > ey)
                {
                    lblkp.Text = "D Partisi";
                }
                if (ey > ay && ey > by && ey > cy && ey > dy)
                {
                    lblkp.Text = "E Partisi";
                }


                int[] array = { int.Parse(lblAoys.Text) , int.Parse(lblBoys.Text), int.Parse(lblCoys.Text),
                int.Parse(lblDoys.Text),int.Parse(lblEoys.Text)};

                Array.Sort(array);
                Array.Reverse(array);

                int l1 = array[0];
                int l2 = array[1];

                int of = l1 - l2;
                lblof.Text = of.ToString();
                

            }
            connect.Close();

            connect.Open();
         
            SqlCommand cmd = new SqlCommand("Select İLCEAD from secimtablo",connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

            connect.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand gr = new SqlCommand("select APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ FROM secimtablo where İLCEAD=@p1", connect);
            gr.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr1 = gr.ExecuteReader();
            chartilce.Series["Partiler"].Points.Clear();
            while (dr1.Read())
            {
                chartilce.Series["Partiler"].Points.AddXY("A PARTİ", dr1[0]);
                chartilce.Series["Partiler"].Points.AddXY("B PARTİ", dr1[1]);
                chartilce.Series["Partiler"].Points.AddXY("C PARTİ", dr1[2]);
                chartilce.Series["Partiler"].Points.AddXY("D PARTİ", dr1[3]);
                chartilce.Series["Partiler"].Points.AddXY("E PARTİ", dr1[4]);
          


            }
            connect.Close() ;
            connect.Open();
            SqlCommand pb = new SqlCommand("Select APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ,İLCENÜFÜS FROM secimtablo where İLCEAD=@p1", connect);
            pb.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr2 = pb.ExecuteReader();
            while (dr2.Read())
            {
                lblAioys.Text = dr2[0].ToString();
                lblBioys.Text = dr2[1].ToString();
                lblCioys.Text = dr2[2].ToString();
                lblDioys.Text = dr2[3].ToString();
                lblEioys.Text = dr2[4].ToString();
                lblkosi.Text = dr2[5].ToString();

                int max = int.Parse(lblAioys.Text) + int.Parse(lblBioys.Text) + int.Parse(lblCioys.Text) + int.Parse(lblDioys.Text) + int.Parse(lblEioys.Text);


                pbAi.Maximum = max;
                pbBi.Maximum = max;
                pbCi.Maximum = max;
                pbDi.Maximum = max;
                pbEi.Maximum = max;


                pbAi.Value = int.Parse(lblAioys.Text);
                pbBi.Value = int.Parse(lblBioys.Text);
                pbCi.Value = int.Parse(lblCioys.Text);
                pbDi.Value = int.Parse(lblDioys.Text);
                pbEi.Value = int.Parse(lblEioys.Text);

                double ayi = (int.Parse(lblAioys.Text)) * 100 / max;
                double byi = (int.Parse(lblBioys.Text) * 100 / max);
                double cyi = (int.Parse(lblCioys.Text) * 100 / max);
                double dyi = (int.Parse(lblDioys.Text) * 100 / max);
                double eyi = (int.Parse(lblEioys.Text) * 100 / max);

                lblayi.Text = "%" + ayi.ToString();
                lblbyi.Text = "%" + byi.ToString();
                lblcyi.Text = "%" + cyi.ToString();
                lbldyi.Text = "%" + dyi.ToString();
                lbleyi.Text = "%" + eyi.ToString();

                int asy = max * 100 / int.Parse(dr2[5].ToString());
                lblasyi.Text = "%" + asy.ToString();

               if (ayi > byi && ayi > cyi && ayi > dyi && ayi > eyi)
                {
                    lblkip.Text = "A Partisi";
                }
                if (byi > ayi && byi > cyi && byi > dyi && byi > eyi)
                {
                    lblkip.Text = "B Partisi";
                }
                if (cyi > ayi && cyi > byi && cyi > dyi && cyi > eyi)
                {
                    lblkip.Text = "C Partisi";
                }
                if (dyi > ayi && dyi > byi && dyi > cyi && dyi > eyi)
                {
                    lblkip.Text = "D Partisi";
                }
                if (eyi > ayi && eyi > byi && eyi > cyi && eyi > dyi)
                {
                    lblkip.Text = "E Partisi";
                }
              

                int[] array = { int.Parse(lblAioys.Text) , int.Parse(lblBioys.Text), int.Parse(lblCioys.Text),
                int.Parse(lblDioys.Text),int.Parse(lblEioys.Text)};

                Array.Sort(array);
                Array.Reverse(array);

                int l1 = array[0];
                int l2 = array[1];

                int of = l1 - l2;
               
                lbliof.Text = of.ToString();


            }
            connect.Close();

       
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    }
}

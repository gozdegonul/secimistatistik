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
using System.Windows.Forms.DataVisualization.Charting;

namespace secimistatistik
{
    public partial class verigiris : Form
    {
        public verigiris()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=Gozde_Huawei;Initial Catalog=secim;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            verisayfa ks = new verisayfa();
            ks.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand gr2 = new SqlCommand("Select APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ from secimtablo where İLCEAD=@p1", connect);
            gr2.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr2 = gr2.ExecuteReader();
            while (dr2.Read())
            {
                lblA.Text = dr2[0].ToString();
                lblB.Text = dr2[1].ToString();
                lblC.Text = dr2[2].ToString();
                lblD.Text = dr2[3].ToString();

            }
            connect.Close();
            connect.Open();
            int aos = int.Parse(lblA.Text) + int.Parse(lblB.Text) + int.Parse(lblC.Text) + int.Parse(lblD.Text) + int.Parse(lblE.Text);
            SqlCommand kos = new SqlCommand("select İLCENÜFÜS FROM secimtablo where İLCEAD=@P1", connect);
            kos.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader kosd = kos.ExecuteReader();
            while (kosd.Read())
            {
                lblkos.Text = kosd[0].ToString();
                int aoy = aos * 100 / int.Parse(kosd[0].ToString());
                lblasy.Text = "%" + aoy.ToString();
            }
            lblaos.Text = aos.ToString();
            connect.Close();


        }

        private void verigiris_Load(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand gr = new SqlCommand("Select İLCEAD from secimtablo", connect);
            SqlDataReader dr = gr.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            connect.Close();







        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand getir = new SqlCommand("select * from secimtablo where İLCEAD = @p1", connect);
            getir.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader reader = getir.ExecuteReader();

            int A = 0, B = 0, C = 0, D = 0, E = 0;


            if (reader.Read())
            {

                A = Convert.ToInt32(reader["APARTİ"]);
                B = Convert.ToInt32(reader["BPARTİ"]);
                C = Convert.ToInt32(reader["CPARTİ"]);
                D = Convert.ToInt32(reader["DPARTİ"]);
                E = Convert.ToInt32(reader["EPARTİ"]);
            }

            reader.Close();


            A += int.Parse(txtA.Text);
            B += int.Parse(txtB.Text);
            C += int.Parse(txtC.Text);
            D += int.Parse(txtD.Text);
            E += int.Parse(txtE.Text);


            SqlCommand guncelle = new SqlCommand("update secimtablo set APARTİ = @p1, BPARTİ = @p2, CPARTİ = @p3, DPARTİ = @p4, EPARTİ = @p5 where İLCEAD = @p6", connect);
            guncelle.Parameters.AddWithValue("@p1", A);
            guncelle.Parameters.AddWithValue("@p2", B);
            guncelle.Parameters.AddWithValue("@p3", C);
            guncelle.Parameters.AddWithValue("@p4", D);
            guncelle.Parameters.AddWithValue("@p5", E);
            guncelle.Parameters.AddWithValue("@p6", comboBox1.Text);
            guncelle.ExecuteNonQuery();
            connect.Close();
            connect.Open();
            SqlCommand gr3 = new SqlCommand("Select APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ from secimtablo where İLCEAD=@p1", connect);
            gr3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr3 = gr3.ExecuteReader();
            while (dr3.Read())
            {
                lblA.Text = dr3[0].ToString();
                lblB.Text = dr3[1].ToString();
                lblC.Text = dr3[2].ToString();
                lblD.Text = dr3[3].ToString();
                lblE.Text = dr3[4].ToString();

            }
            connect.Close();
            connect.Open();
            SqlCommand ins = new SqlCommand("Select İLCENÜFÜS FROM secimtablo where İLCEAD=@p1", connect);
            ins.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader g = ins.ExecuteReader();
            while (g.Read())
            {
                int maxn = int.Parse(g[0].ToString());
                int t = int.Parse(lblA.Text) + int.Parse(lblB.Text) + int.Parse(lblC.Text) + int.Parse(lblD.Text) + int.Parse(lblE.Text);
                if (t <= maxn)
                {
                    MessageBox.Show("Veriler başarı ile yüklenmiştir.");


                }
                else if (t > maxn)
                {
                    MessageBox.Show("Girilen oy sayısı geçersizdir. Girilen oy sayısı kullanılan oy sayısından fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    A -= int.Parse(txtA.Text);
                    B -= int.Parse(txtB.Text);
                    C -= int.Parse(txtC.Text);
                    D -= int.Parse(txtD.Text);
                    E -= int.Parse(txtE.Text);

                    lblA.Text = A.ToString();
                    lblB.Text = B.ToString();
                    lblC.Text = C.ToString();
                    lblD.Text = D.ToString();
                    lblE.Text = E.ToString();

                }
            }
            connect.Close();
            connect.Open();
            SqlCommand sq = new SqlCommand("update secimtablo set APARTİ=@p1,BPARTİ=@p2,CPARTİ=@p3,DPARTİ=@p4,EPARTİ=@p5 where İLCEAD=@p6", connect);
            sq.Parameters.AddWithValue("@p1", lblA.Text);
            sq.Parameters.AddWithValue("@p2", lblB.Text);
            sq.Parameters.AddWithValue("@p3", lblC.Text);
            sq.Parameters.AddWithValue("@p4", lblD.Text);
            sq.Parameters.AddWithValue("@p5", lblE.Text);
            sq.Parameters.AddWithValue("@p6", comboBox1.Text);
            sq.ExecuteNonQuery();

            txtA.Text = string.Empty;
            txtB.Text = string.Empty;
            txtC.Text = string.Empty;
            txtD.Text = string.Empty;
            txtE.Text = string.Empty;
            txtA.Focus();

            connect.Close();




        
    

   
             
          
            


         

       


            }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }


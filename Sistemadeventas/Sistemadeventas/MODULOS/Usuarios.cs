using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Sistemadeventas
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panelICONO.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            panelICONO.Visible = true;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
           if(txtnombre.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroicono.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtcorreo.Text);
                    cmd.Parameters.AddWithValue("@Rol", txtrol.Text);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();//convirtiendo la imagen
                    icono.Image.Save(ms, icono.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                    panel4.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox3.Image;
            lblnumeroicono.Text = "1";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;

        }

        private void textnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox4.Image;
            lblnumeroicono.Text = "2";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox5.Image;
            lblnumeroicono.Text = "3";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox6.Image;
            lblnumeroicono.Text = "4";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox7.Image;
            lblnumeroicono.Text = "5";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox8.Image;
            lblnumeroicono.Text = "6";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox9.Image;
            lblnumeroicono.Text = "7";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            icono.Image = pictureBox10.Image;
            lblnumeroicono.Text = "8";
            LblanuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void textlogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblidusuario.Text = datalistado.SelectedCells[1].RowIndex.ToString();
            txtnombre.Text = datalistado.SelectedCells[2].RowIndex.ToString();
            txtlogin.Text = datalistado.SelectedCells[3].RowIndex.ToString();

            txtpassword.Text = datalistado.SelectedCells[4].RowIndex.ToString();

            icono.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            icono.Image = Image.FromStream(ms);
            LblanuncioIcono.Visible = false;

            lblnumeroicono.Text = datalistado.SelectedCells[6].RowIndex.ToString();
            txtcorreo.Text = datalistado.SelectedCells[7].RowIndex.ToString();
            txtrol.Text = datalistado.SelectedCells[8].RowIndex.ToString();
            panel4.Visible = true;

        }
    }
}

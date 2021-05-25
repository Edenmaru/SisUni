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
using System.Text.RegularExpressions;
using System.Configuration;

namespace SistemaUnique
{
    public partial class Form6 : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlcon"].ConnectionString);

        DataTable Categorias()
        {

            SqlDataAdapter da = new SqlDataAdapter("exec sp_categorias_combo", cn);
            DataTable tb = new DataTable();
            da.Fill(tb);

            return tb;
        }


        public Form6()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeComponent();
            cboCategoria.DisplayMember = "des_cat";
            cboCategoria.ValueMember = "cod_cat";
            cboCategoria.DataSource = Categorias();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtProducto.Text.Trim()) || String.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                using (new UtilMessageBox(this))
                {
                    MessageBox.Show("Ingrese los datos faltantes");
                }

            }
            else if (Regex.IsMatch(txtPrecio.Text, "^[0-9]{1,5}[.]{0,1}[0-9]{0,2}$") == false)
            {
                using (new UtilMessageBox(this))
                {
                    MessageBox.Show("Ingresar solo números y . para separar los decimales");
                }

            }
            else
            {
                decimal precio = decimal.Parse(txtPrecio.Text);
                cn.Open();
                try
                {


                    SqlCommand cmd = new SqlCommand("sp_agregarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nom", txtProducto.Text.Trim());
                    cmd.Parameters.AddWithValue("@stock", num1.Value);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@categoria", cboCategoria.SelectedValue);

                    int q = cmd.ExecuteNonQuery();
                    if (q == 0)
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Error al agregar producto");
                        }

                    }
                    else
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Producto agregado correctamente");
                        }
                        txtProducto.Clear();
                        txtPrecio.Clear();
                        txtProducto.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    using (new UtilMessageBox(this))
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally { cn.Close(); }

            }
        }
    }
}

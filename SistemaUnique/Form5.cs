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
using System.Configuration;

namespace SistemaUnique
{
    public partial class Form5 : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlcon"].ConnectionString);

        DataTable Categorias()
        {

            SqlDataAdapter da = new SqlDataAdapter("exec sp_categorias_combo", cn);
            DataTable tb = new DataTable();
            da.Fill(tb);

            return tb;
        }

        DataTable BuscarProducto(int codigo)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_buscarProducto", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@cod_prod", codigo);
            DataTable tb = new DataTable();
            da.Fill(tb);

            return tb;
        }

        public Form5()
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



        private void btnAumentar_Click(object sender, EventArgs e)
        {

            if (num1.Value == 0 || cboProducto.SelectedValue == null)
            {
                using (new UtilMessageBox(this)) { MessageBox.Show("Ingrese datos correctamente"); }
            }
            else
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_aumentarStock", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod_prod", cboProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@cantidad", num1.Value);

                    int q = cmd.ExecuteNonQuery();
                    if (q == 0)
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Error al aumentar stock");
                        }
                    }
                    else
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Producto actualizado correctamente");
                        }
                        num1.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    using (new UtilMessageBox(this))
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    cn.Close();
                }
                dgProducto.DataSource = BuscarProducto((int)cboProducto.SelectedValue);
                dgProducto.AutoResizeColumns();
                dgProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedValue != null)
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_listarProductosxCategoria_combo", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@cod", cboCategoria.SelectedValue);
                DataTable tb = new DataTable();
                da.Fill(tb);
                cboProducto.DisplayMember = "nom_prod";
                cboProducto.ValueMember = "cod_prod";
                cboProducto.DataSource = tb;

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cboProducto.SelectedValue == null)
            {
                using (new UtilMessageBox(this)) { MessageBox.Show("Ingrese datos correctamente"); }
            }
            else
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod_prod", cboProducto.SelectedValue);
                    

                    int q = cmd.ExecuteNonQuery();
                    if (q == 0)
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Error al eliminar producto");
                        }
                    }
                    else
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Producto eliminado correctamente");
                        }
                        cboCategoria.DisplayMember = "des_cat";
                        cboCategoria.ValueMember = "cod_cat";
                        cboCategoria.DataSource = Categorias();
                        num1.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    using (new UtilMessageBox(this))
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }

}

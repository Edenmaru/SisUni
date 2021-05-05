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

namespace SistemaUnique
{
    public partial class Form3 : Form
    {
        //Colocar usuario y password del Gestor de Base de Datos en uid y pwd respectivamente
        SqlConnection cn = new SqlConnection("server=.;database=BD_SIS_UNIQUE;uid=usuario;pwd=password");

        DataTable Categorias()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("exec sp_categorias_combo", cn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            
            return tb;
        }

        DataTable Ventas()
        {

            SqlDataAdapter da = new SqlDataAdapter("exec sp_listarVentas", cn);
            DataTable tb = new DataTable();
            da.Fill(tb);

            return tb;
        }

        IEnumerable<Producto> listadoProductos()
        {
            List<Producto> listado = new List<Producto>();
            SqlCommand cmd = new SqlCommand("sp_productos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto p = new Producto();
                p.cod_prod = dr.GetInt32(0);
                p.nom_prod = dr.GetString(1);
                p.stock = dr.GetInt32(2);
                p.precio = dr.GetDecimal(3);
                p.cat_prod = dr.GetInt32(4);
                listado.Add(p);
            }
            dr.Close();
            cn.Close();

            return listado;
        }

        public Form3()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeComponent();

            cboCategoria.DisplayMember = "des_cat";
            cboCategoria.ValueMember = "cod_cat";
            cboCategoria.DataSource = Categorias();

            

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Producto p = listadoProductos().Where(x => x.cod_prod == (int)cboProducto.SelectedValue).FirstOrDefault();

            if (num1.Value == 0 || cboProducto.SelectedValue == null) {
                using (new UtilMessageBox(this)) { 
                MessageBox.Show("Ingrese datos correctamente");
            } }

            else if(p.stock<num1.Value) {
                using (new UtilMessageBox(this))
                {
                    MessageBox.Show("No hay suficiente stock");
                }
            }
            else { 
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_vender", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_prod", cboProducto.SelectedValue);
                cmd.Parameters.AddWithValue("@cantidad", num1.Value);

                int q = cmd.ExecuteNonQuery();
                    if (q == 0)
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Error al vender");
                        }
                    }
                    else
                    {
                        using (new UtilMessageBox(this))
                        {
                            MessageBox.Show("Producto vendido");
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
            dgVenta.DataSource = Ventas();
                dgVenta.AutoResizeColumns();
                dgVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}

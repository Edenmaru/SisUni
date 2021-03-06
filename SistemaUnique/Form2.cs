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
    public partial class Form2 : Form
    {
        
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["mssqlcon"].ConnectionString);

        DataTable Categorias()
        {
            SqlDataAdapter da = new SqlDataAdapter("exec sp_categorias_combo", cn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public Form2()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeComponent();

            cboCategoria.DataSource = Categorias();
            cboCategoria.DisplayMember = "des_cat";
            cboCategoria.ValueMember = "cod_cat";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_listarProductosxCategoria", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@cod",cboCategoria.SelectedValue);
            DataTable tb = new DataTable();
            da.Fill(tb);
            dgProductos.DataSource = tb;
            dgProductos.AutoResizeColumns();
            dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Form4 : Form
    {
        //Colocar usuario y password del Gestor de Base de Datos en uid y pwd respectivamente
        SqlConnection cn = new SqlConnection("server=.;database=BD_SIS_UNIQUE;uid=usuario;pwd=password");

        public Form4()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeComponent();
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpHasta.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_listarProductosVendidos", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@fec1", dtpDesde.Value);
            da.SelectCommand.Parameters.AddWithValue("@fec2", dtpHasta.Value);
            DataTable tb = new DataTable();
            da.Fill(tb);
            if (tb.Rows.Count == 0)
            {
                using (new UtilMessageBox(this))
                {
                    MessageBox.Show("No existen ventas realizadas entre esas fechas");
                }
            }
            else
            {
                dgProductos.DataSource = tb;
                dgProductos.AutoResizeColumns();
                dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
                
        }
    }
}

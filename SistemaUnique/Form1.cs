using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaUnique
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void productoXCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 forma2 = new Form2();
            forma2.StartPosition = FormStartPosition.CenterParent;
            forma2.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 forma3 = new Form3();
            forma3.StartPosition = FormStartPosition.CenterParent;
            forma3.ShowDialog();
        }

        private void productosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 forma4 = new Form4();
            forma4.StartPosition = FormStartPosition.CenterParent;
            forma4.ShowDialog();
        }

        private void aumentarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 forma5 = new Form5();
            forma5.StartPosition = FormStartPosition.CenterParent;
            forma5.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 forma6 = new Form6();
            forma6.StartPosition = FormStartPosition.CenterParent;
            forma6.ShowDialog();
        }
    }
}

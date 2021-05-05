namespace SistemaUnique
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoXCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aumentarStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.listadosToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(232, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // listadosToolStripMenuItem
            // 
            this.listadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productoXCategoríaToolStripMenuItem,
            this.productosVendidosToolStripMenuItem});
            this.listadosToolStripMenuItem.Name = "listadosToolStripMenuItem";
            this.listadosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.listadosToolStripMenuItem.Text = "Listados";
            // 
            // productoXCategoríaToolStripMenuItem
            // 
            this.productoXCategoríaToolStripMenuItem.Name = "productoXCategoríaToolStripMenuItem";
            this.productoXCategoríaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.productoXCategoríaToolStripMenuItem.Text = "Producto x Categoría";
            this.productoXCategoríaToolStripMenuItem.Click += new System.EventHandler(this.productoXCategoríaToolStripMenuItem_Click);
            // 
            // productosVendidosToolStripMenuItem
            // 
            this.productosVendidosToolStripMenuItem.Name = "productosVendidosToolStripMenuItem";
            this.productosVendidosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.productosVendidosToolStripMenuItem.Text = "Productos vendidos";
            this.productosVendidosToolStripMenuItem.Click += new System.EventHandler(this.productosVendidosToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.aumentarStockToolStripMenuItem,
            this.realizarPedidoToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.pedidosToolStripMenuItem.Text = "Productos";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.agregarToolStripMenuItem.Text = "Agregar nuevo producto";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // aumentarStockToolStripMenuItem
            // 
            this.aumentarStockToolStripMenuItem.Name = "aumentarStockToolStripMenuItem";
            this.aumentarStockToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.aumentarStockToolStripMenuItem.Text = "Actualizar stock";
            this.aumentarStockToolStripMenuItem.Click += new System.EventHandler(this.aumentarStockToolStripMenuItem_Click);
            // 
            // realizarPedidoToolStripMenuItem
            // 
            this.realizarPedidoToolStripMenuItem.Name = "realizarPedidoToolStripMenuItem";
            this.realizarPedidoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.realizarPedidoToolStripMenuItem.Text = "Realizar venta";
            this.realizarPedidoToolStripMenuItem.Click += new System.EventHandler(this.realizarPedidoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(232, 158);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SISTEMA YANBAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoXCategoríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosVendidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aumentarStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
    }
}


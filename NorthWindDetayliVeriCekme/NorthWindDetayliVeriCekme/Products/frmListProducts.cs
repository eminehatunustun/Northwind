using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Products
{
    public partial class frmListProducts : Form
    {
        public frmListProducts()
        {
            InitializeComponent();
        }

        private void frmListProducts_Load(object sender, EventArgs e)
        {
            Entity.Products pro = new Entity.Products();
            pro.ListViewDoldur(lstwProducts);
        }
    }
}

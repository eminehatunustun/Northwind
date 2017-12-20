using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Suppliers
{
    public partial class frmListSuppliers : Form
    {
        public frmListSuppliers()
        {
            InitializeComponent();
        }

        private void frmListSuppliers_Load(object sender, EventArgs e)
        {
            Entity.Suppliers sup = new Entity.Suppliers();
            sup.listVieweDoldur(lstwSuppliers);
        }
    }
}

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
    public partial class frmDeleteSuppliers : Form
    {
        public frmDeleteSuppliers()
        {
            InitializeComponent();
        }
        Entity.Suppliers sup = new Entity.Suppliers();
        DAL.SuppliersDAL supDAL = new DAL.SuppliersDAL();
        private void frmDeleteSuppliers_Load(object sender, EventArgs e)
        {        
            sup.listVieweDoldur(lstwSuppliers);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Silmek istediğinize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (answer == DialogResult.Yes)
            {
                foreach (ListViewItem li in lstwSuppliers.SelectedItems)
                {
                    sup = li.Tag as Entity.Suppliers;
                }
             int result=   supDAL.Delete(sup.id);
                MessageBox.Show(result +" satır silindi.");
                sup.listVieweDoldur(lstwSuppliers);
            }
        }
    }
}

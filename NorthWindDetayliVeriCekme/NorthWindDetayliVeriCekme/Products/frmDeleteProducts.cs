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
    public partial class frmDeleteProducts : Form
    {
        public frmDeleteProducts()
        {
            InitializeComponent();
        }
        Entity.Products pro = new Entity.Products();
        DAL.ProductsDal proDAL = new DAL.ProductsDal();
        private void frmDeleteProducts_Load(object sender, EventArgs e)
        {
            pro.ListViewDoldur(lstwProducts);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Silmek istediğinize emin misiniz","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
            if (answer==DialogResult.Yes)
            {
                foreach (ListViewItem li in lstwProducts.SelectedItems)
                {
                    pro=li.Tag as  Entity.Products;
                    pro.id = pro.id;
                }
                proDAL.Delete(pro.id);
                pro.ListViewDoldur(lstwProducts);
            }
        }
    }
}

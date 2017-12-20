using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Categories
{
    public partial class frmDeleteCategories : Form
    {
        public frmDeleteCategories()
        {
            InitializeComponent();
        }
        Entity.Categories cat = new Entity.Categories();
        DAL.CategoriesDAL catDAL = new DAL.CategoriesDAL();
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Silmek istediğinize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (answer == DialogResult.Yes)
            {
                foreach (ListViewItem li in lstwCategories.SelectedItems)
                {
                    cat = li.Tag as Entity.Categories;
                }
                catDAL.Delete(cat.id);
                cat.ListVieweDoldur(lstwCategories);
            }
        }

        private void frmDeleteCategories_Load(object sender, EventArgs e)
        {
            cat.ListVieweDoldur(lstwCategories);
        }
    }
}

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
    public partial class frmUpdateCategories : Form
    {
        public frmUpdateCategories()
        {
            InitializeComponent();
        }
        DAL.CategoriesDAL catDAL = new DAL.CategoriesDAL();
        private void lstwCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lstwCategories.SelectedItems)
            {
                Entity.Categories seciliCat = li.Tag as Entity.Categories;
                txtCategoryName.Text = seciliCat.CategoryName;
                txtDescription.Text = seciliCat.Description;
            }
        }

        private void frmUpdateCategories_Load(object sender, EventArgs e)
        {

            Entity.Categories cat = new Entity.Categories();
            cat.ListVieweDoldur(lstwCategories);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Entity.Categories cat = new Entity.Categories();
            foreach (ListViewItem li in lstwCategories.SelectedItems)
            {
                cat = li.Tag as Entity.Categories;           
            }
            cat.CategoryName = txtCategoryName.Text;
            cat.Description = txtDescription.Text;
            catDAL.Update(cat);
            cat.ListVieweDoldur(lstwCategories);
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
        }
    }
}

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
    public partial class frmSaveCategories : Form
    {
        public frmSaveCategories()
        {
            InitializeComponent();
        }
        DAL.CategoriesDAL catDAL = new DAL.CategoriesDAL();
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Entity.Categories cat = new Entity.Categories();
            cat.CategoryName = txtCategoryName.Text;
            cat.Description = txtDescription.Text;
           int result= catDAL.Save(cat);
            MessageBox.Show(result + " satır etkilendi.");
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
        }
    }
}

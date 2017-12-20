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
    public partial class frmSaveProducts : Form
    {
        public frmSaveProducts()
        {
            InitializeComponent();
        }

        private void frmSaveProducts_Load(object sender, EventArgs e)
        {
            Entity.Categories cat = new Entity.Categories();
            cat.ComboboxDoldur(cbCategori);

            Entity.Suppliers sup = new Entity.Suppliers();
            sup.ComboboxDoldur(cbSupplier);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entity.Products pro = new Entity.Products();
            pro.ProductName = txtProductName.Text;
            pro.UnitPrice = nudUnitPrice.Value;
            pro.UnitsInStock = int.Parse(nudUnitsInStock.Value.ToString());

            Entity.Categories seciliCat = cbCategori.SelectedItem as Entity.Categories;
            pro.CategoryID = seciliCat.id;

            Entity.Suppliers seciliSup = cbSupplier.SelectedItem as Entity.Suppliers;
            pro.SupplierID = seciliSup.id;

            DAL.ProductsDal proDAL = new DAL.ProductsDal();
            int result = proDAL.Save(pro);
            MessageBox.Show(result.ToString() + " satır etkilendi.");
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
            en.Temizle(groupBox2);
        }
    }
}

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
    public partial class frmUpdateProducts : Form
    {
        public frmUpdateProducts()
        {
            InitializeComponent();
        }
        DAL.ProductsDal proDAL = new DAL.ProductsDal();
        Entity.Categories cat = new Entity.Categories();
        Entity.Suppliers sup = new Entity.Suppliers();
        Entity.Products pro = new Entity.Products();
        private void frmUpdateProducts_Load(object sender, EventArgs e)
        {           
            cat.ComboboxDoldur(cbCategori);          
            sup.ComboboxDoldur(cbSupplier);          
            pro.ListViewDoldur(lstwProducts);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        
            foreach (ListViewItem item in lstwProducts.SelectedItems)
            {
                pro = item.Tag as Entity.Products;
            }
            pro.ProductName = txtProductName.Text;
            pro.UnitPrice = nudUnitPrice.Value;
            pro.UnitsInStock = int.Parse(nudUnitsInStock.Value.ToString());
            pro.id = pro.id;

            Entity.Categories seciliCat = cbCategori.SelectedItem as Entity.Categories;
            pro.CategoryID = seciliCat.id;

            Entity.Suppliers seciliSup = cbSupplier.SelectedItem as Entity.Suppliers;
            pro.SupplierID = seciliSup.id;

            int result = proDAL.Update(pro);
            MessageBox.Show(result.ToString() + " satır etkilendi.");
            pro.ListViewDoldur(lstwProducts);
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
            en.Temizle(groupBox2);

        }

        private void lstwProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lstwProducts.SelectedItems)
            {
                pro = li.Tag as Entity.Products;
                txtProductName.Text = pro.ProductName;
                nudUnitPrice.Value = pro.UnitPrice;
                nudUnitsInStock.Value = pro.UnitsInStock;
                foreach (Entity.Categories item in cbCategori.Items)
                {
                    if (item.id==int.Parse(li.SubItems[2].Text))
                    {
                        cbCategori.SelectedItem = item;
                    }
                }
                foreach (Entity.Suppliers item in cbSupplier.Items)
                {
                    if (item.id == int.Parse(li.SubItems[1].Text))
                    {
                        cbSupplier.SelectedItem = item;
                    }
                }
            }
        }
    }
}

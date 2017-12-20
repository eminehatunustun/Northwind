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
    public partial class frmUpdateSuppliers : Form
    {
        public frmUpdateSuppliers()
        {
            InitializeComponent();
        }
        Entity.Suppliers sup = new Entity.Suppliers();
        DAL.SuppliersDAL supDAL = new DAL.SuppliersDAL();
        private void frmUpdateSuppliers_Load(object sender, EventArgs e)
        {       
            sup.listVieweDoldur(lstwSuppliers);
        }

        private void lstwSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lstwSuppliers.SelectedItems)
            {
                sup = li.Tag as Entity.Suppliers;
                txtCompanyName.Text = sup.CompanyName;
                txtContactName.Text = sup.ContactName;
                txtContactTitle.Text = sup.ContactTitle;
                txtCity.Text = sup.City;
                txtCountry.Text = sup.Country;
                txtAddress.Text = sup.Adress;
                mtxtPhone.Text = sup.Phone;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lstwSuppliers.SelectedItems)
            {
                sup = li.Tag as Entity.Suppliers;
            }
            sup.CompanyName = txtCompanyName.Text;
            sup.ContactName = txtContactName.Text;
            sup.ContactTitle = txtContactTitle.Text;
            sup.City = txtCity.Text;
            sup.Country = txtCountry.Text;
            sup.Adress = txtAddress.Text;
            sup.Phone = mtxtPhone.Text;
           int result= supDAL.Update(sup);
            MessageBox.Show(result + " satır güncellendi.");
            sup.listVieweDoldur(lstwSuppliers);
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
            en.Temizle(groupBox2);

        }
    }
}

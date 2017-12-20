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
    public partial class frmSaveSuppliers : Form
    {
        public frmSaveSuppliers()
        {
            InitializeComponent();
        }

        private void frmSaveSuppliers_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Entity.Suppliers sup = new Entity.Suppliers();
            sup.CompanyName = txtCompanyName.Text;
            sup.ContactName = txtContactName.Text;
            sup.ContactTitle = txtContactTitle.Text;
            sup.City = txtCity.Text;
            sup.Country = txtCountry.Text;
            sup.Adress = txtAddress.Text;
            sup.Phone = mtxtPhone.Text;
            DAL.SuppliersDAL supDAL = new DAL.SuppliersDAL();
            int result= supDAL.Save(sup);
            MessageBox.Show(result + " satır eklendi.");
            Entity.Entity en = new Entity.Entity();
            en.Temizle(groupBox1);
            en.Temizle(groupBox2);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            foreach (Control item in this.Controls)
            {
                if (item is MdiClient)
                {
                    item.BackColor = Color.SpringGreen;
                }
            }
        }
        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.frmListProducts frmListPro = new Products.frmListProducts();
            frmListPro.MdiParent = this;
            frmListPro.Show();
            
        }   
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.frmSaveProducts frmSavePro = new Products.frmSaveProducts();
            frmSavePro.MdiParent = this;
            frmSavePro.Show();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.frmUpdateProducts frmUpdatePro = new Products.frmUpdateProducts();
            frmUpdatePro.MdiParent = this;
            frmUpdatePro.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.frmDeleteProducts frmDeletePro = new Products.frmDeleteProducts();
            frmDeletePro.MdiParent = this;
            frmDeletePro.Show();
        }

        private void lİsteleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Categories.frmListCategories frmListCat = new Categories.frmListCategories();
            frmListCat.MdiParent = this;
            frmListCat.Show();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Categories.frmSaveCategories frmSaveCat = new Categories.frmSaveCategories();
            frmSaveCat.MdiParent = this;
            frmSaveCat.Show();
        }

        private void güncelleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Categories.frmUpdateCategories frmUpdateCat = new Categories.frmUpdateCategories();
            frmUpdateCat.MdiParent = this;
            frmUpdateCat.Show();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Categories.frmDeleteCategories frmDeleteCat = new Categories.frmDeleteCategories();
            frmDeleteCat.MdiParent = this;
            frmDeleteCat.Show();
        }

        private void lİsteleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Suppliers.frmListSuppliers frmListSuppliers = new Suppliers.frmListSuppliers();
            frmListSuppliers.MdiParent = this;
            frmListSuppliers.Show();
        }

        private void ekleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Suppliers.frmSaveSuppliers frmSaveSup = new Suppliers.frmSaveSuppliers();
            frmSaveSup.MdiParent = this;
            frmSaveSup.Show();
        }

        private void güncelleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Suppliers.frmUpdateSuppliers frmUpdateSup = new Suppliers.frmUpdateSuppliers();
            frmUpdateSup.MdiParent = this;
            frmUpdateSup.Show();
        }

        private void silToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Suppliers.frmDeleteSuppliers frmDeleteSup = new Suppliers.frmDeleteSuppliers();
            frmDeleteSup.MdiParent = this;
            frmDeleteSup.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

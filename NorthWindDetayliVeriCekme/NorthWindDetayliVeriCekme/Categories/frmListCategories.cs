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
    public partial class frmListCategories : Form
    {
        public frmListCategories()
        {
            InitializeComponent();
        }

        private void frmListCategories_Load(object sender, EventArgs e)
        {
            Entity.Categories cat = new Entity.Categories();
            cat.ListVieweDoldur(lstwCategories);
        }
    }
}

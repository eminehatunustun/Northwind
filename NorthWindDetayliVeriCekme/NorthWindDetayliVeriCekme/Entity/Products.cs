using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Entity
{
   public class Products :Entity
    {
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
        public void ListViewDoldur(ListView lstw)
        {
            lstw.Items.Clear();
            DAL.ProductsDal proDAL = new DAL.ProductsDal();
            List<Products> listPro = proDAL.List();
            foreach (Products pr in listPro)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = pr;
                li.Text = pr.ProductName;
                li.SubItems.Add(pr.SupplierID.ToString());
                li.SubItems.Add(pr.CategoryID.ToString());
                li.SubItems.Add(pr.UnitPrice.ToString());
                li.SubItems.Add(pr.UnitsInStock.ToString());
                li.SubItems.Add(pr.UnitsOnOrder.ToString());
                li.SubItems.Add(pr.Discontinued.ToString());
                lstw.Items.Add(li);
            }
        }
    }
}

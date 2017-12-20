using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Entity
{
   public class Suppliers :Entity
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public override string ToString()
        {
            return this.CompanyName;
        }
        public void ComboboxDoldur (ComboBox cb)
        {
            DAL.SuppliersDAL supDAL = new DAL.SuppliersDAL();

            List<Suppliers> listSup = supDAL.List();
            foreach (Suppliers sup in listSup)
            {
                cb.Items.Add(sup);
            }
            cb.SelectedIndex = 0;
        }
        public void listVieweDoldur(ListView lstw)
        {
            lstw.Items.Clear();
            DAL.SuppliersDAL supDAL = new DAL.SuppliersDAL();
            List<Suppliers> listSup = supDAL.List();
            foreach (Suppliers sup in listSup)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = sup;
                li.Text = sup.CompanyName;
                li.SubItems.Add(sup.ContactName);
                li.SubItems.Add(sup.ContactTitle);
                li.SubItems.Add(sup.Adress);
                li.SubItems.Add(sup.City);
                li.SubItems.Add(sup.Country);
                li.SubItems.Add(sup.Phone);
                lstw.Items.Add(li);
            }
        }
    }
}

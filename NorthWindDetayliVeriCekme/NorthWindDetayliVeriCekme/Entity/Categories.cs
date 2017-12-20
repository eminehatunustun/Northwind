using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWindDetayliVeriCekme.Entity
{
   public class Categories :Entity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return CategoryName;
        }
        public void ComboboxDoldur(ComboBox cb)
        {
            DAL.CategoriesDAL catDCAL = new DAL.CategoriesDAL();

            List<Categories> listCat = catDCAL.List();
            foreach (Categories cat in listCat)
            {
                cb.Items.Add(cat);
            }
            cb.SelectedIndex = 0;
        }
        public void ListVieweDoldur(ListView lstw)
        {
            lstw.Items.Clear();
            DAL.CategoriesDAL catDAL = new DAL.CategoriesDAL();
            List<Categories> listCat = catDAL.List();
            foreach (Categories cat in listCat)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = cat;
                li.Text = cat.CategoryName;
                li.SubItems.Add(cat.Description);
                lstw.Items.Add(li);
            }
        }
    }
}

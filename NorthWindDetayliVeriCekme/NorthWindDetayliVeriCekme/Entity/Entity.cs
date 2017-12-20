using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NorthWindDetayliVeriCekme.Entity
{
 public   class Entity : IEntity
    {
        private int ID;
        public int id
        {
            get
            {
                return this.ID;
            }

            set
            {
                this.ID = value;
            }
        }
        public void Temizle(GroupBox gb)
        {
            foreach (var item in gb.Controls)
            {
                if (item is TextBox )
                {              
                    TextBox c = (TextBox)item;
                    c.Clear();
                }
                if(item is NumericUpDown)
                {
                    NumericUpDown c = (NumericUpDown)item;
                    c.Value = 0;
                }
            }
        }
    }
}

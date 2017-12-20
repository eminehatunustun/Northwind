using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindDetayliVeriCekme.Entity;
using System.Data.SqlClient;
using System.Data;

namespace NorthWindDetayliVeriCekme.DAL
{
    public class ProductsDal : DataAccessLayer<Entity.Products>
    {
        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnn);
        //--------------------------------------------------------------------------------------------------------
        public override List<Entity.Products> List()
        {
            List<Entity.Products> listPro = new List<Entity.Products>();
            CnnOpen();
            try
            {
                cmd = new SqlCommand("Select * from Products", cnn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Entity.Products pr = new Entity.Products();
                        pr.id = int.Parse(reader["ProductID"].ToString());
                        pr.CategoryID = int.Parse(reader["SupplierID"].ToString());
                        pr.SupplierID = int.Parse(reader["CategoryID"].ToString());
                        pr.ProductName = reader["ProductName"].ToString();
                        pr.UnitPrice = decimal.Parse(reader["UnitPrice"].ToString());
                        pr.UnitsInStock = int.Parse(reader["UnitsInStock"].ToString());
                        pr.UnitsOnOrder = int.Parse(reader["UnitsOnOrder"].ToString());
                        pr.Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
                        listPro.Add(pr);
                    }
                }
            }
            catch (SqlException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            catch (Exception ey)
            {

                System.Windows.Forms.MessageBox.Show(ey.Message);
            }
            finally
            {
                cnn.Close();
            }
            return listPro;
        }
        //--------------------------------------------------------------------------------------------------------
        public override int Save(Entity.Products instance)
        {
            int result = 0;
            CnnOpen();
            try
            {
                cmd = new SqlCommand("pr_SaveProducts", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", instance.ProductName);
                cmd.Parameters.AddWithValue("@UnitPrice", instance.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", instance.UnitsInStock);
                cmd.Parameters.AddWithValue("@CategoryID", instance.CategoryID);
                cmd.Parameters.AddWithValue("@SupplierID", instance.SupplierID);
                result = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            catch (Exception ey)
            {

                System.Windows.Forms.MessageBox.Show(ey.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        //--------------------------------------------------------------------------------------------------------
        public override int Update(Entity.Products instance)
        {
            int result = 0;
            CnnOpen();
            try
            {
                cmd = new SqlCommand("pr_UpdateProducts", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", instance.ProductName);
                cmd.Parameters.AddWithValue("@UnitPrice", instance.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", instance.UnitsInStock);
                cmd.Parameters.AddWithValue("@CategoryID", instance.CategoryID);
                cmd.Parameters.AddWithValue("@SupplierID", instance.SupplierID);
                cmd.Parameters.AddWithValue("@ProductID", instance.id);
                result = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            catch (Exception ey)
            {

                System.Windows.Forms.MessageBox.Show(ey.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        //--------------------------------------------------------------------------------------------------------
        public override int Delete(object instanceID)
        {
            int result = 0;
            CnnOpen();
            try
            {
                cmd = new SqlCommand("pr_DeleteProducts", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", instanceID);
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            catch (Exception ey)
            {

                System.Windows.Forms.MessageBox.Show(ey.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        public void CnnOpen()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
        }
        //--------------------------------------------------------------------------------------------------------   
    }
}

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
    public class SuppliersDAL : DAL.DataAccessLayer<Entity.Suppliers>
    {
        SqlDataReader reader;
        SqlCommand cmd;
        SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnn);
        private void cnnOpen()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
        }
        public override List<Entity.Suppliers> List()
        {
            List<Entity.Suppliers> listSup = new List<Entity.Suppliers>();
            cnnOpen();
            try
            {
                cmd = new SqlCommand("Select * from Suppliers", cnn);
               reader= cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Entity.Suppliers sup = new Entity.Suppliers();
                        sup.id = int.Parse(reader["SupplierID"].ToString());
                        sup.CompanyName = reader["CompanyName"].ToString();
                        sup.ContactName = reader["ContactName"].ToString();
                        sup.ContactTitle = reader["ContactTitle"].ToString();
                        sup.Adress = reader["Address"].ToString();
                        sup.City = reader["City"].ToString();
                        sup.Country = reader["Country"].ToString();
                        sup.Phone = reader["Phone"].ToString();
                        listSup.Add(sup);
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
            return listSup;
        }

        public override int Save(Entity.Suppliers instance)
        {
            int result = 0;
            cnnOpen();
            try
            {
                cmd = new SqlCommand("pr_SaveSuppliers", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", instance.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", instance.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", instance.ContactTitle);
                cmd.Parameters.AddWithValue("@City", instance.City);
                cmd.Parameters.AddWithValue("@Country", instance.Country);
                cmd.Parameters.AddWithValue("@Address", instance.Adress);
                cmd.Parameters.AddWithValue("@Phone", instance.Phone);
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

        public override int Update(Entity.Suppliers instance)
        {
            int result = 0;
            cnnOpen();
            try
            {
                cmd = new SqlCommand("pr_UpdateSuppliers", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", instance.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", instance.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", instance.ContactTitle);
                cmd.Parameters.AddWithValue("@City", instance.City);
                cmd.Parameters.AddWithValue("@Country", instance.Country);
                cmd.Parameters.AddWithValue("@Address", instance.Adress);
                cmd.Parameters.AddWithValue("@Phone", instance.Phone);
                cmd.Parameters.AddWithValue("@SupplierID", instance.id);
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
        public override int Delete(object instanceID)
        {
            int result = 0;
            cnnOpen();
            try
            {
                cmd = new SqlCommand("pr_DeleteSuppliers", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierID", instanceID);
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
    }
}

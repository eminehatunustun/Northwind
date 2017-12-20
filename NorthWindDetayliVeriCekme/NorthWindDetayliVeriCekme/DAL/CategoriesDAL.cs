using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindDetayliVeriCekme.Entity;
using System.Data;
using System.Data.SqlClient;

namespace NorthWindDetayliVeriCekme.DAL
{
    public class CategoriesDAL : DataAccessLayer<Entity.Categories>
    {
        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnn);

        private void cnnOpen()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
        }

        //------------------------------------
        public override List<Entity.Categories> List()
        {
            List<Entity.Categories> listCat = new List<Entity.Categories>();
            cnnOpen();
            try
            {
                cmd = new SqlCommand("Select * from Categories", cnn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Entity.Categories cat = new Entity.Categories();
                        cat.id = int.Parse(reader["CategoryID"].ToString());
                        cat.CategoryName = reader["CategoryName"].ToString();
                        cat.Description = reader["Description"].ToString();
                        listCat.Add(cat);
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
            return listCat;
        }
        public override int Save(Entity.Categories instance)
        {
            int result = 0;
            cnnOpen();
            try
            {
                cmd = new SqlCommand("pr_SaveCategories", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", instance.CategoryName);
                cmd.Parameters.AddWithValue("@Description", instance.Description);
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

        public override int Update(Entity.Categories instance)
        {
            int result = 0;
            cnnOpen();
            try
            {
                cmd = new SqlCommand("pr_UpdateCategories", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", instance.CategoryName);
                cmd.Parameters.AddWithValue("@Description", instance.Description);
                cmd.Parameters.AddWithValue("@CategoryID", instance.id);
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
                cmd = new SqlCommand("pr_DeleteCategories", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", instanceID);
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

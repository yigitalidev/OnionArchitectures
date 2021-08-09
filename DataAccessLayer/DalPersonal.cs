using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DalPersonal
    {
        public static List<EntityPersonal> PersonalList()
        {
            List<EntityPersonal> value = new List<EntityPersonal>();
            SqlCommand commandİnf = new SqlCommand("Select * from Tbl_Information", connection.cnn);
            if (commandİnf.Connection.State != ConnectionState.Open)
            {
                commandİnf.Connection.Open();
            }
            SqlDataReader dr = commandİnf.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonal ent = new EntityPersonal();
                ent.Id = int.Parse(dr["Id"].ToString());
                ent.Name = dr["Name"].ToString();
                ent.Surname = dr["Surname"].ToString();
                ent.City = dr["Cıty"].ToString();
                ent.Mission = dr["Mıssıon"].ToString();
                ent.Wage = short.Parse(dr["Wage"].ToString());
                value.Add(ent);
            }
            dr.Close();
            return value;
        }

        public static int PersonalAdd(EntityPersonal e)
        {
            SqlCommand commandAdd = new SqlCommand("insert into Tbl_Information (Name,Surname,Cıty,Mıssıon,Wage) values (@p1,@p2,@p3,@p4,@p5)", connection.cnn);
            if (commandAdd.Connection.State != ConnectionState.Open)
            {
                commandAdd.Connection.Open();
            }
            commandAdd.Parameters.AddWithValue("@p1", e.Name);
            commandAdd.Parameters.AddWithValue("@p2", e.Surname);
            commandAdd.Parameters.AddWithValue("@p3", e.City);
            commandAdd.Parameters.AddWithValue("@p4", e.Mission);
            commandAdd.Parameters.AddWithValue("@p5", e.Wage);
            return commandAdd.ExecuteNonQuery();
        }

        public static bool PersonalDelete(int p)
        {
            SqlCommand cmdDelete = new SqlCommand("Delete from Tbl_Information where Id=@p1",connection.cnn);
            if (cmdDelete.Connection.State != ConnectionState.Open)
            {
                cmdDelete.Connection.Open();
            }
            cmdDelete.Parameters.AddWithValue("@p1",p);
            return cmdDelete.ExecuteNonQuery()>0;
        }

        public static bool PersonalUpdate(EntityPersonal ent)
        {
            SqlCommand cmdUpdate = new SqlCommand("Update Tbl_Information set Name=@p1,Surname=@p2,Cıty=@p3,Mıssıon=@p4,Wage=@p5 where Id=@p6",connection.cnn);
            if (cmdUpdate.Connection.State != ConnectionState.Open)
            {
                cmdUpdate.Connection.Open();
            }
            cmdUpdate.Parameters.AddWithValue("@p1", ent.Name);
            cmdUpdate.Parameters.AddWithValue("@p2", ent.Surname);
            cmdUpdate.Parameters.AddWithValue("@p3", ent.City);
            cmdUpdate.Parameters.AddWithValue("@p4", ent.Mission);
            cmdUpdate.Parameters.AddWithValue("@p5", ent.Wage);
            cmdUpdate.Parameters.AddWithValue("@p6", ent.Id);
            return cmdUpdate.ExecuteNonQuery()>0;
        }
    }
}

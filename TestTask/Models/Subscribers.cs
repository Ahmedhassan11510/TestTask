using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    [Table("Subscribers")]

    public class Subscribers
    {
        public int Id { get; set; }
        public string E_mail { get; set; }



        SqlConnection Conn = new SqlConnection("Data Source=A7MED;Initial Catalog=TaskData;Integrated Security=True");

        public void Addsub(Subscribers subscriber)
        {
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("insert into Subscribers (E_mail) values('" + subscriber.E_mail + "')", Conn);
            Scmm.ExecuteNonQuery();
            Conn.Close();
        }

        public List<Subscribers> AllSubscribers()
        {
            List<Subscribers> AllSub = new List<Subscribers>();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Subscribers ", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                Subscribers subscrib = new Subscribers();
                subscrib.Id = Convert.ToInt32(dr["Id"]);
                subscrib.E_mail = Convert.ToString(dr["E_mail"]);
                


                AllSub.Add(subscrib);
            }
            Conn.Close();

            return AllSub;
        }
        public Subscribers GetSubscriber(int id)
        {
            Subscribers subscrib = new Subscribers();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Subscribers where Id='"+id+"' ", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                subscrib.Id = Convert.ToInt32(dr["Id"]);
                subscrib.E_mail = Convert.ToString(dr["E_mail"]);



            }
            Conn.Close();

            return subscrib;
        }

        public void UpdateSub(int id, Subscribers subscriber)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("UPDATE Subscribers set E_mail='" + subscriber.E_mail + "'  where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }
        public void Delete(int id)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("Delete From Subscribers where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }




    }
}
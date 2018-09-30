using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    [Table("Consultation")]
    
    public class Consultations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string E_mail { get; set; }

        public string Phone { get; set; }
        public string Question { get; set; }
        public string Service { get; set; }


        SqlConnection Conn = new SqlConnection("Data Source=A7MED;Initial Catalog=TaskData;Integrated Security=True");

        public void Addconsultation(Consultations consultation)
        {
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("insert into Consultation (Name,E_mail,Phone,Question,Service) values( N'" + consultation.Name + "', N'" + consultation.E_mail + "','" + consultation.Phone + "',N'" + consultation.Question + "',N'" + consultation.Service + "')", Conn);
            Scmm.ExecuteNonQuery();
            Conn.Close();
        }
        public List<Consultations> AllConsultations()
        {
            List<Consultations> Allconsultattion = new List<Consultations>();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Consultation ", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                Consultations consoult = new Consultations();
                consoult.Id = Convert.ToInt32(dr["Id"]);
                consoult.E_mail = Convert.ToString(dr["E_mail"]);
                consoult.Name = Convert.ToString(dr["Name"]);
                consoult.Phone = Convert.ToString(dr["Phone"]);
                consoult.Question = Convert.ToString(dr["Question"]);
                consoult.Service = Convert.ToString(dr["Service"]);





                Allconsultattion.Add(consoult);
            }
            Conn.Close();

            return Allconsultattion;
        }

        public Consultations GetConsultation(int id)
        {
            Consultations consoult = new Consultations();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Consultation where Id='"+id+"'", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                consoult.Id = Convert.ToInt32(dr["Id"]);
                consoult.E_mail = Convert.ToString(dr["E_mail"]);
                consoult.Name = Convert.ToString(dr["Name"]);
                consoult.Phone = Convert.ToString(dr["Phone"]);
                consoult.Question = Convert.ToString(dr["Question"]);
                consoult.Service = Convert.ToString(dr["Service"]);





            }
            Conn.Close();

            return consoult;
        }


        public void Updateconsultations(int id, Consultations consultation)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("UPDATE Consultation set E_mail='" + consultation.E_mail + "',Name='"+ consultation .Name+ "',Service='" + consultation.Service + "',Phone='" + consultation.Phone + "',Question='" + consultation.Question + "'  where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }
        public void Delete(int id)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("Delete From Consultation where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    [Table("Users")]
    public class Users
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string E_mail { get; set; }
        
        public string Phone { get; set; }
        public string Massage { get; set; }
        public string Poromocode { get; set; }


        SqlConnection Conn = new SqlConnection("Data Source=A7MED;Initial Catalog=TaskData;Integrated Security=True");

        public void Register(Users user)
        {
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("insert into Users (Name,E_mail,Phone,Massage,Promocode) values( N'" + user.Name + "', N'" + user.E_mail + "','" + user.Phone + "',N'" + user.Massage + "','" + user.Poromocode + "')", Conn);
            Scmm.ExecuteNonQuery();
            Conn.Close();
        }
        public List<Users> Allusers()
        {
            List<Users> Allusers = new List<Users>();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Users ", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                Users user = new Users();
                user.Id = Convert.ToInt32(dr["Id"]);
                user.Name = Convert.ToString(dr["Name"]);
                user.E_mail = Convert.ToString(dr["E_mail"]);
                user.Phone = Convert.ToString(dr["Phone"]);
                user.Massage = Convert.ToString(dr["Massage"]);
                user.Poromocode = Convert.ToString(dr["Promocode"]);


                Allusers.Add(user);
            }
            Conn.Close();

            return Allusers;
        }

        public Users Getuser(int id)
        {
            Users user = new Users();
            Conn.Open();
            SqlCommand Scmm = new SqlCommand("select * from Users where Id='"+id+"'", Conn);
            SqlDataReader dr = Scmm.ExecuteReader();
            while (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                user.Name = Convert.ToString(dr["Name"]);
                user.E_mail = Convert.ToString(dr["E_mail"]);
                user.Phone = Convert.ToString(dr["Phone"]);
                user.Massage = Convert.ToString(dr["Massage"]);
                user.Poromocode = Convert.ToString(dr["Promocode"]);


            }
            Conn.Close();

            return user;
        }



        public void Updateuser(int id, Users user)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("UPDATE Users set Massage=N'"+user.Massage+"' ,Name =N'" + user.Name + "' ,E_mail='" + user.E_mail + "',Phone='" + user.Phone + "'  where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }
        public void Delete(int id)
        {
            Conn.Open();
            SqlCommand Sqlcmm = new SqlCommand("Delete From Users where Id='" + id + "' ", Conn);
            Sqlcmm.ExecuteNonQuery();
            Conn.Close();
        }
    }
}

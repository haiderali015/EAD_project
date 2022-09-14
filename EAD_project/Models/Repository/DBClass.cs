using EAD_project.Model;
using EAD_project.Models.Interface;
using Microsoft.Data.SqlClient;

namespace EAD_project.Models
{
    public class DBClass : ICustomer
    {
        public void saveData(CDatum l)
        {
           var context=new CDatumContext();
            context.customers.Add(l);
            context.SaveChanges();


        }



        public bool matchData(string email, string password)
        {
            var db = new CDatumContext();
            var result = db.customers.Any(customer => customer.Email == email && customer.Password == password);

            return result;
        }


        /*public static List<members> displayMembers()
       {
           List<members> members = new List<members>();
           return members;
       }*/

















        public static bool AdminLogin(string email, string password)
        {

            string connection = @"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from admins  WHERE email = @e AND password=@p";
            SqlParameter p1 = new SqlParameter("e", email);
            SqlParameter p2 = new SqlParameter("p", password);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


    }

    }


    


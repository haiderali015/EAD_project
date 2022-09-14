using Microsoft.Data.SqlClient;
namespace EAD_project.Models
{
    public class roomsdata
    {
        public int roomNum { get; set; }
        public string description { get; set; }
        public string roomPic { get; set; }
        public string roomPrice { get; set; }
        public string suite { get; set; }
        public string reserved { get; set; }  

    }
    public class roomsDataFunction
    {
        public static List<roomsdata> getData()
        {
            string connection =@"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn=new SqlConnection(connection);
            conn.Open();
            string sql = "select * from Rooms";
            List<roomsdata> roomsdataList = new List<roomsdata>();
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                roomsdata roomsdata = new roomsdata();
                roomsdata.roomNum = Convert.ToInt32(dr[1]);
                roomsdata.description = Convert.ToString(dr[2]);
                roomsdata.roomPic = Convert.ToString(dr[3]);
                roomsdata.roomPrice = Convert.ToString(dr[4]);
                roomsdata.suite = Convert.ToString(dr[5]);
                roomsdataList.Add(roomsdata);
            }
            return roomsdataList;

        }

       

        public  void addRoom(int roomNo, string desc,string roomPic,string roomPrice,string suite)
        {
            string connection = @"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
         
            string query = "INSERT INTO Rooms(roomNum,description,roomPic,roomPrice,suite) VALUES('" + roomNo + "','" + desc + "','"+ roomPic+ "','" + roomPrice + "','" + suite + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int quz = cmd.ExecuteNonQuery();
            

        }

        public void DeleteAccount(int roomNum)
        {                                                       //deleting a user 
            string connection = @"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string query = "DELETE FROM Rooms WHERE roomNum='" + roomNum + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            int quz = cmd.ExecuteNonQuery();
           

        }

        /*public void roomReserved(int roomNo, string desc, string roomPic, string roomPrice, string suite)
        {
            string connection = @"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            string query = "INSERT INTO Rooms(roomNum,description,roomPic,roomPrice,suite) VALUES('" + roomNo + "','" + desc + "','" + roomPic + "','" + roomPrice + "','" + suite + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int quz = cmd.ExecuteNonQuery();


        }*/
    }
}

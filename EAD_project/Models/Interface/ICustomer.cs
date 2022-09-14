namespace EAD_project.Models.Interface
{
    public interface ICustomer
    {
        public  void saveData(CDatum l);

        public  bool matchData(string email, string password);
    }
}

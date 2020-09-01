namespace VoterRegistration.Data
{
    public interface IDataLayer
    {
        string GetUser(int userId);
        bool RegisterUser(int voterId, string voterName);
    }
}
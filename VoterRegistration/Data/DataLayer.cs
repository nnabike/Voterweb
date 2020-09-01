using System;

namespace VoterRegistration.Data
{
    public class DataLayer : IDataLayer
    {
        readonly VoterDataLayer voterDataLayer = new VoterDataLayer();

        public DataLayer()
        {

        }

        public string GetUser(int voterId) { return voterDataLayer.GetUser(voterId); }

        public bool RegisterUser(int voterId, string voterName)
        {
            try
            {
                voterDataLayer.RegisterUser(voterId, voterName);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update the Voter", ex);
            }

        }
    }
}
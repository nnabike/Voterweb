using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace VoterRegistration.Data
{
    public class VoterDataLayer
    {
        string connString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        
        public string GetUser(int voterId)
        {
            string userName = string.Empty;
            using (OracleConnection objConn = new OracleConnection(connString))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = @"GETVOTER";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("voterid", OracleDbType.Int32).Value = voterId;
                objCmd.Parameters.Add("out_name", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    
                    userName = objCmd.Parameters["out_name"].Value.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to get user from datastore", ex);
                }
                objConn.Close();
            }
            return userName;
        }
        public void RegisterUser(int voterId, string voterName)
        {
            using (OracleConnection objConn = new OracleConnection(connString))
            {
                OracleCommand objCmd = new OracleCommand
                {
                    Connection = objConn,
                    CommandText = @"UpdateVoter",
                    CommandType = CommandType.StoredProcedure
                };
                objCmd.Parameters.Add("P_voterid", OracleDbType.Int32).Value = voterId;
                objCmd.Parameters.Add("p_votername", OracleDbType.Varchar2, 50).Value = voterName;

                try
                {
                    
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to update user in datastore", ex);
                }
                objConn.Close();
            }
        }
    }
}

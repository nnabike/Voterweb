using System;
using System.Collections.Generic;
using VoterRegistration.Data;
using VoterRegistration.DataObjects;

namespace VoterRegistration.Business
{
    public class RegisterBusiness : IRegisterBusiness
    {
        IDataLayer _dataLayer;
        public RegisterBusiness(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public VoterDO GetVoter(int voterId)
        {
            var voterDO = new VoterDO { VoterId = voterId };

            if (!ValidateVoterId(voterId))
            {
                voterDO.Message = "Invalid User";
                return voterDO;
            }

            try
            {
                var userName = _dataLayer.GetUser(voterId);
                voterDO.IsSuccess = true;
                voterDO.Name = userName;
            }
            catch (Exception ex)
            {
                voterDO.IsSuccess = false;
                voterDO.Message = ex.Message; 
                //Log detailed exception here
            }
            return voterDO;
        }

        public VoterDO RegisterVoter(int voterId, string voterName)
        {
            var voterDO = new VoterDO
            {
                IsSuccess = false,
                Name = voterName,
                VoterId = voterId,
            };
            if (ValidateName(voterName))
            {
                try
                {
                    var isRegistered = _dataLayer.RegisterUser(voterId, voterName);
                    voterDO.IsSuccess = isRegistered;
                }
                catch (Exception ex)
                {
                    voterDO.Message = ex.Message;
                }
            }
            else
            {
                voterDO.Message = "Admin and Root are reserved names";
            }

            return voterDO;
        }

        private bool ValidateName(string voterName)
        {
            var reservedNames = new List<string> { "admin", "root" };

            return !reservedNames.Contains(voterName) 
                && !string.IsNullOrEmpty(voterName);
        }

        private bool ValidateVoterId(int userId)
        {
            return userId > 0;
        }

    }
}
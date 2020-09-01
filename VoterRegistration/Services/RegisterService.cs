using VoterRegistration.Business;
using VoterRegistration.Data;
using VoterRegistration.Models;

namespace VoterRegistration.Services
{
    public class RegisterService
    {
        //Todo: Implement Unity and Use constructor injection here
        readonly RegisterBusiness registerBusiness = new RegisterBusiness(new DataLayer());

        public VoterResponse GetVoter(int voterId)
        {
            var voterDO = registerBusiness.GetVoter(voterId);
            return new VoterResponse { 
                        Voter = new Voter { Name = voterDO.Name, VoterId = voterDO.VoterId },
                        Message = voterDO.Message,
                        IsSuccess = voterDO.IsSuccess
            };
            
        }

        public VoterResponse RegisterVoter(int voterId, string voterName)
        {
            var voterDO = registerBusiness.RegisterVoter(voterId, voterName);
            return new VoterResponse
            {
                Voter = new Voter { Name = voterDO.Name, VoterId = voterDO.VoterId },
                Message = voterDO.Message,
                IsSuccess = voterDO.IsSuccess
            };

        }


    }
}
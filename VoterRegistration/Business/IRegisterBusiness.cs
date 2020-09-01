using VoterRegistration.DataObjects;

namespace VoterRegistration.Business
{
    public interface IRegisterBusiness
    {
        VoterDO GetVoter(int userId);
        VoterDO RegisterVoter(int voterId, string voterName);
    }
}
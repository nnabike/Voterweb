namespace VoterWeb.Models
{
    public class VoterResponse
    {
        public Voter Voter { get; set; }
        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}
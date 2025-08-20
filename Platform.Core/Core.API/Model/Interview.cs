namespace Core.API.Model
{
    public class Interview
    {
        public Guid Id { get; set; }
        public int Candidate { get; set; }
        public Recruiter recruiter { get; set; }
        public int InterviewerId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public string MeetingLink { get; set; }
        public InterviewStatus Status { get; set; }
    }
}
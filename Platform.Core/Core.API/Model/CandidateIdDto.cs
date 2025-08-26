namespace Core.API.Model;

public class CandidateInfoDto
{
      public CandidateInfoDto() { }  


        public string Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public IFormFile ResumeUrl { get; set; }
}
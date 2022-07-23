using System.ComponentModel.DataAnnotations;

namespace Interview.Application.InputModels
{
    public class CalendarInputModel
    {
        [Required]
        public int CandidateId { get; set; }
        [Required]
        [MinLength(1)]
        public List<int> InterviewersIds { get; set; }
    }
}

using Interview.Application.InputModels.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interview.Application.InputModels
{
    public class AvailabilityInputModel
    {
        public AvailabilityInputModel() { }

        public AvailabilityInputModel(string name, List<AvailabilitySlotsInputModel> availabilities)
        {
            Name = name;
            Availabilities = availabilities;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public List<AvailabilitySlotsInputModel> Availabilities { get; set; }
        public bool Valid => new AvailabilityValidator().Validate(this).IsValid;
        public IReadOnlyList<string> Notifications => new AvailabilityValidator().Validate(this).Errors.Select(p => p.ErrorMessage).ToList();
    }

    public class AvailabilitySlotsInputModel {
        public AvailabilitySlotsInputModel() { }
        public AvailabilitySlotsInputModel(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

using Interview.Application.InputModels;

namespace Interview.Tests
{
    [Trait(nameof(Interview), "Interview")]
    public class AvailabilityTests
    {
        [Fact]
        public void Should_Return_With_One_Notification_Of_EndDate() {
            var slots = new List<AvailabilitySlotsInputModel>() {
                new(new DateTime(2022,07,27,05,00,00), new DateTime(2022,07,27,05,00,00))
            };
            var candidate = new CandidateInputModel("John", slots);

            Assert.Equal(1, candidate.Notifications.Count);
        }

        [Fact]
        public void Should_Return_With_Notification_Of_WeekendDays()
        {
            var slots = new List<AvailabilitySlotsInputModel>() {
                new(new DateTime(2022,07,23,08,00,00), new DateTime(2022,07,23,09,00,00))
            };
            var candidate = new CandidateInputModel("Carla", slots);

            Assert.Equal(2, candidate.Notifications.Count);
        }

        [Fact]
        public void Should_Return_With_Notification_Of_Minutes()
        {
            var slots = new List<AvailabilitySlotsInputModel>() {
                new(new DateTime(2022,07,28,08,30,00), new DateTime(2022,07,28,09,30,00))
            };
            var interviewer = new InterviewerInputModel("Mary", slots);

            Assert.Equal(2, interviewer.Notifications.Count);
        }

        [Fact]
        public void Should_Return_Without_Notification_Of_Candidate()
        {
            var slots = new List<AvailabilitySlotsInputModel>() {
                new(new DateTime(2022,08,01,10,00,00), new DateTime(2022,08,01,11,00,00))
            };
            var candidate = new CandidateInputModel("Juan", slots);

            Assert.Equal(0, candidate.Notifications.Count);
        }

        [Fact]
        public void Should_Return_Without_Notification_Of_Interviewer()
        {
            var slots = new List<AvailabilitySlotsInputModel>() {
                new(new DateTime(2022,08,01,10,00,00), new DateTime(2022,08,01,11,00,00))
            };
            var candidate = new InterviewerInputModel("Diana", slots);

            Assert.Equal(0, candidate.Notifications.Count);
        }
    }
}

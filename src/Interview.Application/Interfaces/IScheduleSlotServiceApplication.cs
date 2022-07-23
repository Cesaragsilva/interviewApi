using Interview.Application.InputModels;

namespace Interview.Application.Interfaces
{
    public interface IScheduleSlotServiceApplication
    {
        bool AllowedSlots(List<AvailabilitySlotsInputModel> slots);
    }
}

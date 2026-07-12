using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusNova.Domain.Models;

namespace NexusNova.UI.ViewModels;

public partial class AgendaViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<AgendaEvent> _events = [];

    [ObservableProperty]
    private int _eventCount;

    public AgendaViewModel()
    {
        LoadSampleEvents();
    }

    private void LoadSampleEvents()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        Events =
        [
            new AgendaEvent
            {
                Title = "Project Alpha Review",
                EventDate = today.AddHours(14),
                IsSynced = true
            },
            new AgendaEvent
            {
                Title = "Weekly Backend Sync",
                EventDate = tomorrow.AddHours(10),
                IsSynced = true
            },
            new AgendaEvent
            {
                Title = "Client Demo & Feedback",
                EventDate = tomorrow.AddHours(16),
                IsSynced = true
            },
            new AgendaEvent
            {
                Title = "Sprint Planning",
                EventDate = tomorrow.AddHours(11).AddMinutes(30),
                IsSynced = true
            },
            new AgendaEvent
            {
                Title = "Gym Workout",
                EventDate = today.AddHours(18),
                IsSynced = true
            }
        ];

        EventCount = Events.Count;
    }

    [RelayCommand]
    private void ClearAgenda()
    {
        Events.Clear();
        EventCount = 0;
    }
}

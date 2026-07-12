using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NexusNova.Domain.Models;

namespace NexusNova.UI.ViewModels;

public partial class AssistantViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _messageInput = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ChatMessage> _messages = [];

    [ObservableProperty]
    private ObservableCollection<SuggestedAction> _suggestedActions = [];

    public AssistantViewModel()
    {
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        Messages =
        [
            new ChatMessage
            {
                Content = "Welcome to NexusNova. I have successfully initialized your secure Google Workspace & Productivity Assistant. How can I help you manage your calendar and optimize your schedule today?",
                IsFromAssistant = true,
                Timestamp = DateTime.Today.AddHours(9).AddMinutes(40)
            },
            new ChatMessage
            {
                Content = "You can ask me to schedule meetings, list your upcoming events, check for schedule conflicts, or draft task summaries.",
                IsFromAssistant = true,
                Timestamp = DateTime.Today.AddHours(9).AddMinutes(41)
            }
        ];

        SuggestedActions =
        [
            new SuggestedAction { Label = "Sprint (Test Conflict)", ActionType = SuggestedActionType.Warning },
            new SuggestedAction { Label = "Gym Workout (1 hr)", ActionType = SuggestedActionType.Calendar },
            new SuggestedAction { Label = "Review PRs", ActionType = SuggestedActionType.Default }
        ];
    }

    [RelayCommand]
    private async Task SendMessageAsync()
    {
        var text = MessageInput.Trim();
        if (string.IsNullOrEmpty(text)) return;

        Messages.Add(new ChatMessage
        {
            Content = text,
            IsFromAssistant = false,
            Timestamp = DateTime.Now
        });
        MessageInput = string.Empty;

        await Task.Delay(1200);
        Messages.Add(new ChatMessage
        {
            Content = "I've received your request. Let me check your calendar and get back to you with the best options.",
            IsFromAssistant = true,
            Timestamp = DateTime.Now
        });
    }

    [RelayCommand]
    private void SelectSuggestedAction(SuggestedAction action)
    {
        MessageInput = action.Label;
    }
}

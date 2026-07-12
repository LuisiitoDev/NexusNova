using CommunityToolkit.Mvvm.Input;
using NexusNova.Models;

namespace NexusNova.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}
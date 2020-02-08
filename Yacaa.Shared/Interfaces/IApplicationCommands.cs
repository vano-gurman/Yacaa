using Prism.Commands;

namespace Yacaa.Shared.Interfaces
{
    public interface IApplicationCommands
    {
        CompositeCommand NavigateCommand { get; }
    }
}
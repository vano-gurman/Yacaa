using Prism.Commands;

namespace Yacaa.Shared.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand NavigateCommand { get; }
    }
}
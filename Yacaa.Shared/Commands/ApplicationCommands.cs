using Prism.Commands;

namespace Yacaa.Shared.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand NavigateCommand { get; } = new CompositeCommand();
    }
}
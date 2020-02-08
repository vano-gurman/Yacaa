using Prism.Commands;
using Yacaa.Shared.Interfaces;

namespace Yacaa.Shared.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand NavigateCommand { get; } = new CompositeCommand();
    }
}
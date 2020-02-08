using System.Collections.ObjectModel;
using Prism.Mvvm;
using Yacaa.Shared.Models;

namespace Yacaa.Modules.Accounting.ViewModels.PartnerInteraction
{
    public class ContractsViewModel : BindableBase
    {
        public ObservableCollection<Contract> Contracts { get; set; }
        public bool ReadOnly { get; set; } = true;
        public ContractsViewModel()
        {
            Contracts = GenerateData();
        }

        private ObservableCollection<Contract> GenerateData()
        {
            return new ObservableCollection<Contract>();
        }
    }
}

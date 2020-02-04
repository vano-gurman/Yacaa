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
            return new ObservableCollection<Contract>()
            {
                new Contract("#111221", "12/01/2019", "Incoming", "RUB", "28/01/2020", "YES"),
                new Contract("#111222", "13/01/2019", "Outgoing", "USD", "29/01/2020", "NO"),
                new Contract("#111223", "14/01/2019", "Incoming", "RUB", "30/01/2020", "NO"),
                new Contract("#111224", "15/01/2019", "Incoming", "USD", "31/01/2020", "YES")
            };
        }
    }
}

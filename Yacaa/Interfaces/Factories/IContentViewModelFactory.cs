using Yacaa.ViewModels.Content.PartnerInteraction;
using Yacaa.ViewModels.Content.Sales;

namespace Yacaa.Interfaces.Factories
{
    public interface IContentViewModelFactory
    {
        #region Partner Interaction

        ContractsViewModel GetContractsViewModel();
        AgreementsViewModel GetAgreementsViewModel();

        #endregion

        #region Sales

        BunkeringViewModel GetBunkeringViewModel();
        WarehouseSalesViewModel GetWarehouseSalesViewModel();

        #endregion
    }
}
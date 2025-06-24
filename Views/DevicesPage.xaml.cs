using ChoosingGadgets.ViewModels;

namespace ChoosingGadgets.Views;

public partial class DevicesPage : ContentPage
{
    public DevicesPage(DevicesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}


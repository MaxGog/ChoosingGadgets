using ChoosingGadgets.ViewModels;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.Views;

public partial class AddDevicePage : ContentPage
{
    public AddDevicePage(AddDeviceViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bloxstrap.Models
{
    public partial class BootstrapperVideo : ObservableObject
    {
        [ObservableProperty]
        private string _name = "";

        [ObservableProperty]
        private string _location = "";
    }
}
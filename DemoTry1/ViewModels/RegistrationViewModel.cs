using ReactiveUI;

namespace DemoTry1.ViewModels;

public class RegistrationViewModel: ViewModelBase
{
    private string _nameController = "";
    private string _passController = "";

    
    public string NameController
    {
        get => _nameController;
        set => this.RaiseAndSetIfChanged(ref _nameController, value);
    }
    
    public string PassController
    {
        get => _passController;
        set => this.RaiseAndSetIfChanged(ref _passController, value);
    }
}
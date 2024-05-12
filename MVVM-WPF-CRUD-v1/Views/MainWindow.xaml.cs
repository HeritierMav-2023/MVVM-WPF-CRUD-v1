using MVVM_WPF_CRUD_v1.ViewModels;
using System.Windows;


namespace MVVM_WPF_CRUD_v1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new StudentViewModel();
        }
    }
}

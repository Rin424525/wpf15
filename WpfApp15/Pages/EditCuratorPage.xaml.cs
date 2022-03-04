using System.Windows.Controls;
using WpfApp15.ViewModels;

namespace WpfApp15.Pages
{
    /// <summary>
    /// Interaction logic for EditCuratorPage.xaml
    /// </summary>
    public partial class EditCuratorPage : Page
    {
        public EditCuratorPage(EditDisciplinePVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

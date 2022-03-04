using System.Windows.Controls;
using WpfApp15.ViewModels;

namespace WpfApp15.Pages
{
    /// <summary>
    /// Interaction logic for EditCuratorPage.xaml
    /// </summary>
    public partial class EditDisciplinePage : Page
    {
        private EditDisciplineVM editDisciplineVM;

        public EditDisciplinePage(EditDisciplinePVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public EditDisciplinePage(EditDisciplineVM editDisciplineVM)
        {
            this.editDisciplineVM = editDisciplineVM;
        }
    }
}

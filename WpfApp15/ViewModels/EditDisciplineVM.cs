using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;


namespace WpfApp15.ViewModels
{
    public class EditDisciplineVM : BaseVM
    {
        public discipline EditDiscipline { get; }
        public CommandVM SaveDiscipline { get; set; }
        public Group DisciplineGroup
        {
            get => disciplineGroup;
            set
            {
                disciplineGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }
        private CurrentPageControl currentPageControl;
        private Group disciplineGroup;

        public EditDisciplineVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDiscipline = new discipline();
            Init();
        }

        public EditDisciplineVM(discipline editDiscipline, CurrentPageControl currentPageControl)
        {
            EditDiscipline = editDiscipline;
            this.currentPageControl = currentPageControl;
            Init();
            DisciplineGroup = Groups.FirstOrDefault(s => s.ID == editDiscipline.ID);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SaveDiscipline = new CommandVM(() => {
                if (DisciplineGroup == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                    return;
                }
                var model = SqlModel.GetInstance();
                if (EditDiscipline.ID == 0)
                    model.Insert(EditDiscipline);
                else
                    model.Update(EditDiscipline);
                currentPageControl.SetPage(new ViewDisciplinePage(DisciplineGroup));
            });
        }

    }
}

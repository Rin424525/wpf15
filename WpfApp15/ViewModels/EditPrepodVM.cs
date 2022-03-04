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
    public class EditPrepodsVM : BaseVM
    {
        public prepod EditPrepod { get; }
        public CommandVM SavePrepod { get; set; }
        public Group PrepodGroup
        {
            get => prepodsGroup;
            set
            {
                prepodsGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }
        private CurrentPageControl currentPageControl;
        private Group prepodsGroup;

        public EditPrepodsVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepod = new prepod();
            Init();
        }

        public EditPrepodsVM(prepod editprepod, CurrentPageControl currentPageControl)
        {
            EditPrepod = editprepod;
            this.currentPageControl = currentPageControl;
            Init();
            PrepodGroup = Groups.FirstOrDefault(s => s.ID == editprepod.ID);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SavePrepod = new CommandVM(() => {
                if (PrepodGroup == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                    return;
                }
                var model = SqlModel.GetInstance();
                if (EditPrepod.ID == 0)
                    model.Insert(EditPrepod);
                else
                    model.Update(EditPrepod);
                currentPageControl.SetPage(new ViewPrepodsPage(PrepodGroup));
            });
        }

    }
}

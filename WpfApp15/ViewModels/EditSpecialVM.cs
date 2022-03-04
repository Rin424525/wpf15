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
    public class EditSpecialVM: BaseVM
    {
        public Special EditSpecial { get; }
        public CommandVM SaveSpecial{ get; set; }
        public Group SpecialGroup
        {
            get => specialGroup;
            set
            {
                specialGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group specialGroup;
        

        public EditSpecialVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = new Special();
            Init();
        }

        public EditSpecialVM(Special editSpecial, CurrentPageControl currentPageControl)
        {
            EditSpecial = editSpecial;
            this.currentPageControl = currentPageControl;
            Init();
            SpecialGroup = Groups.FirstOrDefault(s => s.ID == editSpecial.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            CommandVM commandVM = new CommandVM(() =>
            {
                var model = SqlModel.GetInstance();
                if (EditSpecial.ID == 0)
                    model.Insert(EditSpecial);
                else
                    model.Update(EditSpecial);
                currentPageControl.SetPage(new ViewSpecialsPage(SpecialGroup));
            });
            SaveSpecial = commandVM;
        }
    }
}

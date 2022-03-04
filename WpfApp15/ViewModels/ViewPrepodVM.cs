using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewPrepodVM : BaseVM
    {
        private Group selectedGroup;
        private List<prepod> PrepodBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                PrepodsBySelectedGroup = SqlModel.GetInstance().SelectPrepodsByGroup(selectedGroup);
                Signal();
            }
        }
        public List<prepod> PrepodsBySelectedGroup
        {
            get => PrepodsBySelectedGroup;
            set
            {
                PrepodsBySelectedGroup = value;
                Signal();
            }
        }
        public prepod SelectedPrepod { get; set; }

        public ViewPrepodVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }

}

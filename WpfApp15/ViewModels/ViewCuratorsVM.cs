using System.Collections.Generic;
using System.Linq;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewCuratorsVM : BaseVM
    {
        private Group selectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                CuratorsBySelectedGroup = SqlModel.GetInstance().SelectCuratorByGroup(selectedGroup);
                Signal();
            }
        }
        public List<curator> CuratorsBySelectedGroup
        {
            get => CuratorsBySelectedGroup;
            set
            {
                CuratorsBySelectedGroup = value;
                Signal();
            }
        }
        public curator SelectedCurator { get; set; }

        public ViewCuratorsVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}


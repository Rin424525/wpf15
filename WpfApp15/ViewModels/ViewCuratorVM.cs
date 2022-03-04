using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewCuratorVM : BaseVM
    {
        private Group selectedGroup;
        private List<curator> curatorBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                CuratorsBySelectedGroup = SqlModel.GetInstance().SelectCuratorsByGroup(selectedGroup);
                Signal();
            }
        }
        public List<curator> CuratorsBySelectedGroup
        {
            get => curatorBySelectedGroup;
            set
            {
                curatorBySelectedGroup = value;
                Signal();
            }
        }
        public Student SelectedStudent { get; set; }

        public ViewCuratorVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }

}

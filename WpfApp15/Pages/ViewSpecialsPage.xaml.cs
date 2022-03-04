﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp15.DTO;
using WpfApp15.ViewModels;

namespace WpfApp15.Pages
{
    /// <summary>
    /// Interaction logic for ViewSpecialsPage.xaml
    /// </summary>
    public partial class ViewSpecialsPage : Page
    {
        public ViewSpecialsPage(Group selectedGroup)
        {
            InitializeComponent();
            DataContext = new ViewSpecialsVM(selectedGroup);
        }
    }
}

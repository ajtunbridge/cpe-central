﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CPECentral.ModernUI.ViewModels;

namespace CPECentral.ModernUI.Views
{
    /// <summary>
    /// Interaction logic for PartView.xaml
    /// </summary>
    public partial class PartView : UserControl
    {
        public PartView(PartViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        
    }
}

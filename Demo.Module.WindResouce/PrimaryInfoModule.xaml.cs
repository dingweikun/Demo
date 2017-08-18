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

namespace Demo.Module
{
    /// <summary>
    /// Interaction logic for WindResouceModule.xaml
    /// </summary>
    [ProjectModule(typeof(WindResouceModule), ProjectModuleCategory.Resource)]
    public partial class WindResouceModule : ProjectModule
    {
        public WindResouceModule()
        {
            InitializeComponent();
        }

        public override ProjectModuleCategory Category => ProjectModuleCategory.Resource;

        protected override void IsInEditValueChangedToFalse()
        {
            //throw new NotImplementedException();
        }

        protected override void IsInEditValueChangedToTrue()
        {
            //throw new NotImplementedException();
        }
    }
}
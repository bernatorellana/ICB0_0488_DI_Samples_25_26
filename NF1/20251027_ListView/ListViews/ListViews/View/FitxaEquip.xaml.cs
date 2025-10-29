using ListViews.Model;
using System;
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
using DependencyPropertyGenerator;
namespace ListViews.View
{


    public partial class FitxaEquip : UserControl
    {
        public FitxaEquip()
        {
            InitializeComponent();
            
        }



        public Equip TheEquip
        {
            get { return (Equip)GetValue(TheEquipProperty); }
            set { SetValue(TheEquipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheEquip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheEquipProperty =
            DependencyProperty.Register("TheEquip", typeof(Equip), typeof(FitxaEquip), new PropertyMetadata(null));




    }
}

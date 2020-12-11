using System;
using System.Collections.Generic;
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

namespace WpfAppDependencyProperty.View
{
    /// <summary>
    /// TimePicker.xaml の相互作用ロジック
    /// </summary>
    public partial class TimePicker : UserControl
    {


        public bool AllTextBoxEnable
        {
            get { return (bool)GetValue(AllTextBoxEnableProperty); }
            set {
                //if (EqualityComparer<bool>.Default.Equals(AllTextBoxEnable, value)) { return; }

                SetValue(AllTextBoxEnableProperty, value);
                foreach (var child in GetAllDescendantObject<TextBox>(this))
                {
                    child.IsEnabled = value;
                }
            }
        }


        // Using a DependencyProperty as the backing store for AllTextBoxEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllTextBoxEnableProperty =
            DependencyProperty.Register(nameof(AllTextBoxEnable), typeof(bool), typeof(TimePicker), new PropertyMetadata(true));


        private static IEnumerable<T> GetAllDescendantObject<T>(DependencyObject dependencyObject) where T:DependencyObject
        {
            foreach (var child in LogicalTreeHelper.GetChildren(dependencyObject))
            {
                if (child is T cobj)
                {
                    yield return cobj;
                }
                if (child is DependencyObject dobj)
                {
                    foreach (var cobj2 in GetAllDescendantObject<T>(dobj))
                    {
                        yield return cobj2;
                    }
                }
            }
        }


        public TimePicker()
        {
            InitializeComponent();
        }
    }
}

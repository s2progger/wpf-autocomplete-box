using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WPFAutoCompleteBox.Controls
{
    public class CompletableTextBox : TextBox
    {
        public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(CompletableTextBox), new PropertyMetadata(null, SelectedItemPropertyChanged));

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public static void SelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CompletableTextBox)d;

            if (control == null) return;

            control.ChangeSelectedItem(e.NewValue);
        }

        public CompletableTextBox()
        {
            LostFocus += new RoutedEventHandler(CompletableTextBox_LostFocus);
        }

        private void ChangeSelectedItem(object item)
        {   
            Text = (item == null) ? null : item.ToString();         
        }

        public void CompletableTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var control = (CompletableTextBox)sender;

            if (control.SelectedItem != null)
                control.Text = control.SelectedItem.ToString();
            else
                control.Text = null;
        }
    }
}

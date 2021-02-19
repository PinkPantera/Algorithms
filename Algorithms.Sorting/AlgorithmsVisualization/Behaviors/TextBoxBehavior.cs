using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AlgorithmsVisualization.Behaviors
{
    public static class TextBoxBehavior
    {
        public static readonly DependencyProperty IsIntInputProperty =
            DependencyProperty.RegisterAttached("IsIntInput",typeof(bool), typeof(TextBoxBehavior), new PropertyMetadata(false, OnIsIntInputChanged));

        public static bool GetIsIntInput(DependencyObject obj)
        {

            return (bool)obj.GetValue(IsIntInputProperty);
        }

        public static void SetIsIntInput(DependencyObject obj, bool value)
        {
            obj.SetValue(IsIntInputProperty, value);
        }

        private static TextCompositionEventHandler OnIsIntInputPreviewTextInputHandler = new TextCompositionEventHandler(TextBox_PreviewTextInput);


        private static void OnIsIntInputChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is TextBox textBox && e.NewValue is bool checkIntInput)
            {
                if (checkIntInput == true)
                {
                    textBox.PreviewTextInput += OnIsIntInputPreviewTextInputHandler;
                }
                else
                {
                    textBox.PreviewTextInput -= OnIsIntInputPreviewTextInputHandler;
                }
            }
        }

        private static void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox &&  !string.IsNullOrEmpty(e.Text))
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }
    }
}

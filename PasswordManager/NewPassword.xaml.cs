﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager
{
    public partial class NewPassword : Window
    {
        public delegate void PassInterception(Passwords pass);
        public event PassInterception AddPassAction;
        PasswdGenerator passgen = new PasswdGenerator();

        public NewPassword()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Passwords pas = new Passwords(PlatforTB.Text, PasswordTB.Text);
                AddPassAction?.Invoke(pas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        public new void Show(Passwords index)
        {
            PlatforTB.Text = index.platform.ToString();
            PasswordTB.Text = index.password.ToString();
            base.Show();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {            
            PasswordTB.Text = passgen.Generate();
        }

        private void DigitCB(object sender, RoutedEventArgs e)
        {
            passgen.digits = !passgen.digits;
        }

        private void UpperCB(object sender, RoutedEventArgs e)
        {
            passgen.upper = !passgen.upper;
        }

        private void LowerCB(object sender, RoutedEventArgs e)
        {
            passgen.lower = !passgen.lower;
        }

        private void SpecialCB(object sender, RoutedEventArgs e)
        {
            passgen.special = !passgen.special;
        }
    }
}

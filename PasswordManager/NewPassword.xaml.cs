using System;
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
        public event PassInterception ChangePassAction;
        PasswdGenerator passgen;

        public NewPassword()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Passwords pas = new Passwords(PlatforTB.Text, PasswordTB.Text, DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                ChangePassAction?.Invoke(pas);
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
            if (LengthTB.Text == "")
            {
                passgen = new PasswdGenerator(length, digflag, uppflag, lowflag, specflag);
            }

            else if(LengthTB.Text != "")
            {
                length = Convert.ToInt32(LengthTB.Text);
                passgen = new PasswdGenerator(length, digflag, uppflag, lowflag, specflag);
            }
            PasswordTB.Text = passgen.Generate();
        }

        bool digflag = false;
        bool uppflag = false;
        bool lowflag = false;
        bool specflag = false;
        int length = 12;

        private void DigitCB(object sender, RoutedEventArgs e)
        {
            digflag = true;
        }

        private void UpperCB(object sender, RoutedEventArgs e)
        {
            uppflag = true;
        }

        private void LowerCB(object sender, RoutedEventArgs e)
        {
            lowflag = true;
        }

        private void SpecialCB(object sender, RoutedEventArgs e)
        {
            specflag = true;
        }
    }
}

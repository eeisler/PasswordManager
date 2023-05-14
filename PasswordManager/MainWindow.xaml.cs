using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /*
     * добавление уже существующего пароля - done
     * редактирование пароля 
     * отображение всего списка паролей в алфавитном порядке - done
     * генерация нового пароля
     * 
     * сущность пароля хранит сведения о:
     *  -ресурсе, для которого используется пароль (эл почта, веб страница и т.д.) - done
     *  -сам пароль в виде строки - done
     *  -дате добавления / обновления записи
     * 
     * реализовать хранение паролей в виде массива структур - done
     * 
     * дополнительно реализовать хранение массива структур в json или xml файл с помощью сериализации
    */

    public partial class MainWindow : Window
    {
        public ObservableCollection<Passwords> passwords = new ObservableCollection<Passwords>();

        public MainWindow()
        {
            InitializeComponent();
            List.ItemsSource = passwords;
            List.Items.SortDescriptions.Clear();
            List.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("platform", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void AddPass_Click(object sender, RoutedEventArgs e)
        {
            NewPassword newPassword = new NewPassword();
            newPassword.Show();

            newPassword.AddPassAction += (pass) =>
            {
                passwords.Add(pass);
            };
        }

        private void DelPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                passwords.RemoveAt(List.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    passwords.RemoveAt(List.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void list_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                NewPassword newpass = new NewPassword();
                newpass.Show(List.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

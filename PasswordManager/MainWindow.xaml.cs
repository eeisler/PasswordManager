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

namespace PasswordManager
{
    /*
     * добавление уже существующего пароля
     * редактирование пароля
     * отображение всего списка паролей в алфавитном порядке(в данном режиме отображаься только ресурсы, где используется пароль)
     * генерация нового пароля
     * 
     * сущность пароля хранит сведения о:
     *  -ресурсе, для которого используется пароль (эл почта, веб страница и т.д.)
     *  -сам пароль в виде строки
     *  -дате добавления / обновления записи
     * 
     * реализовать хранение паролей в виде массива структур
     * 
     * дополнительно реализовать хранение массива структур в json или xml файл с помощью сериализации
    */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPass_Click(object sender, RoutedEventArgs e)
        {
            NewPassword newPassword = new NewPassword();
            newPassword.Show();
        }

        private void DelPass_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}

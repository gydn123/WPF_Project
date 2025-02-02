using FirstProject1.Models;
using FirstProject1.ViewModels;
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

namespace FirstProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show("알림 띄우기");
            mainViewModel = new MainViewModel();
            mainViewModel.ProgressValue = 30;
            DataContext = mainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> myList1 = new List<User>();

            labelTest1.Content = "내용 변경";
            //MessageBox.Show(TextBox1.Text + "");
            User userA = new User();
            userA.UserImg = @"E:\\CsharpPractice\\FirstProject1\\FirstProject1\\Resources\\photo1.jpg";
            userA.Name = "Noah";
            userA.UserAge = 15;

            User userB = new User();
            userB.UserImg = @"E:\CsharpPractice\FirstProject1\FirstProject1\Resources\1724339909.gif";
            userB.Name = "Liam";
            userB.UserAge = 20;

            myList1.Add(userA);
            myList1.Add(userB);

            ListView1.ItemsSource = myList1;
            mainViewModel.ProgressValue = 100;

        }

    }
}
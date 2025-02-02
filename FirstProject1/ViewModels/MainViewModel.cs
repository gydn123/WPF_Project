using CommunityToolkit.Mvvm.Input;
using FirstProject1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FirstProject1.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int progressValue;
        public ICommand TestClick { get; set; }

        public ICommand SecondShow { get; set; }

        public MainViewModel()
        {
            //TestClick = new TestClickCommand(this);
            //TestClick = new RelyCommand<object>(ExecuteMyButton, CanMyButton);
            TestClick = new AsyncRelayCommand(ExecuteMyButton2);
            SecondShow = new AsyncRelayCommand(ExecuteMyButton3);

            Task t = ExecuteMyButton2();

        }

        public int ProgressValue
        {
            get { return progressValue; }
            set 
            {
                progressValue = value;
                NotifyPropertyChanged(nameof(ProgressValue));
            }
        }

        bool CanMyButton(object param)
        {
            if(param == null) return false;

            return param.ToString().Equals("ABC")? true : false;
        }

        void ExecuteMyButton(object param)
        {

            int w = 0;
            //MessageBox.Show(param.ToString() + "AAA");
            Task task1 = Task.Run(() => 
            {
                for (int i = 0; i < 10; i++)
                {
                    progressValue = i;
                }
            });

            Task rtn2 = Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    progressValue = i;
                    w = i;
                    Thread.Sleep(2000);
                }
            });

            //rtn2.Wait();
            MessageBox.Show(w+"");
        }

        public async Task ExecuteMyButton2()
        {
            int w = 0;

            Task<int> rtn2 = Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    progressValue = i;
                    w = i;
                    Thread.Sleep(2000);
                }
                int k = 5;
                return k;
            });

            await rtn2;
            MessageBox.Show(w + "");
        }

        public async Task ExecuteMyButton3()
        {
            SecondView secondView = new SecondView();
            SecondViewModel secondViewModel = new SecondViewModel();
            secondViewModel.ProgressValue = 70;
            secondView.DataContext = secondViewModel;
            secondView.ShowDialog();

            await Task.Delay(0);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

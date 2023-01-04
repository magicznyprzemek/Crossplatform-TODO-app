using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TODO.ViewModels
{
    public class MainPageViewModel : BindableObject, INotifyPropertyChanged
    {

        public ObservableCollection<Task> TaskList;
        public MainPageViewModel()
        {
            TaskList = new ObservableCollection<Task>();
            AddTask = new Command(OnIncrement);
            Refresh = new Command(refresh);

            for (int i=0; i<1; i++)
            {
                OnIncrement();
            }
            
        }


        string LocalDescription = "Nowy Task!";
    
        public ObservableCollection<Task> Tasks
        {
            get => TaskList;
            set
            {
                TaskList = value;
                OnPropertyChanged();
            }

        }
       
        public string DesText
        {
            get => LocalDescription;
            set
            {
                LocalDescription = value;
                OnPropertyChanged();

            }
        }
        public ICommand AddTask { get; }
        public ICommand Refresh { get; }
        void refresh()
        {
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            IsRefreshing = true;
            foreach (Task x in Tasks)
            {
                if(x.IsCompleted)
                {
                    temp.Add(x);
                }
            }
            Tasks = temp;
           
            IsRefreshing = false;
        }
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        void OnIncrement()
        {
            if (LocalDescription.Length > 500)
            {
                App.Current.MainPage.DisplayAlert("Alert", $"you exceeded the character limit by {500-LocalDescription.Length}", "OK");
            }
            else
            {
                Tasks.Insert(0, (new Task { Description = LocalDescription, IsCompleted = true }));
                DesText = "";
            }
        }

       
    }
}


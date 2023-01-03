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
          //  TaskList.Add(new Task { Description = "test123", IsCompleted = false });
            AddTask = new Command(OnIncrement);
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

        void OnIncrement()
        {
            Tasks.Add(new Task { Description = LocalDescription, IsCompleted = true });
            DesText = "";

        }

    }
}


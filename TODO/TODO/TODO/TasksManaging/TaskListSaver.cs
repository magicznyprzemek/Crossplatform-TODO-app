using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace TODO.TasksManaging
{
    public class TaskListSaver
    {
        public String path = "LocalSavedTasks";

        public void SaveTasks(ObservableCollection<Task> list)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list);
                Xamarin.Essentials.Preferences.Set("list", json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        public ObservableCollection<Task> getList()
        {
            string json = Xamarin.Essentials.Preferences.Get("list", "");
            ObservableCollection<Task> items = JsonConvert.DeserializeObject<ObservableCollection<Task>>(json);


            return items;
        }


    }
}


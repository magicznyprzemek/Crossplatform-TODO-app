using System;
using System.Collections;
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
            Task example = new Task { Description = "Hello World!", IsCompleted = true };
            string exampleJSON = JsonConvert.SerializeObject(example);
            string json = Xamarin.Essentials.Preferences.Get("list", exampleJSON);
            ObservableCollection<Task> items = JsonConvert.DeserializeObject<ObservableCollection<Task>>(json);


            return items;
        }


    }
}


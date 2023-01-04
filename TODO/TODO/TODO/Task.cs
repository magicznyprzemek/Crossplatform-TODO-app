using System;
namespace TODO
{
    public class Task
    {
        
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task() { }


        public Task(Task x)
        {
            Description = x.Description;
            IsCompleted = x.IsCompleted;
        }

        
    }
}




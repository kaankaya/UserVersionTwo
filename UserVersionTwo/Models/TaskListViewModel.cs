﻿namespace UserVersionTwo.Models
{
    public class TaskListViewModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}

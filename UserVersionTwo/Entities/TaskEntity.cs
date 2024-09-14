namespace UserVersionTwo.Entities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public int UserId { get; set; }
        //public string? UserName { get; set; }
        public bool IsDelete { get; set; }

    }
}

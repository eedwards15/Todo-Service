namespace Todo_Web_Api.ViewModel
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public int ProjectId { get; set; }
        public List<TaskViewModel> Subtasks { get; set; }
    }

}

namespace Livia.Application.ViewModels
{
    public class TaskViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public int Id { get; set; }
    }
}

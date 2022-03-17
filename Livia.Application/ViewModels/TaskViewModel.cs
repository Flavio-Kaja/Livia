using Livia.Domain.Models.Task;

namespace Livia.Application.ViewModels
{
    public class TaskViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public int Id { get; set; }

        public ICollection<Tag>? Tags { get; set; }
        public Category Category { get; set; } = default!;
    }

    public class CreateTaskViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }

        public IList<int>? TagIds { get; set; }
        public int? CategoryId { get; set; }
    }

    public class UpdateTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }

        public IList<int>? TagIds { get; set; }
        public int? CategoryId { get; set; }
    }

}

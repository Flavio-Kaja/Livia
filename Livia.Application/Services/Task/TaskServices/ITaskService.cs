using Livia.Application.ViewModels;
using Livia.Domain.Models.Base;

namespace Livia.Application.Services.Task.TaskServices
{
    using Task = Domain.Models.Task.Task;
    public interface ITaskService
    {
        HashSet<TaskViewModel> GetTasksAsync(int? categoryId = null, ICollection<int>? tagIds = null);
        System.Threading.Tasks.Task CreateTaskAsync(CreateTaskViewModel request);

        System.Threading.Tasks.Task<Result<Task>> UpdateTaskAsync(UpdateTaskViewModel request);
    }
}

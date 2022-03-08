using Livia.Domain.Interfaces;
using Livia.Domain.Models.Task;
using Microsoft.Extensions.Caching.Memory;

namespace Livia.Application.Services.Task.TaskServices
{
    using Task = Livia.Domain.Models.Task.Task;
    public class TaskService : ITaskService
    {

        private readonly IMemoryCache _memoryCashe;
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<Category> _categoryRepository;

        public TaskService(IMemoryCache memoryCashe, IRepository<Category> categoryRepository, IRepository<Task> taskRepository)
        {
            _memoryCashe = memoryCashe;
            _categoryRepository = categoryRepository;
            _taskRepository = taskRepository;
        }

        public HashSet<Task> GetTasks(int categoryId)
        {
            var tasks = _taskRepository.TableNoTracking.Where(t => t.CategoryId == categoryId).ToHashSet();
            return tasks;

        }

    }
}

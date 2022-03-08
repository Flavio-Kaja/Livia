using AutoMapper;
using Livia.Application.Extensions;
using Livia.Application.ViewModels;
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
        private readonly IRepository<Tag> _tagRepository;
        public readonly IMapper _mapper;


        public TaskService(IMemoryCache memoryCashe, IRepository<Category> categoryRepository, IRepository<Task> taskRepository, IMapper mapper, IRepository<Tag> tagRepository)
        {
            _memoryCashe = memoryCashe;
            _categoryRepository = categoryRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public HashSet<TaskViewModel> GetTasks(int? categoryId = null, ICollection<int>? tagIds = null)
        {
            var tasks = _taskRepository.TableNoTracking.
                If(categoryId == null, y => y.Where(t => t.CategoryId == categoryId))
                .If(tagIds == null || tagIds.Count == 0, q => q.Where(t => t.Tags.Where(tt => tagIds.Contains(tt.Id)) != null))
                .ToHashSet();

            //  var sexyQueries = _tagRepository.TableNoTracking.Where(t=>tagIds.Contains(t.Id)).Select(t=>t.Tasks).Distinct().If(categoryId == null, y => y.Where(t => t.CategoryId == categoryId))
            HashSet<TaskViewModel> tasksVM = _mapper.Map<HashSet<Task>, HashSet<TaskViewModel>>(tasks);
            return tasksVM;
        }

    }
}

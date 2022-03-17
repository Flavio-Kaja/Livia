using AutoMapper;
using Livia.Application.Extensions;
using Livia.Application.ViewModels;
using Livia.Data.Context;
using Livia.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Livia.Application.Services.Task.TaskServices
{
    using Task = Livia.Domain.Models.Task.Task;
    public class TaskService : ITaskService
    {

        private readonly IMemoryCache _memoryCashe;

        public readonly IMapper _mapper;
        private readonly IInternalDbContext _dbcontext;

        public TaskService(IInternalDbContext dbcontext, IMapper mapper, IMemoryCache memoryCashe)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _memoryCashe = memoryCashe;
        }

        public HashSet<TaskViewModel> GetTasksAsync(int? categoryId = null, ICollection<int>? tagIds = null)
        {
            var tasks = _dbcontext.Tasks.AsNoTracking().
                If(categoryId != null, y => y.Where(t => t.CategoryId == categoryId))
                .If(tagIds != null || tagIds!.Count != 0, q => q.Where(t => t.Tags!.Where(tt => tagIds == null || tagIds.Count == 0 || tagIds.Contains(tt.Id)) != null))
                .ToHashSet();

            //var query = _taskRepository.TableNoTracking.Include(task => task.Tags.Where(tag => tagIds.Contains(tag.Id))).
            //    If(categoryId == null, y => y.Where(t => t.CategoryId == categoryId))
            //    .If(tagIds == null || tagIds.Count == 0, q => q.Where(t => t.Tags.Where(tt => tagIds.Contains(tt.Id)) != null));

            HashSet<TaskViewModel> tasksVM = _mapper.Map<HashSet<Task>, HashSet<TaskViewModel>>(tasks);
            return tasksVM;
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(CreateTaskViewModel request)
        {
            Task task = _mapper.Map<CreateTaskViewModel, Task>(request);
            _dbcontext.Tasks.Add(task);
            if (request.CategoryId != null)
            {
                var category = await _dbcontext.Categories.FirstOrDefaultAsync(category => category.Id == request.CategoryId);
                task.CategoryId = category == default ? null : category.Id;
            }
            if (request.TagIds == null || request.TagIds.Count == 0)
            {
                var tags = await _dbcontext.Tags.Where(tags => request.TagIds!.Contains(tags.Id)).ToListAsync();

                task.Tags = tags;
            }
            await _dbcontext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<Result<Task>> UpdateTaskAsync(UpdateTaskViewModel request)
        {
            var entity = await _dbcontext.Tasks.SingleOrDefaultAsync(task => task.Id == request.Id);
            if (entity is null)
                return await System.Threading.Tasks.Task.FromResult(Result.Fail<Task>("A task with this id was not found"));

            entity.Title = request.Title;
            entity.Deadline = request.Deadline;
            entity.Description = request.Description;
            if (request.CategoryId != null)
            {
                var category = await _dbcontext.Categories.FirstOrDefaultAsync(category => category.Id == request.CategoryId);
                entity.CategoryId = category == default ? null : category.Id;
            }
            if (request.TagIds == null || request.TagIds.Count == 0)
            {
                var tags = await _dbcontext.Tags.Where(tags => request.TagIds!.Contains(tags.Id)).ToListAsync();

                entity.Tags = tags;
            }
            await _dbcontext.SaveChangesAsync();
            return await System.Threading.Tasks.Task.FromResult(Result.Ok(entity));
        }
    }

}


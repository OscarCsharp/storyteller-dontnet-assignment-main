using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoLists;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserStore<IdentityUser> userStore;
        private readonly GravatarProfileService _profileService;

        public TodoListController(ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore, GravatarProfileService profileService)
        {
            this.dbContext = dbContext;
            this.userStore = userStore;
            _profileService = profileService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Id();
            var todoLists = dbContext.RelevantTodoLists(userId);

            foreach (var list in todoLists)
            {
                var gravatarName = await _profileService.GetDisplayNameAsync(list.Owner.Email);
                list.Owner.UserName = gravatarName ?? list.Owner.UserName;
            }

            var viewmodel = TodoListIndexViewmodelFactory.Create(todoLists);
            return View(viewmodel);
        }

        public IActionResult Detail(string todoListId,bool showCompleted = false)
        {
            var todoList = dbContext.SingleTodoList(todoListId);
            if (!showCompleted)
            {
                todoList.Items = todoList.Items
                    .Where(x => x.IsDone == false)
                    .ToList();
            }
            ViewData["showCompleted"] = showCompleted;
            var viewmodel = TodoListDetailViewmodelFactory.Create(todoList);
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TodoListFields());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoListFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var currentUser = await userStore.FindByIdAsync(User.Id(), CancellationToken.None);

            var todoList = new TodoList(currentUser, fields.Title);

            await dbContext.AddAsync(todoList);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Create", "TodoItem", new {todoList.TodoListId});
        }
    }
}
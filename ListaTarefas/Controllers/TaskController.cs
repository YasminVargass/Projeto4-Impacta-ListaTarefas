using Microsoft.AspNetCore.Mvc;
using ListaTarefas.Models;
using System.Threading.Tasks;

namespace ListaTarefas.Controllers
{
    public class TaskController : Controller
    {

        private static List<TaskModel> _tasks = new List<TaskModel>() {
            new TaskModel { Id = 1, Name = "Yasmin", TaskName = "Lavar Louça", Status = "Em andamento" },
            new TaskModel { Id = 2, Name = "Leila", TaskName = "Lavar o Banheiro", Status = "Concluído" }};
        public IActionResult Index()
        {
            return View(_tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
                _tasks.Add(task);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var existTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
                if (existTask != null)
                {
                    existTask.Id = task.Id;
                    existTask.Name = task.Name;
                    existTask.Status = task.Status;
                    existTask.EndDate = task.EndDate;
                }
                return RedirectToAction("Index");
            }
            return View(task);
        }
        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t=> t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            _tasks.Remove(task);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var task = _tasks.FirstOrDefault(t=> t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }

       public IActionResult TaskConcluded()
        {
            return View(_tasks);
        }
        public IActionResult TaskInProgress()
        {
            return View(_tasks);
        }
    }
}
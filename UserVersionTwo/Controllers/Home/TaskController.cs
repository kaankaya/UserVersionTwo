using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using UserVersionTwo.Entities;
using UserVersionTwo.Models;

namespace UserVersionTwo.Controllers.Home
{
    public class TaskController : Controller
    {
        static List<TaskEntity> _tasks = new List<TaskEntity>()
        {
            new TaskEntity{TaskId = 1, TaskName ="Sayfayı Düzenle", TaskDescription="Tüm içeriklerin css ini ayarla", TaskStatus =false, UserId=1},
            new TaskEntity{TaskId = 2, TaskName ="Javascript Düzenle", TaskDescription="Tüm içeriklerin js ini ayarla", TaskStatus =false, UserId=2},
        };
        public IActionResult Index()
        {
            var tasks = _tasks.Where(x => x.IsDelete == false).Select(x => new TaskListViewModel
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                TaskDescription = x.TaskDescription,
                TaskStatus = x.TaskStatus,
                UserId = x.UserId,
                UserName = StaticData._users.FirstOrDefault(y => y.Id == x.UserId)?.UserName
            }).ToList();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //kullanıcıları burada selectbox a ekledim isimlerini gösterdim.value ile ıd lerini aldım text ile isimlerini
            var users = StaticData._users.Where(x => x.IsActive == true).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Name} {x.LastName}"
            }).ToList();
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskAddViewModel task)
        {
            if (ModelState.IsValid)
            {
                var maxId = _tasks.Max(x => x.TaskId);
                var newTask = new TaskEntity()
                {
                    TaskId = maxId + 1,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    UserId = task.UserId,
                };
                _tasks.Add(newTask);
                return RedirectToAction("Index");
            }
            // Eğer task hata varsa kullanıcıları tekrar dropdown'a eklemek için
            var users = StaticData._users
                .Where(x => x.IsActive)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} {x.LastName}"
                }).ToList();

            ViewBag.Users = users;
            return View(task);

        }
        public IActionResult Details(int id)
        {
            //İlgili Task ı buldum 
            var taskDetail = _tasks.FirstOrDefault(x => x.TaskId == id);
            //kullanıcının Id sini göstermek yerine o task daki kullanıcı ıd ile eşleşen static user listemdeki kullanıcıyı bulup değişkene atadım
            var users = StaticData._users.FirstOrDefault(u => u.Id == taskDetail.UserId);
            //bu değişkeni viewbag ile view taşıdım ve kontrol ettim gelen değer true ise ad soyadı aldım
            ViewBag.UserName = users != null ? $"{users.Name} {users.LastName}" : "Kullanıcı Bulunamadı";
            return View(taskDetail);   
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //İlgili task ı buldum
            var taskEdit = _tasks.FirstOrDefault(x => x.TaskId == id);
            var taskEditModel = new TaskEditViewModel()
            {
                TaskId = taskEdit.TaskId,
                TaskName = taskEdit.TaskName,
                TaskDescription = taskEdit.TaskDescription,
                TaskStatus = taskEdit.TaskStatus,
                UserId = taskEdit.UserId,
            };
            var usersTask = StaticData._users.FirstOrDefault(u => u.Id == taskEdit.UserId);
            ViewBag.UserName = usersTask != null ? $"{usersTask.Name} {usersTask.LastName}" : "Kullanıcı Bulunamadı";
            var users = StaticData._users.Where(x => x.IsActive == true).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Name} {x.LastName}"
            }).ToList();
            ViewBag.Users = users;

            return View(taskEditModel);

        }
        [HttpPost]
        public IActionResult Edit(TaskEditViewModel taskEdit)
        {
            if (ModelState.IsValid)
            {
                
                var task = _tasks.FirstOrDefault(x=>x.TaskId == taskEdit.TaskId);
                if(task == null)
                {
                    return NotFound();
                }
                task.TaskName = taskEdit.TaskName;
                task.TaskDescription = taskEdit.TaskDescription;
                task.TaskStatus = taskEdit.TaskStatus;
                task.UserId = taskEdit.UserId;
                return RedirectToAction("Index");
            }
            return View(taskEdit);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           
            var task = _tasks.FirstOrDefault(x=> x.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var confirm = _tasks.FirstOrDefault(y => y.TaskId == id);
            if(confirm == null)
            {
                return NotFound();
            }
            _tasks.Remove(confirm);
            return RedirectToAction("Index");
        }
    }
}

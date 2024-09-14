using Microsoft.AspNetCore.Mvc;
using UserVersionTwo.Entities;
using UserVersionTwo.Models;

namespace UserVersionTwo.Controllers.Home
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult AdminIndex()
        {
            //girişten aldıgım tempdata bilgilerini burada değişkene atayıp.Daha sonra viewbag ile sayfaya gönderiyoruz
            //tempdata ile gelen veriler sadece 1 kere kullanılır yenileme yapıldıgı anda kaybolur.Eğer kalıcı olmasını istiyorsak session kullanmamız gerekiyor
            var userName = TempData["UserName"]?.ToString();
            var role = TempData["Role"]?.ToString();
            ViewBag.UserName = userName;
            ViewBag.Role = role;
            //users diye bir değişken tanımladık
            //_users entities den aldıgımız listeye where ile silinmemiş kullanıcıları listele dedik daha sonraları onları select ile seçtik ve ara katman model imize new leyerk aktardık
            var users = StaticData._users.Where(x => x.IsDeleted == false).Select(x => new UserListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Birthday = x.Birthday,
                UserName = x.UserName,
                Password = x.Password,
                Role = x.Role,
                IsActive = x.IsActive,
            }).ToList(); //verileri filtreyip göstereceğimiz için bu eşleştirdiğimiz değerleride listeye çevirdik
            return View(users);
        }

        [HttpPost]
        public IActionResult LoginModal(UserEntity userEntity)
        {
            var user = StaticData._users.FirstOrDefault(x => x.UserName == userEntity.UserName && x.Password == userEntity.Password && x.Role == "Admin");
            if (user == null)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı, şifre hatalı ya da kullanıcı Admin değil!";
                return View("Index");
            }
            if (user != null & user.IsActive)
            {
                //tempdata ile giriş yapan kullanıcının kullanıcı adı ve rol bilgileri aldım öbür viewde kullanacağım.
                TempData["Username"] = user.UserName;
                TempData["Role"] = user.Role;
                user.IsLogin = true;
                return RedirectToAction("AdminIndex", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı, şifre hatalı ya da kullanıcı Admin değil!";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(UserAddViewModel userAdd)
        {
            //Eğer hatalı bir giriş olursa formda ki verilerin kaybolmaması için return ile geri döndürdüm
            if (!ModelState.IsValid)
            {
                return View(userAdd);
            }
            int maxId = StaticData._users.Max(x => x.Id);
            var entityUser = new UserEntity()
            {
                Id = maxId + 1,
                Name = userAdd.Name,
                LastName = userAdd.LastName,
                Email = userAdd.Email,
                Birthday = userAdd.Birthday,
                UserName = userAdd.UserName,
                Password = userAdd.Password,
                Role = userAdd.Role,

            };
            StaticData._users.Add(entityUser);
            return RedirectToAction("AdminIndex");
        }

        public IActionResult Details(int id)
        {
            var userDetail = StaticData._users.FirstOrDefault(x => x.Id == id);


            return View(userDetail);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //id parametresi ile düzenlenmek istenen değeri buluyorum userEdit değişkenine atıyorum
            var userEdit = StaticData._users.FirstOrDefault(x => x.Id == id);
            //eğer null ise notfound hatası verdiriyorum
            if (userEdit == null)
            {
                return NotFound();
            }
            //yeni bir değişken tanımlayıp ara katman için kullanacağım view model ile id ye göre çektiğim verileri işliyorum
            var userEditModel = new UserEditViewModel()
            {
                Id = userEdit.Id,
                Name = userEdit.Name,
                LastName = userEdit.LastName,
                Email = userEdit.Email,
                Birthday = userEdit.Birthday,
                UserName = userEdit.UserName,
                Password = userEdit.Password,
                Role = userEdit.Role,
                IsActive = userEdit.IsActive,

            };

            return View(userEditModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = StaticData._users.FirstOrDefault(x => x.Id == model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Birthday = model.Birthday;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Role = model.Role;
                user.IsActive = model.IsActive;
                return RedirectToAction("AdminIndex");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = StaticData._users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = StaticData._users.FirstOrDefault(y => y.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            StaticData._users.Remove(user);
            return RedirectToAction("AdminIndex");
        }
    }
}

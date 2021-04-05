using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication3;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class EnderecoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Endereco
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Enderecoes.ToList());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> ApiRequestAsync(string cep)
        {
            if (cep != null)
            {
                if (cep.Length == 8)
                {
                    var endereco = new Endereco();
                    endereco = await ApiRequest.SendAsync($"{cep}/json");
                    return View("Create", endereco);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        // POST: Endereco/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Endereco model)
        {

            if (ModelState.IsValid)
            {
                model.EnderecoId = Guid.NewGuid();
                db.Enderecoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnderecoId,Cep,Logradouro,Complemento,Bairro,Localidade,Uf,Ibge,Gia,Ddd,Siafi")] Endereco endereco)
        {
            Debug.WriteLine(endereco.Cep);
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Endereco endereco = db.Enderecoes.Find(id);
            db.Enderecoes.Remove(endereco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult CriandoJs() {
            return View();
        }

        [HttpPost]
        public ActionResult CriandoJs(Endereco model)
        {
                model.EnderecoId = Guid.NewGuid();
                db.Enderecoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}

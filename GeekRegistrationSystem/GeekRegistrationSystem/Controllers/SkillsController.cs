using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekRegistrationSystem.Models;

namespace GeekRegistrationSystem.Controllers
{
    public class SkillsController : Controller
    {
        private GRSModel db = new GRSModel();

        // GET: Skills
        public ActionResult Index(int candidateId = 0)
        {
            if (candidateId == 0) {
                var candidateSkills = db.CandidateSkills.Include(c => c.Candidate).Include(c => c.Skill);
                return View(candidateSkills.ToList());
            }
            else
            {
                var candidateSkills = db.CandidateSkills.Where(x=>x.CandidateId == candidateId).Include(c => c.Candidate).Include(c => c.Skill);
                return View(candidateSkills.ToList());
            }

            
        }

        // GET: Skills/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkill candidateSkill = db.CandidateSkills.Find(id);
            if (candidateSkill == null)
            {
                return HttpNotFound();
            }
            return View(candidateSkill);
        }

        // GET: Skills/Create
        public ActionResult Create(int candidateId = 0)
        {
            ViewBag.CandidateId = new SelectList(db.Candidates.Where(x=>x.Id == candidateId ), "Id", "FirstName");
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "Name");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CandidateId,SkillId")] CandidateSkill candidateSkill)
        {
            if (ModelState.IsValid)
            {
                //candidateSkill.Candidate = db.Candidates.Where(x => x.Id == candidateSkill.CandidateId).Single();
                //candidateSkill.Skill = db.Skills.Where(x => x.Id == candidateSkill.SkillId).Single();
                //candidateSkill.Id = 0;
                db.CandidateSkills.Add(candidateSkill);
                db.SaveChanges();
                return RedirectToAction("Index", new { candidateId = candidateSkill.CandidateId });
            }

            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "FirstName", candidateSkill.CandidateId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "Name", candidateSkill.SkillId);
            return View(candidateSkill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkill candidateSkill = db.CandidateSkills.Find(id);
            if (candidateSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "FirstName", candidateSkill.CandidateId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "Name", candidateSkill.SkillId);
            return View(candidateSkill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CandidateId,SkillId")] CandidateSkill candidateSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "FirstName", candidateSkill.CandidateId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "Name", candidateSkill.SkillId);
            return View(candidateSkill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkill candidateSkill = db.CandidateSkills.Find(id);
            if (candidateSkill == null)
            {
                return HttpNotFound();
            }
            return View(candidateSkill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CandidateSkill candidateSkill = db.CandidateSkills.Find(id);
            db.CandidateSkills.Remove(candidateSkill);
            db.SaveChanges();
            return RedirectToAction("Index", new { candidateId = candidateSkill.CandidateId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

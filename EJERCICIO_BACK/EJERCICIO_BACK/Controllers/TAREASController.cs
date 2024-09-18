using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EJERCICIO_BACK.Models;

namespace EJERCICIO_BACK.Controllers
{
    public class TAREASController : ApiController
    {
        private TaskManagerContext db = new TaskManagerContext();

        // GET: api/TAREAS
        public IQueryable<TAREAS> GetTAREAS()
        {
            return db.TAREAS;
        }

        // GET: api/TAREAS/5
        [ResponseType(typeof(TAREAS))]
        public IHttpActionResult GetTAREAS(int id)
        {
            TAREAS tAREAS = db.TAREAS.Find(id);
            if (tAREAS == null)
            {
                return NotFound();
            }

            return Ok(tAREAS);
        }

        // PUT: api/TAREAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTAREAS(int id, TAREAS tAREAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tAREAS.ID)
            {
                return BadRequest();
            }

            db.Entry(tAREAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAREASExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TAREAS
        [ResponseType(typeof(TAREAS))]
        public IHttpActionResult PostTAREAS(TAREAS tAREAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TAREAS.Add(tAREAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tAREAS.ID }, tAREAS);
        }

        // DELETE: api/TAREAS/5
        [ResponseType(typeof(TAREAS))]
        public IHttpActionResult DeleteTAREAS(int id)
        {
            TAREAS tAREAS = db.TAREAS.Find(id);
            if (tAREAS == null)
            {
                return NotFound();
            }

            db.TAREAS.Remove(tAREAS);
            db.SaveChanges();

            return Ok(tAREAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TAREASExists(int id)
        {
            return db.TAREAS.Count(e => e.ID == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewTest;

namespace NewTest.Controllers
{
    public class Tbl_StringDataController : ApiController
    {
        private StringCountEntities db = new StringCountEntities();

        // GET: api/Tbl_StringData
        public IQueryable<Tbl_StringData> GetTbl_StringData()
        {
            return db.Tbl_StringData;
        }

        // GET: api/Tbl_StringData/5
        [ResponseType(typeof(Tbl_StringData))]
        public async Task<IHttpActionResult> GetTbl_StringData(int id)
        {
            Tbl_StringData tbl_StringData = await db.Tbl_StringData.FindAsync(id);
            if (tbl_StringData == null)
            {
                return NotFound();
            }

            return Ok(tbl_StringData);
        }

        // PUT: api/Tbl_StringData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTbl_StringData(int id, Tbl_StringData tbl_StringData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_StringData.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_StringData).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_StringDataExists(id))
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

        // POST: api/Tbl_StringData
        [ResponseType(typeof(Tbl_StringData))]
        public async Task<IHttpActionResult> PostTbl_StringData(Tbl_StringData tbl_StringData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_StringData.Add(tbl_StringData);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tbl_StringData.Id }, tbl_StringData);
        }

        // DELETE: api/Tbl_StringData/5
        [ResponseType(typeof(Tbl_StringData))]
        public async Task<IHttpActionResult> DeleteTbl_StringData(int id)
        {
            Tbl_StringData tbl_StringData = await db.Tbl_StringData.FindAsync(id);
            if (tbl_StringData == null)
            {
                return NotFound();
            }

            db.Tbl_StringData.Remove(tbl_StringData);
            await db.SaveChangesAsync();

            return Ok(tbl_StringData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_StringDataExists(int id)
        {
            return db.Tbl_StringData.Count(e => e.Id == id) > 0;
        }
    }
}
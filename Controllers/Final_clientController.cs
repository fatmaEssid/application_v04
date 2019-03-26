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
using facturation_v05.Models;

namespace facturation_v05.Controllers
{
    public class Final_clientController : ApiController
    {
        private FacturationBDD_v02Entities db = new FacturationBDD_v02Entities();

        // GET: api/Final_client
        public System.Object GetFinal_client()
        {
            var result = (from a in db.Final_client
                          select new
                          {
                              a.final_client_id,
                              a.final_client_nom,
                              a.final_client_adresse,
                              a.final_client_contact,
                              a.final_client_email
                          }).ToList();
            return result;
        }
        /*  public System.Object GetOrders()
     {
         var result = (from a in db.Orders
                       join b in db.Customers on a.CustomerID equals b.CustomerID

                       select new
                       {
                           a.OrderID,
                           a.OrderNo,
                           Customer = b.Name,
                           a.PMethod,
                           a.GTotal
                       }).ToList();

         return result;
     }*/


        // GET: api/Final_client/5
        [ResponseType(typeof(Final_client))]
        public IHttpActionResult GetFinal_client(int id)
        {
            Final_client final_client = db.Final_client.Find(id);
            if (final_client == null)
            {
                return NotFound();
            }

            return Ok(final_client);
        }

        // PUT: api/Final_client/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinal_client(int id, Final_client final_client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != final_client.final_client_id)
            {
                return BadRequest();
            }

            db.Entry(final_client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Final_clientExists(id))
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

        // POST: api/Final_client
        [ResponseType(typeof(Final_client))]
        public IHttpActionResult PostFinal_client(Final_client final_client)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Final_client.Add(final_client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = final_client.final_client_id }, final_client);*/
            db.Final_client.Add(final_client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = final_client.final_client_id }, final_client);
        }

        // DELETE: api/Final_client/5
        [ResponseType(typeof(Final_client))]
        public IHttpActionResult DeleteFinal_client(int id)
        {
            Final_client final_client = db.Final_client.Find(id);
            if (final_client == null)
            {
                return NotFound();
            }

            db.Final_client.Remove(final_client);
            db.SaveChanges();

            return Ok(final_client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Final_clientExists(int id)
        {
            return db.Final_client.Count(e => e.final_client_id == id) > 0;
        }
    }
}
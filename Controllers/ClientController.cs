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
    public class ClientController : ApiController
    {
        private FacturationBDD_v02Entities db = new FacturationBDD_v02Entities();

        // GET: api/Client
        public System.Object GetClient()
        {

            var result = (from a in db.Client
                          join b in db.Client_details on a.client_id equals b.client_id
                          join c in db.Final_client on b.final_client_id equals c.final_client_id

                          select new
                          {
                              a.client_id,
                              a.client_nom,
                              a.client_siret,
                              a.client_adresse,
                              a.client_email,
                              a.client_TVA,
                              c.final_client_nom
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

        // GET: api/Client/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Client/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.client_id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            /* if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             db.Client.Add(client);
             db.SaveChanges();

             return CreatedAtRoute("DefaultApi", new { id = client.client_id }, client);*/

            try
            {
                //client table
                db.Client.Add(client);
                //clientDetails 
                foreach (var c in client.Client_details)
                {
                    db.Client_details.Add(c);
                }
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // DELETE: api/Client/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.client_id == id) > 0;
        }
    }
}
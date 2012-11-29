using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WellableBusinessService.WellableData;
using System.Data.Services.Client;



namespace WellableBusinessService.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IEnumerable<User> Get()
        {
            return Wellable.Data.Users;
        }

        // GET api/values/5

        /// <summary>
        /// This will get a user from its ID
        /// </summary>
        /// <param name="id">the user id in the</param>
        /// <returns></returns>
        public User Get(long id)
        {
            try
            {
                var user = Wellable.Data.Users.Where(x => x.UserId == id).FirstOrDefault();
                return user;
            }
            catch (System.Data.Services.Client.DataServiceQueryException)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("User not found")
                });
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]User userToAdd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var context = Wellable.Data;
                    context.AddToUsers(userToAdd);
                    var resp = context.SaveChanges();

                }
                catch (Exception ex) //DataServiceRequestException
                {
                    throw new ApplicationException(
                        "An error occurred when saving changes.", ex);
                }

    


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userToAdd);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userToAdd.UserId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]User value)
        {

            //if (ModelState.IsValid && id == value.UserIdApplicationId)
            //{
            //    db.Entry(application).State = EntityState.Modified;

            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound);
            //    }

            //    return Request.CreateResponse(HttpStatusCode.OK);
            //}
            //else
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest);
            //}



        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
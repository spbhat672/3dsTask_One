using REST_Employee_Service.Models;
using REST_Employee_Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace REST_Employee_Service.Controllers
{
    public class EmployeeController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Get/{id?}")]
        public HttpResponseMessage Get(int? id)
        {
            try
            {

                var empList = new List<EmpModel>();
                if(id == null)
                {
                    empList = EmpRepository.GetAllEmployees();
                }
                else
                {
                    empList.Add(EmpRepository.GetEmployee(id));
                }
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, empList);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching Employee Data");
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Post")]
        public HttpResponseMessage Post(EmpModel model)
        {
            try
            {
                EmpRepository.AddEmployee(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Put")]
        public HttpResponseMessage Put(EmpModel model)
        {
            try
            {
                int x = EmpRepository.UpdateEmployee(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, x);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, ex);
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                int x = EmpRepository.DeleteEmployee(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, x);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, ex);
            }
        }

    }
}
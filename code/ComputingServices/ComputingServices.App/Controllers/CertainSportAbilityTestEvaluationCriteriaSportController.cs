using ComputingServices.App.Models;
using ComputingServices.Core.Domain.Models.CertainSportAbilityTest;
using ComputingServices.Core.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComputingServices.App.Controllers
{
    public class CertainSportAbilityTestEvaluationCriteriaSportController : ApiController
    {
        // GET api/certainsportabilitytestevaluationcriteriasport
        public IEnumerable<CertainSportAbilityTestEvaluationCriteriaSportDTO> Get()
        {
            IEnumerable<CertainSportAbilityTestEvaluationCriteriaSportDTO> sportDTOs;

            using (var context = new ComputingServicesContext())
            {
                sportDTOs = context.CertainSportAbilityTestEvaluationCriteriaSports.Select(item => new CertainSportAbilityTestEvaluationCriteriaSportDTO
                { 
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name
                }).ToList();
            }

            return sportDTOs;
        }

        // GET api/certainsportabilitytestevaluationcriteriasport/5
        public CertainSportAbilityTestEvaluationCriteriaSportDTO Get(int id)
        {
            CertainSportAbilityTestEvaluationCriteriaSportDTO sportDTO;

            using (var context = new ComputingServicesContext())
            {
                CertainSportAbilityTestEvaluationCriteriaSport sport = context.CertainSportAbilityTestEvaluationCriteriaSports.SingleOrDefault(item=>item.Id==id);
                if(sport == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                sportDTO = new CertainSportAbilityTestEvaluationCriteriaSportDTO
                { 
                    Id = sport.Id,
                    Code = sport.Code,
                    Name = sport.Name
                };
            }

            return sportDTO;
        }

        // POST api/certainsportabilitytestevaluationcriteriasport
        public HttpResponseMessage Post([FromBody]CertainSportAbilityTestEvaluationCriteriaSportDTO sportDTO)
        {
            CertainSportAbilityTestEvaluationCriteriaSport sport = new CertainSportAbilityTestEvaluationCriteriaSport(sportDTO.Code, sportDTO.Name);

            using (var context = new ComputingServicesContext())
            {
                context.CertainSportAbilityTestEvaluationCriteriaSports.Add(sport);

                context.SaveChanges();
            }

            sportDTO.Id = sport.Id;

            var response = Request.CreateResponse(HttpStatusCode.Created, sportDTO);
            string url = Url.Link("DefaultApi", new { sportDTO.Id });
            response.Headers.Location = new Uri(url);

            return response;
        }

        // DELETE api/certainsportabilitytestevaluationcriteriasport/5
        public HttpResponseMessage Delete(int id)
        {
            using (var context = new ComputingServicesContext())
            {
                CertainSportAbilityTestEvaluationCriteriaSport sport = context.CertainSportAbilityTestEvaluationCriteriaSports.SingleOrDefault(item => item.Id == id);
                if (sport == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                context.CertainSportAbilityTestEvaluationCriteriaSports.Remove(sport);

                context.SaveChanges();
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, id);
            return response;
        }
    }
}

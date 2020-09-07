using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;

namespace ZUMOAPPNAMEService.Controllers
{
    public class DecommissionDataController : TableController<DecommissionData>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ZUMOAPPNAMEContext context = new ZUMOAPPNAMEContext();
            DomainManager = new EntityDomainManager<DecommissionData>(context, Request);

        }

        // GET tables/TodoItem
        public IQueryable<DecommissionData> GetAllDecommissionDatas()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DecommissionData> GetDecommissionData(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DecommissionData> PatchDecommissionData(string id, Delta<DecommissionData> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostDecommissionData(DecommissionData a)
        {
            DecommissionData current = await InsertAsync(a);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDecommissionData(string id)
        {
            return DeleteAsync(id);
        }

    }
}
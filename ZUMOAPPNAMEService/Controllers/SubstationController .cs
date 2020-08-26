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
    public class SubstationController : TableController<Substations>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SubstationContext context = new SubstationContext();
            DomainManager = new EntityDomainManager<Substations>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<Substations> GetAllSubItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Substations> GetSubItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Substations> PatchSubItem(string id, Delta<Substations> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostSubItem(Substations a)
        {
            Substations current = await InsertAsync(a);
            return CreatedAtRoute("Substations", new { id = current.Id }, current); //was Tables
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSubItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}
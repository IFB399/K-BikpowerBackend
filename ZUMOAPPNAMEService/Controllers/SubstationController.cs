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
    public class SubstationController : TableController<Substation>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ZUMOAPPNAMEContext context = new ZUMOAPPNAMEContext();
            DomainManager = new EntityDomainManager<Substation>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<Substation> GetAllSubItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Substation> GetSubItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Substation> PatchSubItem(string id, Delta<Substation> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostSubItem(Substation a)
        {
            Substation current = await InsertAsync(a);
            return CreatedAtRoute("Substations", new { id = current.Id }, current); //was Tables
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSubItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}
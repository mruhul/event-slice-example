using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Api
{
    [Route("v1/[controller]")]
    public class SavedItemsController : Controller
    {
        [Route("{id}")]
        public async Task<IEnumerable<string>> Get(string id)
        {
            await Task.Delay(130);

            return new []{"24817626", "22875451", "25246752", "17333171" };
        } 
    }
}
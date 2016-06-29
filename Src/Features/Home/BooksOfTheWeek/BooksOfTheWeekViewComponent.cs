using System.Collections.Generic;
using System.Linq;
using Bolt.RequestBus;
using BookWorm.Api;
using BookWorm.Web.Features.Shared.SavedBooks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{
    public class BooksOfTheWeekViewComponent : ViewComponent
    {
        private readonly IRequestBus bus;

        public BooksOfTheWeekViewComponent(IRequestBus bus)
        {
            this.bus = bus;
        }

        public IViewComponentResult Invoke()
        {
            var vm = bus.Send<BooksOfTheWeekQuery, IEnumerable<BookDto>>(new BooksOfTheWeekQuery());

            return View("~/Features/Home/BooksOfTheWeek/Views/BooksOfTheWeek.cshtml", vm.Value);
        } 
    }

}

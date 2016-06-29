using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.RequestBus;
using Bolt.RequestBus.Filters;
using Bolt.RequestBus.Handlers;
using BookWorm.Api;
using BookWorm.Web.Features.Shared.SavedBooks;
using System.Linq;

namespace BookWorm.Web.Features.Home.BooksOfTheWeek
{
    public class BooksOfTheWeekQuery : IRequest{ }
    public class BooksOfTheWeekQueryHandler : RequestHandlerBase<BooksOfTheWeekQuery, IEnumerable<BookDto>>
    {
        private readonly ISavedItemsProvider savedItemsProvider;
        private readonly IBooksOfTheWeekProvider booksOfTheWeekProvider;

        public BooksOfTheWeekQueryHandler(ISavedItemsProvider savedItemsProvider, IBooksOfTheWeekProvider booksOfTheWeekProvider)
        {
            this.savedItemsProvider = savedItemsProvider;
            this.booksOfTheWeekProvider = booksOfTheWeekProvider;
        }

        protected override IEnumerable<BookDto> Process(BooksOfTheWeekQuery msg)
        {
            var savedItems = savedItemsProvider.Get();

            var vm = booksOfTheWeekProvider.Get().Select(x =>
            {
                x.IsSaved = savedItems?.Any(id => x.Id == id) ?? false;
                return x;
            });

            return vm;
        }
    }
}
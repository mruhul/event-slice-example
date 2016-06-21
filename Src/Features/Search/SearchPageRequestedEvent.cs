using Bolt.RequestBus;
using BookWorm.Web.Features.Shared.CategoryMenu;
using BookWorm.Web.Features.Shared.Events;

namespace BookWorm.Web.Features.Search
{
    public class SearchPageRequestedEvent : IEvent, IPageRequestedEvent, IRequireCategoryMenu, BookWorm.Web.Features.Shared.SavedBooks.IRequireSavedItems
    {
        public string Category { get; set; }
    }
}
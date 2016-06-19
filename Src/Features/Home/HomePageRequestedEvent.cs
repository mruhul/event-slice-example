using Bolt.RequestBus;
using BookWorm.Web.Features.Shared.CategoryMenu;
using BookWorm.Web.Features.Shared.Events;

namespace BookWorm.Web.Features.Home
{
    public class HomePageRequestedEvent : IEvent, IPageRequestedEvent, IRequireCategoryMenu
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm.Web.Features.Shared
{
    public class Settings
    {
        public string SearchApiUrl { get; set; }
        public string DetailsApiUrl { get; set; }
        public string UsersApiUrl { get; set; }
        public string CartApiUrl { get; set; }
    }

    public interface ISearchApiSettings
    {
        string Url { get; }
    }

    public class DetailsApiSettings : IDetailsApiSettings
    {
        public string Url { get; set; }
    }

    public interface IDetailsApiSettings
    {
        string Url { get; }
    }

    public interface IUsersApiSettings
    {
        string Url { get; }
    }

    public interface ICartApiSettings
    {
        string Url { get; }
    }
}

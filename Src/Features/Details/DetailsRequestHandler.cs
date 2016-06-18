using System;
using System.Threading.Tasks;
using Bolt.RequestBus;
using Bolt.RequestBus.Handlers;
using Bolt.RestClient;
using Bolt.RestClient.Extensions;
using Src.Infrastructure.Attributes;

namespace BookWorm.Web.Features.Details
{
    public class  DetailsQuery : IRequest
    {
        public string Id { get; set; }
    }

    public class DetailsViewModel
    {
        public string Id {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public string Image {get; set;}
        public decimal Price {get; set;}
        public string Details {get; set;}

        public string ISBN {get; set;}
    }

    [AutoBind]
    public class DetailsRequestHandler : AsyncRequestHandlerBase<DetailsQuery, DetailsViewModel>
    {
        private readonly IRestClient restClient;

        public DetailsRequestHandler(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        protected override async Task<DetailsViewModel> ProcessAsync(DetailsQuery query)
        {
            var response = await restClient.For("http://localhost:5000/api/v1/books/{0}", query.Id)
                .AcceptJson()
                .Timeout(1000)
                .RetryOnFailure(2)
                .GetAsync<Api.BookDetailsDto>();
            
            var dto = response.Output;

            if(dto == null) return null;

            return new DetailsViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                Image = dto.Image,
                Price = dto.Price,
                Details = dto.Details
            };
        }
    }
}
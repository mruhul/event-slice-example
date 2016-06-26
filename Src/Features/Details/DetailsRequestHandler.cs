using System;
using System.Threading.Tasks;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RequestBus.Handlers;
using Bolt.RestClient;
using Bolt.RestClient.Builders;
using Bolt.RestClient.Extensions;
using BookWorm.Web.Features.Shared;
using Microsoft.Extensions.Options;
using Src.Infrastructure.Attributes;
using Src.Infrastructure.ErrorSafeHelpers;

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
        public bool IsSaved { get; set; }
        public string Category { get; set; }
    }

    [AutoBind]
    public class DetailsRequestHandler : AsyncRequestHandlerBase<DetailsQuery, DetailsViewModel>
    {
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly IOptions<DetailsApiSettings> option;

        public DetailsRequestHandler(IRestClient restClient, ILogger logger, IOptions<DetailsApiSettings> option)
        {
            this.restClient = restClient;
            this.logger = logger;
            this.option = option;
        }

        protected override async Task<DetailsViewModel> ProcessAsync(DetailsQuery query)
        {
            var response = await ErrorSafe
                .WithLogger(logger)
                .ExecuteAsync(() => restClient.For(
                        UrlBuilder.Host(option.Value.Url).Route($"books/{query.Id}")
                    ).AcceptJson()
                    .Timeout(1000) 
                    .RetryOnFailure(2)
                    .GetAsync<BookDetailsDto>());
            
            var dto = response.Value?.Output;

            if(dto == null) return null;

            return new DetailsViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                Image = dto.Image,
                Price = dto.Price,
                Details = dto.Description,
                ISBN = dto.ISBN,
                Category = dto.Category
            };
        }
    }

    public class BookDetailsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string ISBN { get; set; }
        public string Category { get; set; }

    }
}
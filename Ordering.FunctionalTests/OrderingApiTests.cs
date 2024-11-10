using System.Net;
using Asp.Versioning;
using Asp.Versioning.Http;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.Testing;
using Ordering.API;

namespace Order.FunctionalTests;

public sealed class OrderingApiTests : IClassFixture<OrderingApiFixture>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;
    private readonly HttpClient _httpClient;

    public OrderingApiTests(OrderingApiFixture fixture)
    {
        var handler = new ApiVersionHandler(new QueryStringApiVersionWriter(), new ApiVersion(1.0));

        _webApplicationFactory = fixture;
        _httpClient = _webApplicationFactory.CreateDefaultClient(handler);
    }

    [Fact(Skip = "Skipped, as it is not compatible with github action.")]
    public async Task GetAllStoredOrdersWorks()
    {
        // given

        // when
        var response = await _httpClient.GetAsync("api/v1/orders?PageIndex=0&PageSize=5");
        var s = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        // then
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

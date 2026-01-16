

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;
using System.ComponentModel;
using PokemonApi.Services;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using FluentAssertions;
using PokemonApi.Filters;

public class ValidationFilterAttribute_Tests
{

    [Trait("Api", "Filtros")]
    [Fact(DisplayName = "Testando filtros")]
    public void OnActionExecuting_ShouldRespondWithError()
    {
        // Arrange

        // Criar um ModelState para usar como contexto do filtro
        var modelState = new ModelStateDictionary();
        // Adicionar erros de validação ao ModelState
        modelState.AddModelError("somekey", "Some error message");

        // Criar o contexto do filtro com o ModelState com erros de validação
        var actionContext = new ActionContext(
            new DefaultHttpContext(),
            Mock.Of<RouteData>(),
            Mock.Of<ActionDescriptor>(),
            modelState
        );

        var executingContext = new ActionExecutingContext(
            actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object?>(),
            Mock.Of<Controller>()
        );

        // Act
        // Chamamos a função OnActionExecuting
        var actionFilter = new MyActionFilter();
        actionFilter.OnActionExecuting(executingContext);

        // Assert
        executingContext.Result.Should().BeOfType<UnprocessableEntityObjectResult>();
    }

    [Trait("Api", "Api Externa")]
    [Theory(DisplayName = "testando serviços externos")]
    [InlineData("https://pokeapi.co/api/v2/pokemon/pikachu")]


    public async void ShouldMakeARequest(string name)
    {
        var mockClient = new Mock<HttpClient>();
        var apiService = new ApiService(mockClient.Object);
        var result = await apiService.GetPokemonByName(name);
        result.Should().BeOfType<JsonElement>();
        result.ToString().Should().Contain("abilities");
    }
}
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, string Description, string ImageFile, decimal Price, List<string> Category);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender send) =>
            {
                var command = request.Adapt<CreateProductCommend>();
                var handle = await send.Send(command);
                var response = handle.Adapt<CreateProductResponse>();

                return Results.Created($"products/{response.Id}", response);
            })
             .WithName("CreateProduct")
             .Produces<CreateProductResponse>(StatusCodes.Status201Created)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Create Product")
             .WithDescription("Create Product");
        }
    }
}
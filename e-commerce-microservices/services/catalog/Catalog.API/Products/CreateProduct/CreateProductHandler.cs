using BuildingBlocks.CQRS;
using Catalog.API.models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommend(string Name, string Description, string ImageFile, decimal Price, List<string> Category)
        : ICommend<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductHandler(IDocumentSession session) : ICommendHandler<CreateProductCommend, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommend commend, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = commend.Name,
                Description = commend.Description,
                ImageFile = commend.ImageFile,
                Price = commend.Price,
                Category = commend.Category,
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
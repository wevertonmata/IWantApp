using IWantApp.Endpoints.Categories;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; } = true;

    internal object Select(Func<object, CategoryResponse> value)
    {
        throw new NotImplementedException();
    }

    internal object Select(Guid id, object name, object active)
    {
        throw new NotImplementedException();
    }
}

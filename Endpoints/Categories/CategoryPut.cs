using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryPut
{
    public static String Template => "/categories/{id}";
    public static String[] Methods => new string[] { HttpMethod.Put.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id,CategoryRequest categoryRequest, ApplicationDBContext context) {

        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();

        category.Name = categoryRequest.Name;
        category.Active= categoryRequest.Active;
       
        context.SaveChanges();
        return Results.Ok(category);
    }
}

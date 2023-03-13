using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using System.Collections.Generic;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static String Template => "/categories";
    public static String[] Methods => new string[] { HttpMethod.Post.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDBContext context) {

        var category = new Category(categoryRequest.Name, "Teste", "Teste");

        if (!category.IsValid) { 
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}",category);
    }
}

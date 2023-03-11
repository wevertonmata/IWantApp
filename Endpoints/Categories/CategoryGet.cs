using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class CategoryGet
{
    public static String Template => "/categories/{id}";
    public static String[] Methods => new string[] { HttpMethod.Get.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid Id, ApplicationDBContext context) {

        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault().ToString();

        return Results.Ok(category);
    }
}

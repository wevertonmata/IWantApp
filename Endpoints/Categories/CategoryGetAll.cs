﻿using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryGetAll{
    public static String Template => "/categories";
    public static String[] Methods => new string[] { HttpMethod.Get.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDBContext context) {

       var categories = context.Categories.ToList();
       var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active});

       return Results.Ok(response);
    }
}

﻿using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static String Template => "/categories";
    public static String[] Methods => new string[] { HttpMethod.Post.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDBContext context) {

        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "Teste",
            CreatedOn= DateTime.Now,
            EditedBy = "Teste",
            EditedOn= DateTime.Now,
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}",category);
    }
}

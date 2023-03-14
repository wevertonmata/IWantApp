﻿using IWantApp.Domain.Products;
using IWantApp.Endpoints.Categories;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll{
    public static String Template => "/employees";
    public static String[] Methods => new string[] { HttpMethod.Get.ToString()};
    public static Delegate Handle => Action;

    public static IResult Action(UserManager<IdentityUser> userManager) {

        var users = userManager.Users.ToList();
        var employees = new List<EmployeeResponse>();
        foreach (var user in users) {
            var claims = userManager.GetClaimsAsync(user).Result;
            var claimName = claims.FirstOrDefault(c => c.Type == "Name");
            var userName = claimName != null ? claimName.Value : string.Empty;
            employees.Add(new EmployeeResponse(user.Email, userName));
        }

        return Results.Ok(employees);
    }
}

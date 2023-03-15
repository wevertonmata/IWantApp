using Dapper;
using IWantApp.Domain.Products;
using IWantApp.Endpoints.Categories;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll{
    public static String Template => "/employees";
    public static String[] Methods => new string[] { HttpMethod.Get.ToString()};
    public static Delegate Handle => Action;

    // Dapper
    public static IResult Action([FromQuery] int? page, [FromQuery] int? rows, QueryAllUserWithClaimName query)
    {
        if (page == null)
            page = 1;

        if (rows == null)
            rows = 10;

        var employees = query.Execute(page.Value, rows.Value);
        return Results.Ok(employees);
    }

    // EF
    // public static IResult Action([FromQuery] int page, [FromQuery] int rows,UserManager<IdentityUser> userManager) {

    //    var users = userManager.Users.Skip((page - 1) * rows).Take(rows).ToList();
    //    var employees = new List<EmployeeResponse>();
    //    foreach (var user in users) {
    //        var claims = userManager.GetClaimsAsync(user).Result;
    //        var claimName = claims.FirstOrDefault(c => c.Type == "Name");
    //        var userName = claimName != null ? claimName.Value : string.Empty;
    //        employees.Add(new EmployeeResponse(user.Email, userName));
    //    }

    //    return Results.Ok(employees);
    //}
}

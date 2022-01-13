using DomainLayer.Model;
using DomainServiceLayer.Interfaces;

public static class CustomerRoutes
{
    public static void ConfigureCustomerRoutes(this WebApplication app)
    {
        app.MapGet("/Customers", GetCustomers);
        app.MapGet("/customers/{id}", GetCustomerById);
        app.MapPost("/customers", InsertCustomer);
        app.MapPut("/customers", UpdateCustomer);
        app.MapDelete("/customers/{id}", DeleteCustomer);
    }

    private static IResult GetCustomers(ICustomerService customerService)
    {
        try
        {
            return Results.Ok(customerService.GetAllCustomers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static IResult GetCustomerById(int id, ICustomerService customerService)
    {
        try
        {
            var customer = customerService.GetCustomer(id);
            return customer is null ? Results.NotFound() : Results.Ok(customer);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static IResult InsertCustomer(Customer customer, ICustomerService customerService)
    {
        try
        {
            customerService.InsertCustomer(customer);
            return Results.Created($"/customers/{customer.Id}", customer);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static IResult UpdateCustomer(Customer customer, ICustomerService customerService)
    {
        try
        {
            customerService.UpdateCustomer(customer);
            return Results.Ok(customer);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static IResult DeleteCustomer(int id, ICustomerService customerService)
    {
        try
        {
            customerService.DeleteCustomer(id);
            return Results.Ok($"Usuário - {id}, foi removido com sucesso na base de dados.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
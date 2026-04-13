using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category()
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };
        
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 201, "Category created successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            if (category == null)
                return new Response<Category?>(null, 404, "Category not found");
            
            category.Title = request.Title;
            category.Description = request.Description;
            
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            
            return new Response<Category?>(category, 200, "Category updated successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            if (category == null)
                return new Response<Category>(null, 404, "Category not found");
        
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return new Response<Category>(category, 200, "Category deleted successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        var category = await context
            .Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
        
        return  category == null
            ? new Response<Category>(null, 404, "Category not found")
            :  new Response<Category>(category);
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request)
    {
        try
        {
             var query = context
                 .Categories
                 .AsNoTracking();
             
             var categories = await query
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .ToListAsync();
             
             var count =  await query.CountAsync();
             
             return new PagedResponse<List<Category>?>(
                 categories,
                 request.PageNumber,
                 request.PageSize,
                 count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using User.Data;
using User.DTO;
using User.Model;
using User.Records;

namespace User.Controller
{
    public static class UserController
    {
        public static void addUserController(this WebApplication app)
        {
            var rout = app.MapGroup(prefix: "user");
            rout.MapPost("", handler: async (UserRecord record, UserContext db) =>
            {
                var newUser = new UserModel(record.Name, record.LastName, record.Email);
                await db.Users.AddAsync(newUser);
                await db.SaveChangesAsync();

            });

            rout.MapGet("", handler: async (UserContext db) =>
            {
                var teste = await db.Users.Where(x => x.Active).ToArrayAsync();
                return teste;
            });

            rout.MapPut(pattern: "{id}", handler: async (string id, UserRecord record, UserContext db) =>
            {
                var user = await db.Users.SingleOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return Results.NotFound();

                user.Ativa();

                db.SaveChangesAsync();

                var userDTO = new UserDTO(user.Name, user.Email, user.Birthday);

                return Results.Ok(userDTO);
            });

            rout.MapDelete(pattern: "{id}", handler: async (string id, UserContext db) =>
            {
                var user = await db.Users.SingleOrDefaultAsync(x => x.Id == id);
                user.Desativa();
                db.SaveChangesAsync();

                return Results.Ok();

            });
        }
	}
}

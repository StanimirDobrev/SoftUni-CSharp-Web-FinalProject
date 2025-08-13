	using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Data.Models;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Services.Core;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

		builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
		{
			options.SignIn.RequireConfirmedAccount = false;
			options.Password.RequireDigit = false;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.Password.RequireLowercase = false;
		})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();
		// Add services to the container.
		builder.Services.AddControllersWithViews();
		builder.Services.AddRazorPages();

		builder.Services.AddScoped<IDriverService, DriverService>();
		builder.Services.AddScoped<ITeamService, TeamService>();
		builder.Services.AddScoped<IRallyEventService, RallyEventService>();
		builder.Services.AddScoped<INewsService, NewsService>();
		builder.Services.AddScoped<ICrewService, CrewService>();


		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		static async Task SeedAdminAsync(IServiceProvider services)
		{
			using var scope = services.CreateScope();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			const string adminRole = "Administrator";
			const string adminEmail = "admin@wrc.local";
			const string adminPass = "Admin123!";

			// Role
			if (!await roleManager.RoleExistsAsync(adminRole))
			{
				var r = await roleManager.CreateAsync(new IdentityRole(adminRole));
				if (!r.Succeeded) throw new Exception(string.Join("; ", r.Errors.Select(e => e.Description)));
			}

			// User
			var user = await userManager.FindByEmailAsync(adminEmail);
			if (user == null)
			{
				user = new ApplicationUser
				{
					UserName = adminEmail,
					Email = adminEmail,
					EmailConfirmed = true
				};

				var u = await userManager.CreateAsync(user, adminPass);
				if (!u.Succeeded) throw new Exception(string.Join("; ", u.Errors.Select(e => e.Description)));
			}

			if (!await userManager.IsInRoleAsync(user, adminRole))
			{
				var a = await userManager.AddToRoleAsync(user, adminRole);
				if (!a.Succeeded) throw new Exception(string.Join("; ", a.Errors.Select(e => e.Description)));
			}
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.MapRazorPages();

		await SeedAdminAsync(app.Services);

		app.Run();
	}
}

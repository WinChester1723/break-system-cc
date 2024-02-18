namespace Infrastructure.Data;

using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/// <summary>
/// Initializes and seeds the application's database with default roles and users.
/// </summary>
/// /// <summary>
/// Initializes a new instance of the <see cref="DbContextInitialiser"/> class.
/// </summary>
/// <param name="logger">The logger for logging seeding-related events.</param>
/// <param name="context">The application's database context.</param>
/// <param name="userManager">The user manager for managing user-related operations.</param>
/// <param name="roleManager">The role manager for managing role-related operations.</param>
/// <param name="webHostEnvironment">The web host environment for accessing web-related information.</param>
public class DbContextInitialiser(
    ILogger<DbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
{
    private readonly ILogger<DbContextInitialiser> logger = logger;
    private readonly ApplicationDbContext context = context;
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly RoleManager<IdentityRole> roleManager = roleManager;
    private readonly IWebHostEnvironment webHostEnvironment = webHostEnvironment;

    /// <summary>
    /// Asynchronously applies any pending migrations for the context to the database.
    /// </summary>
    /// <returns> <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task TryMigrateAsync()
    {
        try
        {
            await this.context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "An error occurred while initialising the database.");
        }
    }

    /// <summary>
    /// Seeds the application's database with default roles and users.
    /// </summary>
    /// <returns> <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task TrySeedAsync()
    {
        try
        {
            await this.SeedUsersAndRolesAsync();
            // await this.SeedPositionsAsync();
            // await this.SeedDepartmentsAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError("Database Seed failed with exception: \n{0}", ex);
        }
    }

    /// <summary>
    /// Attempts to seed the application's database with default roles and users.
    /// </summary>
    /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task SeedUsersAndRolesAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Admin");

        if (this.roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await this.roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };

        if (this.userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await this.userManager.CreateAsync(administrator, "Myhradmin1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await this.userManager.AddToRolesAsync(administrator, [administratorRole.Name]);
            }
        }

        await this.context.SaveChangesAsync();
    }

    #region OtherMethods
    // /// <summary>
    // /// Attempts to seed the application's database with default positions.
    // /// </summary>
    // /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
    // public async Task SeedPositionsAsync()
    // {
    //     if (!this.context.Positions.Any())
    //     {
    //         string positionFilePath = Path.Combine(this.webHostEnvironment.ContentRootPath, "Data", "database-position-seed.json");
    //         List<Position> positions = await ReadFromJsonFileAsync<Position>(positionFilePath);
    //         await this.context.Positions.AddRangeAsync(positions);
    //         await this.context.SaveChangesAsync();
    //     }
    // }

    // /// <summary>
    // /// Attempts to seed the application's database with default departments.
    // /// </summary>
    // /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
    // public async Task SeedDepartmentsAsync()
    // {
    //     if (!this.context.Departments.Any())
    //     {
    //         string departmentFilePath = Path.Combine(this.webHostEnvironment.ContentRootPath, "Data", "database-department-seed.json");
    //         List<Department> departments = await ReadFromJsonFileAsync<Department>(departmentFilePath);
    //         await this.context.Departments.AddRangeAsync(departments);
    //         await this.context.SaveChangesAsync();
    //     }
    // }

    // /// <summary>
    // /// Reads JSON data from a file asynchronously and deserializes it into a list of objects of type T.
    // /// </summary>
    // /// <typeparam name="T">The type of object to deserialize.</typeparam>
    // /// <param name="filePath">The path to the JSON file to read.</param>
    // /// <returns>A task representing the asynchronous operation. The task result contains a list of deserialized objects of type T.</returns>
    // /// <exception cref="ArgumentNullException">Thrown when the filePath parameter is null.</exception>
    // /// <exception cref="FileNotFoundException">Thrown when the file specified by filePath does not exist.</exception>
    // /// <exception cref="Exception">Thrown when deserialization fails or the deserialized list is null.</exception>
    // private static async Task<List<T>> ReadFromJsonFileAsync<T>(string filePath)
    // {
    //     // Check if the file exists
    //     if (!File.Exists(filePath))
    //     {
    //         throw new FileNotFoundException("The specified file does not exist.", filePath);
    //     }

    //     // Read JSON data from file
    //     using var reader = new StreamReader(filePath);
    //     string json = await reader.ReadToEndAsync();

    //     // Deserialize JSON into a list of objects of type T
    //     List<T> items = JsonConvert.DeserializeObject<List<T>>(json) ?? throw new Exception("Deserialized list is null.");

    //     return items;
    // }
    #endregion
}

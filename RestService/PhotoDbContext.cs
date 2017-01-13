namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotoDbContext : DbContext
    {
        // Your context has been configured to use a 'PhotoDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RestService.PhotoDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotoDbContext' 
        // connection string in the application configuration file.
        public PhotoDbContext()
            : base("name=PhotoDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Photo> Photos { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
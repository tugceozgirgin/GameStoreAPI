using GameStore.Api.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
: DbContext(options) //those options are the ones that are going to provide the gain store context all of the details about how to connect actual database
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    //will be executed as soon as the migration is executed
    //opportunity to do things tthat slightly modify th modle according to our need
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {Id=1, Name= "Fighthing"},
            new {Id=2, Name= "Roleplaying"},
            new {Id=3, Name= "Sports"},
            new {Id=4, Name= "Racing"},
            new {Id=5, Name= "Kids and Family"}

        ); //whtever data we introduce her ehas to exist when the migration process completes.
    }

}
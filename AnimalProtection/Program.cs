using Microsoft.EntityFrameworkCore;

using System.Data;


namespace LINQMethodDemo

{

    public class AnimalContext : DbContext

    {

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Species> Species { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)

        {

            builder.UseSqlServer(/* Your connection string */);

        }

    }


    public class Animal

    {

        public Guid AnimalId { get; set; }

        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Species Species { get; set; }

    }


    public class Species

    {

        public Guid SpeciesId { get; set; }

        public String Name { get; set; }

    }


    public class Program

    {

        public static void Main()

        {

            using (var context = new AnimalContext())

            {

                var whiteCougarSpecies = context.Species.Where((s) => s.Name == "White cougar");

                IEnumerable<Animal> whiteCougars = context.Animals.Where((a) => a.Species == whiteCougarSpecies);

            }

        }

    }
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFconsole
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class MusicContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RONNYF-THI-V\SQLEXPRESS;Database=EFConsole;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicContext())
            {
                //context.Albums.Add(new Album() { Title = "Shakira"});
                //var count = context.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);

                foreach (var album in context.Albums)
                {
                    Console.WriteLine(" - {0}", album.Title);
                }

                Console.WriteLine();

                Console.ReadLine();
            }
        }
    }
}
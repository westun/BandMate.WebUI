using BandMate.Domain.Core.Models;
using BandMate.Domain.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BandMate.Domain.Persistence
{
    public class BandMateContext : DbContext
    {
        public BandMateContext(DbContextOptions options)
            : base(options)
        {
        }       

        public DbSet<Election> Elections { get; set; }
        public DbSet<ElectionVote> ElectionVotes { get; set; }
        public DbSet<SongListType> SongListTypes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongAccount> SongAccounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SetList> SetLists { get; set; }
        public DbSet<SetListItem> SetListItems { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandName> BandNames { get; set; }
        public DbSet<BandAccount> BandAccounts { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        //public DbSet<Lesson> Lessong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ElectionVote>(eb =>
            {
                eb.HasOne(ev => ev.Election)
                    .WithMany(ev => ev.ElectionVotes)
                    .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(ev => ev.Account)
                    .WithMany(ev => ev.ElectionVotes)
                    .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(ev => ev.Song)
                    .WithMany(ev => ev.ElectionVotes)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            //modelBuilder.Entity<ElectionVote>().HasRequired(x => x.Election).WithMany(e => e.ElectionVotes).WillCascadeOnDelete(false);
            //modelBuilder.Entity<ElectionVote>().HasRequired(x => x.Account).WithMany(a => a.ElectionVotes).WillCascadeOnDelete(false);
            //modelBuilder.Entity<ElectionVote>().HasRequired(x => x.Song).WithMany(s => s.ElectionVotes).WillCascadeOnDelete(false);

            modelBuilder.Entity<Song>()
                .HasMany(s => s.ElectionSongs)
                .WithOne(es => es.Song)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Election>()
                .HasMany(e => e.ElectionSongs)
                .WithOne(e => e.Election)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Configurations.Add(new PasswordResetRequestConfiguration());

            new PasswordResetRequestConfiguration()
                .Configure(modelBuilder.Entity<PasswordResetRequest>());
        }

    }
}
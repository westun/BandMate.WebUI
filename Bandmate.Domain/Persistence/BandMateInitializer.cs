//using System;
//using System.Collections.Generic;
//using System.Linq;
//using BandMate.Domain.Core.Models;

//namespace BandMate.Domain.Persistence
//{
//    public class BandMateInitializer : System.Data.Entity.CreateDatabaseIfNotExists<BandMateContext>
//    {
//        //this method won't run if not setup to use BandMateInitializer in web.config
//        protected override void Seed(BandMateContext context)
//        {
//            this.CreateAndAddBands(context);
//            this.CreateAndAddAccounts(context);
//            //this.CreateAndAddSetListType(context); //this is now done using sql db migration scripts so that SongListType is "static" data
//            this.AddTheGunShowSongs(context, this.GetTheGunShowSongs());
//            this.AddWeNeedABandNameSongs(context, this.GetWeNeedABandNameSongs());

//            //var gigs = new List<Gig> {
//            //    new Gig { 
//            //        StartTime = new DateTimeOffset(new DateTime(2017, 2, 15, 20, 0, 0)), 
//            //        EndTime = new DateTimeOffset(new DateTime(2017, 2, 16, 1, 0, 0)), 
//            //        Venue = new Venue { 
//            //            Name = "The Showbox", 
//            //            Website = "http://www.showboxpresents.com/", 
//            //            Address = new Address{ 
//            //                City = "Seattle", 
//            //                State = "WA", 
//            //                Street1 = "1426 1st Ave", 
//            //                Zip = "98101" 
//            //            }
//            //        }
//            //    },
//            //};

//            //context.Gigs.AddRange(gigs);
//            //context.SaveChanges();

//            //var elections = new List<Election>
//            //{
//            //    new Election
//            //    {
//            //       Account = accounts.FirstOrDefault(a => a.Username == "westun"),
//            //       StartDate = DateTimeOffset.Now,
//            //       EndDate = DateTimeOffset.Now,
//            //       Name = "First Election of previous song list",
//            //       Songs = songs,
//            //       Active = true,
//            //    }
//            //};

//            //context.Elections.AddRange(elections);
//            //context.SaveChanges();
//        }

//        #region Account
//        private void CreateAndAddAccounts(BandMateContext context)
//        {
//            var wesAccount =
//                new Account {
//                    Email = "wesleytunnermann@gmail.com", FirstName = "Wesley", LastName = "Tunnermann",
//                    Roles = new List<Role> { new Role { Name = "Admin" } },
//                    AccountCredentials = new AccountCredential[] { new AccountCredential { Active = true, Version = "1.0", Password = "$2a$10$Q7CbV0uV47ya.SyUA6Hxju43gmeVvFMv0K1K80SH8aSpWubFBcm.m", Salt = "$2a$10$Q7CbV0uV47ya.SyUA6Hxju" } },
//                };

//            context.Accounts.Add(wesAccount);
//            context.SaveChanges();

//            wesAccount.BandAccounts = new List<BandAccount> {
//                new BandAccount { Account = wesAccount, Band = context.Bands.FirstOrDefault(b => b.Name == "The Gun Show") },
//                new BandAccount { Account = wesAccount, Band = context.Bands.FirstOrDefault(b => b.Name == "The Electrolytes") },
//                new BandAccount { Account = wesAccount, Band = context.Bands.FirstOrDefault(b => b.Name == "We Need A Band Name"), Default = true },
//                new BandAccount { Account = wesAccount, Band = context.Bands.FirstOrDefault(b => b.Name == "eventcore")},
//                new BandAccount { Account = wesAccount, Band = context.Bands.FirstOrDefault(b => b.Name == "Alkaline Trio Tribute")},
//            };
            
//            context.SaveChanges();
//        }
//        #endregion
        
//        #region Band
//        private void CreateAndAddBands(BandMateContext context)
//        {
//            var bands = new List<Band>
//            {
//                new Band { Name = "The Gun Show" },
//                new Band { Name = "The Electrolytes" },
//                new Band { Name = "We Need A Band Name" },
//                new Band { Name = "eventcore" },
//                new Band { Name = "Alkaline Trio Tribute" },
//            };
//            context.Bands.AddRange(bands);
//        }
//        #endregion

//        #region SongListType
//        private void CreateAndAddSetListType(BandMateContext context)
//        {
//            var ListTypes = new List<SongListType>{
//                new SongListType{ ListTypeName = "Current" },
//                new SongListType{ ListTypeName = "Archived" },
//                new SongListType{ ListTypeName = "Rating" },
//                new SongListType{ ListTypeName = "Denied" },
//                new SongListType{ ListTypeName = "Destroyed" },
//                new SongListType{ ListTypeName = "CoverSong" },
//            };
//            context.SongListTypes.AddRange(ListTypes);
//            context.SaveChanges();
//        }
//        #endregion

//        #region TheGunShow
//        private void AddTheGunShowSongs(BandMateContext context, IEnumerable<Song> songs)
//        {
//            int id = context.Bands.Where(b => b.Name == "The Gun Show").Select(b => b.BandID).FirstOrDefault();
//            foreach (Song song in songs)
//            {
//                song.BandID = id;
//            }
//            context.Songs.AddRange(songs);
//            context.SaveChanges();
//        }

//        private IEnumerable<Song> GetTheGunShowSongs()
//        {
//            return new List<Song>{
//                new Song{  Artist = "Fall Out Boy", Title = "Beat It", YoutubeURL = null },
//                new Song{  Artist = "The Darkness", Title = "I Believe In A Thing Called Love", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The All American Rejects", Title = "Gives You Hell", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Paramore", Title = "Misery Business", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Journey", Title = "Don't Stop Believin'", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Young the Giant", Title = "My Body", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Ramones", Title = "Blitzkrieg Bop", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Fall Out Boy", Title = "Dance, Dance", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Eve 6", Title = "Inside Out", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Fountains Of Wayne", Title = "Stacy's Mom", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Jimmy Eat World", Title = "The Middle", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Joan Jett", Title = "I Love Rock N Roll", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Letters To Cleo", Title = "I Want You To Want Me", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Lit", Title = "My Own Worst Enemy", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Motely Crew", Title = "Girls, Girls, Girls", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "ACDC", Title = "Highway To Hell", YoutubeURL = "https://www.youtube.com/watch?v=qKggnBh2Mdw", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "ACDC", Title = "You Shook Me All Night Long", YoutubeURL = "http://www.youtube.com/watch?v=Lo2qQmj0_h4", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Lady Gaga", Title = "Bad Romance", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Avril Lavigne", Title = "Skater Boy", YoutubeURL = "https://www.youtube.com/watch?v=TIy3n2b7V9k", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Beastie Boys", Title = "Fight For Your Right", YoutubeURL = "https://www.youtube.com/watch?v=eBShN8qT4lk", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Big And Rich", Title = "Save A Horse (Ride A Cowboy)", YoutubeURL = "https://www.youtube.com/watch?v=Qt0_oPPK6eA", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Billy Idol", Title = "Rebel Yell", YoutubeURL = "https://www.youtube.com/watch?v=VdphvuyaV_I", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Blink 182", Title = "All The Small Things", YoutubeURL = "https://www.youtube.com/watch?v=9Ht5RZpzPqw", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Blondie", Title = "Call Me", YoutubeURL = "https://www.youtube.com/watch?v=y6QBaZHltJw", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Bon Jovi", Title = "You Give Love A Bad Name", YoutubeURL = "https://www.youtube.com/watch?v=KrZHPOeOxQQ", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Def Leppard", Title = "Pour Some Sugar On Me", YoutubeURL = "https://www.youtube.com/watch?v=AQ4xwmZ6zi4", CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Green Day", Title = "Basket Case", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Guns N' Roses", Title = "Paradise City", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Jet", Title = "Are You Gonna Be My Girl", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Neon Trees", Title = "Animal", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "No Doubt", Title = "Just A Girl", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Poison", Title = "Talk Dirty To Me", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Rick Springfield", Title = "Jessie's Girl", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Rise Against", Title = "Savior", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Sum 41", Title = "Fat Lip", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Black Keys", Title = "Lonely Boy", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Cars", Title = "Just What I Needed", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Outfield", Title = "Your Love", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Ramones", Title = "I Wanna Be Sedated", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "The Strokes", Title = "Last Night", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Van Halen", Title = "Panama", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Warrant", Title = "Cherry Pie", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{  Artist = "Weezer", Title = "Buddy Holly", YoutubeURL = null, CreatedDate = DateTimeOffset.Now },
//                new Song{ Artist = "Foreigner", Title = "Jukebox Hero", YoutubeURL = "https://www.youtube.com/watch?v=fr6KVNt-1Ek", CreatedDate = DateTimeOffset.Now },
//                new Song{ Artist = "Dokken", Title = "Breaking the Chains ", YoutubeURL = "https://www.youtube.com/watch?v=nQb1t_Yw0S8&index=20&list=PLAxZTpvqVMv5yekxHuJPxnhhFYnfF4M9j", CreatedDate = DateTimeOffset.Now },
//                new Song{ Artist = "Def Leppard", Title = "Animal", YoutubeURL = "https://www.youtube.com/watch?v=ecFPU--vvf0&index=19&list=PLAxZTpvqVMv5yekxHuJPxnhhFYnfF4M9j", CreatedDate = DateTimeOffset.Now },
//                new Song{ Artist = "ZZ Top", Title = "Legs", YoutubeURL = "https://www.youtube.com/watch?v=8bM23t2FuBs&index=21&list=PLAxZTpvqVMv5yekxHuJPxnhhFYnfF4M9j", CreatedDate = DateTimeOffset.Now },
//                new Song{ Artist = "KISS", Title = "I WAS MADE FOR LOVING YOU", YoutubeURL = "https://www.youtube.com/watch?v=u7isxoTIeYM&index=28&list=PLAxZTpvqVMv5yekxHuJPxnhhFYnfF4M9j", CreatedDate = DateTimeOffset.Now},
//            };
//        }
//        #endregion

//        #region WeNeedABandName
//        private IEnumerable<Song> GetWeNeedABandNameSongs()
//        {
//            return new List<Song>{
//                new Song { Title = "Give It All You Got", Bpm = 123, KeySignature = "Eb Min ", CreatedDate = new DateTimeOffset(new DateTime(2016, 9, 16)),
//                    SongAccounts = new SongAccount[] { new SongAccount { AccountID = 1, Notes = "my song notes" } } },
//                new Song { Title = "Patience", KeySignature = "C# Maj", Bpm = 135, CreatedDate = new DateTimeOffset(new DateTime(2016,10, 29)) },
//                new Song { Title = "Train Wreck", Bpm = 183, KeySignature = "B Min", CreatedDate = new DateTimeOffset(new DateTime(2016,10, 11)) },
//                new Song { Title = "Mayday", KeySignature = "F Maj", Bpm = 150, CreatedDate = new DateTimeOffset(new DateTime(2016, 10, 5)) },
//                new Song { Title = "I Know Everything", KeySignature = "Eb Maj", CreatedDate = new DateTimeOffset(new DateTime(2016, 12, 20)) },
//                new Song { Title = "Let Me Go", KeySignature = "C# Min", CreatedDate = new DateTimeOffset(new DateTime(2016, 11, 22)) },
//                new Song { Title = "Whoa Oh Oh Oh", CreatedDate = new DateTimeOffset(new DateTime(2017, 12, 13)) },
//                new Song { Title = "Everything You Do", CreatedDate = new DateTimeOffset(new DateTime(2017, 1, 3)) },
//                new Song { Title = "Refuse To Believe", CreatedDate = new DateTimeOffset(new DateTime(2017, 1, 15)) },
//                new Song { Title = "Tease Me", KeySignature = "B Min", CreatedDate = new DateTimeOffset(new DateTime(2017, 2, 3)) },
//                new Song { Title = "Teenage Runaway", Bpm = 170, CreatedDate = new DateTimeOffset(new DateTime(2017, 2, 14)) },
//                new Song { Title = "Liar Liar", KeySignature = "F Maj", Bpm = 190, CreatedDate = new DateTimeOffset(new DateTime(2017, 3, 7)) },
//                new Song { Title = "She's Dangerous", KeySignature = "F# Min", CreatedDate = new DateTimeOffset(new DateTime(2017, 3, 18)) },
//                new Song { Title = "Wish You Were Dead", KeySignature = "E Maj", CreatedDate = new DateTimeOffset(new DateTime(2017, 4, 1)) },
//                new Song { Title = "I Don't Sin", KeySignature = "Ab Min", CreatedDate = new DateTimeOffset(new DateTime(2017, 4, 16)) },
//                new Song { Title = "Cross The Line", KeySignature = "D Min", CreatedDate = new DateTimeOffset(new DateTime(2017, 4, 25)) },
//                new Song { Title = "Young Again", KeySignature = "C Maj", CreatedDate = new DateTimeOffset(new DateTime(2017, 5, 15)) },
//                new Song { Title = "Trama Queen", CreatedDate = new DateTimeOffset(new DateTime(2017, 5, 28)) },
//                new Song { Title = "Can't Look At You", Bpm = 163, CreatedDate = new DateTimeOffset(new DateTime(2017, 5, 28)) },
//                new Song { Title = "Drive", CreatedDate = new DateTimeOffset(new DateTime(2017, 6, 11)) },
//                new Song { Title = "Bad Boy", CreatedDate = new DateTimeOffset(new DateTime(2017, 6, 25)) },
//            };
//        }

//        private void AddWeNeedABandNameSongs(BandMateContext context, IEnumerable<Song> songs)
//        {
//            int id = context.Bands.Where(b => b.Name == "We Need A Band Name").Select(b => b.BandID).FirstOrDefault();
//            foreach (Song song in songs)
//            {
//                song.BandID = id;
//            }
//            context.Songs.AddRange(songs);
//            context.SaveChanges();
//        }
//        #endregion

//    }
//}
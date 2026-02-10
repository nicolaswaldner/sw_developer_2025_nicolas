using Wifi.PlaylistEditor.BaseTypes;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.RepositoryTypes.M3u;

namespace Wifi.PlaylistEditor.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playlistItemFactory = new PlaylistItemFactory();

            //var filePathList = new string[]
            //{
            //    @"C:\Users\User\Documents\demofiles\001 - Bruno Mars - Grenade.mp3",
            //    @"C:\Users\User\Documents\demofiles\01 - Broken Pieces (feat. Nihils).mp3",
            //    @"C:\Users\User\Documents\demofiles\002 - Lena - Taken By A Stranger.mp3",
            //    @"C:\Users\User\Documents\demofiles\003 - Adele - Rolling in the deep.mp3",
            //    @"C:\Users\User\Documents\demofiles\004 - Hurts - Stay.mp3",
            //    @"C:\Users\User\Documents\demofiles\005 - Taio Cruz feat. Kylie Minogue - Higher.mp3",
            //    @"C:\Users\User\Documents\demofiles\006 - Lady Gaga - Born This Way.mp3",
            //    @"C:\Users\User\Documents\demofiles\brettspiel.jpg",
            //    @"C:\Users\User\Documents\demofiles\gettyimages-929531216-594x594.jpg",
            //    @"C:\Users\User\Documents\demofiles\istockphoto-1150931120-612x612.jpg",
            //    @"C:\Users\User\Documents\demofiles\Kayla-Person.jpg",
            //    @"C:\Users\User\Documents\demofiles\pexels-mikebirdy-170811.jpg",
            //    @"C:\Users\User\Documents\demofiles\Sizilianischer_Auto.jpg"
            //};

            if (args.Length == 0 ) //mit drag n drop auf consoleapp.exe dateien tun
            {
                return;
            }
            
            var playlist = new Playlist("Demo Playlist Charts 2026", "DJ Gandalf");

            foreach (var filePath in args)
            {
                var item = playlistItemFactory.Create(filePath);
                if(item != null)
                {
                    playlist.Add(item);
                }
            }

            //Playlist Datei generieren
            var repository = new M3uRepository(playlistItemFactory);
            repository.Save(playlist, playlist.Title + ".m3u");

        }
    }
}

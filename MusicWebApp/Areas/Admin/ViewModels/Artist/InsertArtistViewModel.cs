namespace MusicWebApp.Areas.Admin.ViewModels.Artist
{
    public class InsertArtistViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string WebSite { get; set; }
        public bool IsSinger { get; set; }
        public bool IsSongWriter { get; set; }
    }
}
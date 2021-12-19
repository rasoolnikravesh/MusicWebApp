namespace MusicWebApp.Areas.Admin.ViewModels.Artist
{
    public class ShowArtistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string WebSite { get; set; }
        public bool IsSongWriter { get; set; }
        public bool IsSinger { get; set; }
        public bool IsCompos { get; set; }
        public bool IsRemixMusics { get; set; }
        public bool IsArrangement { get; set; }
    }
}

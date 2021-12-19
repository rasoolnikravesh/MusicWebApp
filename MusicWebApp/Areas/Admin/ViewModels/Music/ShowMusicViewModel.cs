using System;

namespace MusicWebApp.Areas.Admin.ViewModels.Music
{
    public class ShowMusicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SingerName { get; set; }
        public DateTime Date { get; set; }
        public string GenreName { get; set; }
        public string SongWriterName { get; set; }
        public string ComposerName { get; set; }

    }
}

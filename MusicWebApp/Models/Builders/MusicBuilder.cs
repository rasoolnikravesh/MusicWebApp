using System;
using System.Collections.Generic;

namespace MusicWebApp.Models.Builders
{
  public class MusicBuilder
  {
    private int _id = 0;
    private string _name = "";
    private string _title = "";
    private string _text = "";
    private DateTime _date = new DateTime(1970, 1, 1);
    private string _url128 = "";
    private string _url320 = "";
    private Genre _genre = null;
    private List<Subject> _subjects = new List<Subject>();
    private Singer _singer = null;
    private SongWriter _songWriter = null;
    private Composer _composer = null;
    private MixMaster _mixMaster = null;
    private Arrangement _arrangement = null;
    private Album _album = null;

    public Music Build() =>
      new Music
      {
        Id = _id,
        Name = _name,
        Title = _title,
        Text = _text,
        Date = _date,
        Url128 = _url128,
        Url320 = _url320,
        Genre = _genre,
        Subjects = _subjects,
        Singer = _singer,
        SongWriter = _songWriter,
        Composer = _composer,
        MixMaster = _mixMaster,
        Arrangement = _arrangement,
        Album = _album
      };

    public MusicBuilder WithId(int value)
    {
      _id = value;
      return this;
    }

    public MusicBuilder WithName(string value)
    {
      _name = value;
      return this;
    }

    public MusicBuilder WithTitle(string value)
    {
      _title = value;
      return this;
    }

    public MusicBuilder WithText(string value)
    {
      _text = value;
      return this;
    }

    public MusicBuilder WithDate(DateTime value)
    {
      _date = value;
      return this;
    }

    public MusicBuilder WithUrl128(string value)
    {
      _url128 = value;
      return this;
    }

    public MusicBuilder WithUrl320(string value)
    {
      _url320 = value;
      return this;
    }

    

    public MusicBuilder WithGenre(Genre value)
    {
      _genre = value;
      return this;
    }

    public MusicBuilder WithSubjects(List<Subject> value)
    {
      _subjects = value;
      return this;
    }

    public MusicBuilder WithSinger(Singer value)
    {
      _singer = value;
      return this;
    }

    public MusicBuilder WithSongWriter(SongWriter value)
    {
      _songWriter = value;
      return this;
    }

    public MusicBuilder WithComposer(Composer value)
    {
      _composer = value;
      return this;
    }

    public MusicBuilder WithMixMaster(MixMaster value)
    {
      _mixMaster = value;
      return this;
    }

    public MusicBuilder WithArrangement(Arrangement value)
    {
      _arrangement = value;
      return this;
    }

    public MusicBuilder WithAlbum(Album value)
    {
      _album = value;
      return this;
    }
  }
}

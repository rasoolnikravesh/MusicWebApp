using System;
using System.Collections.Generic;

namespace MusicWebApp.Models.Builders
{
  public class AlbumBuilder
  {
    private int _id = 0;
    private string _name = "";
    private byte[] _image = new byte[]{ 0 };
    private List<Subject> _subjects = new List<Subject>();
    private Genre _genre = null;
    //private Group _group = null;
    private Singer _singer = null;
    private DateTime _created = new DateTime(1970, 1, 1);
    private string _fullUrl = "";
    private List<Music> _musics = new List<Music>();
    private string _details = "";

    public Album Build() =>
      new Album
      {
        Id = _id,
        Name = _name,
        Image = _image,
        Subjects = _subjects,
        Genre = _genre,
        //Group = _group,
        Singer = _singer,
        Created = _created,
        FullUrl = _fullUrl,
        Musics = _musics,
        Details = _details
      };

    public AlbumBuilder WithId(int value)
    {
      _id = value;
      return this;
    }

    public AlbumBuilder WithName(string value)
    {
      _name = value;
      return this;
    }

    public AlbumBuilder WithImage(byte[] value)
    {
      _image = value;
      return this;
    }

    public AlbumBuilder WithSubjects(List<Subject> value)
    {
      _subjects = value;
      return this;
    }

    public AlbumBuilder WithGenre(Genre value)
    {
      _genre = value;
      return this;
    }

   
    public AlbumBuilder WithSinger(Singer value)
    {
      _singer = value;
      return this;
    }

    public AlbumBuilder WithCreated(DateTime value)
    {
      _created = value;
      return this;
    }

    public AlbumBuilder WithFullUrl(string value)
    {
      _fullUrl = value;
      return this;
    }

    public AlbumBuilder WithMusics(List<Music> value)
    {
      _musics = value;
      return this;
    }

    public AlbumBuilder WithDetails(string value)
    {
      _details = value;
      return this;
    }
  }
}

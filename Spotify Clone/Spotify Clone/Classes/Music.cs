using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Clone.Classes
{
    internal class Music
    {
         
        private int id;
        private string name;
        
        private int albumId;
        private int playlistId;

        private string path;
        private int likes;
        private List<string> comments = new List<string> ();
        
        public void setId(int musicId)
        {
            id = musicId;
        }   
        public int getId() 
        { 
            return id;
        }
        public void setName(string musicName)
        {
            name = musicName;
        }
      
        public void setAlbumId(int id)
        {
            albumId = id;   
        }
        public int getAlbumId() 
        {
            return albumId;
        }
        public void setPlaylistId(int id)
        {
            playlistId = id;
        }
        public int getPlaylistId()
        {
            return playlistId;
        }
        public void setPath(string p)
        {
            path = p;
        }
        public string getPath()
        {
            return path;    
        }
        public void addLike()
        {
            likes++;
        }
        public void addComment(string comment)
        {
            comments.Add(comment);
        }
        public void addToPlaylist(int musicId, int playlistId)
        {

        }
    }
}


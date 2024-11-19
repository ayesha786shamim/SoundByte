using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Clone.Classes
{
    internal abstract class MusicFile
    {
        private int id;
        private string name;
        private string userId;

        //Music File Id is actually an Album or a playlist Id
        //depending upon which inherited class is using it
        public void setId(int musicFileId)
        {
            id = musicFileId;
        }
        public int getId() 
        {
            return id;
        }

        //Music fileName is actually an Album or a playlist Id
        //depending upon which inherited class is using it
        public void setName(string fileName)
        {
            name = fileName;
        }
        public string getName()
        {
            return name;    
        }

      
        //When the prducer calls the create album method this will set the albums
        //userId attribute with the producers user Id
        public void setUserId(string userIdentity)
        {
            userId = userIdentity;
        }

        //This function simply updates the musics that are in the MusicTable.

        public void updateMusicInMusicTable(int musicId)
        {

        }

        //This function simply deletes the music that are in the musicList.
        public void deleteMusicInMusicTable(int musicId)
        {

        }
        public string getUserId()
        {
            return userId;
        }
    }
}

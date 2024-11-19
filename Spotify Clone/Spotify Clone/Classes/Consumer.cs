using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Clone.Classes
{
    internal class Consumer
    {
        

        //This method will take the userID and the name of the playlist that user want to make. 
        //It then creates the object of Playlist Class and set the parameter values to it's attributes 
        //through its setter and getters.
        public void createPlaylist(string userId, string playlistName)
        {

        }
        public void updatePlayist(int playlistId)
        {

        }
        public void deletePlaylist(int playlistId)
        {

        }

        //using the userID this fucntion will retrieve and display
        //the playlists having the userID of the current user
        //form the plalistTable of sound byte Database
        public void readPlaylists(string userId)
        {

        }

        //This fuction sends the musicPath to the music player to play it
        public void playMusic(string musicPath)
        {

        }

        //This fucntion will take the musicID and then find that music and calls its 
        // addLike method to increment the like count.
        public void likeMusic(int musicId)
        {

        }

        //This fucntion will take the musicID and then find that music and calls its 
        // addComment method to add this new comment.
        public void commentMusic(int musicId)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Clone.Classes
{
    internal class SharedDataSingleton
    {
        private static SharedDataSingleton instance;
        public string SharedData { get; set; }

        private SharedDataSingleton()
        {
            // Private constructor to prevent instantiation outside the class
        }

        public static SharedDataSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedDataSingleton();
                }
                return instance;
            }
        }
    }
}

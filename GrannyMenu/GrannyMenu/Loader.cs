﻿using Photon.Pun;
using System.Collections.Specialized;
using System.Net;
using UnityEngine;

namespace GrannyMenu
{
    public class Loader
    {
        public static void Init()
        {
            Loader.Load = new UnityEngine.GameObject();
            Loader.Load.AddComponent<Hacks>();
            Loader.Load.AddComponent<PlayerTracker>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }

        public static void Unload()
        {
            _Unload();
        }
    
        private static void _Unload()
        {
            GameObject.Destroy(Load);
        }//

        private static GameObject Load;
    }
}

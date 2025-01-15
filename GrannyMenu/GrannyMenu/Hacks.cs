
using Assets.Scripts;
using Assets.Scripts.Network;
using ExitGames.Client.Photon;
using Invector.CharacterController;
using JetBrains.Annotations;
using JustPlay.Explosions;
using JustPlay.PsfLight.Events;
using Lol.OneVsOne.Settings;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;


namespace GrannyMenu
{
    class Hacks : MonoBehaviour
    {
        public static bool Chams, SpamRemoveAllBuildings, GodMode, SpamBullets, SpamDropPick;
        private static PlayerController INSTANCE = PlayerController.JGCPJEAMFIG;
        public static PlayerController LocalPlayerObject;
        public static GameObject[] ARR;
        public static float hue;
        public static int option = 1;
        public static string type = "Destroy";
        public static string ID = "No Track";

        public static void WriteToFile(string info, string t)
        {
            if (t == "D")
            {
                File.WriteAllText("C:\\Users\\Netik\\Desktop\\Dump.txt", info);
            }
            else
            {
                File.WriteAllText("C:\\Users\\Netik\\Desktop\\IdToTrack.txt", info);
            }
        }

        /* Drawing *\
  _____                     _             
 |  __ \                   (_)            
 | |  | |_ __ __ ___      ___ _ __   __ _ 
 | |  | | '__/ _` \ \ /\ / / | '_ \ / _` |
 | |__| | | | (_| |\ V  V /| | | | | (_| |
 |_____/|_|  \__,_| \_/\_/ |_|_| |_|\__, |
                                     __/ |
                                    |___/
        */
       public static void PickUp()
        {
            foreach (Pickupable h2 in UnityEngine.Object.FindObjectsOfType<Pickupable>())
            {
                h2.PickUp(LocalPlayerObject, Pickupable.DHFCDEEJGBB.Auto);
            }
        }

        public static void Drop()
        {
            WeaponsController[] array22 = UnityEngine.Object.FindObjectsOfType<WeaponsController>();
            foreach (WeaponsController h in array22)
            {
                for (int i = 0; i < 50; i++)
                {
                  
                    h.DropWeapon(i, LocalPlayerObject.transform.position);
                }

            }
        }

        public static void God()
        {
            PlayerHealth[] array22 = UnityEngine.Object.FindObjectsOfType<PlayerHealth>();
            foreach (PlayerHealth h in array22)
            {
                PhotonNetwork.Destroy(h.GetComponentInChildren<PlayerHealth>().photonView);
            }
        }

        public static void KickAll(Photon.Realtime.Player pla)
        {
            PartyRoomConnector[] array22 = UnityEngine.Object.FindObjectsOfType<PartyRoomConnector>();
            foreach (PartyRoomConnector h in array22)
            {
                for (int i = 0; i < 50; i++)
                { 
                    h.KickPlayer(pla);
                }
            }
        }
        public static float ya;
        

        private void OnGUI()
        {

          

            if (GUILayout.Button("Test"))
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

                //ZoneCircle.Instance.
            }
            if (GUILayout.Button("Join " + ID))
            {
                Connector.CPBDFOPICLP.EnterParty(ID);
            }
            DrawMenu(Tab);
            if (GUILayout.Button("-> " + Tab, new GUILayoutOption[0]) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Tab += 1;
            }
            if (GUILayout.Button("<- " + Tab, new GUILayoutOption[0]) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Tab -= 1;
            }
        }


        public static void DrawMenu(int pid)
        {
           
                if (pid == 1)
            {
                SpamBullets = GUILayout.Toggle(SpamBullets, "Spammer [F1]", new GUILayoutOption[0]);
                GodMode = GUILayout.Toggle(GodMode, "God [F2]", new GUILayoutOption[0]);
                Chams = GUILayout.Toggle(Chams, "Y a "+ya, new GUILayoutOption[0]);
                SpamRemoveAllBuildings = GUILayout.Toggle(SpamRemoveAllBuildings, "Remove Buildings [F3]", new GUILayoutOption[0]);
                SpamDropPick = GUILayout.Toggle(SpamDropPick, "Bring All Weapons", new GUILayoutOption[0]);
                
            }
            if (pid == 2)
            {
                if (option == 4)
                {
                    PlayerTracker.preDeterminedPlayers[0] = File.ReadAllText("C:\\Users\\Netik\\Desktop\\IdToTrack.txt");
                }
                changedatatypes();
                GUILayout.Label("Lobby: "+ID);
                
                GUILayout.Space(10f);
                if (GUILayout.Button("Act: " + type + option))
                {
                    option += 1;
                    
                    if (option > 4)
                    {
                        option = 1;
                    }
                }
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                {
                    if (GUILayout.Button(player.NickName))
                    {
                        if (option == 1)
                        {
                            PhotonNetwork.DestroyAll();
                        }
                        else if(option == 2)
                        {
                            PhotonNetwork.SetMasterClient(player);
                        }
                        else if(option == 3)
                        {
                            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

                            WriteToFile("Name: " + player.NickName + "\n" + "Custom Properties: " + player.CustomProperties + "\n" + "Fire Base ID: " +player.FirebaseUserId, "D");
                        }
                        else if (option == 4)
                        {
                            PlayerTracker.preDeterminedPlayers[0] = player.UserId;
                            WriteToFile(player.UserId,"asdasd");
                        }

                    }
                }
                 


               
            }
            if (pid == 3)
            {
                if (GUILayout.Button("Plus Me"))
                    foreach (PlayersManager s in UnityEngine.Object.FindObjectsOfType<PlayersManager>())
                    {
                        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                        UnityEngine.Object.Instantiate(GameManager.Instance.gameObject);
                        s.SpawnBot();
                        s.SpawnLocalPlayer();
                    }
            }
        }

        public static void changedatatypes()
        {
            if (option == 1)
            {
                type = "Destroy";
            }
            else if(option == 2)
            {
                type = "SetMaster";
            }
            else if (option == 3)
            {
                type = "Write ID";
            }
            else if (option == 4)
            {
                type = "Track";
            }
        }

        /*
  ______ _   _ _____  
 |  ____| \ | |  __ \ 
 | |__  |  \| | |  | |
 |  __| | . ` | |  | |
 | |____| |\  | |__| |
 |______|_| \_|_____/ 
         */
        private void Update()
        {
            MenuStuff();
        }
        public static int Tab = 1;

        /* Scripts *\
                                             
   _____           _       _       
  / ____|         (_)     | |      
 | (___   ___ _ __ _ _ __ | |_ ___ 
  \___ \ / __| '__| | '_ \| __/ __|
  ____) | (__| |  | | |_) | |_\__ \
 |_____/ \___|_|  |_| .__/ \__|___/
                    | |            
                    |_|    
        ↓
        */
        public static void ESP()
        {
            //PhotonNetwork.GetCustomRoomList()
            Camera camera = Camera.main;    
            foreach (var players in FindObjectsOfType<PlayerController>())
            {
                ya = players.gameObject.transform.position.y;
                bool isLocal = players.IsMine();
                if (isLocal)
                {
                    LocalPlayerObject = players;
                   
                }
                // var isBot = players.EBPEIGIEEIF;

                var rend = players.GetComponents<Renderer>();
                foreach (Renderer renderer in rend)
                {
                    if (!isLocal)
                    {
                        renderer.material.mainTexture = null;
                        renderer.material.shader = Shader.Find("GUI/Text Shader");
                        renderer.material.color = Color.HSVToRGB(hue, 1f, 1f);
                        hue += 0.00001f;
                        bool flag = hue >= 1f;
                        if (flag)
                        {//
                            hue = 0f;
                        }
                        
                    }
                }
            }
        }

        public static void MenuStuff()
        {
            if (SpamDropPick)
            {
                PickUp();
                Drop();
            }
            if (Chams)
                {
                ESP();
                }
                if (SpamRemoveAllBuildings)
                {
                    PlayerBuildingManager.IsOneHitBuildings = true;
                    BuildingNetworkController.Instance.KillAllBuildings(true);
                }
                if (GodMode)
                {

                    UnityEngine.Object.Destroy(LocalPlayerObject.GetComponentInChildren<PlayerHealth>());

                }


            
            if (SpamBullets)
            {
                bool key5 = Input.GetKey(KeyCode.Mouse0);
                if (key5)
                {
                    HitscanWeaponModel[] array = UnityEngine.Object.FindObjectsOfType<HitscanWeaponModel>();
                    foreach (HitscanWeaponModel hitscanWeaponModel in array)
                    {
                        hitscanWeaponModel.AddAmmo(10000);
                        hitscanWeaponModel.AddMagazine(10000);
                        hitscanWeaponModel.Fire(default, default, default, true, default);

                    }
                }
            }
        }
        /*
______ _   _ _____  
|  ____| \ | |  __ \ 
| |__  |  \| | |  | |
|  __| | . ` | |  | |
| |____| |\  | |__| |
|______|_| \_|_____/ 
      */
    }
}
    





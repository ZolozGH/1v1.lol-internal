using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

namespace GrannyMenu
{
    internal class PlayerTracker : MonoBehaviourPunCallbacks
    {
        // Token: 0x06000014 RID: 20 RVA: 0x00002B38 File Offset: 0x00000D38
        public void Start()
        {
            PlayerTracker.TrackerTimer = new Timer();
            PlayerTracker.TrackerTimer.Elapsed += PlayerTracker.CheckTrackedPlayer;
            PlayerTracker.TrackerTimer.Interval = 1500.0;
            PlayerTracker.TrackerTimer.Enabled = true;
        }

        // Token: 0x06000015 RID: 21 RVA: 0x00002B88 File Offset: 0x00000D88
        public static void CheckTrackedPlayer(object source, ElapsedEventArgs e)
        {
            bool inRoom = PhotonNetwork.InRoom;
            bool flag = inRoom;
            if (flag)
            {
                PhotonNetwork.FindFriends(PlayerTracker.preDeterminedPlayers);
            }
            else
            {
                PhotonNetwork.FindFriends(PlayerTracker.preDeterminedPlayers);
            }
        }

        // Token: 0x06000016 RID: 22 RVA: 0x00002BBD File Offset: 0x00000DBD
        public static void TrackPlayer(string[] players)
        {
            PlayerTracker.OnGUIEnabled = true;
            PhotonNetwork.FindFriends(players);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x00002BD0 File Offset: 0x00000DD0
        public string CheckRoom(string Room)
        {
            bool flag = Room == "";
            bool flag2 = flag;
            string result;
            if (flag2)
            {
                result = "<color=grey>NONE</color>";
            }
            else
            {
                result = Room;
            }
            return result;
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00002C11 File Offset: 0x00000E11
        public void ReplaceTextForTrackedPlayer(string codeToReplace)
        {
            Hacks.ID = this.CheckRoom(codeToReplace);
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002C2C File Offset: 0x00000E2C
        public override void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            base.OnFriendListUpdate(friendList);
            foreach (FriendInfo friendInfo in friendList)
            {
                string userId = friendInfo.UserId;
                this.ReplaceTextForTrackedPlayer(friendInfo.Room);
            }
        }

        // Token: 0x0400000F RID: 15
        public static Timer TrackerTimer;

        // Token: 0x04000010 RID: 16
        public static bool OnGUIEnabled = false;

        // Token: 0x04000011 RID: 17
        public static GameObject thing;

        // Token: 0x04000012 RID: 18
        public static string[] preDeterminedPlayers = new string[1];
    }
}

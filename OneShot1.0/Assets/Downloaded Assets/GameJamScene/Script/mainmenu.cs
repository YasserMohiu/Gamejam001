using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;


namespace PhotonTutorial.Menus
{
    public class mainmenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject findOpponetPanel = null;
        [SerializeField] private GameObject waitingStatusPanel = null;
        [SerializeField] private TextMeshProUGUI waitingStatusText = null;

        private bool isConnecting = false;

        private const string GameVersion = ".01";
        private const int MaxPlayersPerRoom = 1;

        private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

        public void FindOpponet()
        {
            isConnecting = true;

            findOpponetPanel.SetActive(false);
            waitingStatusPanel.SetActive(true);

            waitingStatusText.text = "Searching . . .";

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected To Master");

            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            waitingStatusPanel.SetActive(false);
            findOpponetPanel.SetActive(true);

            Debug.Log($"Disconnected due to: {cause}");
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("No clients are waiting for an opponent, creating a new room");

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Client successfully joined a room");

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

            if (playerCount != MaxPlayersPerRoom)
            {
                waitingStatusText.text = "Waiting For Opponent";
                Debug.Log("Client is waiting for an opponent");
            }
            else
            {
                waitingStatusText.text = "Opponent Found";
                Debug.Log("Match is ready to begin");
            }
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom) ;
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                waitingStatusText.text = "Opponent Found";
                Debug.Log("Match is ready to begin");

                PhotonNetwork.LoadLevel("Scene_Main");
            }
        }

    }
}

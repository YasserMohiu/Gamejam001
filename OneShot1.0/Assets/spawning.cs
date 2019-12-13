using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial
{
    public class spawning : MonoBehaviour
    {
        [SerializeField] private GameObject playerprefab = null;
        // Start is called before the first frame update
        private void Start()
        {
            PhotonNetwork.Instantiate(playerprefab.name, Vector3.zero, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
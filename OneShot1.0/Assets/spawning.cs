using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial
{
	public class spawning : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab = null;
		// Start is called before the first frame update
		private void Start()
		{
			PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
		}
	}
}

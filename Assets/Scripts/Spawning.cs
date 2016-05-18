using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

		public GameObject Orb;

    // Use this for initialization
    void Start () {
				// Orb =
				for(int x = 0; x < 5; x++){
					Vector3 pos;
					float xBound = Random.Range(-350.0F, 110.0F);
					float zBound = Random.Range(-110.0F, 350.0F);

					pos.x = xBound;
					pos.y = 5.0F;
					pos.z = zBound;
					Instantiate(Orb, pos, Quaternion.identity);
				}
    }

    // Update is called once per frame
    void Update () {

		}
}

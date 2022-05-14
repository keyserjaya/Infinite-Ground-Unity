using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour {

    ///Deactiavate ground yg tidak terlihat > pindahkan posisi-nya > activate lagi
    
    [Tooltip("Pivot for the ground to follow")] 
    public Transform target;

    [SerializeField] Transform groundPrefab;

    [SerializeField, Tooltip("Ground size in world scale")] 
    Vector3 groundSize = new Vector3(1f, 0f, 1f);


    readonly List<Transform> spawnedGround = new List<Transform>();

    Vector3 groundOffset;
    Vector3 groundSizeHalf;
    Vector3 newGroundTrigger;

    private void Awake()
    {
        groundOffset = groundSize * 3f;
        groundSizeHalf = groundSize * 0.5f;
        newGroundTrigger = groundSize + groundSizeHalf;

        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                SpawnGround(new Vector3(i * groundSize.x, 0, j * groundSize.z));
            }
        }

        void SpawnGround(Vector3 pos) {
            Transform obj = Instantiate(groundPrefab, transform);
            obj.transform.position = pos;
            spawnedGround.Add(obj);
        }
    }

    private void Update() {
        FixOutsideRange();
    }

    void FixOutsideRange() {
        for (int i = 0; i < spawnedGround.Count; i++) {
            Vector3 groundPos = spawnedGround[i].position;
            Vector3 mag = target.position - groundPos;
            if (mag.x < -newGroundTrigger.x) 
            {
                groundPos.x -= groundOffset.x;
            } 
            else if (mag.x > newGroundTrigger.x) 
            {
                groundPos.x += groundOffset.x;
            }

            if (mag.z < -newGroundTrigger.z)
            {
                groundPos.z -= groundOffset.z;
            }
            else if (mag.z > newGroundTrigger.z)
            {
                groundPos.z += groundOffset.z;
            }

            spawnedGround[i].transform.position = groundPos;
        }
    }
}

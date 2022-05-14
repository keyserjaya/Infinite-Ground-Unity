using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniteGroundExample {
    public class SimplePlayerMove : MonoBehaviour
    {
        [SerializeField] float speed = 5f;

        void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime * speed;
        }
    }
}
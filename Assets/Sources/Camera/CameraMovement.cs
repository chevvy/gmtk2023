using System;
using UnityEngine;

namespace Sources.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform player;

        private void Update()
        {
            transform.position = player.position;
        }
    }
}
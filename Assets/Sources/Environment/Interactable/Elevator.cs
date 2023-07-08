using System;
using UnityEditor.Build;
using UnityEngine;

namespace Sources.Environment.Interactable
{
    public class Elevator : MonoBehaviour
    {
        public GameObject elevator;
        
        // TODO (Alix) Get this working with anchors FML
        // public GameObject anchorUp;
        // public GameObject anchorDown;

        public Vector3 upPosition;
        public Vector3 downPosition;

        public float elevatorSpeed = 10f;
        
        private Vector3 _elevatorDestination;
        private bool _goingUp = true;
        private bool _initialContact;

        private void Awake()
        {
            Debug.Assert(null != elevator);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            _initialContact = true;

            other.transform.parent = transform;

            if (_elevatorDestination == upPosition || _elevatorDestination == downPosition)
                _goingUp = !_goingUp;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            other.transform.parent = null;
        }

        private void FixedUpdate()
        {
            if (!_initialContact) return;
            
            _elevatorDestination = _goingUp ? upPosition : downPosition;
            
            transform.position = Vector3.MoveTowards(transform.position, _elevatorDestination, elevatorSpeed * Time.deltaTime);
        }
    }
}
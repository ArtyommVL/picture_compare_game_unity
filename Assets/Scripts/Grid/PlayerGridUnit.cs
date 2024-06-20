using System;
using UnityEngine;

namespace Grid
{
    public class PlayerGridUnit : MonoBehaviour
    {
        private bool _isTriggerOn;
        
        public bool IsTriggerOn { get => _isTriggerOn; set => _isTriggerOn = value; }
        
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<CubeUnit>(out CubeUnit cubeUnit))
            {
                if (_isTriggerOn)
                {
                    Debug.Log("Right");
                }
            }
        }
    }
}
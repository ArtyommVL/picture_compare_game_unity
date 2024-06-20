using UnityEngine;

namespace Grid
{
    public class PlayerGridUnit : MonoBehaviour
    {
        private bool _isTriggerStay = false;
        private bool _isTriggerOn;

        public bool IsTriggerStay
        {
            get => _isTriggerStay;
            set => _isTriggerStay = value;
        }
        
        public bool IsTriggerOn
        {
            get => _isTriggerOn; 
            set => _isTriggerOn = value;
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<CubeUnit>(out CubeUnit cubeUnit))
            {
                if (_isTriggerOn && !cubeUnit.IsSelected)
                {
                    _isTriggerStay = true;
                    cubeUnit.SetColor(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<CubeUnit>(out CubeUnit cubeUnit))
            {
                if (_isTriggerOn)
                {
                    _isTriggerStay = false;
                    cubeUnit.SetColor(false);
                }
            }
        }
    }
}
using UnityEngine;

namespace Grid
{
    public class CubeUnit : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color activeColor = Color.green;
        [SerializeField] private Color noneActiveColor = Color.cyan;
        [SerializeField] private Color selectedColor = Color.red;

        private bool _isSelected = false;

        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }
        
        public void MoveWith(Transform parent)
        {
            if (_isSelected)
            {
                var newPosition = new Vector3(
                    parent.position.x, 
                    transform.position.y, 
                    parent.position.z + 1f);

                transform.position = newPosition;
            }
        }

        public void SetColor(bool isCollider)
        {
            if (!_isSelected)
            {
                meshRenderer.material.color = isCollider
                    ? activeColor
                    : noneActiveColor; 
            }
        }

        public void SetSelectedColor(bool isSelected)
        {
            meshRenderer.material.color = isSelected
                ? selectedColor
                : noneActiveColor;
        }
    }
}
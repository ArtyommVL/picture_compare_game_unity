using UnityEngine;

namespace Grid
{
    public class CubeUnit : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color activeColor = Color.green;
        [SerializeField] private Color noneActiveColor = Color.cyan;

        public void SetColor(bool isCollider)
        {
            meshRenderer.material.color = isCollider 
                ? activeColor 
                : noneActiveColor;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridGenerator : MonoBehaviour
    {
        [SerializeField] private uint widthX = 3;
        [SerializeField] private uint widthZ = 3;

        private readonly Dictionary<Vector3, bool> _blocks = new ();
        
        private void Awake()
        {
            _blocks.Clear();
            
            for (int i = 0; i < widthX; i++)
            {
                for (int j = 0; j < widthZ; j++)
                {
                    float positionX = i;
                    float positionZ = j;

                    bool isActive = Random.Range(0, 2) == 1;
                    _blocks.Add(new Vector3(positionX,0.1f,positionZ),isActive);
                }
            }
        }

        public Dictionary<Vector3, bool> UpdatePositionsForParent(Transform parent)
        {
            var cache = new Dictionary<Vector3, bool>();

            foreach (var block in _blocks)
            {
                var key = block.Key + parent.position;
                cache.Add(key, block.Value);
            }

            return cache;
        }
    }
}
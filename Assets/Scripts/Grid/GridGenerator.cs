using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Grid
{
    public class GridGenerator : MonoBehaviour
    {
        public event EventHandler GridUpdated; 
        
        [SerializeField] private uint widthX = 3;
        [SerializeField] private uint widthZ = 3;

        private readonly Dictionary<Vector3, bool> _blocks = new();

        private int _activeBlockCount;

        public int ActiveBlocksCount
        {
            get => _activeBlockCount;
            set => _activeBlockCount = value;
        }

        private void Start()
        {
            GenerateGrid();
        }

        [ContextMenu("Generate")]
        private void GenerateGrid()
        { 
            _blocks.Clear();
            _activeBlockCount = 0;
            
            for (int i = 0; i < widthX; i++)
            {
                for (int j = 0; j < widthZ; j++)
                {
                    float positionX = i;
                    float positionZ = j;

                    bool isActive = Random.Range(0, 2) == 1;
                    _blocks.Add(new Vector3(positionX, 0.1f, positionZ), isActive);
                    if (isActive)
                    {
                        _activeBlockCount += 1;
                    }
                }
            }
            GridUpdated?.Invoke(this,null);
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
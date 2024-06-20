using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Grid
{
    public class StorageGridGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> storageGrid;
        
        private void OnEnable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;    
        }
        
        private void OnGridUpdated(object sender, EventArgs e)
        {
            for (int i = 0; i < storageGrid.Count; i++)
            {
                storageGrid[i].SetActive(false);
                if (storageGrid[i].TryGetComponent<CubeUnit>(out var cubeUnit))
                {
                    cubeUnit.IsSelected = false;
                    cubeUnit.SetColor(false);
                }
            }
            
            for (int i = 0; i < gridGenerator.ActiveBlocksCount; i++)
            {
                storageGrid[i].SetActive(true);
                storageGrid[i].transform.position = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Key;
                
            }
        }
        
        private void OnDisable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;    
        }
    }
}
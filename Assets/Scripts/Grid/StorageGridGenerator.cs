using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class StorageGridGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
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
            }
            
            for (int i = 0; i < gridGenerator.ActiveBlocksCount; i++)
            {
                storageGrid[i].SetActive(true);
            }
        }
        
        private void OnDisable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;    
        }
    }
}
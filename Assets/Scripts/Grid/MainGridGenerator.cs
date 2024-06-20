using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Grid
{
    public class MainGridGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> gridUnit;

        private void OnEnable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;
        }

        private void OnGridUpdated(object sender, EventArgs senderEventArgs)
        {
            for (int i = 0; i < gridUnit.Count; i++)
            {
                var isActive = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Value;
                gridUnit[i].SetActive(isActive);
            }
        }

        private void OnDisable()
        {
            gridGenerator.GridUpdated -= OnGridUpdated;
        }
    }
}
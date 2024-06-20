using System;
using UnityEngine;

namespace Grid
{
    public class GridRestarter : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;

        private void OnEnable()
        {
            PlayerGridGenerator.GameCompleted += OnGameCompleted;
        }

        private void OnGameCompleted(object sender, bool isCompleted)
        {
            if (isCompleted)
            {
                gridGenerator.GenerateGrid();
            }
        }

        private void OnDisable()
        {
            PlayerGridGenerator.GameCompleted -= OnGameCompleted;
        }
    }
}
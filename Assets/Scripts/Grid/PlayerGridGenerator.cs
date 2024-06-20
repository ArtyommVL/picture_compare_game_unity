using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Grid
{
    public class PlayerGridGenerator : MonoBehaviour
    {
        public static event EventHandler<bool> GameCompleted;

        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> gridPatternUnit;

        private readonly List<PlayerGridUnit> _completedUnits = new List<PlayerGridUnit>();
        
        private void OnEnable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;    
        }
        
        private void Update()
        {
            GameCompleted?.Invoke(this, CompareAllUnits());
        }

        private void OnDisable()
        {
            gridGenerator.GridUpdated -= OnGridUpdated;
        }

        private void OnGridUpdated(object sender, EventArgs e)
        {
            for (int i = 0; i < gridPatternUnit.Count; i++)
            {
                var isActive = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Value;

                if (gridPatternUnit[i].TryGetComponent<PlayerGridUnit>(out var patternUnit))
                {
                    patternUnit.IsTriggerOn = isActive;
                    _completedUnits.Add(patternUnit);
                }
            }
        }

        private bool CompareAllUnits()
        {
            return _completedUnits.All(unit
                => unit.IsTriggerStay
                   || !unit.IsTriggerOn);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Grid
{
    public class PlayerGridGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> gridPatternUnit;

        private List<PlayerGridUnit> _completedUnits = new List<PlayerGridUnit>();
        
        private void Start()
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

        private void Update()
        {
            if (CompareAllUnits())
            {
                Debug.Log("GAME COMPLETE");
            }
            else
            {
                Debug.Log("PLAY");
            }
        }

        private bool CompareAllUnits()
        {
            foreach (var unit in _completedUnits)
            {
                if (!unit.IsTriggerStay && unit.IsTriggerOn)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
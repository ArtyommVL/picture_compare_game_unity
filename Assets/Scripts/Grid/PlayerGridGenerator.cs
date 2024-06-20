using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Grid
{
    public class PlayerGridGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> gridPatternUnit;
        
        private void Start()
        {
            for (int i = 0; i < gridPatternUnit.Count; i++)
            {
                var isActive = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Value;

                if (gridPatternUnit[i].TryGetComponent<PlayerGridUnit>(out var patternUnit))
                {
                    patternUnit.IsTriggerOn = isActive;
                }
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    [CreateAssetMenu(fileName = "GridSettings", menuName = "ScriptableObjects/GridSettings", order = 1)]
    public class GridSettings : ScriptableObject
    {
        [SerializeField] private List<GameObject> row;
        [SerializeField] private int column;

        public List<GameObject> Row => row;
        public int Column => column;
    }
}
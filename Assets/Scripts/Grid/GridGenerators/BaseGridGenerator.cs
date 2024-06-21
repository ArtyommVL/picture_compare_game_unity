using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid.GridGenerators
{
    public abstract class BaseGridGenerator : MonoBehaviour
    {
        [SerializeField] protected GridGenerator gridGenerator;
        [SerializeField] protected Transform parent;
        [SerializeField] protected List<GameObject> gridUnits;

        protected virtual void OnEnable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;
        }

        protected virtual void OnGridUpdated(object sender, EventArgs gridEventArgs)
        {
            
        }

        protected void OnDisable()
        {
            gridGenerator.GridUpdated += OnGridUpdated;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grid.GridGenerators
{
    public class PlayerGridGenerator : BaseGridGenerator
    {
        public static event EventHandler<bool> GameCompleted;
        
        private readonly List<PlayerGridUnit> _completedUnits = new List<PlayerGridUnit>();
        
        private void Update()
        {
            GameCompleted?.Invoke(this, CompareAllUnits());
        }

        protected override void OnGridUpdated(object sender, EventArgs e)
        {
            for (int i = 0; i < gridUnits.Count; i++)
            {
                var isActive = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Value;

                if (gridUnits[i].TryGetComponent<PlayerGridUnit>(out var patternUnit))
                {
                    patternUnit.IsTriggerOn = isActive;
                    _completedUnits.Add(patternUnit);
                }
            }
        }

        private bool CompareAllUnits() =>
            _completedUnits.All(unit
                => unit.IsTriggerStay
                   || !unit.IsTriggerOn);
    }
}
using System;
using System.Linq;

namespace Grid.GridGenerators
{
    public class MainGridGenerator : BaseGridGenerator
    {
        protected override void OnGridUpdated(object sender, EventArgs senderEventArgs)
        {
            for (int i = 0; i < gridUnits.Count; i++)
            {
                var isActive = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Value;
                gridUnits[i].SetActive(isActive);
            }
        }
    }
}
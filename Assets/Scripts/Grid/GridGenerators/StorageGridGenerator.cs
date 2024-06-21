using System;
using System.Linq;

namespace Grid.GridGenerators
{
    public class StorageGridGenerator : BaseGridGenerator
    {
        protected override void OnGridUpdated(object sender, EventArgs e)
        {
            for (int i = 0; i < gridUnits.Count; i++)
            {
                gridUnits[i].SetActive(false);
                if (gridUnits[i].TryGetComponent<CubeUnit>(out var cubeUnit))
                {
                    cubeUnit.IsSelected = false;
                    cubeUnit.SetColor(false);
                }
            }
            
            for (int i = 0; i < gridGenerator.ActiveBlocksCount; i++)
            {
                gridUnits[i].SetActive(true);
                gridUnits[i].transform.position = gridGenerator.UpdatePositionsForParent(parent).ElementAt(i).Key;
            }
        }
    }
}
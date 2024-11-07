using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;

    private void DisableUI()
    {
        this.gameObject.SetActive(false);
    }
    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.GreenTank);
        DisableUI();
    }

    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.BlueTank);
        DisableUI();
    }

    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RedTank);
        DisableUI();
    }
}

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
        tankSpawner.CreateTank(TankTypes.GreenTank, OwnerTypes.Player);
        DisableUI();
    }

    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.BlueTank, OwnerTypes.Player);
        DisableUI();
    }

    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RedTank, OwnerTypes.Player);
        DisableUI();
    }
}

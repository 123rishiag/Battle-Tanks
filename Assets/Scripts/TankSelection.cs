using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpawner tankSpawner;
    public GameManager gameManager;

    private void DisableUI()
    {
        this.gameObject.SetActive(false);
    }
    public void GreenTankSelected()
    {
        gameManager.SetTankController(tankSpawner.CreateTank(TankTypes.GreenTank, OwnerTypes.Player));
        DisableUI();
    }

    public void BlueTankSelected()
    {
        gameManager.SetTankController(tankSpawner.CreateTank(TankTypes.BlueTank, OwnerTypes.Player));
        DisableUI();
    }

    public void RedTankSelected()
    {
        gameManager.SetTankController(tankSpawner.CreateTank(TankTypes.RedTank, OwnerTypes.Player));
        DisableUI();
    }
}

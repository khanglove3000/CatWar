using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCat : MonoBehaviour
{
    public Transform SwordCatPrefab;
    public Transform DualSwordCatPrefab;
    public Transform GreateSwordCatPrefab;
    public Transform spawnPoint;
    public void SelectSwordCat()
    {
        Instantiate(SwordCatPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SelectDualSwordCat()
    {
        Instantiate(DualSwordCatPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public void SelectGreateSwordCat()
    {
        Instantiate(GreateSwordCatPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}

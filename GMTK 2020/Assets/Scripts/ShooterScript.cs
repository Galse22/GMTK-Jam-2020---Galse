using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float CooldownBtwFire;

    public float baseCooldownTime;

    public GameObject bulletUp;

    public Transform ShootingThingPos;

    void Update()
    {
        if (CooldownBtwFire < 0)
        {
            Instantiate(bulletUp, ShootingThingPos.position, Quaternion.identity);
            CooldownBtwFire = baseCooldownTime;
        }

        if (CooldownBtwFire >= 0)
        {
            CooldownBtwFire -= Time.deltaTime;
        }
    }
}

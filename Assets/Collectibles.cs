using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public bool isCoins, isSpeedUp;
    public float speedMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl pc = other.GetComponent<PlayerControl>();

            if (isCoins)
            {
                pc.score++;
                Destroy(gameObject);
            }
            if (isSpeedUp)
            {
                pc.newMoveSpeed *= speedMultiplier;
                pc.startTime = true;
                Destroy(gameObject);
            }
        }
    }
}

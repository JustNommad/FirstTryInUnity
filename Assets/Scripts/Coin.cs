using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.AddCoins();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("Coin->player is null!");
            }
            
        }
    }
}

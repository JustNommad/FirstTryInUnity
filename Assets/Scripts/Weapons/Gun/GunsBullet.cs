using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class GunsBullet : MonoBehaviour
{
    [SerializeField]
    private int _damageGunsBullet = 30;
    [SerializeField]
    private int _splashDamageGunsBullet = 15;
    [SerializeField]
    private int _chargesInOneClip = 30;
    [SerializeField]
    private int _maxChargesInOneClip = 30;
    [SerializeField]
    private int _chargesInBag = 120;
    [SerializeField]
    private int _maxChargesInBag = 120;
    void Start()
    {
        // уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
        Destroy(gameObject, 8);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (!coll.isTrigger) // чтобы пуля не реагировала на триггер
        {
            switch (coll.tag)
            {
                case "Player":
                    {
                        Player player = GameObject.Find("Player").GetComponent<Player>();
                        player.TakingDamage();
                        Destroy(this.gameObject);
                        break;
                    }
                case "Enemy":
                    {
                        Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
                        enemy.EnemysDamage();
                        Destroy(this.gameObject);
                        break;
                    }
            }

            Destroy(gameObject);
        }
    }
}
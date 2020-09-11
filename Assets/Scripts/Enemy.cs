using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemyLive = 100;
    [SerializeField]
    private float _enemyArmor = 100;

    private Player _player;
    private PlasmaRifle _weapon;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.Log("Enemy_script: _player is null!");
        }
    }

    void Update()
    {
        if(_enemyLive < 1)
        {
            Destroy(this.gameObject);
        }
        if(_enemyArmor < 1)
        {
            _enemyArmor = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            EnemysDamage();
        }
    }
    public void EnemysDamage()
    {        
        _enemyLive -= 30 - (_enemyArmor / 5);
        _enemyArmor -= 30;
    }
}

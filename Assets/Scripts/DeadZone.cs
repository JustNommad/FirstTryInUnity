using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;                                               //обьект точки респавна
    private void OnTriggerEnter(Collider other)                                     //функция срабатывания триггера
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();                           //если это Player, то создаем объект класса Player и помещаем в него ссылку

            if(player != null)
            {
                player.Damage();                                                    //если добавление компонента успешно, то наносим игроку урон
            }

            CharacterController cc = other.GetComponent<CharacterController>();     //создаем объект класса для оправлением состояния объекта в Unity
            if(cc != null)
            {
                cc.enabled = false;                                                 //замораживаем обьект
            }

            other.transform.position = _respawnPoint.transform.position;            //меняем нынешнюю позицию игрока на позициб объекта спавна
            StartCoroutine(CCEnableRoutine(cc));                                    //запуск таймера
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)                     //функция таймера ожидания 0.1 секунды, после чего объект размораживается
    {
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;
    }
}

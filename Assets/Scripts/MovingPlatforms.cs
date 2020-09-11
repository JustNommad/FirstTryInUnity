using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;               //объекты хранящие информацию о положении обьекта в пространстве, нужны для задания направление перемещения платформы
    private float _speed = 15.0f;                       //скорость перемещения платформы
    private bool _switching = false;                    //выбор направления движения платформы

    void FixedUpdate()                                  
    {
        if(_switching == false)                                                                                             //движение влево
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, Time.deltaTime * _speed);       //перемещения платформы от точки до точки
            if(transform.position == _targetB.position)                                                                     //если объект прибыл в точку 
            {
                _switching = true;                                                                                          //... поменять направление
            }
        }
        else if(_switching == true)                                                                                         //движение вправо
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, Time.deltaTime * _speed);
            if(transform.position == _targetA.position)
            {
                _switching = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)                                                                  //работа триггера 
    {
        if(other.tag == "Player")                                                                               //если на платформе игрок, ...
        {
            other.transform.parent = this.transform;                                                            //... то сделать объект игрока дочерним
        }
    }
    public void OnTriggerExit(Collider other)                                                                   //если объект вышел из зоны триггера
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;                                                                      //Player перестает быть дочерним обьектом
        }
    }
}

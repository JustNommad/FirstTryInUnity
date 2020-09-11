using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private WeaponManager _weaponManager;
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 10.0f;                               //переменная скорости перемещения игрока
    [SerializeField]
    private float _gravity = 1.0f;                              //сила гравитации, по умолчанию 1, в интерфейсе юнити можно задать любое значение
    [SerializeField]
    private float _jumpHight = 15.0f;                           //высота прыжка
    private float _speedPowerUp = 1.0f;                         //переменная скорости бонуса скорости
    private float _yVelocity;                                   //кэш высоты прыжка игрока, с которой будут проводиться операции вычитания 
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins = 0;                                     //переменная накопления собранных предметов
    private UIManager _uiManager;                               //обьект интерфейса
    [SerializeField]
    private int _lives = 100;                                     //здоровье игрока
    [SerializeField]
    private int _armor = 100;
    void Start()
    {
        _controller = GetComponent<CharacterController>();      //помещение содержимого компанента игрока с объект 
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();       //помещение в обьект _uiManager ссылки на компонент Canvas в котором хранится объект Текста

        if(_uiManager == null)                                                  //проверка на правильность выполнения операции по добавлению ссылки компонента
        {
            Debug.LogError("Player_script Error! _uiManager is null");
        }

        _weaponManager = GetComponent<WeaponManager>();
         
        if(_weaponManager == null)
        {
            Debug.Log("Player_script Error! _weaponManager is null!");
        }

        _uiManager.UpdateCoinDisplay(_coins);                                   //вызов функции из UIManager для обновления информации интерфейса
        _uiManager.UpdateLivesDisplay(_lives);
        _uiManager.UpdateArmorDisplay(_lives);
    }
    void Update()
    {
        PlayerStatus();
        MovingPlayer();
        WeaponChoise();
    }
    public void MovingPlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");        //переменная регистрации нажатия клавишь горизонтального перемещения

        Vector3 diraction = new Vector3(horizontalInput, 0, 0);     //переменная перемещения игрока в пространстве, перемещение осуществляется по оси Х
        Vector3 velocity = diraction * _speed * _speedPowerUp;      //переменная скорости перемещения персонажа с учетом бонуса к скорости

        if (_controller.isGrounded == true)                          //находится ли игрок на земле
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHight;                            //запись высоты прыжка в переменную
                _canDoubleJump = true;                              //игрок может совершить двойной прыжок
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)          //проверка нажатии клавиши и на возможность двойного прыжка
            {
                _yVelocity += _jumpHight;                                       //дополнительное увеличение высоты прыжка
                _canDoubleJump = false;                                         //отключение двойного прыжка
            }
            _yVelocity -= _gravity;                                 //если нет, то уменьшаем кэш высоты прыжка игрока по оси Y на величину переменной _gravity
        }

        velocity.y = _yVelocity;                                    //записываем положение игрока по Y 
        _controller.Move(velocity * Time.deltaTime);                //функция перемещения игрока искходя из его скорости с учетом реального времени,
                                                                    //чтобы игрок не перемещался со скоростю света
    }
    public void AddCoins()                                                  // функция добавления предметов и обновление информации на интерфейсе
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
    public void Damage()                                                        //функция нанесения уровна игроку, обновление интерфейса и ...
    {                                                                           //... и загрузка сцены если здоровье закончилось
        _uiManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void TakingDamage()
    {
        if (_armor != 0)
        {
            _lives -= 30 - (_armor / 5);
            _armor -= 30;
        }
        else
        {
            _lives -= 30;
        }
        _uiManager.UpdateLivesDisplay(_lives);
        _uiManager.UpdateArmorDisplay(_armor);
    }
    private void PlayerStatus()
    {
        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
            Destroy(this.gameObject);
        }
        if (_armor < 1)
        {
            _uiManager.UpdateArmorDisplay(_armor);
            _armor = 0;
        }
    }
    public void WeaponChoise()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(Input.GetKeyDown(KeyCode.Alpha1).ToString());
            _weaponManager.TakeAGun();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponManager.TakeAAutoRifle();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _weaponManager.TakeAPlasmaRifle();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            _weaponManager.TakeAShootGun();
        }
    }
}

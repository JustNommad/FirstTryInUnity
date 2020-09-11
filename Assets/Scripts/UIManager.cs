using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;                                 //объект Text хранящий ссылку на объект текста на интерфейсе
    [SerializeField]
    private Text _livesText;
    [SerializeField]
    private Text _armorText;
    [SerializeField]
    private Text _ammoText;
    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = "Coins: " + coins.ToString();      //редактирование текста интерфейса
    }
    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
    public void UpdateArmorDisplay(int armor)
    {
        _armorText.text = "Armor: " + armor.ToString();
    }
    public void UpdateAmmoDisplay(int ammo)
    {
        _ammoText.text = "  0/0";
    }
}

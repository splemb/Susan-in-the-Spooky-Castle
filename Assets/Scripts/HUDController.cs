using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private GameObject player;

    //public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI magicText;

    public Image[] spellSlots;
    public Sprite[] spellIcons;

    public Image[] heartSlots;

    public Sprite heartIcon;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        string NameOfSpell = "";

        //healthText.text = "Health: " + player.GetComponent<PlayerController>().health.ToString();

        foreach (Image i in heartSlots) i.enabled = false;
        for (int i = 0; i < player.GetComponent<PlayerController>().health; i++) heartSlots[i].enabled = true;

        for (int i = 0; i < player.GetComponent<ShootProjectile>().spells.Count; i++)
        {
            switch (player.GetComponent<ShootProjectile>().spells[i].tag)
            {
                case "Magic/Force":
                    spellSlots[i].sprite = spellIcons[0];
                    spellSlots[i].transform.localScale = Vector3.one * 0.5f;
                    spellSlots[i].color = new Color(255, 255, 255, 255);
                    break;
                case "Magic/Light":
                    spellSlots[i].sprite = spellIcons[1];
                    spellSlots[i].transform.localScale = Vector3.one * 0.5f;
                    spellSlots[i].color = new Color(255, 255, 255, 255);
                    break;
                case "Magic/Gravity":
                    spellSlots[i].sprite = spellIcons[2];
                    spellSlots[i].transform.localScale = Vector3.one * 0.5f;
                    spellSlots[i].color = new Color(255, 255, 255, 255);
                    break;
                case "Magic/Teleport":
                    spellSlots[i].sprite = spellIcons[3];
                    spellSlots[i].transform.localScale = Vector3.one * 0.5f;
                    spellSlots[i].color = new Color(255, 255, 255, 255);
                    break;
            }
        }

        switch (player.GetComponent<ShootProjectile>().spells[player.GetComponent<ShootProjectile>().currentSpell].tag)
        {
            case "Magic/Force":
                NameOfSpell = "Force";
                break;
            case "Magic/Light":
                NameOfSpell = "Light";
                break;
            case "Magic/Gravity":
                NameOfSpell = "Gravity";
                break;
            case "Magic/Teleport":
                NameOfSpell = "Teleport";
                break;
        }

        spellSlots[player.GetComponent<ShootProjectile>().currentSpell].transform.localScale = Vector3.one;

        magicText.text = NameOfSpell;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public SpriteRenderer WeaponSprite;
    public List<Sprite> WeapSprites;
    public List<GameObject> Weapons,Colliders;

    private PlayerMovement _pm;
    private WeaponStat _WS;
    private int index;

    private Controls inputs;

    void Awake()
    {
        inputs = new Controls();
        inputs.Player.SwitchLeft.started+= context => SwitchLeft();
        inputs.Player.SwichRight.started += context => SwitchRight();
    }

        // Start is called before the first frame update
    void Start()
    {
        _pm = FindObjectOfType<PlayerMovement>();
        _WS = FindObjectOfType<WeaponStat>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSprite.sprite = WeapSprites[index];
    }

    void SwitchLeft()
    {
        Weapons[index].SetActive(false);
        Colliders[index].SetActive(false);
        index -= 1;
        if(index<0)
        {
            index = Weapons.Count - 1;
        }
        Weapons[index].SetActive(true);
        Colliders[index].SetActive(true);
    }

    void SwitchRight()
    {
        Weapons[index].SetActive(false);
        Colliders[index].SetActive(false);
        index += 1;
        if (index > Weapons.Count - 1)
        {
            index = 0;
        }
        Weapons[index].SetActive(true);
        Colliders[index].SetActive(true);
    }


    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}

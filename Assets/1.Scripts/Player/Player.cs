using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public struct PlayerData
{
    public float speed;
    public float maxHp;
    public WeaponData clasicWeapon;
}
public enum State
{
    Stand,
    Run,
    Dead
}

public enum ClasicWeaponType
{
    Gun,
    Shovels,
    Plough,
    Machinegun,
    Hoe,
    Shotgun
}

public abstract class Player : MonoBehaviour
{
    public State state = State.Stand;
    public ClasicWeaponType clasicWeapontype = new ClasicWeaponType();
    public PlayerData playerData = new PlayerData();

    [HideInInspector] public List<Enemy> enemys;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected List<Sprite> standSP;
    [SerializeField] protected List<Sprite> runSP;
    [SerializeField] protected List<Sprite> deadSP;
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    public Transform weaponPos;
    public Transform bulletparent;
    public Transform bulletpos;
    Animation anim;
    float curHp = 0f;
    float maxHP = 0f;
    float curExp = 0f;
    float speed = 0f;
    [HideInInspector] public Enemy target = null;
    [HideInInspector] public Dictionary<string, Weapon> curWeapons = new Dictionary<string, Weapon>();

    public float HP
    {
        get { return curHp; }
        set { curHp = value; }
    }
    public float MaxHp
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    [HideInInspector] public float maxExp = 100f;
    public float Exp
    {
        get { return curExp; }
        set { curExp = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float Damage { get; set; }
    public abstract void Initalize();
    void Start()
    {
        HP = playerData.maxHp;
        MaxHp = playerData.maxHp;
        speed = playerData.speed;
        weaponPos = transform.GetChild(0);
        bulletpos = transform.GetChild(1);

        
    }
    void Update()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        if (curHp <= 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(deadSP, 0.1f);
            GetComponent<CapsuleCollider2D>().isTrigger = false;
            GameManager.instance.uicont.DieImage();
            transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.isLive = false;
        }

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector3 ve2 = new Vector3(x, y, 0f);
        Vector3 dir = Vector3.Normalize(ve2);
        transform.position += dir * Time.deltaTime * Speed;

        if (weaponPos.transform.childCount >= 1)
        {
            int weaponChild = weaponPos.transform.childCount;

            if (x < 0 && GetComponent<SpriteRenderer>().flipX != true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                for (int i = 0; i < weaponChild; i++)
                {
                    weaponPos.transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else if (x > 0 && GetComponent<SpriteRenderer>().flipX != false)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                for (int i = 0; i < weaponChild; i++)
                {
                    weaponPos.transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else
        {
            if (x < 0 && GetComponent<SpriteRenderer>().flipX != true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                
            }
            else if (x > 0 && GetComponent<SpriteRenderer>().flipX != false)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                
            }
        }
        if ((x != 0 || y != 0) && state != State.Run)
        {
            state = State.Run;
            GetComponent<SpriteAnimation>().SetSprite(runSP, 0.1f);
        }
        else if (x == 0 && y == 0 && state != State.Stand)
        {
            state = State.Stand;
            GetComponent<SpriteAnimation>().SetSprite(standSP, 0.1f);
        }
        FindTarget();
        SetDirWeapon();
    }
    void SetDirWeapon()
    {
        if (enemys.Count >= 1)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bulletpos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
    void FindTarget()
    {
        if (enemys.Count != 0)
        {
            foreach (var enemy in enemys)
            {
                if (target == null)
                {
                    target = enemy;
                }
                else
                {
                    float dis = Vector3.Distance(transform.position, target.transform.position);
                    float enemydis = Vector3.Distance(transform.position, enemy.transform.position);
                    if (dis > enemydis)
                    {
                        target = enemy;
                    }
                }
            }
        }
    }
    public void SetWeaponData(WeaponData weaponData)
    {
        bool dir = GetComponent<SpriteRenderer>().flipX;
        Weapon weapon = Instantiate(weaponData.Weapon, weaponPos.transform);
        weapon.GetComponent<SpriteRenderer>().flipX = dir;
        curWeapons.Add(weaponData.WeaponName, weapon);
    }
    public void LevelUp()
    {
        HP = MaxHp;
        curExp = 0;
        maxExp += 50f;
    }
}
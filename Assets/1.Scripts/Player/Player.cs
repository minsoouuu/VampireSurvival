using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public struct PlayerData
{
    public float speed;
    public float maxHp;
}

public enum State
{
    Stand,
    Run,
    Dead
}

public abstract class Player : MonoBehaviour
{
    public State state = State.Stand;
    public PlayerData playerData = new PlayerData();

    [HideInInspector] public List<Enemy> enemys;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected List<Sprite> standSP;
    [SerializeField] protected List<Sprite> runSP;
    [SerializeField] protected List<Sprite> deadSP;
    [SerializeField] private Sprite[] weaponSprites;
    [HideInInspector] public SpriteRenderer weapon;
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletparent;
    [SerializeField] Transform bulletpos;
    Animation anim;
    float attackdelay = 0;
    float curHp = 0;

    public List<Image> myWeaponIvens;

    WeaponData weaponData;

    public float HP
    {
        get { return curHp; }
        set { curHp = value; }
    }
    float curExp = 0;
    [HideInInspector] public float maxExp = 100f;
    public float Exp
    {
        get { return curExp; }
        set { curExp = value; }
    }
    public abstract void Initalize();

    void Start()
    {
        HP = playerData.maxHp;
        weapon = transform.GetChild(0).GetComponent<SpriteRenderer>();
        bulletpos = transform.GetChild(1);
        SetWeaponData(GameManager.instance.weaponDatas[0]);
        weapon.sprite = weaponData.Weapon.GetComponent<SpriteRenderer>().sprite;
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
            //GameManager.instance.uicont.DieImage();
            transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.isLive = false;
        }

        attackdelay += Time.deltaTime;

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector3 ve2 = new Vector3(x, y, 0f);
        Vector3 dir = Vector3.Normalize(ve2);
        transform.position += dir * Time.deltaTime * playerData.speed;

        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            weapon.flipX = true;
        }
        else if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            weapon.flipX = false;
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

        if (attackdelay > weaponData.Weapon.weapons.shotDelay)
        {
            FindTarget();
            attackdelay = 0;
        }
    }
    void FindTarget()
    {
        if (enemys.Count != 0)
        {
            Enemy target = null;

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
            float targetdis = Vector3.Distance(transform.position, target.transform.position);
            if (targetdis < 10)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                bulletpos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                Bullet bt = Instantiate(weaponData.Bullet, bulletpos);
                bt.transform.SetParent(bulletparent);
            }
        }
    }
   
    public void SetWeaponData(WeaponData weaponData)
    {
        this.weaponData = weaponData;
        this.weaponData.Weapon.Initailize();
    }

    public void LevelUp()
    {
        curHp = playerData.maxHp;
        curExp = 0;
        maxExp += 50f;
    }
}
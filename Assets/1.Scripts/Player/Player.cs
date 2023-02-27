using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] protected List<Sprite> standSP;
    [SerializeField] protected List<Sprite> runSP;
    [SerializeField] protected List<Sprite> deadSP;
    protected SpriteRenderer spriteRenderer;
    Animation anim;
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletparent;
    float curHp = 0;
    float attackdelay = 0;


    public float HP
    {
        get { return curHp; }
        set 
        { 
            curHp = value;
        }
    }
    public abstract void Initalize();

    void Start()
    {
        HP = playerData.maxHp;
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        if (curHp < 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(deadSP, 0.1f);
            //GameManager.instance.uicont.DieImage();
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
        }
        else if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
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

        if (attackdelay > 1)
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
                target = enemy;
                if (target != null)
                {
                    float dis = Vector3.Distance(transform.position, target.transform.position);
                    if()
                }
            }


            if (dis < 10)
            {
                Vector3 dir = target.transform.position - transform.position;
                Bullet bt = Instantiate(bullet, transform);
                bt.SetDir(dir);
                bt.transform.SetParent(bulletparent);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] protected List<Sprite> standSP;
    [SerializeField] protected List<Sprite> runSP;
    [SerializeField] protected List<Sprite> deadSP;

    protected SpriteRenderer spriteRenderer;
    Animation anim;
    [HideInInspector] public float x;
    [HideInInspector] public float y;

    float curHp;

    public float HP
    {
        get { return curHp; }
        set 
        { 
            curHp = value;
            Debug.Log(curHp);
        }
    }

    public abstract void Initalize();

    void Start()
    {
        curHp = playerData.maxHp;
    }
    void Update()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float damage;
    public float hp;
}

public enum States
{
    Stand,
    Run,
    Hit
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData enemyData = new EnemyData();
    States state = States.Stand;
    [SerializeField] private List<Sprite> runSprites;
    [SerializeField] private List<Sprite> deadSprites;
    [SerializeField] private List<Sprite> hitSprites;
    Player player;
    float curHp = 0;
    float maxHp = 100;
    float attackdelayTime = 0;
    
    public float HP
    {
        get { return curHp; }
        set { curHp = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        curHp = maxHp;
    }

    public abstract void Init();

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        Vector3 dirVec = playerPos - myPos;
        Vector3 dir = Vector3.Normalize(dirVec);
        Debug.Log(dir);
        transform.Translate(dir * Time.deltaTime * enemyData.speed);
        */

        if (!GameManager.instance.isLive)
        {
            return;
        }
        attackdelayTime += Time.deltaTime;
        
        Vector3 dir = player.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemyData.speed);

        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= 0.7f)
        {

        }
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyData.speed * Time.deltaTime);

        if (player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (transform.position != Vector3.zero && state != States.Run)
        {
            state = States.Run;
            GetComponent<SpriteAnimation>().SetSprite(runSprites, 0.1f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (state != States.Hit)
            {
                state = States.Hit;
                collision.gameObject.GetComponent<Player>().HP -= enemyData.damage;
                GetComponent<SpriteAnimation>().SetSprite(hitSprites, 0.1f);
            }
            
        }
    }

    void Die()
    {
        GetComponent<SpriteAnimation>().SetSprite(deadSprites, 0.1f);
        GameManager.instance.isLive = false;
    }
}

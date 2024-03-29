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
    Hit,
    Die
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData enemyData = new EnemyData();
    States state = States.Stand;
    [SerializeField] private List<Sprite> runSprites;
    [SerializeField] private List<Sprite> deadSprite;
    [SerializeField] private Sprite hitSprite;
    [SerializeField] private Item[] expItems;
    [SerializeField] private Item[] hel_mags;
    [SerializeField] private Item[] stetsItems;
    [HideInInspector] public Transform itemParent;
    float curHp = 0;
    float attackdelayTime = 0;

    bool isLive = true;
    public float HP
    {
        get { return curHp; }
        set { curHp = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        curHp = enemyData.hp;
    }

    public abstract void Init();

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        if (!isLive)
        {
            return;
        }
        if (HP <= 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            ItemDrop();
            isLive = false;
            GetComponent<SpriteAnimation>().SetSprite(deadSprite, 0.1f,Die);
        }
        attackdelayTime += Time.deltaTime;
        
        Vector3 dir = GameManager.instance.player.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemyData.speed);

        float dis = Vector3.Distance(transform.position,GameManager.instance.player.transform.position);
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyData.speed * Time.deltaTime);

        if (GameManager.instance.player.transform.position.x < transform.position.x)
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
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (state != States.Hit)
            {
                state = States.Hit;
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, runSprites, 0.1f);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().HP -= enemyData.damage;
        }
    }
    void Die()
    {
        GameManager.instance.player.enemys.Remove(this);

        if (GameManager.instance.player.curWeapons.ContainsKey("plough"))
        {
            GameManager.instance.player.curWeapons["plough"].GetComponent<Plough>().targets.Remove(this);
        }
        Destroy(gameObject);
    }
    void ItemDrop()
    {
        Instantiate(expItems[Random.Range(0, expItems.Length)], transform).transform.SetParent(itemParent);
        int rand = Random.Range(0, 100);
        if (rand <= 2)
        {
            // Ȯ�� ���
            Instantiate(hel_mags[Random.Range(0, hel_mags.Length)],transform).transform.SetParent(itemParent);
        }
        else if (rand > 99)
        {
            Instantiate(stetsItems[Random.Range(0, hel_mags.Length)], transform).transform.SetParent(itemParent);
        }
    }
}

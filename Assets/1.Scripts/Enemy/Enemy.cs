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
    [SerializeField] private List<Sprite> runSprites;
    [SerializeField] private List<Sprite> deadSprites;
    [SerializeField] private List<Sprite> hitSprites;
    Player player;
    public EnemyData enemyData = new EnemyData();
    States state = States.Stand;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        Vector3 vec = new Vector3(0, 0, 0);
        transform.Translate(vec.normalized);
    }

    public abstract void Init();

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        Vector3 dirVec = playerPos - myPos;
        Vector3 dir = Vector3.Normalize(dirVec);
        Debug.Log(dir);
        transform.Translate(dir * Time.deltaTime * enemyData.speed);
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyData.speed * Time.deltaTime);

        /*
        if (player.transform.position.y < transform.position.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime * enemyData.speed * 2);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * 2);
        }
        */

        if (player.transform.position.x < transform.position.x)
        {
            //transform.Translate(Vector3.left * Time.deltaTime * enemyData.speed);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            //transform.Translate(Vector3.right * Time.deltaTime * enemyData.speed);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (transform.position != Vector3.zero && state != States.Run)
        {
            state = States.Run;
            GetComponent<SpriteAnimation>().SetSprite(runSprites, 0.1f);
        }
    }
}

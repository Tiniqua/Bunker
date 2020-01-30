using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int scoreValue = 1;
    public float waitTime;
    private float currentTime;
    private bool shot;
    public float speed;
    private bool stop;
    private bool withinRange;
    public  int health;

    public Transform robot;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    AudioSource audioData;

    public void Start()
    {
        health = GameManager.Instance.enemyHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        robot = this.transform.GetChild(0);
        bulletSpawnPoint = robot.GetChild(0); //Gets the bulletspawn for the specific object
        speed = 3f;

    }
    public void Update()
    {

        if (health <= 0)
        {
            Die();
        }



        if (!bulletSpawnPoint)
        {
            bulletSpawnPoint = this.transform.GetChild(2);
        }

        if (withinRange)
        {

            this.transform.LookAt(player.transform); //makes the enemy look at the player

            if (!stop)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }

            if (stop)
            {

                if (currentTime == 0)
                {
                    Shoot();
                }

                if (shot && (currentTime < waitTime))
                {
                    currentTime += 1 * Time.deltaTime;
                }

                if (currentTime >= waitTime)
                {
                    currentTime = 0;
                }
            }
        }

    }
    

    

    public void Shoot()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.transform.rotation = this.transform.rotation;

    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "StoppingDistance")
        {
            stop = true;
            speed = 0f;
           
        }

        if(coll.tag == "Vision")
        {
            Debug.Log(withinRange = true);
        }
    }

    public void OnTriggerExit(Collider coll)
    {
      

        if (coll.tag == "StoppingDistance")
        {
            stop = false;
            speed = 3f;
        }

        if (coll.tag == "vision")
        {
            Debug.Log(withinRange = false);
        }
    }

    public void Die()
    {
        Debug.Log(this.gameObject.name + " has died");
        KillsManager.score += scoreValue;
        ScoreManager.score += scoreValue;
        Destroy(this.gameObject);
    }
}

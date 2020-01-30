using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    //public GameObject camera;
    public GameObject playerObj;
    private bool canShoot = true;
    public float health;
    public float timeBetweenShots;
    private bool dead = false;

    //Keycard Bools
    public bool redKeyCard;
    public bool blueKeyCard;
    public bool greenKeyCard;
    

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    public GameObject deadScreen;
    public GameObject HUD;

    private Transform bulletSpawned;
    AudioSource audioData;
    ScoreManager SM = new ScoreManager();


    void Start()
    {
        HUD = GameObject.Find("HUD");

        redKeyCard = false;
        blueKeyCard = false;
        greenKeyCard = false;

    }
    private void Update()
    {
        if (!HUD.GetComponent<PauseMenu>().GameIsPaused) //Player facing mouse when not paused
        {
            

            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0f;

            if (plane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
            }
        }
        //Player Movement 

        if (Input.GetKey(KeyCode.W)) //player wants to move up
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) //player wants to move left
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) //player wants to move down
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) //player wants to move right
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        //Shooting

        if (Input.GetMouseButtonDown(0) && canShoot && !dead) //Player presses left mouse button and wants to shoot
        {
            //Shoot();
            StartCoroutine(fireRate());
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("BulletShot");
            
        }

        if (health <= 0)
        {
           
            Die();
            
        }
    }

    IEnumerator fireRate()
    {
        Shoot();
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

    private void Die()
    {
        print("You've Died!");
        Time.timeScale = 0;
        deadScreen.SetActive(true);
        SM.SaveFile();
        dead = true;
    }
    
}

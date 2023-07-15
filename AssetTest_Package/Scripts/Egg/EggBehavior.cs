using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    // All instance of EggBehavior share this one EggSystem
    private static EggSpawnSystem sEggSystem = null;
    public static void InitializeEggSystem(EggSpawnSystem e) { sEggSystem = e; }

    private const float kEggSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);

        // Figure out termination
        bool outside = GameManager.sTheGlobalBehavior.CollideWorldBound(GetComponent<Renderer>().bounds) == CameraSupport.WorldBoundStatus.Outside;
        if (outside)
        {
            DestroyThisEgg("Self");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Egg OnTriggerEnter");
        // Collision with hero (especially when first spawned) does not count
        if (collision.gameObject.name != "Hero") 
            DestroyThisEgg(collision.gameObject.name);
    }

    private void DestroyThisEgg(string name)
    {
        // Watch out!! a collision with overlap objects (e.g., two objects at the same location 
        // will result in two OnTriggerEntger2D() calls!!
        if (gameObject.activeSelf)
        {
            sEggSystem.DecEggCount();
            gameObject.SetActive(false);  // set inactive!
            Destroy(gameObject);
        } else
        {
            Debug.Log("Calling Egg Destroy on a destroyed egg: " + name);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnCoinScript : MonoBehaviour
{
    public GameObject theCoin;
    public AudioSource audioPlayer;
    Vector3 myVector;

    void Update()
    {
        if (Time.timeScale != 0) //Pauses spinning coins when game is paused
        {
            gameObject.transform.Rotate(1f, 0f, 0f, Space.Self);
        }
        //if (theCoin != null && ((theCoin.transform.position.x > 13.5f) || (theCoin.transform.position.x < -13.5f) || (theCoin.transform.position.y > 13.5f) || (theCoin.transform.position.y < -13.5f)))
        //{
            //SpawnCoin();
            //Debug.Log("COIN IS OUTSIDE");
            //myVector = new Vector3(-4.44f, 1.5f, -11.26f);
            //theCoin.transform.position = myVector;
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioPlayer.Play();
            SpawnCoin();
            ScoreController.Score++;
            Destroy(gameObject);
        }
    }

    private void SpawnCoin()
    {
        // Generate a random position inside a sphere around the SpawnCoinScript object 
        //Found this in Unity documentation https://docs.unity3d.com/540/Documentation/ScriptReference/NavMesh.SamplePosition.html
        Vector3 randomOffset = Random.insideUnitSphere * 10f;
        Vector3 randomPosition = transform.position + randomOffset;

        // Ensure that the coin is within the playable area
        randomPosition.x = Mathf.Clamp(randomPosition.x, -13.5f, 13.5f);
        randomPosition.y = Mathf.Clamp(randomPosition.y, -13.5f, 13.5f);

        // Find a position on the NavMesh closest to the random position
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 10.0f, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
        }

        randomPosition.y = 1.5f; // Coin Y position

        Quaternion rotation = Quaternion.Euler(0f, 0f, 90f); // 90 degrees rotation on Z axis
        theCoin = Instantiate(theCoin, randomPosition, rotation);
    }
}

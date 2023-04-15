using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
// THIS SCRIPT IS ATTACHED TO THE ENEMY
// SPEED OF THE PLAYER IN NAVMESHAGENT IS 5, FOR ENEMY IS 3.5
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemy;
    public GameObject player;
    public ThirdPersonCharacter character;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {

        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        enemy.SetDestination(player.transform.position);

        if (enemy.remainingDistance > enemy.stoppingDistance)
        {
            character.Move(enemy.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioPlayer.Play();
            ScoreController.Lives--;
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Latest Update  25.05.2015 by Mathias
/// 
/// This AI is still very basic, it does not contain any kind of pathfinding
/// It just follows the player.
/// They are rigidbody so they can push things but not the player, 
/// Because they are not allowed to move to close to it
/// Based upon _minDistance
/// 
/// _rangeDistance is how far away the player has to be for it to work
/// _speed is how fast the enemy moves
/// 
/// 
/// All the functions in this script may be overwritten for more advanced AI
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour {
	public float _rangeDistance = 10;
	public float _minDistance = 1.2f;
	public float _speed = 3;

    public GameObject _player;
    public Rigidbody _rbody;


    // Use this for initialization
    void Start () {
		_rbody = GetComponent<Rigidbody>();
	}

    private void FixedUpdate() {
        UpdateEnemy();
    }

    /// <summary>
    /// Follow and rotate towards the enemy is the default AI behaviour but it can be more complex if overwritten
    /// </summary>
	public virtual void UpdateEnemy () {
		// Find the player
		if(_player == null){
			_player = GameObject.FindGameObjectWithTag("Player");
			return;
		}

		// ignore the player if its not within the set range
		if(Vector3.Distance(transform.position, _player.transform.position) > _rangeDistance)
			return;

		// look at the player with a slerp
		var rotation = Quaternion.LookRotation(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z) - transform.position);
		transform.rotation = rotation;

		// if its to close to the player then dont move
		if(Vector3.Distance(transform.position, _player.transform.position) < _minDistance)
			return;
		else
			_rbody.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed);
	}

}

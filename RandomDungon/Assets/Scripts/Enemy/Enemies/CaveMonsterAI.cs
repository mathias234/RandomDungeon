using UnityEngine;
using System.Collections;

namespace RandomDungeon.Entity {
    public class CaveMonsterAI : EnemyAI {

        private void FixedUpdate() {
            UpdateEnemy();
        }

        /// <summary>
        /// Follow and rotate towards the enemy is the default AI behaviour but it can be more complex if overwritten
        /// </summary>
        public override void UpdateEnemy() {
            // Find the player
            if (_player == null) {
                _player = GameObject.FindGameObjectWithTag("Player");
                return;
            }

            // ignore the player if its not within the set range
            if (Vector3.Distance(transform.position, _player.transform.position) > _rangeDistance)
                return;

            // look at the player with a slerp
            var rotation = Quaternion.LookRotation(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z) - transform.position);
            transform.rotation = rotation;
            Animator anim = GetComponent<Animator>();

            // if its to close to the player then dont move
            if (Vector3.Distance(transform.position, _player.transform.position) < _minDistance) {
                anim.SetBool("IsRunning", false);
                return;
            }
            else {
                anim.SetBool("IsRunning", true);
                _rbody.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed);
            }
        }
    }
}
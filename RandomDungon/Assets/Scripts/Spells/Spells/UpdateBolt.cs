using UnityEngine;
using System.Collections;

public class UpdateBolt : MonoBehaviour {
    public Bolt bolt;
    public float speed;

    void Start() {
        gameObject.SetActive(false);
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position;
        transform.rotation = player.rotation;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        bolt.LifeTime += Time.deltaTime;

        if (bolt.LifeTime >= bolt.BaseLifeTime) {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().TakeDamage(Random.Range(bolt.DamageValue - bolt.DamageVariance, bolt.DamageValue + bolt.DamageVariance));
            Destroy(gameObject);
        }
    }
}

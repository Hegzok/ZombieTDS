using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;

    public int damage;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        transform.LookAt(DataStorage.MouseInfo.ReturnMousePos(this.transform));
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            IKillable iKillable = other.GetComponent<IKillable>();
            iKillable?.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}

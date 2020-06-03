using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float radius;
    [SerializeField] private float force;
    private bool added;
    // Start is called before the first frame update
    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        base.Start();
        LaunchGrenade();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        
    }

    private void LaunchGrenade()
    {
        rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        #region Detect IKillable and deal damage to them
        if (!other.gameObject.CompareTag("Player"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);
            List<IKillable> killable = new List<IKillable>();

            if (!added)
            {
                foreach (var collider in hitColliders)
                {
                    killable.Add(collider.GetComponent<IKillable>());
                }
                added = true;
            }

            foreach (var creature in killable)
            {
                creature?.TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }
        #endregion
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

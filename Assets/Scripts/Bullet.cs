using UnityEngine;

namespace CombatSystem
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();                
        }
        
        public void SetBullet(int damage, float speed)
        {
            _damage = damage;
            _speed = speed;
        }

        public void Fire()
        {
            _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Character"))
            {
                print("collided with : " + collision.transform.parent.name);
                collision.transform.parent.GetComponent<Character>().DamageHealth(_damage);
            }
        }
    }
}
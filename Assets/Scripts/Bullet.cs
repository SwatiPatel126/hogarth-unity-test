using UnityEngine;

namespace CombatSystem
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Rigidbody _rigidbody;
        private float _life=3f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Destroy(gameObject, _life);
        }
        //Set bullet properties
        public void SetBullet(int damage, float speed)
        {
            _damage = damage;
            _speed = speed;
        }

        //Fire bullet in it's forward direction. Applied force to get reallife bullet physics behaviour 
        public void Fire()
        {
            _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        }

        //Damage character health if bullet collides with character
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Character"))
            {
                Debug.Log("bullet collided with : " + collision.transform.parent.name);
                collision.transform.parent.GetComponent<Character>().DamageHealth(_damage);
                Destroy(gameObject);
            }
        }
    }
}
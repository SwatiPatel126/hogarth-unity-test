using UnityEngine;

namespace CombatSystem
{
    public class Weapon : MonoBehaviour
    {
        public float AttackSpeed=1f;
        public float Range=7f;

        [SerializeField]
        private GameObject _bulletPrefab;
        [SerializeField]
        private float _bulletSpeed=15f;
        [SerializeField]
        private int _damage;
        
        //TODO: Object pooling for bullet

        //Attack on target. Initialize bullet and fire it
        public void Attack()
        {
            if (_bulletPrefab != null)
            {
                GameObject bulletObj = Instantiate(_bulletPrefab,transform);
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetBullet(_damage, _bulletSpeed);                
                bullet.Fire();
            }
        }
    }
}

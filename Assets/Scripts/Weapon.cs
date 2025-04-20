using UnityEngine;

namespace CombatSystem
{
    public class Weapon : MonoBehaviour
    {
        private float _attackSpeed;
        public float Range;
        [SerializeField]
        private GameObject _bulletPrefab;
        [SerializeField]
        private float _bulletSpeed=10f;
        [SerializeField]
        private int _damage;
        void Start()
        {

        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Attack();
            }
        }

        private void Attack()
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

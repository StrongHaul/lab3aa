using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    public Weapon weapon;
    public Transform bullet;    // пуля
    public Transform bulletpos;     // откуда будет вылетать пуля
    [SerializeField] private int BulletSpeed = 1000;      // скорость пули
    private int BulletCurrent = 10;      // количество пуль
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") & BulletCurrent > 0)
        {
            //Transform newbullet = (Transform)Instantiate(bullet, GameObject.Find("BulletSpawn").transform.position, Quaternion.identity);
            Transform newbullet = (Transform)Instantiate(bullet, bulletpos.transform.position, transform.rotation);
            newbullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed);      // скорость вылета пули
            BulletCurrent--;
            shoot();
        }
        if (Input.GetButtonDown("Reload Weapon"))   // нажали на R
        {
            BulletCurrent = 10;
        }
    }

    [Client]
    private void shoot()
    {
        RaycastHit target;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out target, weapon.range, mask))
            if (target.collider.tag == "Player")      // если попали в игрока
                Cmdplayershoot(target.collider.name, weapon.damage);
    }

    [Command]
    void Cmdplayershoot(string id, float damage)
    {
        Debug.Log("Попали в игрока " + id);
        Player player = GameManager.Getplayer(id);
        player.Takedamage(damage);
    }
}

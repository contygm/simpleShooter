using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Projectile projectilePrefab;
    // NOTE: will help filter game objets found in raycasting
    public LayerMask mask;

    void Start()
    {
        
    }

    void Update () {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if(mouseButtonDown) {
            raycastOnMouseClick();  
        }
    }

    void shoot(RaycastHit hit){
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();  // NOTE: create projectile instance
        // REVIEW: var name is lame
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);
        var direction = pointAboveFloor - transform.position;  // NOTE: calculate parallell direction
        var shootRay = new Ray(this.transform.position, direction);  // NOTE: describes projectile trajectory
        
        Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.green, 2);
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        projectile.FireProjectile(shootRay);
    }

    void raycastOnMouseClick () {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

        if(Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide)) {
            shoot(hit);
        }
    }
}

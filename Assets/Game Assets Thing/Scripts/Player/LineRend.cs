using UnityEngine;

public class LineRend : MonoBehaviour
{
    public LineRenderer lineRend;
    public Transform hitPos;
    public Color laser1;
    public Color laser2;
    public Color plasma1;
    public Color plasma2;
    public bool shoot;
    public bool laser;
    public bool plasma;
    public float dmg;
    public float laserStartWidth;
    public float laserEndWidth;
    public float plasmaStartWidth;
    public float plasmaEndWidth;
    RaycastHit2D hit;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.enabled = false;
        lineRend.useWorldSpace = true;
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.up);
        Debug.DrawLine(transform.position, hit.point, Color.green);
        hitPos.position = hit.point;
        lineRend.SetPosition(0, transform.position);
        lineRend.SetPosition(1, hitPos.position);

        if (shoot)
        {
            lineRend.enabled = true;
        }
        else
        {
            lineRend.enabled = false;
        }

        if (laser)
        {
            lineRend.startWidth = laserStartWidth;
            lineRend.endWidth = laserEndWidth;
            lineRend.startColor = laser1;
            lineRend.endColor = laser2;
        }
        else
        if (plasma)
        {
            lineRend.startWidth = plasmaStartWidth;
            lineRend.endWidth = plasmaEndWidth;
            lineRend.startColor = plasma1;
            lineRend.endColor = plasma2;
        }
    }

    public void RayDmg(float damage)
    {
        dmg = damage;

        if (hit.collider.gameObject.CompareTag("Enemy"))
        {
            hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
        }
        else
        if (hit.collider.gameObject.CompareTag("Boss"))
        {
            hit.collider.gameObject.GetComponent<BossHealth>().TakeDamage(dmg);
        }
    }
}

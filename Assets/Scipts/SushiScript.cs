using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SushiScript : MonoBehaviour
{
    public int TunaRollValue = 100;
    public int RiceBallValue = 50;
    public int BombValue = -500;
    public Material TunaRollMaterial;
    public Material RiceBallMaterial;
    public Material BombMaterial;
    public float MinSpeed=2;
    public float MaxSpeed=10;
    public float MinRotationSpeed = 10;
    public float MaxRotationSpeed = 40;
    private int m_value;
    private float m_verticalSpeed;
    private float m_RotationSpeed;
    public enum e_SushiType
    {
        tuna_roll = 0,
        rice_ball,
        bomb,
    }
   
    public void Initialize(e_SushiType e_Sushi)
    {
        m_verticalSpeed = Random.Range(MinSpeed, MaxSpeed);
        m_RotationSpeed = Random.Range(MinRotationSpeed, MaxRotationSpeed);

        switch (e_Sushi)
        {
            case e_SushiType.tuna_roll:
                {
                    m_value = TunaRollValue;
                    GetComponent<MeshRenderer>().material = TunaRollMaterial;
                    break;
                }
            case e_SushiType.rice_ball:
                {
                    m_value = RiceBallValue;
                    GetComponent<MeshRenderer>().material = RiceBallMaterial;
                    break;
                }
            case e_SushiType.bomb:
                {
                    m_value = BombValue;
                    GetComponent<MeshRenderer>().material = BombMaterial;
                    break;
                }
            default:
                {
                    Destroy(gameObject);
                    break;
                }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize(e_SushiType.tuna_roll);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * m_verticalSpeed * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.back * m_RotationSpeed * Time.deltaTime, Space.World);
    }
}

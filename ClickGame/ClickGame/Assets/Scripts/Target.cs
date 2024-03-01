using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    private Rigidbody rigi;
    private GameManager gameMan;
    public TextMeshProUGUI scoretext;
    public int pointValue;
    public ParticleSystem expParticle;
    

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();

        rigi.AddForce(RandomForce(), ForceMode.Impulse);
        rigi.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4,4), -2,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        if (gameMan.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(expParticle, transform.position, expParticle.transform.rotation);
            gameMan.UpdateScore(pointValue);
        }
       


    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Finish") && gameMan.isGameActive)
        {
            gameMan.UpdateLives(-1);
        }       
            
    }


    

    Vector3 RandomForce(){
       return Vector3.up * Random.Range(28,50);
    }

    float RandomTorque(){
       return Random.Range(-10,10);
    }
}

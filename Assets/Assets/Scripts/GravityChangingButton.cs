using Bran;
using UnityEngine;

public class GravityChangingButton : MonoBehaviour, IButtons
{

    private InGamePhysics inGamePhysics;
    private InputReader input;

    void Start()
    {
        inGamePhysics = GameObject.Find("Player").GetComponent<InGamePhysics>();
        input = InputReader.Instance;
    }

    public void Interact()
    {
       inGamePhysics.AdjustPlayerGravity(.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Interact();
        }
    }

}

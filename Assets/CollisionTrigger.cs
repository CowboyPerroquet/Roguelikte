using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    MeshCollider mesh;
    GameObject test;
   public bool right = true, left = true, front = true, back = true;
    public List<string> collisionlist;

    private void Start()
    {
        mesh = GetComponent<MeshCollider>();


        collisionlist= new List<string>();
    }

    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log(collision.gameObject.name + mesh.gameObject.name);
        Debug.Log(mesh.gameObject.name);
        if (!collisionlist.Contains(collision.gameObject.name)) {
            collisionlist.Add(collision.gameObject.name);
        }
    }

    public void Reset()
    {
        collisionlist = new List<string>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider + "enter collision but not foreach");

        foreach (ContactPoint contact in collision.contacts)
        {

            Debug.Log(contact.otherCollider.gameObject.name + " colision ");
        }

    }

    public void PlaceAvailable(int where)
    {
       
        switch (where)
        {
            //if right == true then he can place onthe right, if right is false, then no child can be add
            case 1:
                if (front)
                {
                    front = false;
                    // GameObject.Find("ButtonBot").SetActive(false);
                }
                break;
            case 2:
                if (back)
                {
                    back = false;
                    //  GameObject.Find("ButtonTop").SetActive(false);
                }
                break;



            case 3:
                if (left)
                {
                    left = false;

                    //   GameObject.Find("ButtonRight").SetActive(false);
                }
                break;
            case 4:
                if (right)
                {

                    right = false;
                    // GameObject.Find("ButtonLeft").SetActive(false);
                }
                break;
        }


    }
    public void WhichButtonToActivate()
    {

        GameObject.Find("RoomSelector").transform.Find("ButtonRight").gameObject.SetActive(true);
        GameObject.Find("RoomSelector").transform.Find("ButtonLeft").gameObject.SetActive(true);
        GameObject.Find("RoomSelector").transform.Find("ButtonBot").gameObject.SetActive(true);
        GameObject.Find("RoomSelector").transform.Find("ButtonTop").gameObject.SetActive(true);
        GameObject buttonleft = GameObject.Find("RoomSelector").transform.Find("ButtonLeft").gameObject;
        GameObject buttonright = GameObject.Find("RoomSelector").transform.Find("ButtonRight").gameObject;
        GameObject buttonbot = GameObject.Find("RoomSelector").transform.Find("ButtonBot").gameObject;
        GameObject buttontop = GameObject.Find("RoomSelector").transform.Find("ButtonTop").gameObject;

        


        if (right == false)
        {
            buttonright.SetActive(false);
        }
        if (!left)
        {
            buttonleft.SetActive(false);
        }



        if (front == false)
        {
            buttonbot.SetActive(false);
        }

        if (!back)
        {
            buttontop.SetActive(false);
        }

    }


}

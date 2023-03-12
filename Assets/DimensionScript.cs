using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
public class DimensionScript : MonoBehaviour
{

    //will be receive by the name of the button we click
    public GameObject prefabOfSalle;
    public GameObject PanelForDimension;
    public int boutonId;
    private GameObject[] gameobjectlist;
    private const int distPorte = 1;
    public int idboutonParent;

    static private Dictionary<int, GameObject> dictGameobj = new Dictionary<int, GameObject>();

    static private int id = 0;
    void Start()
    {
        gameobjectlist = Resources.LoadAll<GameObject>("Room");
        setDimension(boutonId);

    }

    public void onClickForDimension(int id)
    {


        PanelForDimension.SetActive(true);
        SeeDimension(id);

    }

    private void SeeDimension(int idRoom)
    {
        
        var prefabRoom = dictGameobj.Where(x => x.Key == boutonId).FirstOrDefault().Value;
        
        PanelForDimension.transform.Find("DonneeLongueur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.localScale.x.ToString(); //prefab.transform.localScale.z.ToString();
        PanelForDimension.transform.Find("DonneeLargeur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.localScale.z.ToString();
        PanelForDimension.transform.Find("DonneeHauteurArriere").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurArriere").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurAvant").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurAvant").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurDroit").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurDroit").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurGauche").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurGauche").gameObject.transform.localScale.y.ToString();

    }

    private void modifyDimesion()
    {
        
        
   
    }
    private int directionid;
    private void setDimension(int boutonId)
    {

        if(boutonId == 0)
        {
            GameObject planeStart  = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeStart.name = "startRoom";
            planeStart.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Create first room at x:0 y:0 z:0");

            var start = Instantiate(prefabOfSalle, planeStart.transform);
            float test = planeStart.transform.position.y;
            start.transform.position = new Vector3(0, planeStart.transform.position.y + test, 0);
            start.name = prefabOfSalle.name;
            
            dictGameobj.Add(boutonId, start);

        }
        // 0: first room (0,0,0)  1 = front , 2 = back , 3 = left, 4 = right 

        if ( boutonId == 1 ) {
            var lastroom = dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value;

            float lastRoomCoordonateX = lastroom.transform.localPosition.x;
            float lastRoomCoordonateZ = lastroom.transform.localPosition.y;
            float distanceToAdd= lastroom.transform.Find("MurAvant").gameObject.transform.localPosition.x - lastroom.transform.Find("MurArriere").gameObject.transform.localPosition.x;

            var roomtoAdd = Instantiate(prefabOfSalle, GameObject.Find("startRoom").transform);
            float distanceforWall = roomtoAdd.transform.Find("MurAvant").gameObject.transform.localPosition.x - roomtoAdd.transform.Find("MurArriere").gameObject.transform.localPosition.x;
            // front move by - x 
            float XCoord = lastRoomCoordonateX - Mathf.Abs(distanceToAdd) - Mathf.Abs(distanceforWall) - 1;

            roomtoAdd.transform.position = new Vector3(XCoord , (float) 0.1 , lastRoomCoordonateZ);
            roomtoAdd.name = prefabOfSalle.name;

            dictGameobj.Add(boutonId, roomtoAdd);

        }
        if (directionid == 2)
        {

            

        }
        if (directionid == 3)
        {



        }
        if (directionid == 4)
        {



        }



    }

}
// Start is called before the first frame update


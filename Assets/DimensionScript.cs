using System.Collections.Generic;
using System.Linq;
using TMPro;
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
    public int WhereToAdd;
    

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
        PanelForDimension.transform.Find("NomPiece").GetComponent<TextMeshProUGUI>().text = prefabRoom.name.ToString();
        PanelForDimension.transform.Find("DonneeLongueur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.localScale.x.ToString();
        PanelForDimension.transform.Find("DonneeLargeur").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.localScale.z.ToString();
        PanelForDimension.transform.Find("DonneeHauteurArriere").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurArriere").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurAvant").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurAvant").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurDroit").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurDroit").gameObject.transform.localScale.y.ToString();
        PanelForDimension.transform.Find("DonneeHauteurGauche").Find("Text Area").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = prefabRoom.transform.Find("MurGauche").gameObject.transform.localScale.y.ToString();

    }

    private void setDimension(int boutonId)
    {

        if (WhereToAdd == 0)
        {
            GameObject planeStart = GameObject.CreatePrimitive(PrimitiveType.Plane);
            planeStart.name = "startRoom";
            planeStart.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Create first room at x:0 y:0 z:0");

            var start = Instantiate(prefabOfSalle, planeStart.transform);
            float test = planeStart.transform.position.y;
            start.transform.position = new Vector3(0, planeStart.transform.position.y + test, 0);
            start.name = prefabOfSalle.name + boutonId;
            PanelForDimension.GetComponent<ButtonSave>().Rooms = start;

            dictGameobj.Add(boutonId, start);

        }
        // 0: first room (0,0,0)  1 = front , 2 = back , 3 = left, 4 = right 

        if (WhereToAdd == 1)
        {
            foreach (var b in dictGameobj)
            {
                Debug.Log(b.Value);
            }
            Debug.Log(dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value);
            var lastroom = dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value;

            float lastRoomCoordonateX = lastroom.transform.localPosition.x;
            float lastRoomCoordonateZ = lastroom.transform.localPosition.z;
            float distanceToAdd = (lastroom.transform.Find("MurAvant").gameObject.transform.localPosition.x - lastroom.transform.Find("MurArriere").gameObject.transform.localPosition.x) / 2;

            var roomtoAdd = Instantiate(prefabOfSalle, GameObject.Find("startRoom").transform);
            float distanceforWall = (roomtoAdd.transform.Find("MurAvant").gameObject.transform.localPosition.x - roomtoAdd.transform.Find("MurArriere").gameObject.transform.localPosition.x) / 2;
            // front move by - x 
            float XCoord = lastRoomCoordonateX + Mathf.Abs(distanceToAdd) + Mathf.Abs(distanceforWall) + 1;

            roomtoAdd.transform.position = new Vector3(XCoord, 0, lastRoomCoordonateZ);
            roomtoAdd.name = prefabOfSalle.name + boutonId;

            dictGameobj.Add(boutonId, roomtoAdd);

        }

        if (WhereToAdd == 2)
        {
            var lastroom = dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value;

            float lastRoomCoordonateX = lastroom.transform.localPosition.x;
            float lastRoomCoordonateZ = lastroom.transform.localPosition.z;
            float distanceToAdd = (lastroom.transform.Find("MurAvant").gameObject.transform.localPosition.x - lastroom.transform.Find("MurArriere").gameObject.transform.localPosition.x) / 2;

            var roomtoAdd = Instantiate(prefabOfSalle, GameObject.Find("startRoom").transform);
            float distanceforWall = (roomtoAdd.transform.Find("MurAvant").gameObject.transform.localPosition.x - roomtoAdd.transform.Find("MurArriere").gameObject.transform.localPosition.x) / 2;
            // front move by - x 
            float XCoord = lastRoomCoordonateX - Mathf.Abs(distanceToAdd) - Mathf.Abs(distanceforWall) - 1;

            roomtoAdd.transform.position = new Vector3(XCoord, 0, lastRoomCoordonateZ);
            roomtoAdd.name = prefabOfSalle.name + boutonId;

            dictGameobj.Add(boutonId, roomtoAdd);


        }


        if (WhereToAdd == 3)
        {
            var lastroom = dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value;

            float lastRoomCoordonateX = lastroom.transform.localPosition.x;
            float lastRoomCoordonateZ = lastroom.transform.localPosition.z;
            float distanceToAdd = (lastroom.transform.Find("MurDroit").gameObject.transform.localPosition.z - lastroom.transform.Find("MurGauche").gameObject.transform.localPosition.z) / 2;

            var roomtoAdd = Instantiate(prefabOfSalle, GameObject.Find("startRoom").transform);
            float distanceforWall = (roomtoAdd.transform.Find("MurDroit").gameObject.transform.localPosition.z - roomtoAdd.transform.Find("MurGauche").gameObject.transform.localPosition.z) / 2;
            // front move by - x 
            float ZCoord = lastRoomCoordonateZ - Mathf.Abs(distanceToAdd) - Mathf.Abs(distanceforWall) - 1;

            roomtoAdd.transform.position = new Vector3(lastRoomCoordonateX, 0, ZCoord);
            roomtoAdd.name = prefabOfSalle.name + boutonId;

            dictGameobj.Add(boutonId, roomtoAdd);

        }


        if (WhereToAdd == 4)
        {
            var lastroom = dictGameobj.Where(x => x.Key == idboutonParent).FirstOrDefault().Value;

            float lastRoomCoordonateX = lastroom.transform.localPosition.x;
            float lastRoomCoordonateZ = lastroom.transform.localPosition.z;
            float distanceToAdd = (lastroom.transform.Find("MurDroit").gameObject.transform.localPosition.z - lastroom.transform.Find("MurGauche").gameObject.transform.localPosition.z) / 2;

            var roomtoAdd = Instantiate(prefabOfSalle, GameObject.Find("startRoom").transform);
            float distanceforWall = (roomtoAdd.transform.Find("MurDroit").gameObject.transform.localPosition.z - roomtoAdd.transform.Find("MurGauche").gameObject.transform.localPosition.z) / 2;
            // front move by - x 
            float ZCoord = lastRoomCoordonateZ + Mathf.Abs(distanceToAdd) + Mathf.Abs(distanceforWall) + 1;

            roomtoAdd.transform.position = new Vector3(lastRoomCoordonateX, 0, ZCoord);
            roomtoAdd.name = prefabOfSalle.name + boutonId;

            dictGameobj.Add(boutonId, roomtoAdd);

        }



    }

}



// Start is called before the first frame update


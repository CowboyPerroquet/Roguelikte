using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;


public class DropdownRoomName : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Dropdown dropdown;
    public TMP_Dropdown dropdownWithRoomName;
    public TMP_Dropdown firstAdd;
 
    public GameObject buttontemplate;
    private GameObject[] gameobjectlist;
    private List<string> gameobjectname = new List<string>();
    public Transform m_ContentContainer;
    static private int idbutton = 0;
    static private bool firstime = true;
    public GameObject Pannel2;
    private static List<string> activerooms = new List<string>();

    static private Dictionary<int, string> dictGameobjName = new Dictionary<int, string>();
    void Start()
    {

        dropdown.gameObject.SetActive(true);
        gameobjectlist = Resources.LoadAll<GameObject>("Room");

        dropdown.ClearOptions();
        
        foreach (GameObject go in gameobjectlist)
        {
            Debug.Log(go.name);

            gameobjectname.Add(go.name);


        }
        dropdown.AddOptions(gameobjectname);

        if (firstime)
        {
            dropdownWithRoomName.ClearOptions();
            firstime = false;
            Addroom(0);
        }


        // Update is called once per frame

        // 0: first room (0,0,0)  1 = front , 2 = back , 3 = left, 4 = right 
    }
    public void Addroom(int room)
    {
        if (room == 0)
        {

            var first = Instantiate(buttontemplate);
            idbutton++;

            first.name = firstAdd.name;
            first.GetComponentInChildren<TMP_Text>().text = firstAdd.GetComponentInChildren<TMP_Text>().text;
            first.transform.SetParent(m_ContentContainer.transform);
            first.AddComponent<DimensionScript>().prefabOfSalle = gameobjectlist.Where(x => x.name == first.GetComponentInChildren<TMP_Text>().text).FirstOrDefault();
            first.GetComponent<DimensionScript>().PanelForDimension = Pannel2;
            first.GetComponent<DimensionScript>().boutonId = idbutton;
            first.GetComponent<Button>().onClick.AddListener(() => first.GetComponent<DimensionScript>().onClickForDimension(idbutton));
            first.GetComponent<DimensionScript>().WhereToAdd = 0;
         
            activerooms.Add(first.GetComponentInChildren<TMP_Text>().text + idbutton);
            dictGameobjName.Add(idbutton, first.GetComponentInChildren<TMP_Text>().text + idbutton);

            dropdownWithRoomName.ClearOptions();
            dropdownWithRoomName.AddOptions(activerooms);

            
        }
        else
        {
            idbutton++;
            var newItem = Instantiate(buttontemplate);

            newItem.name = dropdownWithRoomName.name;
            newItem.GetComponentInChildren<TMP_Text>().text = dropdown.GetComponentInChildren<TMP_Text>().text;


            newItem.transform.SetParent(m_ContentContainer.transform);
            

            newItem.AddComponent<DimensionScript>().prefabOfSalle = gameobjectlist.Where(x => x.name == newItem.GetComponentInChildren<TMP_Text>().text).FirstOrDefault();
            newItem.GetComponent<DimensionScript>().PanelForDimension = Pannel2;
            newItem.GetComponent<DimensionScript>().boutonId = idbutton;
            newItem.GetComponent<Button>().onClick.AddListener(() => newItem.GetComponent<DimensionScript>().onClickForDimension(idbutton));
            foreach (var item in dictGameobjName)
            {
                Debug.Log(item.Key + item.Value);
            }
            newItem.GetComponent<DimensionScript>().idboutonParent = dictGameobjName.Where(x => x.Value == dropdownWithRoomName.GetComponentInChildren<TMP_Text>().text).FirstOrDefault().Key;
            newItem.GetComponent<DimensionScript>().WhereToAdd = room;
            activerooms.Add(newItem.GetComponentInChildren<TMP_Text>().text + idbutton);
             dictGameobjName.Add(idbutton, newItem.GetComponentInChildren<TMP_Text>().text + idbutton);
          
           
            dropdownWithRoomName.ClearOptions();
            dropdownWithRoomName.AddOptions(activerooms);

            //
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DropdownRoomName : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Dropdown dropdown;
    public TMP_Dropdown dropdownWithRoomName;
    public TMP_Dropdown firstAdd;
    Button buttontop, buttonBot, buttonLeft, buttonRight;
    public GameObject buttontemplate;
    private GameObject[] gameobjectlist;
    private List<string> gameobjectname = new List<string>();
    public Transform m_ContentContainer; 
    static private int idbutton = 0;
    public GameObject Pannel2;


    void Start()
    {

        dropdown.gameObject.SetActive(true);
        gameobjectlist = Resources.LoadAll<GameObject>("Room");

        dropdown.ClearOptions();
        dropdownWithRoomName.ClearOptions();
        foreach (GameObject go in gameobjectlist)
        {
            Debug.Log(go.name);

            gameobjectname.Add(go.name);


        }
        dropdown.AddOptions(gameobjectname);
        dropdownWithRoomName.AddOptions(gameobjectname);

        Addroom(0);
        // Update is called once per frame

        // 0: first room (0,0,0)  1 = front , 2 = back , 3 = left, 4 = right 
    }
    public void Addroom(int room)
    {
        if (room == 0)
        {

            var first = Instantiate(buttontemplate);

            first.name = firstAdd.name;
            first.GetComponentInChildren<TMP_Text>().text = firstAdd.GetComponentInChildren<TMP_Text>().text;
            first.transform.SetParent(m_ContentContainer.transform);
            first.AddComponent<DimensionScript>().prefabOfSalle = gameobjectlist.Where(x => x.name == first.GetComponentInChildren<TMP_Text>().text).FirstOrDefault();
            first.GetComponent<DimensionScript>().PanelForDimension = Pannel2;
            first.GetComponent<DimensionScript>().boutonId = idbutton;
            first.GetComponent<Button>().onClick.AddListener(() => first.GetComponent<DimensionScript>().onClickForDimension(idbutton));
            idbutton++;
            return;
        }


        var newItem = Instantiate(buttontemplate);

        newItem.name = dropdownWithRoomName.name;
        newItem.GetComponentInChildren<TMP_Text>().text = dropdown.GetComponentInChildren<TMP_Text>().text;


        newItem.transform.SetParent(m_ContentContainer.transform);
       
       
         newItem.AddComponent<DimensionScript>().prefabOfSalle = gameobjectlist.Where(x => x.name == newItem.GetComponentInChildren<TMP_Text>().text).FirstOrDefault();    
         newItem.GetComponent<DimensionScript>().PanelForDimension = Pannel2;
         newItem.GetComponent<DimensionScript>().boutonId = idbutton;
         newItem.GetComponent<Button>().onClick.AddListener(() => newItem.GetComponent<DimensionScript>().onClickForDimension(idbutton));
         idbutton++;
        //

    }
}

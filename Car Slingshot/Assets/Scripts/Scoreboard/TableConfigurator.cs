using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableConfigurator : MonoBehaviour
{
    [SerializeField] GameObject rowPrefab;


    List<Profile> allProfiles;


    private void LoadTable(int days)
    {

        foreach (Transform child in transform)
            Destroy(child.gameObject);

        allProfiles = DataSaver.GetData();

        allProfiles.Sort((a, b) => a.time.CompareTo(b.time));

        
        var filtredProfiles = allProfiles.Where(p => (System.DateTime.Today - p.date).TotalDays <days);


        int number = 0;
        foreach (Profile profile in filtredProfiles)
        {
            number++;
            GameObject newRow = Instantiate(rowPrefab, transform);
            newRow.GetComponent<RowInfo>().SetRowData(number, profile.name, profile.time);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("mainmenu_scene");
    }

    public void LoadTableForEver()
    {
        LoadTable(99999999);
    }
    public void LoadTableForWeek()
    {
        LoadTable(7);
    }
    public void LoadTableForDay()
    {
        LoadTable(1);
    }

    void Start()
    {
        LoadTable(999999999);
    }

}

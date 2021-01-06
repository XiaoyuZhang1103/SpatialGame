using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuFunction : MonoBehaviour
{
    public InputFieldTask map;
    public string nameOfMap2;

    // Update is called once per frame
   public string   DeliverToSpecialMapStructure()
    {
        string s = map.groupOfP;
        int length = s.Length;
        switch (length )
        {
            case 1:
                SceneManager.LoadScene("map1_3DR1");
                return nameOfMap2="map2_3DR1";
            case 2:
                SceneManager.LoadScene("map1_3DR1");
                return nameOfMap2 = "map2_2DR1";
            case 3:
                SceneManager.LoadScene("map2_3DR1");
                return nameOfMap2 = "map1_3DR1";
            case 4:
                SceneManager.LoadScene("map2_3DR1");
                return nameOfMap2 = "map2_2DR1";
            case 5:
                SceneManager.LoadScene("map1_2DR1");
                return nameOfMap2 = "map2_2DR1";
            case 6:
                SceneManager.LoadScene("map1_2DR1");
                return nameOfMap2 = "map2_3DR1";
            case 7:
                SceneManager.LoadScene("map2_2DR1");
                return nameOfMap2 = "map1_3DR1";
            case 8:
                SceneManager.LoadScene("map2_2DR1");
                return nameOfMap2 = "map1_2DR1";

        }

        return nameOfMap2;
    }
}

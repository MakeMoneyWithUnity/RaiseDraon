using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {
    private int gold;

    // Use this for initialization
    void Start () {
	
	}

    public int Gold {
        get {
            return gold;
        }

        set {
            gold = value;
            PlayerPrefs.SetInt("Gold", gold);
        }
    }

}

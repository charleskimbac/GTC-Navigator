using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UI.Extensions;

public class FixInputField : MonoBehaviour {
    public GameObject startingInputObj; //<- first initialized in editor
    public GameObject endingInputObj; //^

    public GameObject startingInputPrefab;
    public GameObject endingInputPrefab;

    public GameObject startingParent;
    public GameObject endingParent;

    private Vector3 startingPos;
    private Vector3 endingPos;

    private Vector3 scale = new Vector3(1.86f, 1.86f, 1.86f);

    private void Start() {
        startingPos = startingInputObj.transform.position;
        endingPos = endingInputObj.transform.position;
    }

    public void fix() {
        Destroy(startingInputObj);
        Destroy(endingInputObj);

        startingInputObj = Instantiate(startingInputPrefab, startingPos, Quaternion.identity);
        endingInputObj = Instantiate(endingInputPrefab, endingPos, Quaternion.identity);

        startingInputObj.transform.parent = startingParent.transform;
        endingInputObj.transform.parent = endingParent.transform;
        startingInputObj.GetComponent<RectTransform>().localScale = scale;
        endingInputObj.GetComponent<RectTransform>().localScale = scale;

        startingInputObj.GetComponentInChildren<AutoCompleteComboBox>().setAvailableOptions(new List<string>(){"Entrance 1", "Entrance 2", "Entrance 3", "Entrance 4", "Entrance 5", "Hall 100", "Hall 800x900", "Hall 500x800", "Hall 100x800", "Hall 650x900", "Hall 600x900", "Hall 400x900", "Hall 500x650", "Hall 500x600", "Hall 400x500", "Hall 650", "Hall 600x700", "Hall 300x600", "Hall 300x400", "Hall 250x300", "Hall 250", "Hall 250x700", "Hall 400x700", "Room 102", "Room 104", "Room 106", "Room 250", "Room 251", "Room 253", "Room 254", "Room 255", "Room 257", "Room 259", "Room 260", "Room 262", "Room 264", "Room 265", "Room 302", "Room 304", "Room 306", "Room 307", "Room 309", "Room 315", "Room 316", "Room 318", "Room 319", "Room 321", "Room 320", "Room 323", "Room 405", "Room 407", "Room 409", "Room 411", "Room 413", "Room 415", "Room 416", "Room 418", "Room 515", "Room 516", "Room 517", "Room 518", "Room 519", "Room 520", "Room 521", "Room 523", "Room 527", "Room 529", "Room 601", "Room 604", "Room 605", "Room 606", "Room 607", "Room 608", "Room 610", "Room 611", "Room 612", "Room 613", "Room 651", "Room 652", "Room 653", "Room 654", "Room 655", "Room 656", "Room 657", "Room 658", "Room 659", "Room 701", "Room 703", "Room 705", "Room 707", "Room 708", "Room 715", "Room 716", "Room 717", "Room 718", "Room 719", "Room 722", "Room 723", "Room 802", "Room 804", "Room 806", "Room 808", "Room 810", "Room 812", "Room 811", "Room 813", "Room 814", "Room 815", "Room 816", "Room 818", "Room 820", "Room 822", "Room 823", "Room 824", "Room 825", "Room 826", "Room 828", "Room 902", "Room 903", "Room 904", "Room 905", "Room 906", "Room 907", "Room 908", "Room 909", "Room 910", "Room 911", "Room 913", "Room 914", "Room 916", "Room 919", "Room 920", "Room 922", "Room 924", "Room 927", "Room 929", "Room 931", "Room 933", "Room 935", "Hall 200x900", "Hall 200x700", "Hall 200x300", "Room 201", "Room 202", "Room 203", "Room 204", "Room 205", "Room 206", "Room 207", "Room 208", "Room 209", "Room 210", "Room 211", "Room 213", "Room 215", "Room 217", "Room 220"
        });
        endingInputObj.GetComponentInChildren<AutoCompleteComboBox>().setAvailableOptions(new List<string>(){"Entrance 1", "Entrance 2", "Entrance 3", "Entrance 4", "Entrance 5", "Hall 100", "Hall 800x900", "Hall 500x800", "Hall 100x800", "Hall 650x900", "Hall 600x900", "Hall 400x900", "Hall 500x650", "Hall 500x600", "Hall 400x500", "Hall 650", "Hall 600x700", "Hall 300x600", "Hall 300x400", "Hall 250x300", "Hall 250", "Hall 250x700", "Hall 400x700", "Room 102", "Room 104", "Room 106", "Room 250", "Room 251", "Room 253", "Room 254", "Room 255", "Room 257", "Room 259", "Room 260", "Room 262", "Room 264", "Room 265", "Room 302", "Room 304", "Room 306", "Room 307", "Room 309", "Room 315", "Room 316", "Room 318", "Room 319", "Room 321", "Room 320", "Room 323", "Room 405", "Room 407", "Room 409", "Room 411", "Room 413", "Room 415", "Room 416", "Room 418", "Room 515", "Room 516", "Room 517", "Room 518", "Room 519", "Room 520", "Room 521", "Room 523", "Room 527", "Room 529", "Room 601", "Room 604", "Room 605", "Room 606", "Room 607", "Room 608", "Room 610", "Room 611", "Room 612", "Room 613", "Room 651", "Room 652", "Room 653", "Room 654", "Room 655", "Room 656", "Room 657", "Room 658", "Room 659", "Room 701", "Room 703", "Room 705", "Room 707", "Room 708", "Room 715", "Room 716", "Room 717", "Room 718", "Room 719", "Room 722", "Room 723", "Room 802", "Room 804", "Room 806", "Room 808", "Room 810", "Room 812", "Room 811", "Room 813", "Room 814", "Room 815", "Room 816", "Room 818", "Room 820", "Room 822", "Room 823", "Room 824", "Room 825", "Room 826", "Room 828", "Room 902", "Room 903", "Room 904", "Room 905", "Room 906", "Room 907", "Room 908", "Room 909", "Room 910", "Room 911", "Room 913", "Room 914", "Room 916", "Room 919", "Room 920", "Room 922", "Room 924", "Room 927", "Room 929", "Room 931", "Room 933", "Room 935", "Hall 200x900", "Hall 200x700", "Hall 200x300", "Room 201", "Room 202", "Room 203", "Room 204", "Room 205", "Room 206", "Room 207", "Room 208", "Room 209", "Room 210", "Room 211", "Room 213", "Room 215", "Room 217", "Room 220"
        });
    }
}

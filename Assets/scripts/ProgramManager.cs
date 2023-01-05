using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Globalization;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
using System.ComponentModel;

//REMOVE: 22, 31, 6

//for the record, bad way to use objects in unity
public class ProgramManager : MonoBehaviour {
    public InputField startInputField;
    public InputField endInputField;
    public TMP_Text stepsTextField;
    string start;
    string end;

    //objects of tmp texts
    public GameObject stillNeedHelpObj;
    public GameObject startingLocationObj;
    public GameObject invalidStartingLocation;
    public GameObject invalidEndingLocation;

    private float z = 1; //default z coord so path shows

    public GameObject mapCanvas;

    public PathManager PathM;
    public AutoCompleteComboBox startingOptions;
    public AutoCompleteComboBox endingOptions;

    private List<Node> list; //holds calculated list of nodes that will be traveled to

    //holds "special" nodes that need more than one coord for pathing
    private List<Node> special;

    List<Node> directory;
    DijkstraShortestPath shortestPath;


    public Node node1; //Entrance 1
    public Node node2; //Entrance 2
    public Node node3; //Entrance 3
    public Node node4; //Entrance 4
    public Node node5; //Entrance 5

    public Node node6; //Hall 100

    // nodes for hall 800 and its connectors
    public Node node7; //Hall 800x900
    public Node node9; //Hall 500x800
    public Node node11; //Hall 100x800

    // nodes for hall 900 and its connectors(established connectors look above)
    public Node node13; //Hall 650x900
    public Node node14; //Hall 600x900
    public Node node16; //Hall 400x900

    // nodes for hall 500 and its connectors(established connectors look above)
    public Node node18; //Hall 500x650
    public Node node19; //Hall 500x600
    public Node node21; //Hall 400x500

    public Node node22; //Hall 650

    // nodes for hall 600 and its connectors(established connectors look above)
    public Node node154; //Hall 600x700

    public Node node26; //Hall 300x600

    // nodes for hall 300 and its connectors(established connectors look above)
    // public Node node28; //Hall 300 East
    public Node node28; //Hall 300x400
    public Node node29; //Hall 250x300

    // nodes for hall 250 and its connectors(established connectors look above)
    public Node node31; //Hall 250
    public Node node32; //Hall 250x700

    public Node node34; //Hall 400x700

    // nodes for rooms
    // 100 rooms
    public Node node38; //Room 102
    public Node node39; //Room 104
    public Node node40; //Room 106

    // 250 rooms
    public Node node41; //Room 250
    public Node node42; //Room 251
    public Node node43; //Room 253
    public Node node44; //Room 254
    public Node node45; //Room 255
    public Node node46; //Room 257
    public Node node47; //Room 259
    public Node node48; //Room 260
    public Node node49; //Room 262
    public Node node50; //Room 264
    public Node node51; //Room 265

    // 300 rooms
    public Node node52; //Room 302
    public Node node53; //Room 304
    public Node node54; //Room 306
    public Node node55; //Room 307
    public Node node56; //Room 309
    public Node node57; //Room 315
    public Node node58; //Room 316
    public Node node59; //Room 318
    public Node node60; //Room 319
    public Node node61; //Room 321
    public Node node62; //Room 320
    public Node node63; //Room 323

    // 400 rooms
    public Node node64; //Room 405
    public Node node65; //Room 407
    public Node node66; //Room 409
    public Node node67; //Room 411
    public Node node69; //Room 413
    public Node node70; //Room 415
    public Node node71; //Room 416
    public Node node72; //Room 418

    // 500 rooms
    public Node node73; //Room 515
    public Node node74; //Room 516
    public Node node75; //Room 517
    public Node node76; //Room 518
    public Node node77; //Room 519
    public Node node78; //Room 520
    public Node node79; //Room 521
    public Node node80; //Room 523
    public Node node81; //Room 527
    public Node node82; //Room 529

    // 600 rooms
    public Node node83; //Room 601
    public Node node84; //Room 604
    public Node node85; //Room 605
    public Node node86; //Room 606
    public Node node87; //Room 607
    public Node node88; //Room 608
    public Node node89; //Room 610
    public Node node90; //Room 611
    public Node node91; //Room 612
    public Node node92; //Room 613

    // 650 rooms
    public Node node93; //Room 651
    public Node node94; //Room 652
    public Node node95; //Room 653
    public Node node96; //Room 654
    public Node node97; //Room 655
    public Node node98; //Room 656
    public Node node99; //Room 657
    public Node node100; //Room 658
    public Node node101; //Room 659

    // 700 rooms
    public Node node102; //Room 701
    public Node node103; //Room 703
    public Node node104; //Room 705
    public Node node105; //Room 707
    public Node node106; //Room 708
    public Node node107; //Room 715
    public Node node108; //Room 716
    public Node node109; //Room 717
    public Node node110; //Room 718
    public Node node111; //Room 719
    public Node node112; //Room 722
    public Node node113; //Room 723

    // 800 rooms
    public Node node114; //Room 802
    public Node node115; //Room 804
    public Node node116; //Room 806
    public Node node117; //Room 808
    public Node node118; //Room 810
    public Node node119; //Room 812
    public Node node120; //Room 811
    public Node node121; //Room 813
    public Node node122; //Room 814
    public Node node123; //Room 815
    public Node node124; //Room 816
    public Node node125; //Room 818
    public Node node126; //Room 820
    public Node node127; //Room 822
    public Node node128; //Room 823
    public Node node129; //Room 824
    public Node node130; //Room 825
    public Node node131; //Room 826
    public Node node132; //Room 828

    // 900 rooms
    public Node node133; //Room 902
    public Node node134; //Room 903
    public Node node135; //Room 904
    public Node node136; //Room 905
    public Node node137; //Room 906
    public Node node138; //Room 907
    public Node node139; //Room 908
    public Node node140; //Room 909
    public Node node141; //Room 910
    public Node node142; //Room 911
    public Node node143; //Room 913
    public Node node177; //Room 914
    public Node node144; //Room 916
    public Node node145; //Room 919
    public Node node146; //Room 920
    public Node node147; //Room 922
    public Node node148; //Room 924
    public Node node149; //Room 927
    public Node node150; //Room 929
    public Node node151; //Room 931
    public Node node152; //Room 933
    public Node node153; //Room 935

    // nodes for hall 200
    public Node node157; //Hall 200x900
    public Node node159; //Hall 200x700
    public Node node161; //Hall 200x300

    // 200 rooms
    public Node node162; //Room 201
    public Node node163; //Room 202
    public Node node164; //Room 203
    public Node node165; //Room 204
    public Node node166; //Room 205
    public Node node167; //Room 206
    public Node node168; //Room 207
    public Node node169; //Room 208
    public Node node170; //Room 209
    public Node node171; //Room 210
    public Node node172; //Room 211
    public Node node173; //Room 213
    public Node node174; //Room 215
    public Node node175; //Room 217
    public Node node176; //Room 220

    private void Awake() {
        startingOptions.setAvailableOptions(new List<string>(){"Entrance 1", "Entrance 2", "Entrance 3", "Entrance 4", "Entrance 5", "Hall 100", "Hall 800x900", "Hall 500x800", "Hall 100x800", "Hall 650x900", "Hall 600x900", "Hall 400x900", "Hall 500x650", "Hall 500x600", "Hall 400x500", "Hall 650", "Hall 600x700", "Hall 300x600", "Hall 300x400", "Hall 250x300", "Hall 250", "Hall 250x700", "Hall 400x700", "Room 102", "Room 104", "Room 106", "Room 250", "Room 251", "Room 253", "Room 254", "Room 255", "Room 257", "Room 259", "Room 260", "Room 262", "Room 264", "Room 265", "Room 302", "Room 304", "Room 306", "Room 307", "Room 309", "Room 315", "Room 316", "Room 318", "Room 319", "Room 321", "Room 320", "Room 323", "Room 405", "Room 407", "Room 409", "Room 411", "Room 413", "Room 415", "Room 416", "Room 418", "Room 515", "Room 516", "Room 517", "Room 518", "Room 519", "Room 520", "Room 521", "Room 523", "Room 527", "Room 529", "Room 601", "Room 604", "Room 605", "Room 606", "Room 607", "Room 608", "Room 610", "Room 611", "Room 612", "Room 613", "Room 651", "Room 652", "Room 653", "Room 654", "Room 655", "Room 656", "Room 657", "Room 658", "Room 659", "Room 701", "Room 703", "Room 705", "Room 707", "Room 708", "Room 715", "Room 716", "Room 717", "Room 718", "Room 719", "Room 722", "Room 723", "Room 802", "Room 804", "Room 806", "Room 808", "Room 810", "Room 812", "Room 811", "Room 813", "Room 814", "Room 815", "Room 816", "Room 818", "Room 820", "Room 822", "Room 823", "Room 824", "Room 825", "Room 826", "Room 828", "Room 902", "Room 903", "Room 904", "Room 905", "Room 906", "Room 907", "Room 908", "Room 909", "Room 910", "Room 911", "Room 913", "Room 914", "Room 916", "Room 919", "Room 920", "Room 922", "Room 924", "Room 927", "Room 929", "Room 931", "Room 933", "Room 935", "Hall 200x900", "Hall 200x700", "Hall 200x300", "Room 201", "Room 202", "Room 203", "Room 204", "Room 205", "Room 206", "Room 207", "Room 208", "Room 209", "Room 210", "Room 211", "Room 213", "Room 215", "Room 217", "Room 220"
        });
        endingOptions.setAvailableOptions(new List<string>(){"Entrance 1", "Entrance 2", "Entrance 3", "Entrance 4", "Entrance 5", "Hall 100", "Hall 800x900", "Hall 500x800", "Hall 100x800", "Hall 650x900", "Hall 600x900", "Hall 400x900", "Hall 500x650", "Hall 500x600", "Hall 400x500", "Hall 650", "Hall 600x700", "Hall 300x600", "Hall 300x400", "Hall 250x300", "Hall 250", "Hall 250x700", "Hall 400x700", "Room 102", "Room 104", "Room 106", "Room 250", "Room 251", "Room 253", "Room 254", "Room 255", "Room 257", "Room 259", "Room 260", "Room 262", "Room 264", "Room 265", "Room 302", "Room 304", "Room 306", "Room 307", "Room 309", "Room 315", "Room 316", "Room 318", "Room 319", "Room 321", "Room 320", "Room 323", "Room 405", "Room 407", "Room 409", "Room 411", "Room 413", "Room 415", "Room 416", "Room 418", "Room 515", "Room 516", "Room 517", "Room 518", "Room 519", "Room 520", "Room 521", "Room 523", "Room 527", "Room 529", "Room 601", "Room 604", "Room 605", "Room 606", "Room 607", "Room 608", "Room 610", "Room 611", "Room 612", "Room 613", "Room 651", "Room 652", "Room 653", "Room 654", "Room 655", "Room 656", "Room 657", "Room 658", "Room 659", "Room 701", "Room 703", "Room 705", "Room 707", "Room 708", "Room 715", "Room 716", "Room 717", "Room 718", "Room 719", "Room 722", "Room 723", "Room 802", "Room 804", "Room 806", "Room 808", "Room 810", "Room 812", "Room 811", "Room 813", "Room 814", "Room 815", "Room 816", "Room 818", "Room 820", "Room 822", "Room 823", "Room 824", "Room 825", "Room 826", "Room 828", "Room 902", "Room 903", "Room 904", "Room 905", "Room 906", "Room 907", "Room 908", "Room 909", "Room 910", "Room 911", "Room 913", "Room 914", "Room 916", "Room 919", "Room 920", "Room 922", "Room 924", "Room 927", "Room 929", "Room 931", "Room 933", "Room 935", "Hall 200x900", "Hall 200x700", "Hall 200x300", "Room 201", "Room 202", "Room 203", "Room 204", "Room 205", "Room 206", "Room 207", "Room 208", "Room 209", "Room 210", "Room 211", "Room 213", "Room 215", "Room 217", "Room 220"
        });
    }

    void Start() {
        stepsTextField.text = "";
        mapCanvas.SetActive(false);


        // creates list of all nodes to use when taking an input
        directory = new List<Node>{
            node1, node2, node3, node4, node5, node6, node7, node9, node11, node13, node14, node16, node18, node19, node21, node22, node26, node28, node29, node31, node32, node34, node38, node39, node40, node41, node42, node43, node44, node45, node46, node47, node48, node49, node50, node51, node52, node53, node54, node55, node56, node57, node58, node59, node60, node61, node62, node63, node64, node65, node66, node67, node69, node70, node71, node72, node73, node74, node75, node76, node77, node78, node79, node80, node81, node82, node83, node84, node85, node86, node87, node88, node89, node90, node91, node92, node93, node94, node95, node96, node97, node98, node99, node100, node101, node102, node103, node104, node105, node106, node107, node108, node109, node110, node111, node112, node113, node114, node115, node116, node117, node118, node119, node120, node121, node122, node123, node124, node125, node126, node127, node128, node129, node130, node131, node132, node133, node134, node135, node136, node137, node138, node139, node140, node141, node142, node143, node144, node145, node146, node147, node148, node149, node150, node151, node152, node153, node154, node157, node159, node161, node162, node163, node164, node165, node166, node167, node168, node169, node170, node171, node172, node173, node174, node175, node176
        };

        // creates connections between the nodes so that you can go between them
        // entrance paths
        node1.addNeighbour(Hall.createInstance(5, node1, node11));
        node11.addNeighbour(Hall.createInstance(5, node11, node1));
        node1.addNeighbour(Hall.createInstance(5, node1, node26)); //entrance 1 and 300x600
        node26.addNeighbour(Hall.createInstance(5, node26, node1)); //^
        node2.addNeighbour(Hall.createInstance(5, node2, node9));
        node3.addNeighbour(Hall.createInstance(5, node3, node7));
        node4.addNeighbour(Hall.createInstance(5, node4, node14));
        node5.addNeighbour(Hall.createInstance(5, node5, node16));

        // path of hall 100 to 100x800
        node11.addNeighbour(Hall.createInstance(5, node11, node6));
        node6.addNeighbour(Hall.createInstance(5, node6, node11));
        // path of hall 100 to room 102
        node6.addNeighbour(Hall.createInstance(2, node6, node38));
        node38.addNeighbour(Hall.createInstance(2, node38, node6));
        // path of hall 100 to room 104
        node6.addNeighbour(Hall.createInstance(2, node6, node39));
        node39.addNeighbour(Hall.createInstance(2, node39, node6));
        // path of hall100 to room 106
        node6.addNeighbour(Hall.createInstance(2, node6, node40));
        node40.addNeighbour(Hall.createInstance(2, node40, node6));

        // path of hall250x700 to hall 250
        node32.addNeighbour(Hall.createInstance(5, node32, node31));
        node31.addNeighbour(Hall.createInstance(5, node31, node32));
        // path of hall 250 to hall 250x300
        node31.addNeighbour(Hall.createInstance(5, node31, node29));
        node29.addNeighbour(Hall.createInstance(5, node29, node31));
        // room 250
        node31.addNeighbour(Hall.createInstance(2, node31, node41));
        node41.addNeighbour(Hall.createInstance(2, node41, node31));
        // room 251
        node31.addNeighbour(Hall.createInstance(2, node31, node42));
        node42.addNeighbour(Hall.createInstance(2, node42, node31));
        // room 253
        node31.addNeighbour(Hall.createInstance(2, node31, node43));
        node43.addNeighbour(Hall.createInstance(2, node43, node31));
        // room 254
        node31.addNeighbour(Hall.createInstance(2, node31, node44));
        node44.addNeighbour(Hall.createInstance(2, node44, node31));
        // room 255
        node31.addNeighbour(Hall.createInstance(2, node31, node45));
        node45.addNeighbour(Hall.createInstance(2, node45, node31));
        // room 257
        node31.addNeighbour(Hall.createInstance(2, node31, node46));
        node46.addNeighbour(Hall.createInstance(2, node46, node31));
        // room 259
        node31.addNeighbour(Hall.createInstance(2, node31, node47));
        node47.addNeighbour(Hall.createInstance(2, node47, node31));
        // room 260
        node31.addNeighbour(Hall.createInstance(2, node31, node48));
        node48.addNeighbour(Hall.createInstance(2, node48, node31));
        // room 262
        node31.addNeighbour(Hall.createInstance(2, node31, node49));
        node49.addNeighbour(Hall.createInstance(2, node49, node31));
        // room 264
        node31.addNeighbour(Hall.createInstance(2, node31, node50));
        node50.addNeighbour(Hall.createInstance(2, node50, node31));
        // room 265
        node31.addNeighbour(Hall.createInstance(2, node31, node51));
        node51.addNeighbour(Hall.createInstance(2, node51, node31));
        /*
        // hall 100x800 to 800S
        node11.addNeighbour(Hall.createInstance(5, node11, node11));
        node11.addNeighbour(Hall.createInstance(5, node11, node11));
        */
        // hall 800S to 500x800
        node11.addNeighbour(Hall.createInstance(5, node11, node9));
        node9.addNeighbour(Hall.createInstance(5, node9, node11));
        // hall 500x800 to 800N
        node9.addNeighbour(Hall.createInstance(5, node9, node7));
        node7.addNeighbour(Hall.createInstance(5, node7, node9));
        /*
        // hall 800N to 800x900
        node7.addNeighbour(Hall.createInstance(5, node7, node7));
        node7.addNeighbour(Hall.createInstance(5, node7, node7));
        */
        // room 802
        node11.addNeighbour(Hall.createInstance(2, node11, node114));
        node114.addNeighbour(Hall.createInstance(2, node114, node11));
        // room 804
        node11.addNeighbour(Hall.createInstance(2, node11, node115));
        node115.addNeighbour(Hall.createInstance(2, node115, node11));
        // room 806
        node11.addNeighbour(Hall.createInstance(2, node11, node116));
        node116.addNeighbour(Hall.createInstance(2, node116, node11));
        // room 808
        node11.addNeighbour(Hall.createInstance(2, node11, node117));
        node117.addNeighbour(Hall.createInstance(2, node117, node11));
        // room 810
        node11.addNeighbour(Hall.createInstance(2, node11, node118));
        node118.addNeighbour(Hall.createInstance(2, node118, node11));
        // room 811
        node11.addNeighbour(Hall.createInstance(2, node11, node120));
        node120.addNeighbour(Hall.createInstance(2, node120, node11));
        // room 812
        node11.addNeighbour(Hall.createInstance(2, node11, node119));
        node119.addNeighbour(Hall.createInstance(2, node119, node11));
        // room 813
        node11.addNeighbour(Hall.createInstance(2, node11, node121));
        node121.addNeighbour(Hall.createInstance(2, node121, node11));
        // room 814
        node11.addNeighbour(Hall.createInstance(2, node11, node122));
        node122.addNeighbour(Hall.createInstance(2, node122, node11));
        // room 815
        node7.addNeighbour(Hall.createInstance(2, node7, node123));
        node123.addNeighbour(Hall.createInstance(2, node123, node7));
        // room 816
        node7.addNeighbour(Hall.createInstance(2, node7, node124));
        node124.addNeighbour(Hall.createInstance(2, node124, node7));
        // room 818
        node7.addNeighbour(Hall.createInstance(2, node7, node125));
        node125.addNeighbour(Hall.createInstance(2, node125, node7));
        // room 820
        node7.addNeighbour(Hall.createInstance(2, node7, node126));
        node126.addNeighbour(Hall.createInstance(2, node126, node7));
        // room 822
        node7.addNeighbour(Hall.createInstance(2, node7, node127));
        node127.addNeighbour(Hall.createInstance(2, node127, node7));
        // room 823
        node7.addNeighbour(Hall.createInstance(2, node7, node128));
        node128.addNeighbour(Hall.createInstance(2, node128, node7));
        // room 824
        node7.addNeighbour(Hall.createInstance(2, node7, node129));
        node129.addNeighbour(Hall.createInstance(2, node129, node7));
        // room 825
        node7.addNeighbour(Hall.createInstance(2, node7, node130));
        node130.addNeighbour(Hall.createInstance(2, node130, node7));
        // room 826
        node7.addNeighbour(Hall.createInstance(2, node7, node131));
        node131.addNeighbour(Hall.createInstance(2, node131, node7));
        // room 828
        node7.addNeighbour(Hall.createInstance(2, node7, node132));
        node132.addNeighbour(Hall.createInstance(2, node132, node7));

        // hall 500x650 to 650
        node18.addNeighbour(Hall.createInstance(5, node18, node22));
        node22.addNeighbour(Hall.createInstance(5, node22, node18));
        // hall 650 to 650x900
        node22.addNeighbour(Hall.createInstance(5, node22, node13));
        node13.addNeighbour(Hall.createInstance(5, node13, node22));
        // room 527
        node18.addNeighbour(Hall.createInstance(2, node18, node81));
        node81.addNeighbour(Hall.createInstance(2, node81, node18));
        // room 529
        node18.addNeighbour(Hall.createInstance(2, node18, node82));
        node82.addNeighbour(Hall.createInstance(2, node82, node18));
        // room 651
        node22.addNeighbour(Hall.createInstance(2, node22, node93));
        node93.addNeighbour(Hall.createInstance(2, node93, node22));
        // room 652
        node22.addNeighbour(Hall.createInstance(2, node22, node94));
        node94.addNeighbour(Hall.createInstance(2, node94, node22));
        // room 653
        node22.addNeighbour(Hall.createInstance(2, node22, node95));
        node95.addNeighbour(Hall.createInstance(2, node95, node22));
        // room 654
        node22.addNeighbour(Hall.createInstance(2, node22, node96));
        node96.addNeighbour(Hall.createInstance(2, node96, node22));
        // room 655
        node22.addNeighbour(Hall.createInstance(2, node22, node97));
        node97.addNeighbour(Hall.createInstance(2, node97, node22));
        // room 656
        node22.addNeighbour(Hall.createInstance(2, node22, node98));
        node98.addNeighbour(Hall.createInstance(2, node98, node22));
        // room 657
        node22.addNeighbour(Hall.createInstance(2, node22, node99));
        node99.addNeighbour(Hall.createInstance(2, node99, node22));
        // room 658
        node22.addNeighbour(Hall.createInstance(2, node22, node100));
        node100.addNeighbour(Hall.createInstance(2, node100, node22));
        // room 659
        node22.addNeighbour(Hall.createInstance(2, node22, node101));
        node101.addNeighbour(Hall.createInstance(2, node101, node22));
        /*
        // hall 300x600 to 600S
        node26.addNeighbour(Hall.createInstance(5, node26, node26));
        node26.addNeighbour(Hall.createInstance(5, node26, node26));
        */
        // hall 600S to 500x600
        node26.addNeighbour(Hall.createInstance(5, node26, node19));
        node19.addNeighbour(Hall.createInstance(5, node19, node26));
        /*
        // hall 500x600 to 600C
        node19.addNeighbour(Hall.createInstance(5, node19, node19));
        node19.addNeighbour(Hall.createInstance(5, node19, node19));
        */
        // hall 600C to 600x700
        node19.addNeighbour(Hall.createInstance(5, node19, node154));
        node154.addNeighbour(Hall.createInstance(5, node154, node19));
        /*
        // hall 600x700 to 600N
        node154.addNeighbour(Hall.createInstance(5, node154, node154));
        node154.addNeighbour(Hall.createInstance(5, node154, node154));
        */
        // hall 600N to 600x900
        node154.addNeighbour(Hall.createInstance(5, node154, node14));
        node14.addNeighbour(Hall.createInstance(5, node14, node154));
        // room 601
        node26.addNeighbour(Hall.createInstance(2, node26, node83));
        node83.addNeighbour(Hall.createInstance(2, node83, node26));
        // room 604, 600S
        node26.addNeighbour(Hall.createInstance(5, node26, node84));
        node84.addNeighbour(Hall.createInstance(5, node84, node26));
        // room 605 600S
        node26.addNeighbour(Hall.createInstance(2, node26, node85));
        node85.addNeighbour(Hall.createInstance(2, node85, node26));
        // room 606
        node19.addNeighbour(Hall.createInstance(2, node19, node86));
        node86.addNeighbour(Hall.createInstance(2, node86, node19));
        // room 607
        node19.addNeighbour(Hall.createInstance(5, node19, node87));
        node87.addNeighbour(Hall.createInstance(5, node87, node19));
        // room 608
        node154.addNeighbour(Hall.createInstance(2, node154, node88));
        node88.addNeighbour(Hall.createInstance(2, node88, node154));
        // room 610
        node154.addNeighbour(Hall.createInstance(2, node154, node89));
        node89.addNeighbour(Hall.createInstance(2, node89, node154));
        // room 611
        node154.addNeighbour(Hall.createInstance(2, node154, node90));
        node90.addNeighbour(Hall.createInstance(2, node90, node154));
        // room 612
        node154.addNeighbour(Hall.createInstance(2, node154, node91));
        node91.addNeighbour(Hall.createInstance(2, node91, node154));
        // room 613
        node14.addNeighbour(Hall.createInstance(2, node14, node92));
        node92.addNeighbour(Hall.createInstance(2, node92, node14));
        /*
        // hall 300x400 to 400S
        node28.addNeighbour(Hall.createInstance(5, node28, node28));
        node28.addNeighbour(Hall.createInstance(5, node28, node28));
        */
        // hall 400S to 400x500
        node28.addNeighbour(Hall.createInstance(5, node28, node21));
        node21.addNeighbour(Hall.createInstance(5, node21, node28));
        /*
        // hall 400x500 to 400C
        node21.addNeighbour(Hall.createInstance(5, node21, node21));
        node21.addNeighbour(Hall.createInstance(5, node21, node21));
        */
        // hall 400C to 400x700
        node21.addNeighbour(Hall.createInstance(5, node21, node34));
        node34.addNeighbour(Hall.createInstance(5, node34, node21));
        /*
        // hall 400x700 to 400NC
        node34.addNeighbour(Hall.createInstance(5, node34, node16));
        node16.addNeighbour(Hall.createInstance(5, node16, node34));
        */
        /*
        // hall 400NC to 400x900
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        */
        /*
        // hall 400x900 to 400N
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        */
        // room 405
        node28.addNeighbour(Hall.createInstance(2, node28, node64));
        node64.addNeighbour(Hall.createInstance(2, node64, node28));
        // room 307
        node28.addNeighbour(Hall.createInstance(2, node28, node55));
        node55.addNeighbour(Hall.createInstance(2, node55, node28));
        // room 309
        node28.addNeighbour(Hall.createInstance(2, node28, node56));
        node56.addNeighbour(Hall.createInstance(2, node56, node28));
        // room 315
        node28.addNeighbour(Hall.createInstance(5, node28, node57));
        node57.addNeighbour(Hall.createInstance(5, node57, node28));
        //room 316
        node28.addNeighbour(Hall.createInstance(5, node28, node58));
        node58.addNeighbour(Hall.createInstance(5, node58, node28));
        // room 407
        node28.addNeighbour(Hall.createInstance(2, node28, node65));
        node65.addNeighbour(Hall.createInstance(2, node65, node28));
        // room 409
        node28.addNeighbour(Hall.createInstance(2, node28, node66));
        node66.addNeighbour(Hall.createInstance(2, node66, node28));
        // room 516
        node28.addNeighbour(Hall.createInstance(5, node28, node74));
        node74.addNeighbour(Hall.createInstance(5, node74, node28));
        // room 411
        node21.addNeighbour(Hall.createInstance(2, node21, node67));
        node67.addNeighbour(Hall.createInstance(2, node67, node21));
        // room 413
        node21.addNeighbour(Hall.createInstance(2, node21, node69));
        node69.addNeighbour(Hall.createInstance(2, node69, node21));
        // room 515
        node21.addNeighbour(Hall.createInstance(5, node21, node73));
        node73.addNeighbour(Hall.createInstance(5, node73, node21));
        // room 716
        node21.addNeighbour(Hall.createInstance(5, node21, node108));
        node108.addNeighbour(Hall.createInstance(5, node108, node21));
        // room 708
        node34.addNeighbour(Hall.createInstance(2, node34, node106));
        node106.addNeighbour(Hall.createInstance(2, node106, node34));
        // room 715
        node34.addNeighbour(Hall.createInstance(5, node34, node107));
        node107.addNeighbour(Hall.createInstance(5, node107, node34));
        // room 707
        node34.addNeighbour(Hall.createInstance(5, node34, node105));
        node105.addNeighbour(Hall.createInstance(5, node105, node34));
        //room 715
        node16.addNeighbour(Hall.createInstance(5, node16, node107));
        node107.addNeighbour(Hall.createInstance(5, node107, node16));
        // room 415
        node16.addNeighbour(Hall.createInstance(2, node16, node70));
        node70.addNeighbour(Hall.createInstance(2, node70, node16));
        // room 416
        node16.addNeighbour(Hall.createInstance(2, node16, node71));
        node71.addNeighbour(Hall.createInstance(2, node71, node16));
        // room 418
        node16.addNeighbour(Hall.createInstance(2, node16, node72));
        node72.addNeighbour(Hall.createInstance(2, node72, node16));
        /*
        // hall 300W to 250x300
        node29.addNeighbour(Hall.createInstance(5, node29, node29));
        node29.addNeighbour(Hall.createInstance(5, node29, node29));
        */
        // hall 250x300 to 300x400
        node29.addNeighbour(Hall.createInstance(5, node29, node28));
        node28.addNeighbour(Hall.createInstance(5, node28, node29));
        /*
        // hall 300x400 to 300E
        node28.addNeighbour(Hall.createInstance(5, node28, node28));
        node28.addNeighbour(Hall.createInstance(5, node28, node28));
        */
        // hall 300E to 300x600
        node28.addNeighbour(Hall.createInstance(5, node28, node26));
        node26.addNeighbour(Hall.createInstance(5, node26, node28));
        // room 302
        node29.addNeighbour(Hall.createInstance(2, node29, node52));
        node52.addNeighbour(Hall.createInstance(2, node52, node29));
        // room 304
        node29.addNeighbour(Hall.createInstance(2, node29, node53));
        node53.addNeighbour(Hall.createInstance(2, node53, node29));
        // room 306
        node29.addNeighbour(Hall.createInstance(2, node29, node54));
        node54.addNeighbour(Hall.createInstance(2, node54, node29));
        // room 315
        node28.addNeighbour(Hall.createInstance(5, node28, node57));
        node57.addNeighbour(Hall.createInstance(5, node57, node28));
        // room 316
        node28.addNeighbour(Hall.createInstance(5, node28, node58));
        node58.addNeighbour(Hall.createInstance(5, node58, node28));
        // room 318
        node28.addNeighbour(Hall.createInstance(2, node28, node59));
        node59.addNeighbour(Hall.createInstance(2, node59, node28));
        // room 319
        node28.addNeighbour(Hall.createInstance(2, node28, node60));
        node60.addNeighbour(Hall.createInstance(2, node60, node28));
        // room 321
        node28.addNeighbour(Hall.createInstance(2, node28, node61));
        node61.addNeighbour(Hall.createInstance(2, node61, node28));
        // room 320
        node28.addNeighbour(Hall.createInstance(2, node28, node62));
        node62.addNeighbour(Hall.createInstance(2, node62, node28));
        // room 323
        node28.addNeighbour(Hall.createInstance(2, node28, node63));
        node63.addNeighbour(Hall.createInstance(2, node63, node28));
        /*
        // hall 400x500 to 500W
        node21.addNeighbour(Hall.createInstance(5, node21, node21));
        node21.addNeighbour(Hall.createInstance(5, node21, node21));
        */
        // hall 500W to  500x600
        node21.addNeighbour(Hall.createInstance(5, node21, node19));
        node19.addNeighbour(Hall.createInstance(5, node19, node21));
        // hall 500x600 to 500x650
        node19.addNeighbour(Hall.createInstance(5, node19, node18));
        node18.addNeighbour(Hall.createInstance(5, node18, node19));
        // hall 500x650 to 500x800
        node18.addNeighbour(Hall.createInstance(5, node18, node9));
        node9.addNeighbour(Hall.createInstance(5, node9, node18));
        // room 515
        node21.addNeighbour(Hall.createInstance(5, node21, node73));
        node73.addNeighbour(Hall.createInstance(5, node73, node21));
        // room 516
        node21.addNeighbour(Hall.createInstance(5, node21, node74));
        node74.addNeighbour(Hall.createInstance(5, node74, node21));
        // room 517
        node21.addNeighbour(Hall.createInstance(2, node21, node75));
        node75.addNeighbour(Hall.createInstance(2, node75, node21));
        // room 518
        node21.addNeighbour(Hall.createInstance(2, node21, node76));
        node76.addNeighbour(Hall.createInstance(2, node76, node21));
        // room 519
        node21.addNeighbour(Hall.createInstance(2, node21, node77));
        node77.addNeighbour(Hall.createInstance(2, node77, node21));
        // room 520
        node21.addNeighbour(Hall.createInstance(2, node21, node78));
        node78.addNeighbour(Hall.createInstance(2, node78, node21));
        // room 521
        node21.addNeighbour(Hall.createInstance(2, node21, node79));
        node79.addNeighbour(Hall.createInstance(2, node79, node21));
        // room 523
        node21.addNeighbour(Hall.createInstance(2, node21, node80));
        node80.addNeighbour(Hall.createInstance(2, node80, node21));
        /*
        // hall 700W to 250x700
        node32.addNeighbour(Hall.createInstance(5, node32, node32));
        node32.addNeighbour(Hall.createInstance(5, node32, node32));
        */
        // hall 250x700 to 400x700
        node32.addNeighbour(Hall.createInstance(5, node32, node34));
        node34.addNeighbour(Hall.createInstance(5, node34, node32));

        // hall 400x700 to 700E
        node34.addNeighbour(Hall.createInstance(5, node34, node154));
        node154.addNeighbour(Hall.createInstance(5, node154, node34));
        /*
        // hall 700E to 600x700
        node154.addNeighbour(Hall.createInstance(5, node154, node154));
        node154.addNeighbour(Hall.createInstance(5, node154, node154));
        */
        //600x700 to 400x700
        node34.addNeighbour(Hall.createInstance(5, node34, node154));
        node154.addNeighbour(Hall.createInstance(5, node154, node34));
        // room 701
        node32.addNeighbour(Hall.createInstance(2, node32, node102));
        node102.addNeighbour(Hall.createInstance(2, node102, node32));
        // room 703
        node32.addNeighbour(Hall.createInstance(2, node32, node103));
        node103.addNeighbour(Hall.createInstance(2, node103, node32));
        // room 705
        node32.addNeighbour(Hall.createInstance(2, node32, node104));
        node104.addNeighbour(Hall.createInstance(2, node104, node32));
        // room 707
        node32.addNeighbour(Hall.createInstance(5, node32, node105));
        node105.addNeighbour(Hall.createInstance(5, node105, node32));
        // room 716
        node154.addNeighbour(Hall.createInstance(5, node154, node108));
        node108.addNeighbour(Hall.createInstance(5, node108, node154));
        // room 717
        node154.addNeighbour(Hall.createInstance(2, node154, node109));
        node109.addNeighbour(Hall.createInstance(2, node109, node154));
        // room 718
        node154.addNeighbour(Hall.createInstance(2, node154, node110));
        node110.addNeighbour(Hall.createInstance(2, node110, node154));
        // room 719
        node154.addNeighbour(Hall.createInstance(2, node154, node111));
        node111.addNeighbour(Hall.createInstance(2, node111, node154));
        // room 722
        node154.addNeighbour(Hall.createInstance(2, node154, node112));
        node112.addNeighbour(Hall.createInstance(2, node112, node154));
        // room 723
        node154.addNeighbour(Hall.createInstance(2, node154, node113));
        node113.addNeighbour(Hall.createInstance(2, node113, node154));
        // room 607
        node154.addNeighbour(Hall.createInstance(5, node154, node87));
        node87.addNeighbour(Hall.createInstance(5, node87, node154));
        /*
        // hall 900W to 400x900
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        node16.addNeighbour(Hall.createInstance(5, node16, node16));
        */
        // hall 400x900 to 900C
        node16.addNeighbour(Hall.createInstance(5, node16, node14));
        node14.addNeighbour(Hall.createInstance(5, node14, node16));
        /*
        // hall 900C to 600x900
        node14.addNeighbour(Hall.createInstance(5, node14, node14));
        node14.addNeighbour(Hall.createInstance(5, node14, node14));
        */
        // hall 600x900 to 650x900
        node14.addNeighbour(Hall.createInstance(5, node14, node13));
        node13.addNeighbour(Hall.createInstance(5, node13, node14));
        /*
        // hall 650x900 to 900E
        node13.addNeighbour(Hall.createInstance(5, node13, node13));
        node13.addNeighbour(Hall.createInstance(5, node13, node13));
        */
        // hall 900E to 800x900
        node13.addNeighbour(Hall.createInstance(5, node13, node7));
        node7.addNeighbour(Hall.createInstance(5, node7, node13));
        // room 902
        node16.addNeighbour(Hall.createInstance(2, node16, node133));
        node133.addNeighbour(Hall.createInstance(2, node133, node16));
        // room 903
        node16.addNeighbour(Hall.createInstance(2, node16, node134));
        node134.addNeighbour(Hall.createInstance(2, node134, node16));
        // room 904
        node16.addNeighbour(Hall.createInstance(2, node16, node135));
        node135.addNeighbour(Hall.createInstance(2, node135, node16));
        // room 905
        node16.addNeighbour(Hall.createInstance(2, node16, node136));
        node136.addNeighbour(Hall.createInstance(2, node136, node16));
        // room 906
        node16.addNeighbour(Hall.createInstance(2, node16, node137));
        node137.addNeighbour(Hall.createInstance(2, node137, node16));
        // room 907
        node16.addNeighbour(Hall.createInstance(2, node16, node138));
        node138.addNeighbour(Hall.createInstance(2, node138, node16));
        // room 908
        node16.addNeighbour(Hall.createInstance(2, node16, node139));
        node139.addNeighbour(Hall.createInstance(2, node139, node16));
        // room 909
        node16.addNeighbour(Hall.createInstance(2, node16, node140));
        node140.addNeighbour(Hall.createInstance(2, node140, node16));
        // room 910
        node16.addNeighbour(Hall.createInstance(2, node16, node141));
        node141.addNeighbour(Hall.createInstance(2, node141, node16));
        // room 911
        node16.addNeighbour(Hall.createInstance(2, node16, node142));
        node142.addNeighbour(Hall.createInstance(2, node142, node16));
        // room 913
        node16.addNeighbour(Hall.createInstance(2, node16, node143));
        node143.addNeighbour(Hall.createInstance(2, node143, node16));
        // room 916
        node14.addNeighbour(Hall.createInstance(2, node14, node144));
        node144.addNeighbour(Hall.createInstance(2, node144, node14));
        // room 919
        node14.addNeighbour(Hall.createInstance(2, node14, node145));
        node145.addNeighbour(Hall.createInstance(2, node145, node14));
        // room 920
        node14.addNeighbour(Hall.createInstance(2, node14, node146));
        node146.addNeighbour(Hall.createInstance(2, node146, node14));
        // room 922
        node14.addNeighbour(Hall.createInstance(2, node14, node147));
        node147.addNeighbour(Hall.createInstance(2, node147, node14));
        // room 924
        node14.addNeighbour(Hall.createInstance(2, node14, node148));
        node148.addNeighbour(Hall.createInstance(2, node148, node14));
        // room 927
        node14.addNeighbour(Hall.createInstance(5, node14, node149));
        node149.addNeighbour(Hall.createInstance(5, node149, node14));
        // room 929
        node13.addNeighbour(Hall.createInstance(5, node13, node150));
        node150.addNeighbour(Hall.createInstance(5, node150, node13));
        // room 931
        node13.addNeighbour(Hall.createInstance(2, node13, node151));
        node151.addNeighbour(Hall.createInstance(2, node151, node13));
        // room 933
        node13.addNeighbour(Hall.createInstance(2, node13, node152));
        node152.addNeighbour(Hall.createInstance(2, node152, node13));
        // room 935
        node13.addNeighbour(Hall.createInstance(2, node13, node153));
        node153.addNeighbour(Hall.createInstance(2, node153, node13));
        /*
        // path of hall 200N to 200x900
        node157.addNeighbour(Hall.createInstance(5, node157, node157));
        node157.addNeighbour(Hall.createInstance(5, node157, node157));
        */
        // path of hall 200x900 to 900W
        node157.addNeighbour(Hall.createInstance(5, node157, node16));
        node16.addNeighbour(Hall.createInstance(5, node16, node157));
        /*
        // path of hall 200x900 to 200 central
        node157.addNeighbour(Hall.createInstance(5, node157, node159));
        node159.addNeighbour(Hall.createInstance(5, node159, node157));
        */
        //path of hall 200C to 200x700
        node159.addNeighbour(Hall.createInstance(5, node159, node159));
        node159.addNeighbour(Hall.createInstance(5, node159, node159));
        // path of hall 200x700 to 700W
        node159.addNeighbour(Hall.createInstance(5, node159, node32));
        node32.addNeighbour(Hall.createInstance(5, node32, node159));
        // path of  hall 200x700 to 200S
        node159.addNeighbour(Hall.createInstance(5, node159, node161));
        node161.addNeighbour(Hall.createInstance(5, node161, node159));
        // path of hall 200S to 200x300
        node161.addNeighbour(Hall.createInstance(5, node161, node161));
        node161.addNeighbour(Hall.createInstance(5, node161, node161));
        // path of hall 200x300 to 300W
        node161.addNeighbour(Hall.createInstance(5, node161, node29));
        node29.addNeighbour(Hall.createInstance(5, node29, node161));
        // room 201
        node161.addNeighbour(Hall.createInstance(2, node161, node162));
        node162.addNeighbour(Hall.createInstance(2, node162, node161));
        // room 202
        node161.addNeighbour(Hall.createInstance(2, node161, node163));
        node163.addNeighbour(Hall.createInstance(2, node163, node161));
        // room 203
        node161.addNeighbour(Hall.createInstance(2, node161, node164));
        node164.addNeighbour(Hall.createInstance(2, node164, node161));
        // room 204
        node161.addNeighbour(Hall.createInstance(2, node161, node165));
        node165.addNeighbour(Hall.createInstance(2, node165, node161));
        // room 205
        node161.addNeighbour(Hall.createInstance(2, node161, node166));
        node166.addNeighbour(Hall.createInstance(2, node166, node161));
        // room 206
        node161.addNeighbour(Hall.createInstance(2, node161, node167));
        node167.addNeighbour(Hall.createInstance(2, node167, node161));
        // room 207
        node161.addNeighbour(Hall.createInstance(2, node161, node168));
        node168.addNeighbour(Hall.createInstance(2, node168, node161));
        // room 208
        node161.addNeighbour(Hall.createInstance(2, node161, node169));
        node169.addNeighbour(Hall.createInstance(2, node169, node161));
        // room 209
        node161.addNeighbour(Hall.createInstance(2, node161, node170));
        node170.addNeighbour(Hall.createInstance(2, node170, node161));
        // room 210
        node161.addNeighbour(Hall.createInstance(2, node161, node171));
        node171.addNeighbour(Hall.createInstance(2, node171, node161));
        // room 211
        node161.addNeighbour(Hall.createInstance(2, node161, node172));
        node172.addNeighbour(Hall.createInstance(2, node172, node161));
        // room 213
        node159.addNeighbour(Hall.createInstance(2, node159, node173));
        node173.addNeighbour(Hall.createInstance(2, node173, node159));
        // room 215
        node159.addNeighbour(Hall.createInstance(2, node159, node174));
        node174.addNeighbour(Hall.createInstance(2, node174, node159));
        // room 217
        node157.addNeighbour(Hall.createInstance(2, node157, node175));
        node175.addNeighbour(Hall.createInstance(2, node175, node157));
        // room 220
        node157.addNeighbour(Hall.createInstance(2, node157, node176));
        node176.addNeighbour(Hall.createInstance(2, node176, node157));

        /*
        //adding pathing coords to halls
        node1.addCoord(3.94f, -2.5f);
        node1.addCoord(4.2f, -3.2f); //actual entrance 1
        node1.addCoord(5, -3.55f);

        node11.addCoord(7.12f, -3.56f);
        node9.addCoord(7.12f, -.44f);
        node7.addCoord(7.12f, 2.61f);
        node13.addCoord(5.41f, 2.61f);
        node18.addCoord(5.41f, -.46f);
        node19.addCoord(3.94f, -.46f);
        node154.addCoord(3.94f, 1.05f);
        node34.addCoord(0.64f, 1.05f);
        node16.addCoord(.64f, 2.61f);
        node14.addCoord(3.94f, 2.61f);
        node26.addCoord(3.94f, -2.01f);
        node28.addCoord(.64f, -2.01f);
        node21.addCoord(.64f, -.44f);
        node32.addCoord(-1.05f, 1.05f);
        node29.addCoord(-1.05f, -2.01f);
        node161.addCoord(-2.71f, -2.01f);
        node159.addCoord(-2.71f, 1.05f);
        node157.addCoord(-2.71f, 2.61f);
        */


        


        // creates object of DijkstraShortestPath class
        shortestPath = ScriptableObject.CreateInstance<DijkstraShortestPath>();
    }

    public GameObject startingList;
    public GameObject endingList;
    public void afterACCB() {
        Vector2 widthHeight = new Vector2(150, 27); //width & height of each selection's rect transform (in dropdown)

        for (int i = 0; i < startingList.transform.childCount; i++) {
            startingList.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = widthHeight;
        }
        for (int i = 0; i < endingList.transform.childCount; i++) {
            endingList.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = widthHeight;
        }
    }

    public void doAll() { //when submit is pressed
        stepsTextField.text = "";
        // input for start and end
        start = startInputField.text;
        end = endInputField.text;
        // for loop to find the start based on the input in the directory of all nodes

        Node startNode = null;
        foreach (Node s in directory) {
            if (s!=null && s.getName().Equals(start)) { //start = Scanner input
                startNode = s;
                break;
            }
        }

        //checker if user inputted bad node name
        if (startNode == null) {
            Debug.Log("bad start name");
            invalidStartingLocation.SetActive(true);
            return;
        }
        else {
            invalidStartingLocation.SetActive(false);
        }
        
        // for loop to find the destination based on the input in the directory of all nodes
        Node endNode = null;
        foreach (Node s in directory) {
            if (s != null && s.getName().Equals(end)) { //end = Scanner input
                endNode = s;
                break;
            }
        }

        if (endNode == null) {
            Debug.Log("bad end name");
            invalidEndingLocation.SetActive(true);
            return;
        }
        else {
            invalidEndingLocation.SetActive(false);
        }

        // calls the function from the dijkstraShortestPath class to get the shortest distances to every node from the starting node
        shortestPath.computeShortestPaths(startNode);

        // for loop to display the directions to get to the destination from the start point
        list = shortestPath.getShortestPathTo(endNode);
        for (int i = 0; i < list.Count; i++) {
            if (i == 0) {
                //first starting location direction
                stepsTextField.text += "   From " + shortestPath.getShortestPathTo(endNode)[0] + ",\n";
            }
            else {
                stepsTextField.text += i + ") Go to " + list[i] + "\n";
            }

            if (checkSpecial(list[i], i)) {
                continue;
            }

            PathM.addNodeLocation(list[i]);
        }

        PathM.generatePath();

        startingLocationObj.SetActive(false);
        stillNeedHelpObj.SetActive(true);

        // input to check if arrived
        //start = startInputField.text;

        //resetting for next find (when button is pressed)
        foreach (Node s in directory) {
            s.setDistance(int.MaxValue);
            s.setVisited(false);
            s.setPredecessor(null);
        }

        PathM.resetPath();
    }

    bool checkSpecial(Node a, int index) { //for nodes with more than 1 coord (in pathing)
        if (a == node1) {
            List<float> xCoords = a.getXCoords();
            List<float> yCoords = a.getYCoords();

            if (index + 1 >= list.Count || index - 1 < 0) { //if first or last point
                PathM.addNodeLocation(new Vector3(xCoords[xCoords.Count / 2], yCoords[yCoords.Count / 2], z)); // /2 gets the middle coord (of List) which is the actual node's coord
                Debug.Log("??");
                return true;
            }
            else if (list[index - 1] == node26) {
                for (int j = 0; j < a.getXCoords().Count; j++) {
                    PathM.addNodeLocation(new Vector3(xCoords[j], yCoords[j], z));
                }
                Debug.Log("special");
            }
            else if (list[index - 1] == node11){
                for (int j = a.getXCoords().Count - 1; j <= 0; j--) {
                    PathM.addNodeLocation(new Vector3(xCoords[j], yCoords[j], z));
                }
            }
            return true;
        }

        return false;
    }
}
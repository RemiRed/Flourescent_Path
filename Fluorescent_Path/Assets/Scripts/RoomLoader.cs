using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RoomLoader : NetworkBehaviour
{
    [SerializeField]
    GameObject corridorPrefab;

    [SerializeField]
    GameObject finalRoomPrefab;

    [SerializeField]
    GameObject doorPrefab;

    [SerializeField]
    int numberOfRooms;
    GameObject[] roomsP1, roomsP2;
    [SerializeField]
    List<GameObject> availableRooms = new List<GameObject>();

    [SerializeField]
    GameObject currentRoomP1, currentRoomP2;

    [SerializeField]
    GameObject currentCorridorP1, currentCorridorP2;

    [SyncVar]
    public bool clearedRoom;

    int nextRoomNumber;

    [SerializeField]
    List<GameObject> doorsP1 = new List<GameObject>();

    [SerializeField]
    List<GameObject> doorsP2 = new List<GameObject>();

    private void Start()
    {
        CmdRandomizeRooms();
    }

    [Command]
    void CmdRandomizeRooms()
    {
        roomsP1 = new GameObject[numberOfRooms];
        for (int i = 0; i < roomsP1.Length; i++)
        {
            int randomP1 = Random.Range(0, availableRooms.Count);
            roomsP1[i] = availableRooms[randomP1];
            availableRooms.RemoveAt(randomP1);
            GameObject compatableRoom = roomsP1[i].GetComponent<RoomVariables>().compatibleRooms[Random.Range(0, roomsP1[i].GetComponent<RoomVariables>().compatibleRooms.Count)];
            roomsP2[i] = compatableRoom;
            availableRooms.Remove(compatableRoom);
            roomsP1[i].GetComponent<RoomVariables>().pairedRoom = roomsP2[i];
            roomsP2[i].GetComponent<RoomVariables>().pairedRoom = roomsP1[i];
        }

    }
    [Command]
    public void CmdLoad() //Loads the next room, or last room if the last room is the next room
    {
        if (nextRoomNumber < roomsP1.Length)
        {
            LoadNextRoom();
        }
        else
        {
            LoadFinalRoom();
        }
    }

    public void UnloadCorridor() //Unloads the previous corridor. Call this after entering the next room
    {
        Destroy(currentCorridorP1);
        Destroy(currentCorridorP2);
        if (nextRoomNumber < roomsP1.Length)
        {
            currentCorridorP1 = Instantiate(corridorPrefab, currentCorridorP1.transform.position + new Vector3(0, 0, currentRoomP1.GetComponent<RoomVariables>().length + currentCorridorP1.GetComponent<RoomVariables>().length), new Quaternion());
        }

        if (nextRoomNumber < roomsP2.Length)
        {
            currentCorridorP2 = Instantiate(corridorPrefab, currentCorridorP2.transform.position + new Vector3(0, 0, currentRoomP2.GetComponent<RoomVariables>().length + currentCorridorP2.GetComponent<RoomVariables>().length), new Quaternion());
        }

        Destroy(doorsP1[0]);
        doorsP1.RemoveAt(0);
        Destroy(doorsP2[0]);
        doorsP2.RemoveAt(0);

    }

    void LoadFinalRoom() //Loads the final room
    {
        Destroy(currentRoomP1);
        Destroy(currentRoomP2);

        currentRoomP1 = Instantiate(finalRoomPrefab, currentCorridorP1.transform.position + new Vector3(0, 0, (finalRoomPrefab.GetComponent<RoomVariables>().length + currentCorridorP1.GetComponent<RoomVariables>().length) / 2f), new Quaternion());
        currentRoomP2 = Instantiate(finalRoomPrefab, currentCorridorP2.transform.position + new Vector3(0, 0, (finalRoomPrefab.GetComponent<RoomVariables>().length + currentCorridorP2.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doorsP1.Add(Instantiate(doorPrefab, currentCorridorP1.transform.position + new Vector3(0, 1.25f, (finalRoomPrefab.GetComponent<RoomVariables>().length * 2 + currentCorridorP1.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));
        doorsP2.Add(Instantiate(doorPrefab, currentCorridorP2.transform.position + new Vector3(0, 1.25f, (finalRoomPrefab.GetComponent<RoomVariables>().length * 2 + currentCorridorP2.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

    }

    void LoadNextRoom() //Loads the next room
    {
        Destroy(currentRoomP1);
        Destroy(currentRoomP2);

        currentRoomP1 = Instantiate(roomsP1[nextRoomNumber], currentCorridorP1.transform.position + new Vector3(0, 0, (roomsP1[nextRoomNumber].GetComponent<RoomVariables>().length + currentCorridorP1.GetComponent<RoomVariables>().length) / 2f), new Quaternion());
        currentRoomP2 = Instantiate(roomsP2[nextRoomNumber], currentCorridorP1.transform.position + new Vector3(0, 0, (roomsP2[nextRoomNumber].GetComponent<RoomVariables>().length + currentCorridorP2.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doorsP1.Add(Instantiate(doorPrefab, currentCorridorP1.transform.position + new Vector3(0, 1.25f, (roomsP1[nextRoomNumber].GetComponent<RoomVariables>().length * 2 + currentCorridorP1.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));
        doorsP2.Add(Instantiate(doorPrefab, currentCorridorP2.transform.position + new Vector3(0, 1.25f, (roomsP2[nextRoomNumber].GetComponent<RoomVariables>().length * 2 + currentCorridorP2.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

        nextRoomNumber++;
    }

}

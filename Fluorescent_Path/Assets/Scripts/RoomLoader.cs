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
    GameObject[] rooms;
    [SerializeField]
    List<GameObject> availableRooms = new List<GameObject>();

    [SerializeField]
    GameObject currentRoom;

    [SerializeField]
    GameObject currentCorridor;

    [SyncVar]
    public bool clearedRoom;

    int nextRoomNumber;

    [SerializeField]
    List<GameObject> doors = new List<GameObject>();

    private void Start()
    {
        rooms = new GameObject[numberOfRooms];
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = availableRooms[Random.Range(0, availableRooms.Count)];
        }
    }

    public void Load() //Loads the next room, or last room if the last room is the next room
    {
        if (nextRoomNumber < rooms.Length)
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
        Destroy(currentCorridor);
        if (nextRoomNumber < rooms.Length)
        {
            currentCorridor = Instantiate(corridorPrefab, currentCorridor.transform.position + new Vector3(0, 0, currentRoom.GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length), new Quaternion());
        }
        Destroy(doors[0]);
        doors.RemoveAt(0);

    }

    void LoadFinalRoom() //Loads the final room
    {
        Destroy(currentRoom);
        currentRoom = Instantiate(finalRoomPrefab, currentCorridor.transform.position + new Vector3(0, 0, (finalRoomPrefab.GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doors.Add(Instantiate(doorPrefab, currentCorridor.transform.position + new Vector3(0, 1.25f, (finalRoomPrefab.GetComponent<RoomVariables>().length * 2 + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

    }

    void LoadNextRoom() //Loads the next room
    {
        Destroy(currentRoom);
        currentRoom = Instantiate(rooms[nextRoomNumber], currentCorridor.transform.position + new Vector3(0, 0, (rooms[nextRoomNumber].GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doors.Add(Instantiate(doorPrefab, currentCorridor.transform.position + new Vector3(0, 1.25f, (rooms[nextRoomNumber].GetComponent<RoomVariables>().length * 2 + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

        nextRoomNumber++;
    }

}

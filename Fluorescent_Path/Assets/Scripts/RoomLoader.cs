using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
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

    public void Load()
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

    public void UnloadCorridor()
    {
        Destroy(currentCorridor);
        if (nextRoomNumber < rooms.Length)
        {
            currentCorridor = Instantiate(corridorPrefab, currentCorridor.transform.position + new Vector3(0, 0, currentRoom.GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length), new Quaternion());
        }
        Destroy(doors[0]);
        doors.RemoveAt(0);

    }

    void LoadFinalRoom()
    {
        Destroy(currentRoom);
        currentRoom = Instantiate(finalRoomPrefab, currentCorridor.transform.position + new Vector3(0, 0, (finalRoomPrefab.GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doors.Add(Instantiate(doorPrefab, currentCorridor.transform.position + new Vector3(0, 1.25f, (finalRoomPrefab.GetComponent<RoomVariables>().length * 2 + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

    }

    void LoadNextRoom()
    {
        Destroy(currentRoom);
        currentRoom = Instantiate(rooms[nextRoomNumber], currentCorridor.transform.position + new Vector3(0, 0, (rooms[nextRoomNumber].GetComponent<RoomVariables>().length + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion());

        doors.Add(Instantiate(doorPrefab, currentCorridor.transform.position + new Vector3(0, 1.25f, (rooms[nextRoomNumber].GetComponent<RoomVariables>().length * 2 + currentCorridor.GetComponent<RoomVariables>().length) / 2f), new Quaternion()));

        nextRoomNumber++;
    }

}

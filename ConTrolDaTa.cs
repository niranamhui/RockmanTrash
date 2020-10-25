using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.UI;

public class ConTrolDaTa : MonoBehaviour
{
    public GameDATA data;
    string dataFillePath; 
    BinaryFormatter bf; 

    private void Awake()
    {
        bf = new BinaryFormatter();
        dataFillePath = Application.persistentDataPath + "/game.dat"; // ไม่ว่าเกมนี่จะไปอยู่lokationไหน เอามาให้ฉัน
    }
    public void UpdateData()
    {
        data.Score = CoinData.Score;
    }

    public void SaveData()
    {
        UpdateData();// เรียกใช้ฟังชั้น
        FileStream fs = new FileStream(dataFillePath, FileMode.Create); // สร้างไฟล์stream ให้สร้างไฟล์ชื่อ ตัวแดงตรง Awake datafile
        bf.Serialize(fs, data); // เอาข้อมูลdata จาก UpdateData มาใส่ในตัวแปร df และเปลี่ยนเป็นภาษาคอมพิวเตอร์
        fs.Close(); // สั่งปิดกันโดนแฮ็ก
    }

    public void LoadData()
    {
        if (File.Exists(dataFillePath)) // ถ้ามีไฟล์ dataFilePath
        {
            FileStream fs = new FileStream(dataFillePath, FileMode.Open); //เปิดไฟล์ที่สร้างเอาไว้
            data = (GameDATA)bf.Deserialize(fs); // เปิดไฟล์เป็นภาษามนุษย์ และหลอกคอมพิวเตอร์ว่าdata คือ ภาษาคอมพิวเตอร์
            fs.Close(); // สั่งปิดกันโดนแฮ็ก
            DisplayData();
        }
    }

    void DisplayData() //นักศึกษาต้องปรับเปลี่ยนตามตัวแปรในเกมของตนเอง เขียนเพื่อเอาขู้อมุลในไฟล์มาแสดงผล
    {
        GameObject.FindGameObjectWithTag("ScoreTxet").GetComponent<Text>().text = data.Score.ToString();//เอาข้อมูลเก่าในไฟล์มาโชว์
        CoinData.Score = data.Score; // ดึงข้อมูลจากฐานข้อมูล มาอัพเดต
    }

    private void OnEnable() // คือฟัั่งที่เปิดมาหลังAwake คือเปิดไฟล์ขึ้นมา
    {
        LoadData();
    }
    private void OnDisable() // เมื่อปิดเกมให้เซฟข้อมูลDATAให้ด้วย
    {
        SaveData();
    }
}

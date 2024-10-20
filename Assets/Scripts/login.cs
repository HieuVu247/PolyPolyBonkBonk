using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DangKyTaiKhoan : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI thongbao;
    public GameObject dangNhapPanel; 

    private string filePath;

    private void Start()
    {
        filePath = Application.dataPath + "/Data/taiKhoan.txt";

        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public void DangKyButton()
    {
        StartCoroutine(DangKy());
    }

    private IEnumerator DangKy()
    {
        if (KiemTraTaiKhoanTonTai(username.text))
        {
            thongbao.text = "Tài khoản đã tồn tại";
        }
        else
        {
            LuuThongTinTaiKhoan(username.text, password.text);
            thongbao.text = "Đăng ký thành công";
        }

        yield return null;
    }

    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());
    }

    private IEnumerator DangNhap()
    {
        if (KiemTraThongTinDangNhap(username.text, password.text))
        {
            thongbao.text = "Đăng nhập thành công";
            SceneManager.LoadScene("map1");
        }
        else
        {
            thongbao.text = "Tên đăng nhập hoặc mật khẩu không đúng";
        }

        yield return null;
    }

    private bool KiemTraTaiKhoanTonTai(string user)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(':');
                if (data.Length > 0 && data[0] == user)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void LuuThongTinTaiKhoan(string user, string pass)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(user + ":" + pass);
        }
    }

    private bool KiemTraThongTinDangNhap(string user, string pass)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(':');
                if (data.Length == 2 && data[0] == user && data[1] == pass)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ChuyenSangDangNhap()
    {
        dangNhapPanel.SetActive(true); 
        gameObject.SetActive(false);
    }
}

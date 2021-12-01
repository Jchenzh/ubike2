using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
// 下載 Newtonsoft.Json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ubike2
{
    }
public class Ubike
{
    public List<Lot> lots = Update();
    public List<string> arealist;

    static public List<Lot> Update()
    {
        // request請求
        string url = "https://tcgbusfs.blob.core.windows.net/dotapp/youbike/v2/youbike_immediate.json";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Timeout = 10000; // request逾時時間
        req.Method = "GET"; // request方式

        // 接收respone
        // 讀取respone資料 到最後一行
        HttpWebResponse respone = (HttpWebResponse)req.GetResponse();
        StreamReader streamReader = new StreamReader(respone.GetResponseStream(), Encoding.UTF8);

        string result = streamReader.ReadToEnd();

        respone.Close();
        streamReader.Close();

        // 將資料轉為json物件
        List<Lot> jsondata = JsonConvert.DeserializeObject<List<Lot>>(result);
        return jsondata;
    }
    public List<string> Updatearea()
    {
        List<string> li = new List<string> { "all"};
        foreach (Lot a in lots) 
        {
            if(!li.Contains(a.sarea)) li.Add(a.sarea);
        }
        arealist = li;
        return li;
    }

    public Lot getdata(string lot)
    {
        foreach (Lot l in lots) if (l.sna == lot) return l;
        return lots[0];
    }
    public List<Lot> area(string area) 
    {
        List<Lot> al = new List<Lot>();
        if (area == "all") return lots;
        else foreach(Lot l in lots)
            {
                if (l.sarea == area) al.Add(l);
            }
        return al;
    }

}
    
public class Lot
{
    // 站名
    public string sna { set; get; }
    // 地址
    public string ar { set; get; }
    // 區
    public string sarea { set; get; }
    // 總數
    public int tot { set; get; }
    // 可借
    public int sbi { set; get; }
    // 可停
    public int bemp { set; get; }
    // 更新時間
    public string updatetime { set; get; }

    public override string ToString()
    {
        string s = "";
        s +=  sna + 
            "\n站位數：" + tot +"\n" +
            "\n地址：\n" + ar + "\n" +
            "\n更新時間：\n" + updatetime + "\n";
        return s;
    }
    static public string Show(string sna)
    {
        return sna;
    }

}

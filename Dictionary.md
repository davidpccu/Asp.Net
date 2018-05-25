### Dictonrary 列舉

可以將Dictionary想成簡單的google翻譯，輸入你要查的單字(Key)例如apple，
他就會回傳相對應的值(Value) 蘋果。

``` C#
// 建立一個簡單的湘北籃球隊範例

Dictionary <int , BasketballPlayer> ShuKoKu_Numbers = new Dictionary < int, BasketballPlayer>()
{
    {4, new BasketballPlayer ( "赤木",202)},
    {7, new BasketballPlayer ( "官城",170)},
    {10, new BasketballPlayer ( "櫻木",189)},
    {11, new BasketballPlayer ( "流川",188)},
    {14, new BasketballPlayer ( "三井",176)},
};

//BasketballPlayer 類別
class BasketballPlayer
{
    //Name屬性:姓名
    public string Name { get; private set; }
    //Height屬性:身高
    public int Height { get; private set; }

    //建構子，初始化。
    public BasketballPlayer(string name, int height)
    {
        Name = name;
        Height = height;
    }
}

```

> 用Foreach將Dictionary的資料取出

``` C#

private void button1_Click(object sender, EventArgs e)
{
    foreach (KeyValuePair  item in ShuKoKu_Numbers)
    {
        Console.WriteLine("索引值為:" + item.Key + " 值為:" + item.Value.Name);
    }
}

```

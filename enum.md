### enum 列舉

列舉類型提供有效率的方式，來定義一組可指派給變數的具名整數常數。

例如，假設您必須定義一個變數，其值代表星期幾。 該變數只會儲存七個有意義的值。 

若要定義這些值，您可以使用以 enum 關鍵字宣告的列舉類型。

``` C#

enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
enum Month : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }; 

```

> 經典案例 - 貪吃蛇

``` C#

private int direction;  //0:上 1:下 2:左 3:右

public void move() //移動的function
{
    switch (direction)
    {
        case 0://上
            y++;
            break;
        case 1://下
            y--;
            break;
        case 2://左
            x++;
            break;
        case 3://右
            x--;
            break;
    }
}

```
開始寫比較大型的程式的時候，往往定義到後面根本搞不清楚，或者忘記更新，最糟糕的是拜複製/貼上大法所賜，忘記改值，於是陷入DEBUG的深遠。

> 經典案例(改)

``` C#

public enum eDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
}
public void move()
{
    switch (direction)
    {
        case eDirection.UP:
            y++;
            break;
        case eDirection.DOWN:
            y--;
            break;
        case eDirection.LEFT:
            x++;
            break;
        case eDirection.RIGHT:
            x--;
            break;
    }
}

```
>可增加程式碼的可讀性


 第二個例子，可以新增一個 Identity 的 Enum，統一管理使用者身分的值，這樣程式可讀性佳，要改變值也只需改一個地方。

``` C#

public enum Identity
{
    //管理者
    Admin = 1,

    //一般使用者
    User = 2,
}

//需判斷的地方
if (user.Identity != Identity.Admin)
{
    throw new Exception("沒有權限。");
}

```

在 C# 還可以用 [Description("")] Attribute 來改進。

``` C#

using System.ComponentModel;

public enum Sex
{
    [Description("男")]
    Male = 1,

    [Description("女")]
    Female = 2
}

```

>這樣不僅可以當 註解，還可以寫一個共用的擴充方法 ToDescription 給所有的 Enum 使用，不用再為每個 Enum 寫各自的轉換函數。

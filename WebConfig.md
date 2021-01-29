## WebConfig

+ 一個ASP.NET 應用程式對應到一個web.config (程式跟目錄與web.config同資料夾)，web.config 可視為該應用程式的專屬設定檔。
+ web.config 設定會覆寫 machine.config (path : C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config  [依據版本會有所不同])
+ web.config 也有階層覆蓋的概念(如MVC的View中的web.config會覆寫跟目錄下的web.config)

### configuration 標籤: 套用至目前的目錄與所有子目錄的設定(根元素)

```c#
<configuration>

  <configSections> </configSections>

  <appSettings> </appSettings> 

  <connectionStrings> </connectionStrings>

  <system.web> </system.web>

</configuration>
```

### configSections 標籤: 標示程式碼與設定值的區段名稱 (該標籤需要擺在第一個)

```c#
<configuration>

   <configSections>
      <section name="sampleSection" type="System.Configuration.SingleTagSectionHandler" />
   </configSections>

   <sampleSection setting1="Value1"/>

   <appSettings> <!-- machine.config內configSections已宣告appSettings這個section-->
      <add name="" value="">
   <appSettings/>

   <connectionStrings><!-- machine.config內configSections已宣告connectionStrings這個section-->
      <add name="Sales"  providerName=""  connectionString= "" />
   </connectionStrings>
</configuration>
```

### system.web 標籤: ASP.NET Web組態設定區段的根目錄元素

```c#
<system.web>
   <authentication> <!-- 設定認證模式 -->
   <authorization> <!-- 授權角色使用者 -->
   <browserCaps>  <!-- 瀏覽器相容性相關 -->
   <clientTarget> <!-- 管理用戶端瀏覽器集合 -->
   <compilation>  <!-- 彙整與編譯設定 -->
   <customErrors> <!-- 客製化錯誤頁面的設定 -->
   <globalization> <!-- 語系跟編碼規則-->
   <httpHandlers> <!-- HttpMethod與Handler的設定 -->
   <httpModules> <!-- Http模組設定 -->
   <httpRuntime> <!-- ASP.NET執行環境的設定 -->
   <!-- maxRequestLength="102400" 預設值4096 KB(4MB)，所以102400KB為100MB-->
   <!-- executionTimeout="600" 上傳時間(秒)，600秒為10分鐘-->
   <identity> <!-- 控制執行應用程式的身分 -->
   <machineKey> <!-- 表單驗證與Session加解密的方式 -->
   <pages> <!-- 設定頁面資訊 -->
   <processModel> <!-- 應用程式的Process設定 -->
   <securityPolicy> <!-- 定義檔案安全層級 -->
   <sessionState> <!-- 設定Session狀態 -->
   <trace> <!-- 追蹤資訊 -->
   <trust> <!-- 設定該應用程式信任層級 -->
   <webServices> <!-- web services xml 定義 -->
</system.web>
```

### location 標籤: 使用該標籤包裝起來，可設定該內容對指定的子資料夾有效。

```c#
<configuration>
   <system.web>  
   </system.web>
   <location path="sub1"><!-- Configuration for the "Sub1" subdirectory. -->
      <system.web>
      </system.web>
   </location>
</configuration>
```

[JSON 要求太長，無法還原序列化](https://gist.github.com/relyky/c1e9133d4e389b2eebec90e69e20aac6)

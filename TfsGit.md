# GitNote

前言:<br/>
這是從【Team Foundation Server】轉【Git】後的使用筆記

> 首先 我覺得這張圖很重要 <br/>
> 在學 Git 之前總覺得指令很多學起來很模糊 <br/>
> 可是在搭配這張圖後 就覺得很簡單了 : ) <br/>

![](https://i.imgur.com/n3AEnNo.png)

## 基礎設定
>**查詢版本**<br/>
>git version<br/> 
>**查詢設定列表**<br/>
>git config --list<br/> 
>**輸入姓名**<br/>
>git config --global user.name "名字"<br/> 
>**輸入email**<br/>
>git config --global user.email "Email"<br/>

## 新增本地/遠端數據庫
>**在本地資料夾新增數據庫**<br/>
>git init<br/> 
>**複製遠端數據庫**<br/>
>git clone 遠端數據庫網址<br/>  

## 增加/刪除檔案
>**增加檔案進入索引**<br/>
>git add 檔案名稱<br/> 
>**增加全部檔案進入索引**<br/>
>git add .<br/>  
>**查詢狀態**<br/>
>git status<br/>  
>**顯示歷史紀錄**<br/>
>git log<br/> 
>**增加全部檔案進入索引**<br/>
>git add .<br/>  
>**將索引提交到數據庫**<br/>
>git commit -m '更新訊息'<br/>


## 還原指令
>**還原工作目錄與索引，會跟最後一次 commit 保持一樣**<br/>
>git reset --hard<br/> 
>**全部檔案取消索引**<br/>
>git reset HEAD<br/>  
>**單一檔案取消索引**<br/>
>git reset HEAD 檔案名稱 <br/>  
>**恢復單一檔案到最新 commit 狀態**<br/>
>git checkout 檔案名稱<br/> 
>**刪除最近一次 commit **<br/>
>git reset --hard "HEAD^"<br/>  
>**上面語法如果刪除錯了可以再用此語法還原**<br/>
>git reset --hard ORIG_HEAD <br/>
>**刪除最近一次 commit，但保留異動內容**<br/>
>git reset --soft "HEAD^" <br/>
>**commit 後發現有幾個檔案忘了加入進去，想要補內容進去時**<br/>
>git commit --amend <br/>


## 分支
>**顯示所有本地分支**<br/>
>git branch<br/> 
>**新增分支**<br/>
>git branch 分支名稱<br/>  
>**切換分支**<br/>
>git checkout 分支名稱<br/>  
>**合併指定分支到目前的分支**<br/>
>git merge 分支名稱<br/> 
>**刪除分支**<br/>
>git branch -d 分支名稱<br/>  

## 遠端數據庫操作
>**複製遠端數據庫**<br/>
>git clone 遠端數據庫網址<br/> 
>**查詢遠端數據庫**<br/>
>git remote<br/>  
>**將本地分支推送到遠端分支**<br/>
>git push 遠端數據庫名稱 遠端分支名稱<br/>  
>**將遠端分支拉下來與本地分支進行合併**<br/>
>git pull<br/> 

## 標籤
>**查詢標籤**<br/>
>git tag<br/> 
>**查詢詳細標籤**<br/>
>git tag -n<br/>  
>**刪除標籤**<br/>
>git tag -d 標籤名稱<br/>  
>**新增輕量標籤**<br/>
>git tag 標籤名稱<br/> 
>**新增標示標籤**<br/>
>git tag -am "備註內容" 標籤名稱<br/> 

## 暫存
>**暫時儲存當前目錄**<br/>
>git stash<br/> 
>**瀏覽 stash 列表**<br/>
>git stash list <br/>  
>**還原暫存**<br/>
>git stash pop<br/>  
>**清除最新暫存**<br/>
>git stash drop<br/> 
>**清除全部暫存**<br/>
>git stash clear<br/> 

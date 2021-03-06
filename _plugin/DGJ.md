---
title: 点歌姬
auther: 宅急送队长
plugin_author: 宅急送队长
plugin_name: 点歌姬
plugin_desc: 用弹幕来播放歌曲吧
plugin_version: 1.5.4
plugin_update_datetime: 2017-02-10 13:10:00 +0800
#plugin_update_desc: |-
#  扒拉扒拉扒拉测试
#  测试，测试测试。
#  换行。
plugin_dllink: /resource/DGJ/DGJ1.5.4.zip
plugin_dlnote: 请不要二次上传到其他网站谢谢
---
作者的[直播间15253](https://live.bilibili.com/15253)
有问题可以去[弹幕姬讨论区](https://f.danmuji.cn)发帖询问

“点歌姬”和“B站弹幕姬”是独立工作的程序，支持和所有直播软件同时使用。

<div id="DGJ360Tip"></div>
<script>
window.is360=function(){var n=!1,r=["31.0.1650.63","45.0.2454.101","50.0.2661.102"];return navigator.userAgent.split(" ").forEach(function(t){t.startsWith("Chrome/")&&r.forEach(function(r){t=="Chrome/"+r&&(n=!0)})}),n};
(function(){
var tiphtml = `
<div class="highlighter-rouge"><pre class="highlight"><code><span style="font-weight: bold;color: #e1715b;font-size: 20px;">检测到你使用的是360浏览器</span>
<span style="font-size: 18px;font-weight: bold;">提醒：</span>有用户反馈，360杀毒有时会在点歌姬下载歌曲时认为是下载病毒
并在没有提醒的情况下静默关闭弹幕姬
请在360杀毒中给弹幕姬添加白名单、或者使用其他杀毒软件</code></pre></div>
`;
/*if(is360()){document.getElementById('DGJ360Tip').innerHTML = tiphtml;}*/
})();
</script>

<br/>

### 近期更新内容：

```
2017-2-10 版本：1.5.4
	*修改搜素模块系统代码中的typo
	*搜索模块“LWLAPI”同步更新到1.0版本，支持了多个歌曲平台
	注：使用新版LWLAPI需要点歌姬本体版本1.5.4或以上

2017.2.5 版本：1.5.3
	*修复部分歌曲在Win7上播放出错的问题

2017.2.2 版本：1.5.2
	+所有弹幕命令都支持繁体了
	+关闭弹幕姬时清空输出文本
	+在界面上添加了“切歌”按钮
	*“播放暂停”按钮的图标分成“播放”和“暂停”两个图标
	*过滤了歌曲缓存文件名中的非法字符
	*修改了版本更新提醒中的更新日期，现在只有年月日，没有时间
```  


1. [安装插件相关](#install)
2. [基本使用](#usage)
    1. [弹幕命令](#usage_cmd)
    2. [界面](#usage_gui)
    3. [输出文本信息](#usage_output)
3. [开发歌曲搜索模块](#dev)

<br/>

## <a name="install"></a>安装插件相关

“点歌姬” 为 “B站弹幕姬”的插件，压缩包内 DMPlugin_DGJ.dll 为点歌姬插件文件。  
安装弹幕姬之后，将插件文件放到插件文件夹中，重启弹幕姬。  
插件文件夹位置：```文档\弹幕姬\Plugins```（Win7中，“文档” 叫做 “我的文档”）

<img class="shadow" src="https://www.danmuji.cn/resource/DGJ/docu.png" alt="文档的位置" />

<br/>

如果安装插件后提示 “同步初始化出错” 类似字样，请先尝试安装.NET Framework 4.6.2，压缩包内已附带一份在线安装包。  
如安装后依旧出错，或有其他错误。请将桌面上生成的错误日志发给插件作者，谢谢~

**点歌姬本体是没有任何歌曲搜索功能的，需要给点歌姬添加 “歌曲搜索模块” 来搜索歌曲。**  
点歌姬压缩包中已附带搜索模块  
目前有三个可用的歌曲搜索模块：（截至到2017.02.10）

- LWLAPI，作者：宅急送队长&LWL12，支持5个歌曲平台的搜索模块
- QQ音乐，作者：宅急送队长，QQ音乐。（部分主播反馈不是很稳定，出现过报错的情况）
- 酷狗音乐，作者：数据源（19106直播间），酷狗音乐

歌曲搜索模块文件后缀统一为 gem，歌曲搜索模块需要放到 ```文档\弹幕姬\Plugins\点歌姬\曲源```（需要开启一次弹幕姬生成文件夹）

<br/>

## <a name="usage"></a>基本使用

在弹幕姬的插件面板，右键插件有三个选项：

- 启用 - 启用插件，启用后插件才能处理弹幕信息
- 禁用 - 禁用插件，点歌姬禁用后会继续播放已经点上的歌曲
- 管理 - 打开插件的界面

插件需要先启用之后才能响应弹幕操作，管理插件不需要先启用插件

<img class="shadow" src="https://www.danmuji.cn/resource/DGJ/admin.png" alt="弹幕姬插件面板" />

<br/>

### <a name="usage_cmd"></a>弹幕命令

所有人都可以使用的命令：

- ```点歌 歌名``` - 点歌
- ```取消点歌``` - 取消自己点的最后一首歌，已经开始播放的不能取消

必须是房管/主播，并且启用弹幕控制才能使用的：

- ```%暂停``` - 暂停播放
- ```%播放``` - 继续播放
- ```%切歌``` - 跳过当前正在播放的歌曲
- ```%删歌 序号``` - 删除某个歌曲
- ```%音量 0-100``` - 调整歌曲音量
- ```%上限 数字``` - 调整点歌数量上限
- ```%歌词``` - 开关是否搜索歌词

一般情况下用不到的命令：

- ```%保存配置``` - 保存当前配置到文件
- ```%加载配置``` - 从文件重新加载配置

<br/>

### <a name="usage_gui"></a>界面

在弹幕姬的插件面板，右键 “点歌姬”，点击“管理”打开界面。  
在点歌姬的搜索模块界面可以选择使用哪个搜索模块。

<br/>

### <a name="usage_output"></a>输出文本信息

写在前面：“点歌姬” 和 “B站弹幕姬” 不依赖于任何直播软件。所有支持从文件读取文字显示的直播软件都能显示点歌姬的歌曲信息

点歌姬的所有输出文本都在```文档\弹幕姬\Plugins\点歌姬\输出文本```中。  
目前有三个文件：歌词输出.txt、歌曲信息.txt、设置信息.txt  
其中 “设置信息” 主要为调试用，并不设计用于显示输出

OBS Classic 添加来源方法：

1. 在 “来源” 中右键，选择 “添加”、“文字来源”
2. 随便填写一个容易区分的来源名字，确认
3. 点击 “使用文件中的文字”，点击浏览，选择需要显示的文件
4. 调整颜色、字体、样式到想要的样子

<br/>

哔哩哔哩直播姬添加来源方法：

1. 点击左下角的 “文本”
2. 给来源设置一个容易区分的名字
3. 勾选 “从文件读” 前面的勾选框
4. 点击浏览，选择需要显示的文件
5. 调整颜色、字体、样式到想要的样子

其他直播软件同理，不再一个一个细说。

<br/>

我的OBS设定的样子：

<img class="shadow" src="https://www.danmuji.cn/resource/DGJ/obs.png" alt="点歌输出信息" />

<br/>

## <a name="dev"></a>**面向开发者-开发歌曲搜索模块**

### 基本开发方法：

1. VS 中新建一个 C# 类库工程，引用 DMPlugin_DGJ.dll
2. 新建一个 public 类，继承```SongsSearchModule```类
3. 在构造函数中调用setInfo(搜索模块名字, 作者名字, 联系方式, 版本号, 介绍, 是否支持歌词);
4. ```Override Search```方法，三个参数分别为点歌人名字、搜索关键词、是否需要歌词。返回```SongItem```，```SongItem.init(this, 歌名, 歌曲ID, 点歌人名字, 歌手数组, 下载地址, 歌词);``` 如没有搜索到歌曲请返回null
5. 如需搜索模块负责歌曲文件的下载（不能使用 http/https 下载的情况），请设置 ```_HandleDownload = true;```，然后重写```Download(SongItem item)```方法。在```Download```方法中将```item.DownloadURL```下载到```item.FilePath```的位置。此处将只在由本搜索模块搜索的歌曲下载时调用。请在此处注意**不要卡死**，务必做好超时取消的功能。下载成功返回0，下载失败返回1
6. 如果需要有设置界面，请设置 ```_NeedSettings = true; ```然后重写```Setting()```方法。一般情况下不建议带设置/GUI，请只在必须时使用。启用设置的情况下，在点歌姬的搜索模块界面右键搜索模块时会多出一个 “设置” 选项

<br/>

### 注：

- **以上所有方法均会在不同线程调用，请注意线程同步和UI操作**
- 如需 XML 注释文件请私聊我（其实感觉也用不到，东西不多）
- namespace 和 class 名没有要求
- 同一个项目允许创建多个搜索模块，点歌姬会依次加载
- 如果某个搜索模块在构造函数出错，点歌姬会跳过，继续加载同文件中其他的搜索模块（如果有多个搜索模块的话）
- 点歌姬搜索模块的后缀是 gem，本质只是**DLL重命名**（手动滑稽），因为比较方便小白用户描述
- 点歌姬将只加载曲源文件夹中的 gem 文件。
- 如需解析 Json，请使用弹幕姬中已经自带了的```Newtonsoft.Json```

<br/>

### 示例：

```csharp
using DMPlugin_DGJ;
using System;
using System.Text;

namespace Example
{
    public class ExampleModule : SongsSearchModule
    {
        public ExampleModule()
        {
            setInfo("搜索模块名字", "作者名字", "联系方式", "版本号", "搜索模块说明", 是否支持歌词);
            // 是否支持歌词仅用作显示，不影响调用Search时传入的参数
            // 联系方式会在搜索模块抛出错误时使用
            // setInfo只有第一次调用时有效
            
            // 使用Log输出日志和弹幕，MianPluginVersion为点歌姬的版本号
            Log($"点歌姬 {MianPluginVersion} 加载搜索模块 {ModuleName} 成功！", true);
            
            // 其他内容可在 Visual Studio 的对象浏览器中查看
        }

        protected override SongItem Search(string username, string str, bool needLyric = false)
        {
            // 在此处进行歌曲搜索解析操作
            if (false)
            { // 搜索成功的情况
                return SongItem.init(this, "歌名", "歌曲ID", username, "歌手数组", "下载地址", "歌词(可选)", "歌曲说明(可选，暂时没有使用)");
                // 请不要对username进行任何变动
                // 无歌词请返回String.Ematy
            } else { // 搜索失败的情况
                Log("搜索失败的原因"); // 可选，但是尽量输出
                return null; // null代表没搜到
            }
        }
    }
}
```
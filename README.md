# vrog
## 代码规范
### 编码格式UTF-8
```sh
# VS调出保存格式的操作步骤：
https://blog.csdn.net/NSJim/article/details/123253659

# VS安装插件，强制保存为UTF-8
扩展 --> 管理扩展 --> 联机 --> 搜索force UTF-8（No BOM) --> 下载 --> 重启VS
```
## C#语法和接口
### 值类型和引用类型的区别
[参考博文](https://www.cnblogs.com/soulsjie/p/13625911.html)
```sh
struct是值类型，class是引用类型
如果赋值struct，修改变量后原值还是不变，但是改成class就可以修改原值
```
[时区TimeZoneInfo类](https://learn.microsoft.com/zh-cn/dotnet/api/system.timezoneinfo?view=net-7.0)

[delegate委托](https://blog.csdn.net/qq_42345116/article/details/123408419)
## 项目用到的unity功能及教程
### UI
#### UI ToolKit
```sh
游戏UI用UGUI和UI ToolKit都可以，编辑器的UI开发官方推荐用ToolKit
UI ToolKit参考了HTML+CSS+JS的工作流，动画和数据支持的更好
UI ToolKit更接近一个窗口一个对象，需要一套管理，可惜不支持3D场景也不支持shader
UGUI是传统树状gameObject，估计要被淘汰掉
```
> 本项目重点不在UI，再加上长远目标是VR/AR，所以选择UGUI

[官方文档](https://docs.unity3d.com/2022.2/Documentation/Manual/UI-system-compare.html)

#### 布局
[pivot与anchor的使用](https://juejin.cn/post/6992876202507632677)
#### 字体
> 常规语言不要用TextMeshPro，美术的艺术字才需要，不然包体会很大

[unity生成中文字体库](https://blog.csdn.net/zhunju0089/article/details/103125168)

[字体缺少特定符号导致unity告警](https://www.bilibili.com/read/cv21557672)

[FontZip工具](https://github.com/forJrking/FontZip)
#### 杂项
[根据alpha值判断是否可点击，实现非长方形按钮](https://www.cnblogs.com/notorious/p/12960386.html)
### 本地化插件Localization
[官方文档](https://docs.unity3d.com/Packages/com.unity.localization@1.4/manual/QuickStartGuideWithVariants.html#localize-strings)
### AI插件NodeCanvas
[官网](https://nodecanvas.paradoxnotion.com/)

[节点概述](https://www.jianshu.com/p/a12470577fd0)

[nav mesh 官网文档](https://docs.unity3d.com/2022.2/Documentation/Manual/Navigation.html)

[nav导航](https://blog.csdn.net/akuojustdoit/article/details/114967888)

[动态导航](https://www.bilibili.com/read/cv13695393)
```sh
dynamic是指每帧重复判断，选择节点一般都要做，只有BOSS二阶段这种特殊情况才不需要勾选
```
### 摇杆
[joystick 接入](https://blog.csdn.net/Vaccae/article/details/111596223)

### timeline
[基本介绍](https://blog.csdn.net/linxinfa/article/details/108374878)

[摄像机动画](https://blog.csdn.net/qq_39435884/article/details/116232225)

[自定义新track](https://blog.csdn.net/qq_37390527/article/details/111714097)

[概念(图多但费劲)](https://blog.csdn.net/js0907/article/details/108250190)

### unity官方扩展插件(待了解)
[UI ToolKit](https://docs.unity3d.com/2022.2/Documentation/Manual/UIElements.html)

[内存分析](https://docs.unity3d.com/Packages/com.unity.memoryprofiler@1.0/manual/index.html)
### 快速创建自定义脚本/文件
```sh
修改Editor/CustomUnityEditor，支持新选项
在Edutor/ScriptTemplates下创建文件模板，对应的代码读新模板
```
### 定义变量的get/set方法后编辑器不可见，挂脚本解决
[源码地址](https://gitcode.net/mirrors/LMNRY/SetProperty.git)


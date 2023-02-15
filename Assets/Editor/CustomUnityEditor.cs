using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

internal class CustomUnityEditor : EditorWindow
{
    private static EditorWindow _window;
    private static List<Dictionary<string, string>> _paths;

    [MenuItem("Assets/Create/Handler", false, 1)]
    private static void CreateCustomScript()
    {
        _paths = new List<Dictionary<string, string>>();
        var paths = GetSelectedDirPath();
        if (paths.Count != 0)
        {
            _paths.Add(paths[paths.Count - 1]);
            CreateScriptFile();
        }
        else
            EditorUtility.DisplayDialog("提示", "请选择文件夹", "确定");
    }

    // 获取文件夹路径
    private static List<Dictionary<string, string>> GetSelectedDirPath()
    {
        // Object[] GetFiltered(Type type, SelectionMode mode)
        // type ---> 只会检索此类型的对象
        // mode ---> SelectionMode.Assets 仅返回 Asset 目录中的资产对象
        var selections =
            Selection.GetFiltered(typeof(Object), SelectionMode.Assets); // Object ---> UnityEngine.Object

        // 路径、文件名称 集合
        return (from obj in selections
                let path = AssetDatabase.GetAssetPath(obj)
                where Directory.Exists(path)
                select new Dictionary<string, string>
            {
                { "name", "NewScript" },
                { "path", AssetDatabase.GetAssetPath(obj) }
            }).ToList();
    }

    // 创建文件
    private static void CreateScriptFile()
    {
        foreach (var pathInfo in _paths.Where(pathInfo => pathInfo["name"] != ""))
        {
            const int instanceId = 0;
            var endAction = CreateInstance<NameByEnterOrUnfocus>();
            var pathName = $"{pathInfo["path"]}/{pathInfo["name"]}.cs";
            const string resourceFile = "Assets/Editor/ScriptTemplates/HandlerTemplate.cs.txt";

#if false
                * 参数1：instanceId       已编辑资源的实例 ID。
                * 参数2：endAction        监听编辑名称的类的实例化
                * 参数3：pathName         创建的文件路径（包括文件名）
                * 参数4：icon             图标  
                * 参数5：resourceFile     模板路径

                endAction 直接使用 new NameByEnterOrUnfocus() 出现以下警告：
                    NameByEnterOrUnfocus must be instantiated using the ScriptableObject.CreateInstance method instead of new NameByEnterOrUnfocus.
                    必须使用ScriptableObject实例化NameByEnterOrUnfocus。CreateInstance方法，而不是新的NameByEnterOrUnfocus。
#endif
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(instanceId, endAction, pathName, null,
                resourceFile);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("⚠ 不填写文件名称不会创建脚本", new GUIStyle { normal = { textColor = Color.red } });

        foreach (var pathInfo in _paths)
            pathInfo["name"] = EditorGUILayout.TextField(pathInfo["path"], pathInfo["name"]);

        if (GUILayout.Button("确定"))
        {
            CreateScriptFile();
            _window.Close();
        }
    }
}

internal class NameByEnterOrUnfocus : EndNameEditAction
{
    /// <summary>
    /// 当用户通过按下 Enter 键或失去键盘输入焦点接受编辑后的名称时，Unity 调用此函数
    /// </summary>
    /// <param name="instanceId">已编辑资源的实例 ID。</param>
    /// <param name="pathName">资源的路径。</param>
    /// <param name="resourceFile">传递给ProjectWindowUtil.StartNameEditingIfProjectWindowExists的资源文件字符串参数</param>
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var obj = CreateScript(pathName, resourceFile);
        // 创建并展示
        ProjectWindowUtil.ShowCreatedAsset(obj);
    }

    private static Object CreateScript(string pathName, string resourceFile)
    {
        // 读取模板文件内容
        var streamReader = new StreamReader(resourceFile);
        var templateText = streamReader.ReadToEnd();
        streamReader.Close();

        // 获取创建的脚本文件名称
        var fileName = Path.GetFileNameWithoutExtension(pathName);

        // 正则替换文本内自定义的变量
        var scriptText = Regex.Replace(templateText, "#SCRIPTNAME#", fileName);

        // 写入脚本
        var streamWriter = new StreamWriter(pathName);
        streamWriter.Write(scriptText);
        streamWriter.Close();

        // 在路径导入资源
        AssetDatabase.ImportAsset(pathName);
        // 返回给定路径assetPath类型类型的第一个资源对象
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
    }
}

/*
               #########                       
              ############                     
              #############                    
             ##  ###########                   
            ###  ###### #####                  
            ### #######   ####                 
           ###  ########## ####                
          ####  ########### ####               
         ####   ###########  #####             
        #####   ### ########   #####           
       #####   ###   ########   ######         
      ######   ###  ###########   ######       
     ######   #### ##############  ######      
    #######  #####################  ######     
    #######  ######################  ######    
   #######  ###### #################  ######   
   #######  ###### ###### #########   ######   
   #######    ##  ######   ######     ######   
   #######        ######    #####     #####    
    ######        #####     #####     ####     
     #####        ####      #####     ###      
      #####       ###        ###      #        
        ###       ###        ###               
         ##       ###        ###               
__________#_______####_______####______________

               我们的未来没有BUG                 
* ==============================================================================
* Filename: LuaExport
* Created:  2018/7/13 14:29:22
* Author:   To Harden The Mind
* Purpose:  
* ==============================================================================
*/

using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public static class LuaExport
{
    static LuaExport()
    {
    }

    [CSObjectWrapEditor.GenPath]
    public static string common_path = Application.dataPath + "/Scripts/GameLua/";

    [LuaCallCSharp]
    public static List<Type> mymodule_lua_call_cs_list = new List<Type>() {
        typeof(System.Type),
        typeof(System.Reflection.Missing),
        typeof(System.Object),


        typeof(UnityEngine.Application),
        typeof(UnityEngine.Behaviour),
        typeof(UnityEngine.Color),
        typeof(UnityEngine.Color32),
        typeof(UnityEngine.Component),
        typeof(UnityEngine.GameObject),
        typeof(UnityEngine.MonoBehaviour),
        typeof(UnityEngine.Object),
        typeof(UnityEngine.Quaternion),
        typeof(UnityEngine.Random),
        typeof(UnityEngine.RectTransform),
        typeof(UnityEngine.Sprite),
        typeof(UnityEngine.SystemInfo),
        typeof(UnityEngine.Texture),
        typeof(UnityEngine.Texture2D),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Transform),
        typeof(UnityEngine.Vector2),
        typeof(UnityEngine.Vector3),
        typeof(UnityEngine.Vector4),
        typeof(UnityEngine.Debug),
        typeof(UnityEngine.RuntimePlatform),

        typeof(Debug),
    };

    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
                typeof(Action),
    };


    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
                new List<string>(){"System.Xml.XmlNodeList", "ItemOf"},
                new List<string>(){"UnityEngine.WWW", "movie"},
    #if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
                new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
                new List<string>(){"UnityEngine.Texture", "imageContentsHash"},
                new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
                new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
                new List<string>(){"UnityEngine.Light", "areaSize"},
                new List<string>(){"UnityEngine.Light", "lightmapBakeType"},
                new List<string>(){"UnityEngine.WWW", "MovieTexture"},
                new List<string>(){"UnityEngine.WWW", "GetMovieTexture"},
                new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
    #if !UNITY_WEBPLAYER
                new List<string>(){"UnityEngine.Application", "ExternalEval"},
    #endif
                new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
                new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
                new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
            };

}


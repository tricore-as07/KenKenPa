#if UNITY_IOS
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;
using System.Collections.Generic;

public class NendIOSXcodeSetup : MonoBehaviour
{
	[PostProcessBuild]
	static void OnPostprocessBuild (BuildTarget buildTarget, string path)
	{
		if (buildTarget != BuildTarget.iOS) {
			return;
		}

		string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

		PBXProject proj = new PBXProject();
		proj.ReadFromFile(projPath);

		string target;

        #if UNITY_2019_3

		// Add NendAdResource.bundle to target Unity-iPhone
        target = proj.GetUnityMainTargetGuid();
		string sectionGuid = proj.GetResourcesBuildPhaseByTarget(target);
		string bundle = "NendAd/Plugins/iOS/NendAd.embeddedframework/Resources/NendAdResource.bundle";
		string fileGuid = proj.AddFile(bundle, "Frameworks/" + bundle, PBXSourceTree.Source);
		proj.RemoveFileFromBuild(target, fileGuid);
		proj.AddFileToBuildSection(target, sectionGuid, fileGuid);

		// Add frameworks to target UnityFramework
		string targetFramework = proj.GetUnityFrameworkTargetGuid();
		proj.AddFrameworkToProject(targetFramework, "AdSupport.framework", false);
		proj.AddFrameworkToProject(targetFramework, "Security.framework", false);
		proj.AddFrameworkToProject(targetFramework, "ImageIO.framework", false);
		proj.AddFrameworkToProject(targetFramework, "WebKit.framework", false);

        #else

		target = proj.TargetGuidByName("Unity-iPhone");
		proj.AddFrameworkToProject (target, "AdSupport.framework", false);
		proj.AddFrameworkToProject (target, "Security.framework", false);
		proj.AddFrameworkToProject (target, "ImageIO.framework", false);
		proj.AddFrameworkToProject (target, "WebKit.framework", false);

        #endif

		proj.WriteToFile(projPath);
	}
}
#endif
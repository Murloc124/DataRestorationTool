using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace DataRestorationTool
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Data Restoration Tool"),
        ExportMetadata("Description", "Tool that enables you to restore deleted data in any Dataverse Environment"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAvlJREFUWEdjZKAA2Np69v///+/vkSM7S8g1hpFcjVFR2YsO7nSJBem3c9kzefnKqXnkmEWWAyzMnSc+vpODYqG08qTuU6f2l5HqCJId4OUZMf3iqfAMbBbpmi7v37FjVREpjiDJAV5e4TMunoxIx2cBqY4g2gHYgh2XQ6SUJvacPn2glJiQIMoBUVFZ8w/udE0gxkCYGlvX3VNWrJiWS0gPQQfY2XlNvXs1NYuQQdjkFTVn9BLKongdQInlMAcRcgROB0RG5iw8tMs5jhyfo+vBFx1YHWBp7jzl0Z2cbGpYDjMDV8LEcICXV8SciyfDk6lpOcwsbFkUxQGenpGzLp0KS0W3fNMOewZhYTYGa9PdKFKhEXIMq1c8IsmtuqZL+3fsWAMvrOAOwBXsT94EMLx+9ZNh8YL7DEVlGgwyIhvAFoLE9dS3M1y66QnmI4tjYyO7ErnYBjsgOjJ77oFdLknoXgFZ0td1A4zxAZA6dEtBYsgOQ9dv47Jr8sqV0/MYQVXqvWtpBdgsQDaYHAfAHIVLr5LWzB5GW1uPvnvX0gvJcQDMl79//2dQlNwIjxqQxQuXWzDER57AG3LKmrMngqMgMjxr6qE9rhilHS1DwN5194xlK6ZlwhOhqalD97N7+SgtG0LxCPMetjTAzs7McPepLzxtoCXCvlOn9heDxFCyobt7WP+VM5Eo6QHmCJgByIkN2VBcuQA9IeoaL5+0Y9eqfJhejIIImyNIyuh4FKNbjhECML3mpk7dT+7lkt3QxOYGGZXJvSdP7sMwE2dlFBGRNfnwbtccavjezmX3tOUrp2GtW/BWxzY27j33r2eAEwu5gOzqGGYhJY4gZDnONIDu28jw7EmH9rgQbF4h64MVtYRCjmCTDGaAmZlj19O7eUQ1NKneKIU5wsMjrO/y6UisxTZMDc2a5cQ4Qs9kxcTtO1dirdhwRQXRUYBsALZiW0ZpYs9JIvsCyGaR5QCQAcjlBL58TrVEiM0gUBZlZGRiPnx4O950gc8RAICDX9FN9aMOAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}
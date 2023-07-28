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
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAIGNIUk0AAHomAACAhAAA+gAAAIDoAAB1MAAA6mAAADqYAAAXcJy6UTwAAAGPUExURf////j493p3s/n5+ImGvR8YqIiFvR8XpxoSrx4XpxsTrxgQrhkQrhkRrhgPrhcPrhwUr1FLwnZxz3dyz15Yxh8XsCMbsm9qzY6K13Vwzy8otikitDozumBax2lkyh4WsGJdyN3c84yI14F906ek4CoitH960ouG1r686K2q4iEZsTkyuuPi9VtWxj84u97d9HZyzyYfs8jG7JaT2hEJrFBKwtvZ8jQtuDgxueDf9GJcyKaj4Li25iQdsj84vFhSxBsSryojtFNNw5WS2t7c85eT2tbV8UtFwEZAvuTj9k1HwT43u56a3crI7JqX3N3b87Kv5LKw5N/e9GVfyRYOrT85vNva8lVPwzYvud7d84qG1tTS8GFbx66r47q45ywltUQ9vSMcskM8veHg9FxXxoB809LR78C+6amm4aSh37Ow5Kil4MfF66ml4TcwudnX8llTxSQcsqOg3xoRr0M9vUY/vjAptiEasUdBv1xWxk5IwSUdsiIbskpEwCsjtTMst01GwCEZsh8XqBoRriAYqNh+MAgAAAABYktHRACIBR1IAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAB3RJTUUH5wcbDAEyKnsUsQAAAsd6VFh0UmF3IHByb2ZpbGUgdHlwZSB4bXAAAEiJnVZbdqMwDP3XKmYJtmRLsBwC5m/Omc9Z/lwZiE3jtNOGhhL0urp6AP39/Yd+4RNjyCSr7DZZ0KiiD82WOChrVtNZi2xsZX88Hjsb7s+a/E42yWmTkDYLSaA76UxpssVgmMWWVHJS/IdDERixyS4lLLLaJItNCkPdPJhGDv5bVy0mLiOPADRJd8chyyF4qgPJ6Yqho7JkTinpBzeQEYTuarKEI8gC093qh4tBi4vuUDTeJcrsB66CMM6M83YE4I1MDFx4dJt48wiQVxRh4dCQAAaoQeKsswXoz8ihANkpJ6TFiIlEHBmbm9+Bp1jRwoHyK/oaumikpuTOzjgFFdx1gxrYgyLS4iLhYsxDyXoLsFCqqpe4TyajsBabpJcB7dzS8uYhZAODnAyZo2reJVzZ8HQZyHJDcbm7Y0nOWwZHSCij0QpYRjVQJ7QaZBuuTVbeR2bN6gpBwxgZvZ7SfLoXdaOIkuEPAbIkHBlXCS2R/R5Sk6iKHt78v0zAAiOo+ifhO8LUhWkp0wAP+utEk4HHv4rzjOiOwHCVa8hbCLqbfkYq5hAFAP3TszSe+OmOPlfsS897X/y+YVxCo54Z8NJ1W++yDQ71k/P9CWsDRu8mDIoy2AuhtunadoLr4YyGXNEj2D6+AZ5TFe9TVZ0ujgffteeuYfdZWy19OlEVZ/0Vtag5zrpyvE0VPZ7dA3lk77z0gJMNbuJX9TnZuwGQlY4sX4GPa/O+NPS92rwrjYWjj97uveuh0FYdGtUH4SiKtKLUWTuEdan6lpy8tM4cGMbg1KYUDs4KeJlr0i8W5CY/4eSjHv2Qk/qw7CmhLzmZ0ClhvP5Pd3Vr0rk2kZZPP47V2fHWMzRbTbhTH2kf6dL/MNPzdzyyn3ef7wR0PeUP0eDNBFN4vIMYHy8V9A/wJwyD4fD4FwAAAXhJREFUOMuFk/dbgkAYgEFA4M6LyrRSy4Y20IZNK8v2nrZs72l772H94R2QKQZ4P8G97wPfJAjVIU0mkjA4FM0wNGXAzSzH8WbKiAOgb1BmHnN9I8H1jCTXNlK5lqHEl2KwaiOdpxv/udqQObQgCADMErAK8StKGnJ82Tm51jybPb+g0IGcVhcqKnYnIpU5KiktK/d47RWVVdWiz19TW1ePfnMhacy5QEMjAHb88abmltZgW3tHqFOuOk0SJgY/oS5/WADdgOvp7fOIvv6BwSEoR8qYFAEOj4xKN2hsfGJS9E1Nz9hAQiBpnAIKRmbnOCRdzS8sRpeWV1ahnCr+hZKkbW3dsbHpdm+B7Ug4urO7t+9Cf6WQDNR1cHh07AzGYiengbPzi8vQlXjNJwuBDe/N7R24f3h8ekYvr2/o/eOTTy1lnOOQRYpWgEolvwRe3Yx4erN443ZqDYRqYFjjkdLiqqFl9caaNRz7zIuTefWk5f02XF6t9f8B8kA1Zfat+RwAAAAldEVYdGRhdGU6Y3JlYXRlADIwMjMtMDctMjdUMTI6MDE6MzErMDA6MDBsdhsfAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDIzLTA3LTI3VDEyOjAxOjMxKzAwOjAwHSujowAAACh0RVh0ZGF0ZTp0aW1lc3RhbXAAMjAyMy0wNy0yN1QxMjowMTo1MCswMDowMComgE8AAAAXdEVYdHBkZjpBdXRob3IAQ8OpZHJpYyBBbGx58k0VHwAAABV0RVh0eG1wOkNyZWF0b3JUb29sAENhbnZh6scSsQAAAABJRU5ErkJggg=="),
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
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Image2Pdf.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Image2Pdf.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image2PDF.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generate.
        /// </summary>
        public static string ButtonGenerate {
            get {
                return ResourceManager.GetString("ButtonGenerate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Drag files to the list below.
        /// </summary>
        public static string LabelDragFile {
            get {
                return ResourceManager.GetString("LabelDragFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Move down.
        /// </summary>
        public static string MenuMoveDown {
            get {
                return ResourceManager.GetString("MenuMoveDown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Move up.
        /// </summary>
        public static string MenuMoveUp {
            get {
                return ResourceManager.GetString("MenuMoveUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove.
        /// </summary>
        public static string MenuRemove {
            get {
                return ResourceManager.GetString("MenuRemove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PDF file has been saved to the location:
        ///{0}
        ///Do you want to open it?.
        /// </summary>
        public static string PdfGenerationCompletedPrompt {
            get {
                return ResourceManager.GetString("PdfGenerationCompletedPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PDF file (*.pdf)|*.pdf.
        /// </summary>
        public static string PdfSaveDialogFilter {
            get {
                return ResourceManager.GetString("PdfSaveDialogFilter", resourceCulture);
            }
        }
    }
}
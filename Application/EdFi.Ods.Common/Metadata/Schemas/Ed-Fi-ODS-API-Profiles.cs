// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.81.0.
// 

using System.Xml.Serialization;

namespace EdFi.Ods.Common.Metadata.Schemas {
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlRoot(Namespace="", IsNullable=false)]
    public partial class Profiles {
        
        private Profile[] profileField;
        
        /// <remarks/>
        [XmlElement("Profile")]
        public Profile[] Profile {
            get {
                return this.profileField;
            }
            set {
                this.profileField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Profile {
        
        private Resource[] resourceField;
        
        private string nameField;
        
        /// <remarks/>
        [XmlElement("Resource")]
        public Resource[] Resource {
            get {
                return this.resourceField;
            }
            set {
                this.resourceField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Resource {
        
        private ContentType readContentTypeField;
        
        private ContentType writeContentTypeField;
        
        private string nameField;
        
        private string logicalSchemaField;
        
        /// <remarks/>
        public ContentType ReadContentType {
            get {
                return this.readContentTypeField;
            }
            set {
                this.readContentTypeField = value;
            }
        }
        
        /// <remarks/>
        public ContentType WriteContentType {
            get {
                return this.writeContentTypeField;
            }
            set {
                this.writeContentTypeField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string logicalSchema {
            get {
                return this.logicalSchemaField;
            }
            set {
                this.logicalSchemaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ContentType {
        
        private PropertyDefinition[] propertyField;
        
        private ClassDefinition[] objectField;
        
        private CollectionDefinition[] collectionField;
        
        private ExtensionClassDefinition[] extensionField;
        
        private MemberSelectionMode memberSelectionField;
        
        /// <remarks/>
        [XmlElement("Property")]
        public PropertyDefinition[] Property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Object")]
        public ClassDefinition[] Object {
            get {
                return this.objectField;
            }
            set {
                this.objectField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Collection")]
        public CollectionDefinition[] Collection {
            get {
                return this.collectionField;
            }
            set {
                this.collectionField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Extension")]
        public ExtensionClassDefinition[] Extension {
            get {
                return this.extensionField;
            }
            set {
                this.extensionField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public MemberSelectionMode memberSelection {
            get {
                return this.memberSelectionField;
            }
            set {
                this.memberSelectionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PropertyDefinition {
        
        private string nameField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [XmlInclude(typeof(ExtensionCollectionDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExtensionClassDefinition {
        
        private PropertyDefinition[] propertyField;
        
        private ExtensionClassDefinition[] objectField;
        
        private ExtensionCollectionDefinition[] collectionField;
        
        private string nameField;
        
        private MemberSelectionMode memberSelectionField;
        
        private string logicalSchemaField;
        
        /// <remarks/>
        [XmlElement("Property")]
        public PropertyDefinition[] Property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Object")]
        public ExtensionClassDefinition[] Object {
            get {
                return this.objectField;
            }
            set {
                this.objectField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Collection")]
        public ExtensionCollectionDefinition[] Collection {
            get {
                return this.collectionField;
            }
            set {
                this.collectionField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public MemberSelectionMode memberSelection {
            get {
                return this.memberSelectionField;
            }
            set {
                this.memberSelectionField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string logicalSchema {
            get {
                return this.logicalSchemaField;
            }
            set {
                this.logicalSchemaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExtensionCollectionDefinition : ExtensionClassDefinition {
        
        private FilterDefinition filterField;
        
        /// <remarks/>
        public FilterDefinition Filter {
            get {
                return this.filterField;
            }
            set {
                this.filterField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FilterDefinition {
        
        private string[] valueField;
        
        private string propertyNameField;
        
        private FilterMode filterModeField;
        
        /// <remarks/>
        [XmlElement("Value")]
        public string[] Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string propertyName {
            get {
                return this.propertyNameField;
            }
            set {
                this.propertyNameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public FilterMode filterMode {
            get {
                return this.filterModeField;
            }
            set {
                this.filterModeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    public enum FilterMode {
        
        /// <remarks/>
        IncludeOnly,
        
        /// <remarks/>
        ExcludeOnly,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    public enum MemberSelectionMode {
        
        /// <remarks/>
        IncludeOnly,
        
        /// <remarks/>
        ExcludeOnly,
        
        /// <remarks/>
        IncludeAll,
        
        /// <remarks/>
        ExcludeAll,
    }
    
    /// <remarks/>
    [XmlInclude(typeof(CollectionDefinition))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClassDefinition {
        
        private PropertyDefinition[] propertyField;
        
        private ClassDefinition[] objectField;
        
        private CollectionDefinition[] collectionField;
        
        private ExtensionClassDefinition[] extensionField;
        
        private string nameField;
        
        private MemberSelectionMode memberSelectionField;
        
        private string logicalSchemaField;
        
        /// <remarks/>
        [XmlElement("Property")]
        public PropertyDefinition[] Property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Object")]
        public ClassDefinition[] Object {
            get {
                return this.objectField;
            }
            set {
                this.objectField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Collection")]
        public CollectionDefinition[] Collection {
            get {
                return this.collectionField;
            }
            set {
                this.collectionField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("Extension")]
        public ExtensionClassDefinition[] Extension {
            get {
                return this.extensionField;
            }
            set {
                this.extensionField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public MemberSelectionMode memberSelection {
            get {
                return this.memberSelectionField;
            }
            set {
                this.memberSelectionField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string logicalSchema {
            get {
                return this.logicalSchemaField;
            }
            set {
                this.logicalSchemaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CollectionDefinition : ClassDefinition {
        
        private FilterDefinition filterField;
        
        /// <remarks/>
        public FilterDefinition Filter {
            get {
                return this.filterField;
            }
            set {
                this.filterField = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeosViewer
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.melin.nu/mop", IsNullable = false)]
    public partial class MOPComplete
    {

        private MOPCompleteResults resultsField;

        /// <remarks/>
        public MOPCompleteResults results
        {
            get
            {
                return this.resultsField;
            }
            set
            {
                this.resultsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResults
    {

        private MOPCompleteResultsTeam[] teamField;

        private string typeField;

        private byte legField;

        private string toField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("team")]
        public MOPCompleteResultsTeam[] team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte leg
        {
            get
            {
                return this.legField;
            }
            set
            {
                this.legField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string to
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeam
    {

        private MOPCompleteResultsTeamName nameField;

        private MOPCompleteResultsTeamOrg orgField;

        private MOPCompleteResultsTeamPerson personField;

        private byte clsField;

        private byte statField;

        private uint stField;

        private ushort rtField;

        private byte placeField;

        /// <remarks/>
        public MOPCompleteResultsTeamName name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public MOPCompleteResultsTeamOrg org
        {
            get
            {
                return this.orgField;
            }
            set
            {
                this.orgField = value;
            }
        }

        /// <remarks/>
        public MOPCompleteResultsTeamPerson person
        {
            get
            {
                return this.personField;
            }
            set
            {
                this.personField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte cls
        {
            get
            {
                return this.clsField;
            }
            set
            {
                this.clsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte stat
        {
            get
            {
                return this.statField;
            }
            set
            {
                this.statField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint st
        {
            get
            {
                return this.stField;
            }
            set
            {
                this.stField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort rt
        {
            get
            {
                return this.rtField;
            }
            set
            {
                this.rtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte place
        {
            get
            {
                return this.placeField;
            }
            set
            {
                this.placeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeamName
    {

        private uint idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeamOrg
    {

        private ushort idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeamPerson
    {

        private MOPCompleteResultsTeamPersonName nameField;

        private MOPCompleteResultsTeamPersonOrg orgField;

        private byte clsField;

        private byte legField;

        private byte statField;

        private uint stField;

        private ushort rtField;

        /// <remarks/>
        public MOPCompleteResultsTeamPersonName name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public MOPCompleteResultsTeamPersonOrg org
        {
            get
            {
                return this.orgField;
            }
            set
            {
                this.orgField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte cls
        {
            get
            {
                return this.clsField;
            }
            set
            {
                this.clsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte leg
        {
            get
            {
                return this.legField;
            }
            set
            {
                this.legField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte stat
        {
            get
            {
                return this.statField;
            }
            set
            {
                this.statField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint st
        {
            get
            {
                return this.stField;
            }
            set
            {
                this.stField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort rt
        {
            get
            {
                return this.rtField;
            }
            set
            {
                this.rtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeamPersonName
    {

        private uint idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.melin.nu/mop")]
    public partial class MOPCompleteResultsTeamPersonOrg
    {

        private ushort idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}

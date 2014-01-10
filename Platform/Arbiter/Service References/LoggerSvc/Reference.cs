﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arbiter.LoggerSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameLog", Namespace="http://schemas.datacontract.org/2004/07/Logger.DataContracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Arbiter.LoggerSvc.PlayerLog))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Arbiter.LoggerSvc.ControllCenterLog))]
    public partial class GameLog : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string logField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string log {
            get {
                return this.logField;
            }
            set {
                if ((object.ReferenceEquals(this.logField, value) != true)) {
                    this.logField = value;
                    this.RaisePropertyChanged("log");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerLog", Namespace="http://schemas.datacontract.org/2004/07/Logger.DataContracts")]
    [System.SerializableAttribute()]
    public partial class PlayerLog : Arbiter.LoggerSvc.GameLog {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Arbiter.LoggerSvc.PlayerData PlayerDataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Arbiter.LoggerSvc.PlayerData PlayerData {
            get {
                return this.PlayerDataField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerDataField, value) != true)) {
                    this.PlayerDataField = value;
                    this.RaisePropertyChanged("PlayerData");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ControllCenterLog", Namespace="http://schemas.datacontract.org/2004/07/Logger.DataContracts")]
    [System.SerializableAttribute()]
    public partial class ControllCenterLog : Arbiter.LoggerSvc.GameLog {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Arbiter.LoggerSvc.ControllCenterData ControllCenterDataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Arbiter.LoggerSvc.ControllCenterData ControllCenterData {
            get {
                return this.ControllCenterDataField;
            }
            set {
                if ((object.ReferenceEquals(this.ControllCenterDataField, value) != true)) {
                    this.ControllCenterDataField = value;
                    this.RaisePropertyChanged("ControllCenterData");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerData", Namespace="http://schemas.datacontract.org/2004/07/Configuration.DataContracts")]
    [System.SerializableAttribute()]
    public partial class PlayerData : Arbiter.LoggerSvc.UnitData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LengthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte MachineIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Arbiter.LoggerSvc.Color MarkerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MarkerPositionXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MarkerPositionYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WidthField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Length {
            get {
                return this.LengthField;
            }
            set {
                if ((this.LengthField.Equals(value) != true)) {
                    this.LengthField = value;
                    this.RaisePropertyChanged("Length");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte MachineId {
            get {
                return this.MachineIdField;
            }
            set {
                if ((this.MachineIdField.Equals(value) != true)) {
                    this.MachineIdField = value;
                    this.RaisePropertyChanged("MachineId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Arbiter.LoggerSvc.Color Marker {
            get {
                return this.MarkerField;
            }
            set {
                if ((this.MarkerField.Equals(value) != true)) {
                    this.MarkerField = value;
                    this.RaisePropertyChanged("Marker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MarkerPositionX {
            get {
                return this.MarkerPositionXField;
            }
            set {
                if ((this.MarkerPositionXField.Equals(value) != true)) {
                    this.MarkerPositionXField = value;
                    this.RaisePropertyChanged("MarkerPositionX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MarkerPositionY {
            get {
                return this.MarkerPositionYField;
            }
            set {
                if ((this.MarkerPositionYField.Equals(value) != true)) {
                    this.MarkerPositionYField = value;
                    this.RaisePropertyChanged("MarkerPositionY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Width {
            get {
                return this.WidthField;
            }
            set {
                if ((this.WidthField.Equals(value) != true)) {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UnitData", Namespace="http://schemas.datacontract.org/2004/07/Configuration.DataContracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Arbiter.LoggerSvc.ControllCenterData))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Arbiter.LoggerSvc.PlayerData))]
    public partial class UnitData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte TeamIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte TeamId {
            get {
                return this.TeamIdField;
            }
            set {
                if ((this.TeamIdField.Equals(value) != true)) {
                    this.TeamIdField = value;
                    this.RaisePropertyChanged("TeamId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ControllCenterData", Namespace="http://schemas.datacontract.org/2004/07/Configuration.DataContracts")]
    [System.SerializableAttribute()]
    public partial class ControllCenterData : Arbiter.LoggerSvc.UnitData {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Color", Namespace="http://schemas.datacontract.org/2004/07/System.Drawing")]
    [System.SerializableAttribute()]
    public partial struct Color : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private short knownColorField;
        
        private string nameField;
        
        private short stateField;
        
        private long valueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short knownColor {
            get {
                return this.knownColorField;
            }
            set {
                if ((this.knownColorField.Equals(value) != true)) {
                    this.knownColorField = value;
                    this.RaisePropertyChanged("knownColor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public short state {
            get {
                return this.stateField;
            }
            set {
                if ((this.stateField.Equals(value) != true)) {
                    this.stateField = value;
                    this.RaisePropertyChanged("state");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long value {
            get {
                return this.valueField;
            }
            set {
                if ((this.valueField.Equals(value) != true)) {
                    this.valueField = value;
                    this.RaisePropertyChanged("value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoggerSvc.ILogManager")]
    public interface ILogManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogManager/AddLog", ReplyAction="http://tempuri.org/ILogManager/AddLogResponse")]
        void AddLog(Arbiter.LoggerSvc.GameLog log);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogManager/AddLog", ReplyAction="http://tempuri.org/ILogManager/AddLogResponse")]
        System.Threading.Tasks.Task AddLogAsync(Arbiter.LoggerSvc.GameLog log);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogManagerChannel : Arbiter.LoggerSvc.ILogManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogManagerClient : System.ServiceModel.ClientBase<Arbiter.LoggerSvc.ILogManager>, Arbiter.LoggerSvc.ILogManager {
        
        public LogManagerClient() {
        }
        
        public LogManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddLog(Arbiter.LoggerSvc.GameLog log) {
            base.Channel.AddLog(log);
        }
        
        public System.Threading.Tasks.Task AddLogAsync(Arbiter.LoggerSvc.GameLog log) {
            return base.Channel.AddLogAsync(log);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoggerSvc.IStatusMessageLogger", CallbackContract=typeof(Arbiter.LoggerSvc.IStatusMessageLoggerCallback))]
    public interface IStatusMessageLogger {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatusMessageLogger/SubscribeForStatusMessages", ReplyAction="http://tempuri.org/IStatusMessageLogger/SubscribeForStatusMessagesResponse")]
        void SubscribeForStatusMessages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStatusMessageLogger/SubscribeForStatusMessages", ReplyAction="http://tempuri.org/IStatusMessageLogger/SubscribeForStatusMessagesResponse")]
        System.Threading.Tasks.Task SubscribeForStatusMessagesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStatusMessageLoggerCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStatusMessageLogger/OnShowStatusMessage")]
        void OnShowStatusMessage(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStatusMessageLoggerChannel : Arbiter.LoggerSvc.IStatusMessageLogger, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StatusMessageLoggerClient : System.ServiceModel.DuplexClientBase<Arbiter.LoggerSvc.IStatusMessageLogger>, Arbiter.LoggerSvc.IStatusMessageLogger {
        
        public StatusMessageLoggerClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StatusMessageLoggerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StatusMessageLoggerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StatusMessageLoggerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StatusMessageLoggerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SubscribeForStatusMessages() {
            base.Channel.SubscribeForStatusMessages();
        }
        
        public System.Threading.Tasks.Task SubscribeForStatusMessagesAsync() {
            return base.Channel.SubscribeForStatusMessagesAsync();
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HalloWCF.ProxyClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Pizza", Namespace="http://schemas.datacontract.org/2004/07/HalloWCF.Host")]
    [System.SerializableAttribute()]
    public partial class Pizza : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
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
        public int Id {
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
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Drink", Namespace="http://schemas.datacontract.org/2004/07/HalloWCF.Host")]
    [System.SerializableAttribute()]
    public partial class Drink : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AlcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
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
        public bool Alc {
            get {
                return this.AlcField;
            }
            set {
                if ((this.AlcField.Equals(value) != true)) {
                    this.AlcField = value;
                    this.RaisePropertyChanged("Alc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
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
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFive", ReplyAction="http://tempuri.org/IService1/GetFiveResponse")]
        int GetFive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFive", ReplyAction="http://tempuri.org/IService1/GetFiveResponse")]
        System.Threading.Tasks.Task<int> GetFiveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Sum", ReplyAction="http://tempuri.org/IService1/SumResponse")]
        int Sum(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Sum", ReplyAction="http://tempuri.org/IService1/SumResponse")]
        System.Threading.Tasks.Task<int> SumAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPizza", ReplyAction="http://tempuri.org/IService1/GetAllPizzaResponse")]
        HalloWCF.ProxyClient.ServiceReference1.Pizza[] GetAllPizza();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPizza", ReplyAction="http://tempuri.org/IService1/GetAllPizzaResponse")]
        System.Threading.Tasks.Task<HalloWCF.ProxyClient.ServiceReference1.Pizza[]> GetAllPizzaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneDrink", ReplyAction="http://tempuri.org/IService1/GetOneDrinkResponse")]
        HalloWCF.ProxyClient.ServiceReference1.Drink GetOneDrink();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneDrink", ReplyAction="http://tempuri.org/IService1/GetOneDrinkResponse")]
        System.Threading.Tasks.Task<HalloWCF.ProxyClient.ServiceReference1.Drink> GetOneDrinkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : HalloWCF.ProxyClient.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<HalloWCF.ProxyClient.ServiceReference1.IService1>, HalloWCF.ProxyClient.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetFive() {
            return base.Channel.GetFive();
        }
        
        public System.Threading.Tasks.Task<int> GetFiveAsync() {
            return base.Channel.GetFiveAsync();
        }
        
        public int Sum(int a, int b) {
            return base.Channel.Sum(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SumAsync(int a, int b) {
            return base.Channel.SumAsync(a, b);
        }
        
        public HalloWCF.ProxyClient.ServiceReference1.Pizza[] GetAllPizza() {
            return base.Channel.GetAllPizza();
        }
        
        public System.Threading.Tasks.Task<HalloWCF.ProxyClient.ServiceReference1.Pizza[]> GetAllPizzaAsync() {
            return base.Channel.GetAllPizzaAsync();
        }
        
        public HalloWCF.ProxyClient.ServiceReference1.Drink GetOneDrink() {
            return base.Channel.GetOneDrink();
        }
        
        public System.Threading.Tasks.Task<HalloWCF.ProxyClient.ServiceReference1.Drink> GetOneDrinkAsync() {
            return base.Channel.GetOneDrinkAsync();
        }
    }
}

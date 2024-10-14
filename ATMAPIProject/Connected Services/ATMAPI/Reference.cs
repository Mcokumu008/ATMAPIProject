﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATMAPI
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", ConfigurationName="ATMAPI.ATMAPI_Port")]
    public interface ATMAPI_Port
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:microsoft-dynamics-schemas/codeunit/ATMAPI:ProcessTransactions", ReplyAction="*")]
        System.Threading.Tasks.Task<ATMAPI.ProcessTransactions_Result> ProcessTransactionsAsync(ATMAPI.ProcessTransactions request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:microsoft-dynamics-schemas/codeunit/ATMAPI:GetAccountBalance", ReplyAction="*")]
        System.Threading.Tasks.Task<ATMAPI.GetAccountBalance_Result> GetAccountBalanceAsync(ATMAPI.GetAccountBalance request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessTransactions", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", IsWrapped=true)]
    public partial class ProcessTransactions
    {
        
        public ProcessTransactions()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ProcessTransactions_Result", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", IsWrapped=true)]
    public partial class ProcessTransactions_Result
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", Order=0)]
        public int return_value;
        
        public ProcessTransactions_Result()
        {
        }
        
        public ProcessTransactions_Result(int return_value)
        {
            this.return_value = return_value;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAccountBalance", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", IsWrapped=true)]
    public partial class GetAccountBalance
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", Order=0)]
        public string account;
        
        public GetAccountBalance()
        {
        }
        
        public GetAccountBalance(string account)
        {
            this.account = account;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAccountBalance_Result", WrapperNamespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", IsWrapped=true)]
    public partial class GetAccountBalance_Result
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:microsoft-dynamics-schemas/codeunit/ATMAPI", Order=0)]
        public decimal return_value;
        
        public GetAccountBalance_Result()
        {
        }
        
        public GetAccountBalance_Result(decimal return_value)
        {
            this.return_value = return_value;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface ATMAPI_PortChannel : ATMAPI.ATMAPI_Port, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class ATMAPI_PortClient : System.ServiceModel.ClientBase<ATMAPI.ATMAPI_Port>, ATMAPI.ATMAPI_Port
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ATMAPI_PortClient() : 
                base(ATMAPI_PortClient.GetDefaultBinding(), ATMAPI_PortClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.ATMAPI_Port.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ATMAPI_PortClient(EndpointConfiguration endpointConfiguration) : 
                base(ATMAPI_PortClient.GetBindingForEndpoint(endpointConfiguration), ATMAPI_PortClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ATMAPI_PortClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ATMAPI_PortClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ATMAPI_PortClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ATMAPI_PortClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ATMAPI_PortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATMAPI.ProcessTransactions_Result> ATMAPI.ATMAPI_Port.ProcessTransactionsAsync(ATMAPI.ProcessTransactions request)
        {
            return base.Channel.ProcessTransactionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATMAPI.ProcessTransactions_Result> ProcessTransactionsAsync()
        {
            ATMAPI.ProcessTransactions inValue = new ATMAPI.ProcessTransactions();
            return ((ATMAPI.ATMAPI_Port)(this)).ProcessTransactionsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATMAPI.GetAccountBalance_Result> ATMAPI.ATMAPI_Port.GetAccountBalanceAsync(ATMAPI.GetAccountBalance request)
        {
            return base.Channel.GetAccountBalanceAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATMAPI.GetAccountBalance_Result> GetAccountBalanceAsync(string account)
        {
            ATMAPI.GetAccountBalance inValue = new ATMAPI.GetAccountBalance();
            inValue.account = account;
            return ((ATMAPI.ATMAPI_Port)(this)).GetAccountBalanceAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ATMAPI_Port))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ATMAPI_Port))
            {
                return new System.ServiceModel.EndpointAddress("http://scudo:7533/aml2018/WS/CRONUS International Ltd./Codeunit/ATMAPI");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ATMAPI_PortClient.GetBindingForEndpoint(EndpointConfiguration.ATMAPI_Port);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ATMAPI_PortClient.GetEndpointAddress(EndpointConfiguration.ATMAPI_Port);
        }
        
        public enum EndpointConfiguration
        {
            
            ATMAPI_Port,
        }
    }
}

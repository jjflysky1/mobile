﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mobile1.Webservice_mail {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Webservice_mail.mailSoap")]
    public interface mailSoap {
        
        // CODEGEN: http://tempuri.org/ 네임스페이스의 요소 이름 HelloWorldResult이(가) "nillable"로 표시되지 않았으므로 메시지 계약을 생성합니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        mobile1.Webservice_mail.HelloWorldResponse HelloWorld(mobile1.Webservice_mail.HelloWorldRequest request);
        
        // CODEGEN: http://tempuri.org/ 네임스페이스의 요소 이름 user_id이(가) "nillable"로 표시되지 않았으므로 메시지 계약을 생성합니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/mail_list", ReplyAction="*")]
        mobile1.Webservice_mail.mail_listResponse mail_list(mobile1.Webservice_mail.mail_listRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public mobile1.Webservice_mail.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(mobile1.Webservice_mail.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public mobile1.Webservice_mail.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(mobile1.Webservice_mail.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class mail_listRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="mail_list", Namespace="http://tempuri.org/", Order=0)]
        public mobile1.Webservice_mail.mail_listRequestBody Body;
        
        public mail_listRequest() {
        }
        
        public mail_listRequest(mobile1.Webservice_mail.mail_listRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class mail_listRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string user_id;
        
        public mail_listRequestBody() {
        }
        
        public mail_listRequestBody(string user_id) {
            this.user_id = user_id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class mail_listResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="mail_listResponse", Namespace="http://tempuri.org/", Order=0)]
        public mobile1.Webservice_mail.mail_listResponseBody Body;
        
        public mail_listResponse() {
        }
        
        public mail_listResponse(mobile1.Webservice_mail.mail_listResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class mail_listResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string mail_listResult;
        
        public mail_listResponseBody() {
        }
        
        public mail_listResponseBody(string mail_listResult) {
            this.mail_listResult = mail_listResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface mailSoapChannel : mobile1.Webservice_mail.mailSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class mailSoapClient : System.ServiceModel.ClientBase<mobile1.Webservice_mail.mailSoap>, mobile1.Webservice_mail.mailSoap {
        
        public mailSoapClient() {
        }
        
        public mailSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public mailSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public mailSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public mailSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        mobile1.Webservice_mail.HelloWorldResponse mobile1.Webservice_mail.mailSoap.HelloWorld(mobile1.Webservice_mail.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            mobile1.Webservice_mail.HelloWorldRequest inValue = new mobile1.Webservice_mail.HelloWorldRequest();
            inValue.Body = new mobile1.Webservice_mail.HelloWorldRequestBody();
            mobile1.Webservice_mail.HelloWorldResponse retVal = ((mobile1.Webservice_mail.mailSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        mobile1.Webservice_mail.mail_listResponse mobile1.Webservice_mail.mailSoap.mail_list(mobile1.Webservice_mail.mail_listRequest request) {
            return base.Channel.mail_list(request);
        }
        
        public string mail_list(string user_id) {
            mobile1.Webservice_mail.mail_listRequest inValue = new mobile1.Webservice_mail.mail_listRequest();
            inValue.Body = new mobile1.Webservice_mail.mail_listRequestBody();
            inValue.Body.user_id = user_id;
            mobile1.Webservice_mail.mail_listResponse retVal = ((mobile1.Webservice_mail.mailSoap)(this)).mail_list(inValue);
            return retVal.Body.mail_listResult;
        }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Swashbuckle.Core.Swagger
{
    public interface ISwaggerProvider
    {
        ResourceListing GetListing(string basePath, string version);

        ApiDeclaration GetDeclaration(string basePath, string version, string resourceName);
    }

    public class ResourceListing
    {
        [JsonProperty("swaggerVersion")]
        public string SwaggerVersion { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("apis")]
        public IList<Resource> Apis { get; set; }

        [JsonProperty("authorizations")]
        public IDictionary<string, AuthorizationScheme> Authorizations { get; set; }
    }

    public class Resource
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ApiDeclaration
    {
        [JsonProperty("swaggerVersion")]
        public string SwaggerVersion { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("basePath")]
        public string BasePath { get; set; }

        [JsonProperty("resourcePath")]
        public string ResourcePath { get; set; }

        [JsonProperty("apis")]
        public IList<Api> Apis { get; set; }

        [JsonProperty("models")]
        public IDictionary<string, DataType> Models { get; set; }

        [JsonProperty("authorizations")]
        public IDictionary<string, object> Authorizations { get; set; }
    }

    public class Api
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("operations")]
        public IList<Operation> Operations { get; set; }
    }

    public class Operation
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("items")]
        public DataType Items { get; set; }

        [JsonProperty("enum")]
        public IList<string> Enum { get; set; }

        [JsonProperty("parameters")]
        public IList<Parameter> Parameters { get; set; }

        [JsonProperty("responseMessages")]
        public IList<ResponseMessage> ResponseMessages { get; set; }

        [JsonProperty("authorizations")]
        public IDictionary<string, object> Authorizations { get; set; }
    }

    public class Parameter
    {
        [JsonProperty("paramType")]
        public string ParamType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("items")]
        public DataType Items { get; set; }

        [JsonProperty("enum")]
        public IList<string> Enum { get; set; }
    }

    public class ResponseMessage
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class DataType
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("items")]
        public DataType Items { get; set; }

        [JsonProperty("enum")]
        public IList<string> Enum { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, DataType> Properties { get; set; }

        [JsonProperty("required")]
        public IList<string> Required { get; set; }

        [JsonProperty("subTypes")]
        public IList<string> SubTypes { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }

    public abstract class AuthorizationScheme
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("passAs")]
        public string PassAs { get; set; }

        [JsonProperty("keyname")]
        public string KeyName { get; set; }
    }

    public class OAuth2AuthorizationScheme : AuthorizationScheme
    {
        public OAuth2AuthorizationScheme(PassAsEnum passAs, string keyName)
        {
            Type = "oauth2";
            PassAs = passAs.ToString();
            KeyName = keyName;
        }

        [JsonProperty("scopes")]
        public IEnumerable<AuthorizationScope> Scopes { get; set; }

        [JsonProperty("grantTypes")]
        public GrantType GrantTypes { get; set; }
    }

    public class BasicAuthorizationScheme : AuthorizationScheme
    {
        public BasicAuthorizationScheme(PassAsEnum passAs, string keyName)
        {
            Type = "basicAuth";
            PassAs = passAs.ToString();
            KeyName = keyName;
        }
    }

    public class GrantType
    {
        [JsonProperty("implicit")]
        public ImplicitGrantType Implicit { get; set; }

        [JsonProperty("authorization_code")]
        public AuthorizationCodeGrantType AuthorizationCode { get; set; }
    }

    public class ImplicitGrantType
    {
        [JsonProperty("loginEndpoint")]
        public LoginEndpoint LoginEndpoint { get; set; }

        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
    }

    public class AuthorizationCodeGrantType
    {
        [JsonProperty("tokenRequestEndpoint")]
        public TokenRequestEndpoint TokenRequestEndpoint { get; set; }

        [JsonProperty("tokenEndpoint")]
        public TokenEndpoint TokenEndpoint { get; set; }
    }

    public class TokenRequestEndpoint
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("clientIdName")]
        public string ClientIdName { get; set; }

        [JsonProperty("clientSecretName")]
        public string ClientSecretName { get; set; }
    }

    public class LoginEndpoint
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class TokenEndpoint
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
    }

    public class AuthorizationScope
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public enum PassAsEnum
    {
        Header,
        Query
    }
}
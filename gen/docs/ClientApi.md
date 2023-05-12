# Org.OpenAPITools.Api.ClientApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiClientGet**](ClientApi.md#apiclientget) | **GET** /api/Client | Get method which returns all clients
[**ApiClientIdDelete**](ClientApi.md#apiclientiddelete) | **DELETE** /api/Client/{id} | Delete method for deleting a client
[**ApiClientIdGet**](ClientApi.md#apiclientidget) | **GET** /api/Client/{id} | Get method which returns clients by id
[**ApiClientIdPut**](ClientApi.md#apiclientidput) | **PUT** /api/Client/{id} | Put method for changing data in the client table
[**ApiClientPost**](ClientApi.md#apiclientpost) | **POST** /api/Client | Post method which add new client



## ApiClientGet

> List&lt;ClientGetDto&gt; ApiClientGet ()

Get method which returns all clients

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiClientGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new ClientApi(Configuration.Default);

            try
            {
                // Get method which returns all clients
                List<ClientGetDto> result = apiInstance.ApiClientGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ClientApi.ApiClientGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**List&lt;ClientGetDto&gt;**](ClientGetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiClientIdDelete

> void ApiClientIdDelete (long id)

Delete method for deleting a client

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiClientIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new ClientApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a client
                apiInstance.ApiClientIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ClientApi.ApiClientIdDelete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiClientIdGet

> ClientGetDto ApiClientIdGet (long id)

Get method which returns clients by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiClientIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new ClientApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns clients by id
                ClientGetDto result = apiInstance.ApiClientIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ClientApi.ApiClientIdGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**|  | 

### Return type

[**ClientGetDto**](ClientGetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiClientIdPut

> void ApiClientIdPut (long id, ClientPostDto clientPostDto = null)

Put method for changing data in the client table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiClientIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new ClientApi(Configuration.Default);
            var id = 789;  // long | 
            var clientPostDto = new ClientPostDto(); // ClientPostDto |  (optional) 

            try
            {
                // Put method for changing data in the client table
                apiInstance.ApiClientIdPut(id, clientPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ClientApi.ApiClientIdPut: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **long**|  | 
 **clientPostDto** | [**ClientPostDto**](ClientPostDto.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json
- **Accept**: Not defined

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiClientPost

> ClientGetDto ApiClientPost (ClientPostDto clientPostDto = null)

Post method which add new client

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiClientPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new ClientApi(Configuration.Default);
            var clientPostDto = new ClientPostDto(); // ClientPostDto |  (optional) 

            try
            {
                // Post method which add new client
                ClientGetDto result = apiInstance.ApiClientPost(clientPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ClientApi.ApiClientPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientPostDto** | [**ClientPostDto**](ClientPostDto.md)|  | [optional] 

### Return type

[**ClientGetDto**](ClientGetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


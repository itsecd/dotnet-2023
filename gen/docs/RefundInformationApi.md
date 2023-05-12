# Org.OpenAPITools.Api.RefundInformationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiRefundInformationGet**](RefundInformationApi.md#apirefundinformationget) | **GET** /api/RefundInformation | Get method which returns all refund information
[**ApiRefundInformationIdDelete**](RefundInformationApi.md#apirefundinformationiddelete) | **DELETE** /api/RefundInformation/{id} | Delete method for deleting a refund information
[**ApiRefundInformationIdGet**](RefundInformationApi.md#apirefundinformationidget) | **GET** /api/RefundInformation/{id} | Get method which returns refund information by id
[**ApiRefundInformationIdPut**](RefundInformationApi.md#apirefundinformationidput) | **PUT** /api/RefundInformation/{id} | Put method for changing data in the refund information table
[**ApiRefundInformationPost**](RefundInformationApi.md#apirefundinformationpost) | **POST** /api/RefundInformation | Post method which add new refund information



## ApiRefundInformationGet

> List&lt;RefundInformation&gt; ApiRefundInformationGet ()

Get method which returns all refund information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRefundInformationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RefundInformationApi(Configuration.Default);

            try
            {
                // Get method which returns all refund information
                List<RefundInformation> result = apiInstance.ApiRefundInformationGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RefundInformationApi.ApiRefundInformationGet: " + e.Message );
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

[**List&lt;RefundInformation&gt;**](RefundInformation.md)

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


## ApiRefundInformationIdDelete

> void ApiRefundInformationIdDelete (long id)

Delete method for deleting a refund information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRefundInformationIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RefundInformationApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a refund information
                apiInstance.ApiRefundInformationIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RefundInformationApi.ApiRefundInformationIdDelete: " + e.Message );
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


## ApiRefundInformationIdGet

> RefundInformation ApiRefundInformationIdGet (long id)

Get method which returns refund information by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRefundInformationIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RefundInformationApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns refund information by id
                RefundInformation result = apiInstance.ApiRefundInformationIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RefundInformationApi.ApiRefundInformationIdGet: " + e.Message );
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

[**RefundInformation**](RefundInformation.md)

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


## ApiRefundInformationIdPut

> void ApiRefundInformationIdPut (long id, RefundInformationPostDto refundInformationPostDto = null)

Put method for changing data in the refund information table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRefundInformationIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RefundInformationApi(Configuration.Default);
            var id = 789;  // long | 
            var refundInformationPostDto = new RefundInformationPostDto(); // RefundInformationPostDto |  (optional) 

            try
            {
                // Put method for changing data in the refund information table
                apiInstance.ApiRefundInformationIdPut(id, refundInformationPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RefundInformationApi.ApiRefundInformationIdPut: " + e.Message );
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
 **refundInformationPostDto** | [**RefundInformationPostDto**](RefundInformationPostDto.md)|  | [optional] 

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


## ApiRefundInformationPost

> RefundInformation ApiRefundInformationPost (RefundInformationPostDto refundInformationPostDto = null)

Post method which add new refund information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRefundInformationPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RefundInformationApi(Configuration.Default);
            var refundInformationPostDto = new RefundInformationPostDto(); // RefundInformationPostDto |  (optional) 

            try
            {
                // Post method which add new refund information
                RefundInformation result = apiInstance.ApiRefundInformationPost(refundInformationPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RefundInformationApi.ApiRefundInformationPost: " + e.Message );
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
 **refundInformationPostDto** | [**RefundInformationPostDto**](RefundInformationPostDto.md)|  | [optional] 

### Return type

[**RefundInformation**](RefundInformation.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/_*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


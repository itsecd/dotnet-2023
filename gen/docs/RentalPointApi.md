# Org.OpenAPITools.Api.RentalPointApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiRentalPointGet**](RentalPointApi.md#apirentalpointget) | **GET** /api/RentalPoint | Get method which returns all rental points
[**ApiRentalPointIdDelete**](RentalPointApi.md#apirentalpointiddelete) | **DELETE** /api/RentalPoint/{id} | Delete method for deleting a rental point
[**ApiRentalPointIdGet**](RentalPointApi.md#apirentalpointidget) | **GET** /api/RentalPoint/{id} | Get method which returns rental point by id
[**ApiRentalPointIdPut**](RentalPointApi.md#apirentalpointidput) | **PUT** /api/RentalPoint/{id} | Put method for changing data in the rental point table
[**ApiRentalPointPost**](RentalPointApi.md#apirentalpointpost) | **POST** /api/RentalPoint | Post method which add new rental point



## ApiRentalPointGet

> List&lt;RentalPointGetDto&gt; ApiRentalPointGet ()

Get method which returns all rental points

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalPointGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalPointApi(Configuration.Default);

            try
            {
                // Get method which returns all rental points
                List<RentalPointGetDto> result = apiInstance.ApiRentalPointGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalPointApi.ApiRentalPointGet: " + e.Message );
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

[**List&lt;RentalPointGetDto&gt;**](RentalPointGetDto.md)

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


## ApiRentalPointIdDelete

> void ApiRentalPointIdDelete (long id)

Delete method for deleting a rental point

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalPointIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalPointApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a rental point
                apiInstance.ApiRentalPointIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalPointApi.ApiRentalPointIdDelete: " + e.Message );
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


## ApiRentalPointIdGet

> RentalPointGetDto ApiRentalPointIdGet (long id)

Get method which returns rental point by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalPointIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalPointApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns rental point by id
                RentalPointGetDto result = apiInstance.ApiRentalPointIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalPointApi.ApiRentalPointIdGet: " + e.Message );
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

[**RentalPointGetDto**](RentalPointGetDto.md)

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


## ApiRentalPointIdPut

> void ApiRentalPointIdPut (long id, RentalPointPostDto rentalPointPostDto = null)

Put method for changing data in the rental point table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalPointIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalPointApi(Configuration.Default);
            var id = 789;  // long | 
            var rentalPointPostDto = new RentalPointPostDto(); // RentalPointPostDto |  (optional) 

            try
            {
                // Put method for changing data in the rental point table
                apiInstance.ApiRentalPointIdPut(id, rentalPointPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalPointApi.ApiRentalPointIdPut: " + e.Message );
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
 **rentalPointPostDto** | [**RentalPointPostDto**](RentalPointPostDto.md)|  | [optional] 

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


## ApiRentalPointPost

> RentalPointGetDto ApiRentalPointPost (RentalPointPostDto rentalPointPostDto = null)

Post method which add new rental point

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalPointPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalPointApi(Configuration.Default);
            var rentalPointPostDto = new RentalPointPostDto(); // RentalPointPostDto |  (optional) 

            try
            {
                // Post method which add new rental point
                RentalPointGetDto result = apiInstance.ApiRentalPointPost(rentalPointPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalPointApi.ApiRentalPointPost: " + e.Message );
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
 **rentalPointPostDto** | [**RentalPointPostDto**](RentalPointPostDto.md)|  | [optional] 

### Return type

[**RentalPointGetDto**](RentalPointGetDto.md)

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


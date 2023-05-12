# Org.OpenAPITools.Api.VehicleApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiVehicleGet**](VehicleApi.md#apivehicleget) | **GET** /api/Vehicle | Get method which returns all vehicles
[**ApiVehicleIdDelete**](VehicleApi.md#apivehicleiddelete) | **DELETE** /api/Vehicle/{id} | Delete method for deleting a vehicle
[**ApiVehicleIdGet**](VehicleApi.md#apivehicleidget) | **GET** /api/Vehicle/{id} | Get method which returns vehicle by id
[**ApiVehicleIdPut**](VehicleApi.md#apivehicleidput) | **PUT** /api/Vehicle/{id} | Put method for changing data in the vehicle table
[**ApiVehiclePost**](VehicleApi.md#apivehiclepost) | **POST** /api/Vehicle | Post method which add new vehicle



## ApiVehicleGet

> List&lt;VehicleGetDto&gt; ApiVehicleGet ()

Get method which returns all vehicles

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleApi(Configuration.Default);

            try
            {
                // Get method which returns all vehicles
                List<VehicleGetDto> result = apiInstance.ApiVehicleGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleApi.ApiVehicleGet: " + e.Message );
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

[**List&lt;VehicleGetDto&gt;**](VehicleGetDto.md)

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


## ApiVehicleIdDelete

> void ApiVehicleIdDelete (long id)

Delete method for deleting a vehicle

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a vehicle
                apiInstance.ApiVehicleIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleApi.ApiVehicleIdDelete: " + e.Message );
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


## ApiVehicleIdGet

> VehicleGetDto ApiVehicleIdGet (long id)

Get method which returns vehicle by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns vehicle by id
                VehicleGetDto result = apiInstance.ApiVehicleIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleApi.ApiVehicleIdGet: " + e.Message );
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

[**VehicleGetDto**](VehicleGetDto.md)

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


## ApiVehicleIdPut

> void ApiVehicleIdPut (long id, VehiclePostDto vehiclePostDto = null)

Put method for changing data in the vehicle table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleApi(Configuration.Default);
            var id = 789;  // long | 
            var vehiclePostDto = new VehiclePostDto(); // VehiclePostDto |  (optional) 

            try
            {
                // Put method for changing data in the vehicle table
                apiInstance.ApiVehicleIdPut(id, vehiclePostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleApi.ApiVehicleIdPut: " + e.Message );
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
 **vehiclePostDto** | [**VehiclePostDto**](VehiclePostDto.md)|  | [optional] 

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


## ApiVehiclePost

> VehicleGetDto ApiVehiclePost (VehiclePostDto vehiclePostDto = null)

Post method which add new vehicle

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehiclePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleApi(Configuration.Default);
            var vehiclePostDto = new VehiclePostDto(); // VehiclePostDto |  (optional) 

            try
            {
                // Post method which add new vehicle
                VehicleGetDto result = apiInstance.ApiVehiclePost(vehiclePostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleApi.ApiVehiclePost: " + e.Message );
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
 **vehiclePostDto** | [**VehiclePostDto**](VehiclePostDto.md)|  | [optional] 

### Return type

[**VehicleGetDto**](VehicleGetDto.md)

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


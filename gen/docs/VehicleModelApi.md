# Org.OpenAPITools.Api.VehicleModelApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiVehicleModelGet**](VehicleModelApi.md#apivehiclemodelget) | **GET** /api/VehicleModel | Get method which returns all vehicle models
[**ApiVehicleModelIdDelete**](VehicleModelApi.md#apivehiclemodeliddelete) | **DELETE** /api/VehicleModel/{id} | Delete method for deleting a vehicle model
[**ApiVehicleModelIdGet**](VehicleModelApi.md#apivehiclemodelidget) | **GET** /api/VehicleModel/{id} | Get method which returns vehicle model by id
[**ApiVehicleModelIdPut**](VehicleModelApi.md#apivehiclemodelidput) | **PUT** /api/VehicleModel/{id} | Put method for changing data in the vehicle model table
[**ApiVehicleModelPost**](VehicleModelApi.md#apivehiclemodelpost) | **POST** /api/VehicleModel | Post method which add new vehicle model



## ApiVehicleModelGet

> List&lt;VehicleModelGetDto&gt; ApiVehicleModelGet ()

Get method which returns all vehicle models

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleModelGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleModelApi(Configuration.Default);

            try
            {
                // Get method which returns all vehicle models
                List<VehicleModelGetDto> result = apiInstance.ApiVehicleModelGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleModelApi.ApiVehicleModelGet: " + e.Message );
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

[**List&lt;VehicleModelGetDto&gt;**](VehicleModelGetDto.md)

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


## ApiVehicleModelIdDelete

> void ApiVehicleModelIdDelete (long id)

Delete method for deleting a vehicle model

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleModelIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleModelApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a vehicle model
                apiInstance.ApiVehicleModelIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleModelApi.ApiVehicleModelIdDelete: " + e.Message );
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


## ApiVehicleModelIdGet

> VehicleModelGetDto ApiVehicleModelIdGet (long id)

Get method which returns vehicle model by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleModelIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleModelApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns vehicle model by id
                VehicleModelGetDto result = apiInstance.ApiVehicleModelIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleModelApi.ApiVehicleModelIdGet: " + e.Message );
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

[**VehicleModelGetDto**](VehicleModelGetDto.md)

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


## ApiVehicleModelIdPut

> void ApiVehicleModelIdPut (long id, VehicleModelPostDto vehicleModelPostDto = null)

Put method for changing data in the vehicle model table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleModelIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleModelApi(Configuration.Default);
            var id = 789;  // long | 
            var vehicleModelPostDto = new VehicleModelPostDto(); // VehicleModelPostDto |  (optional) 

            try
            {
                // Put method for changing data in the vehicle model table
                apiInstance.ApiVehicleModelIdPut(id, vehicleModelPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleModelApi.ApiVehicleModelIdPut: " + e.Message );
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
 **vehicleModelPostDto** | [**VehicleModelPostDto**](VehicleModelPostDto.md)|  | [optional] 

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


## ApiVehicleModelPost

> VehicleModelGetDto ApiVehicleModelPost (VehicleModelPostDto vehicleModelPostDto = null)

Post method which add new vehicle model

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiVehicleModelPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new VehicleModelApi(Configuration.Default);
            var vehicleModelPostDto = new VehicleModelPostDto(); // VehicleModelPostDto |  (optional) 

            try
            {
                // Post method which add new vehicle model
                VehicleModelGetDto result = apiInstance.ApiVehicleModelPost(vehicleModelPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling VehicleModelApi.ApiVehicleModelPost: " + e.Message );
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
 **vehicleModelPostDto** | [**VehicleModelPostDto**](VehicleModelPostDto.md)|  | [optional] 

### Return type

[**VehicleModelGetDto**](VehicleModelGetDto.md)

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


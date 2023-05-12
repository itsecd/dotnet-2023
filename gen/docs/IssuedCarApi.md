# Org.OpenAPITools.Api.IssuedCarApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiIssuedCarGet**](IssuedCarApi.md#apiissuedcarget) | **GET** /api/IssuedCar | Get method which returns all issued cars
[**ApiIssuedCarIdDelete**](IssuedCarApi.md#apiissuedcariddelete) | **DELETE** /api/IssuedCar/{id} | Delete method for deleting a issued car
[**ApiIssuedCarIdGet**](IssuedCarApi.md#apiissuedcaridget) | **GET** /api/IssuedCar/{id} | Get method which returns issued car by id
[**ApiIssuedCarIdPut**](IssuedCarApi.md#apiissuedcaridput) | **PUT** /api/IssuedCar/{id} | Put method for changing data in the issued car table
[**ApiIssuedCarPost**](IssuedCarApi.md#apiissuedcarpost) | **POST** /api/IssuedCar | Post method which add new issued car



## ApiIssuedCarGet

> List&lt;IssuedCar&gt; ApiIssuedCarGet ()

Get method which returns all issued cars

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiIssuedCarGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new IssuedCarApi(Configuration.Default);

            try
            {
                // Get method which returns all issued cars
                List<IssuedCar> result = apiInstance.ApiIssuedCarGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuedCarApi.ApiIssuedCarGet: " + e.Message );
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

[**List&lt;IssuedCar&gt;**](IssuedCar.md)

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


## ApiIssuedCarIdDelete

> void ApiIssuedCarIdDelete (long id)

Delete method for deleting a issued car

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiIssuedCarIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new IssuedCarApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a issued car
                apiInstance.ApiIssuedCarIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuedCarApi.ApiIssuedCarIdDelete: " + e.Message );
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


## ApiIssuedCarIdGet

> IssuedCar ApiIssuedCarIdGet (long id)

Get method which returns issued car by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiIssuedCarIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new IssuedCarApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns issued car by id
                IssuedCar result = apiInstance.ApiIssuedCarIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuedCarApi.ApiIssuedCarIdGet: " + e.Message );
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

[**IssuedCar**](IssuedCar.md)

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


## ApiIssuedCarIdPut

> void ApiIssuedCarIdPut (long id, IssuedCarPostDto issuedCarPostDto = null)

Put method for changing data in the issued car table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiIssuedCarIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new IssuedCarApi(Configuration.Default);
            var id = 789;  // long | 
            var issuedCarPostDto = new IssuedCarPostDto(); // IssuedCarPostDto |  (optional) 

            try
            {
                // Put method for changing data in the issued car table
                apiInstance.ApiIssuedCarIdPut(id, issuedCarPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuedCarApi.ApiIssuedCarIdPut: " + e.Message );
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
 **issuedCarPostDto** | [**IssuedCarPostDto**](IssuedCarPostDto.md)|  | [optional] 

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


## ApiIssuedCarPost

> IssuedCar ApiIssuedCarPost (IssuedCarPostDto issuedCarPostDto = null)

Post method which add new issued car

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiIssuedCarPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new IssuedCarApi(Configuration.Default);
            var issuedCarPostDto = new IssuedCarPostDto(); // IssuedCarPostDto |  (optional) 

            try
            {
                // Post method which add new issued car
                IssuedCar result = apiInstance.ApiIssuedCarPost(issuedCarPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuedCarApi.ApiIssuedCarPost: " + e.Message );
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
 **issuedCarPostDto** | [**IssuedCarPostDto**](IssuedCarPostDto.md)|  | [optional] 

### Return type

[**IssuedCar**](IssuedCar.md)

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


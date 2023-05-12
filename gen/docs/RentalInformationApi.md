# Org.OpenAPITools.Api.RentalInformationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiRentalInformationGet**](RentalInformationApi.md#apirentalinformationget) | **GET** /api/RentalInformation | Get method which returns all rental information
[**ApiRentalInformationIdDelete**](RentalInformationApi.md#apirentalinformationiddelete) | **DELETE** /api/RentalInformation/{id} | Delete method for deleting a rental information
[**ApiRentalInformationIdGet**](RentalInformationApi.md#apirentalinformationidget) | **GET** /api/RentalInformation/{id} | Get method which returns rental information by id
[**ApiRentalInformationIdPut**](RentalInformationApi.md#apirentalinformationidput) | **PUT** /api/RentalInformation/{id} | Put method for changing data in the rental information table
[**ApiRentalInformationPost**](RentalInformationApi.md#apirentalinformationpost) | **POST** /api/RentalInformation | Post method which add new rental information



## ApiRentalInformationGet

> List&lt;RentalInformation&gt; ApiRentalInformationGet ()

Get method which returns all rental information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalInformationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalInformationApi(Configuration.Default);

            try
            {
                // Get method which returns all rental information
                List<RentalInformation> result = apiInstance.ApiRentalInformationGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalInformationApi.ApiRentalInformationGet: " + e.Message );
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

[**List&lt;RentalInformation&gt;**](RentalInformation.md)

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


## ApiRentalInformationIdDelete

> void ApiRentalInformationIdDelete (long id)

Delete method for deleting a rental information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalInformationIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalInformationApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Delete method for deleting a rental information
                apiInstance.ApiRentalInformationIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalInformationApi.ApiRentalInformationIdDelete: " + e.Message );
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


## ApiRentalInformationIdGet

> RentalInformation ApiRentalInformationIdGet (long id)

Get method which returns rental information by id

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalInformationIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalInformationApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get method which returns rental information by id
                RentalInformation result = apiInstance.ApiRentalInformationIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalInformationApi.ApiRentalInformationIdGet: " + e.Message );
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

[**RentalInformation**](RentalInformation.md)

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


## ApiRentalInformationIdPut

> void ApiRentalInformationIdPut (long id, RentalInformationPostDto rentalInformationPostDto = null)

Put method for changing data in the rental information table

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalInformationIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalInformationApi(Configuration.Default);
            var id = 789;  // long | 
            var rentalInformationPostDto = new RentalInformationPostDto(); // RentalInformationPostDto |  (optional) 

            try
            {
                // Put method for changing data in the rental information table
                apiInstance.ApiRentalInformationIdPut(id, rentalInformationPostDto);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalInformationApi.ApiRentalInformationIdPut: " + e.Message );
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
 **rentalInformationPostDto** | [**RentalInformationPostDto**](RentalInformationPostDto.md)|  | [optional] 

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


## ApiRentalInformationPost

> RentalInformation ApiRentalInformationPost (RentalInformationPostDto rentalInformationPostDto = null)

Post method which add new rental information

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRentalInformationPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RentalInformationApi(Configuration.Default);
            var rentalInformationPostDto = new RentalInformationPostDto(); // RentalInformationPostDto |  (optional) 

            try
            {
                // Post method which add new rental information
                RentalInformation result = apiInstance.ApiRentalInformationPost(rentalInformationPostDto);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RentalInformationApi.ApiRentalInformationPost: " + e.Message );
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
 **rentalInformationPostDto** | [**RentalInformationPostDto**](RentalInformationPostDto.md)|  | [optional] 

### Return type

[**RentalInformation**](RentalInformation.md)

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


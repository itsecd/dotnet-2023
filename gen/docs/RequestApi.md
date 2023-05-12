# Org.OpenAPITools.Api.RequestApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiRequestCarsForRentGet**](RequestApi.md#apirequestcarsforrentget) | **GET** /api/Request/cars_for_rent | Get information about cars that are rented
[**ApiRequestClientsByModelIdIdGet**](RequestApi.md#apirequestclientsbymodelididget) | **GET** /api/Request/clients_by_model_id/{id} | Get information about clients who took the car with the specified identifier
[**ApiRequestNumberOfLeasesForEachCarGet**](RequestApi.md#apirequestnumberofleasesforeachcarget) | **GET** /api/Request/number_of_leases_for_each_car | Get the number of leases for each car
[**ApiRequestTopCarRentalLocationsGet**](RequestApi.md#apirequesttopcarrentallocationsget) | **GET** /api/Request/top_car_rental_locations | Get information about rental locations where cars have been rented the maximum number of times,  arrange by name
[**ApiRequestTopFiveFrequentlyRentedVehiclesGet**](RequestApi.md#apirequesttopfivefrequentlyrentedvehiclesget) | **GET** /api/Request/top_five_frequently_rented_vehicles | Get information about the top 5 most frequently rented cars
[**ApiRequestVehiclesGet**](RequestApi.md#apirequestvehiclesget) | **GET** /api/Request/vehicles | Get information about vehicles



## ApiRequestCarsForRentGet

> void ApiRequestCarsForRentGet ()

Get information about cars that are rented

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestCarsForRentGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);

            try
            {
                // Get information about cars that are rented
                apiInstance.ApiRequestCarsForRentGet();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestCarsForRentGet: " + e.Message );
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


## ApiRequestClientsByModelIdIdGet

> void ApiRequestClientsByModelIdIdGet (long id)

Get information about clients who took the car with the specified identifier

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestClientsByModelIdIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);
            var id = 789;  // long | 

            try
            {
                // Get information about clients who took the car with the specified identifier
                apiInstance.ApiRequestClientsByModelIdIdGet(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestClientsByModelIdIdGet: " + e.Message );
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


## ApiRequestNumberOfLeasesForEachCarGet

> void ApiRequestNumberOfLeasesForEachCarGet ()

Get the number of leases for each car

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestNumberOfLeasesForEachCarGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);

            try
            {
                // Get the number of leases for each car
                apiInstance.ApiRequestNumberOfLeasesForEachCarGet();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestNumberOfLeasesForEachCarGet: " + e.Message );
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


## ApiRequestTopCarRentalLocationsGet

> void ApiRequestTopCarRentalLocationsGet ()

Get information about rental locations where cars have been rented the maximum number of times,  arrange by name

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestTopCarRentalLocationsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);

            try
            {
                // Get information about rental locations where cars have been rented the maximum number of times,  arrange by name
                apiInstance.ApiRequestTopCarRentalLocationsGet();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestTopCarRentalLocationsGet: " + e.Message );
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


## ApiRequestTopFiveFrequentlyRentedVehiclesGet

> void ApiRequestTopFiveFrequentlyRentedVehiclesGet ()

Get information about the top 5 most frequently rented cars

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestTopFiveFrequentlyRentedVehiclesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);

            try
            {
                // Get information about the top 5 most frequently rented cars
                apiInstance.ApiRequestTopFiveFrequentlyRentedVehiclesGet();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestTopFiveFrequentlyRentedVehiclesGet: " + e.Message );
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


## ApiRequestVehiclesGet

> List&lt;VehicleGetDto&gt; ApiRequestVehiclesGet ()

Get information about vehicles

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiRequestVehiclesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "http://localhost";
            var apiInstance = new RequestApi(Configuration.Default);

            try
            {
                // Get information about vehicles
                List<VehicleGetDto> result = apiInstance.ApiRequestVehiclesGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RequestApi.ApiRequestVehiclesGet: " + e.Message );
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


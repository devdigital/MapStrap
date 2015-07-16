# MapStrap
MapStrap is a simple set of interfaces for defining mappings between types in a strictly layered .NET application.

MapStrap uses [AutoMapper](http://automapper.org/) to provide the automated mapping using a convention based approach. 
It simplifies the configuration of AutoMapper through a simple set of interfaces that move mapping code away from bootstrapping
code and next to the associated Data Transfer Object (DTO).

# Quickstart

1. Install the [MapStrap](https://www.nuget.org/packages/MapStrap) NuGet package.
2. Use the MapStrap interface types on your Data Transfer Objects (DTOs) to define your AutoMapper mappings.
3. Use the MapStrap type to bootstrap the configuration of AutoMapper.

# Details

## Mapping from Domain Models to Data Transfer Objects (DTOs)

In a strictly layered application, DTOs are used in responses. 
For example, in an MVC application a view model is passed to a view, rather than a domain model directly. 
In a Web API, an API model is returned as the response, rather than returning a domain model.

To configure your mapping between your domain model and DTO, use one of the following interfaces provided by MapStrap on your DTO types:

* IMapFromDomain<TDomain> - use this for convention only based mappings
* IHaveCustomMap<TSource, TDestination> - use this to add overriding configurations to your mappings (gets access to AutoMapper IMappingExpression)
* IHaveCustomConfiguration - use this to have access to full AutoMapper configuration (gets access to AutoMapper IConfiguration)

### Examples

## Mapping from Data Transfer Objects (DTOs) to Domain Models

## Bootstrapping


## Mapping

# Downloads

* [MapStrap](https://www.nuget.org/packages/MapStrap/)

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
For example, in an MVC application a view model is passed to a view, rather than exposing a domain model. 
In a Web API, an API model is serialized as part of the response to an HTTP request, rather than returning a domain model directly.

To configure your mapping between your domain model and DTO, use one of the following interfaces provided by MapStrap on your DTO types:

* `IMapFromDomain<TDomain>` - use this for convention only based mappings
* `IHaveCustomMap<TSource, TDestination>` - use this to add overriding configurations to your mappings (gets access to AutoMapper IMappingExpression)
* `IHaveCustomConfiguration` - use this to have access to full AutoMapper configuration (gets access to AutoMapper IConfiguration)

### Examples

Assume that we have the following `User` domain model:

```csharp
public class User
{
    private readonly int id;
    
    private readonly string name;

    public User(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
    
    public int Id
    {
        get
        {
            return this.id;
        }
    }
    
    public string Name
    {
        get
        {
            return this.name;
        }
    }
}
```

If we wish to map by convention only (map property values if their names match), then we can define our `UserDto` using the `IMapFromDomain<TDomain>` interface, where `TDomain` is the type of the domain model that we are mapping from (in this case `User`).

```csharp
public class UserDto : IMapFromDomain<User>
{
   public int Id { get; set; }
   public string Name { get; set; }
}
```

That's it! You'll see later how we bootstrap using MapStrap so that the appropriate AutoMapper mapping is automatically created, and how we then perform a mapping from a `User` instance to a `UserDto`.

### Mapping Customisations 

If you wish to add some futher configuration to your mapping, to override some of the AutoMapper conventions, then you can use the `IHaveCustomMap<TSource, TDestination>` where `TSource` is the domain type (in this case `User`) and `TDestination` is the DTO type (in this case `UserDto`). 

This interface defines a Map method that takes an AutoMapper `IMappingExpression<TSource, TDestination>`:

```csharp
public class UserDto : IHaveCustomMap<User, UserDto>
{
   public int Id { get; set; }
   public string Name { get; set; }
   
   public void Map(IMappingExpression<User, UserDto> mapping)
   {
      mapping.ForMember(
          u => u.Name,
          cfg => cfg.ResolveUsing(u => "User name is " + u.Id));
   }
}
```

If you want full control over AutoMapper, then you can use the `IHaveCustomConfiguration` interface. This defines a `Configure` method which takes the AutoMapper configuration instance:

```csharp
public class UserDto : IHaveCustomConfiguration
{
   public int Id { get; set; }
   public string Name { get; set; }
   
   public void Configure(IConfiguration configuration)
   {
       // Access AutoMapper configuration instance here
       ...
   }
}
```

## Mapping from Data Transfer Objects (DTOs) to Domain Models

Domain models use encapsulation to protect their invariants, therefore AutoMapper is not used to map from DTOs to domain models. However, MapStrap does provide a couple of convenience methods to standardise how domain models are instantiated from DTOs.

A typical example is when returning domain models from domain repositories where repository implementations sit within a data layer, and the data layer uses DTOs to model the data store - for example mapping Entity Framework DTOs used within `DbSets` to domain models.

### Examples

In the majority of cases your data DTO will map to a single domain model type. You can use the provided `IMapToDomain<TDomain>` interface on your data DTO. It defines a single `TDomain ToDomainModel()` method:

```
public class UserDataDto : IMapToDomain<User>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User ToDomainModel()
    {
       return new User(this.Id, this.Name);
    }
}
```

In some cases your data DTO may map to more than one domain type. In this case, you can continue decorating your data DTO type with multiple instances of `IMapToAlternativeDomain<TDomain>` - one for each domain model type. This interface defines a single `void ToDomainModel(out TDomain result)` method:

```
public class UserDataDto : IMapToDomain<User>, IMapToAlternativeDomain<Admin>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User ToDomainModel()
    {
       return new User(this.Id, this.Name);
    }
    
    public void ToDomainModel(out Admin result)
    {
       result = new Admin(...);
    }
}
```

## Bootstrapping


## Mapping

# Downloads

MapStrap is available via NuGet:

* [MapStrap](https://www.nuget.org/packages/MapStrap/)

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

* *IMapFromDomain<TDomain>* - use this for convention only based mappings
* *IHaveCustomMap<TSource, TDestination>* - use this to add overriding configurations to your mappings (gets access to AutoMapper IMappingExpression)
* *IHaveCustomConfiguration* - use this to have access to full AutoMapper configuration (gets access to AutoMapper IConfiguration)

### Examples

Assume that we have the following *User* domain model:

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

If we wish to map by convention only (map property values if their names match), then we can define our *UserDto* using the *IMapFromDomain<TDomain>* interface, where TDomain is the type of the domain model that we are mapping from (in this case *User*).

```csharp
public class UserDto : IMapFromDomain<User>
{
   public int Id { get; set; }
   public string Name { get; set; }
}
```

That's it! You'll see later how we bootstrap MapStrap so that the appropriate AutoMapper mapping is automatically created, and how we then perform a mapping from a *User* instance to a *UserDto*.

If you wish to add some futher configuration to your mapping, to override some of the AutoMapper conventions, then you can use the *IHaveCustomMap<TSource, TDestination>* where TSource is the domain type (in this case *User*) and TDestination is the DTO type (in this case *UserDto*). 

This interface defines a Map method that takes an AutoMapper IMappingExpression<TSource, TDestination>:

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

## Mapping from Data Transfer Objects (DTOs) to Domain Models

## Bootstrapping


## Mapping

# Downloads

* [MapStrap](https://www.nuget.org/packages/MapStrap/)

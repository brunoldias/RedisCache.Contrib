## RedisCache.Contrib [![RedisCache](https://badgen.net/nuget/v/RedisCache.Contrib/latest)](https://www.nuget.org/packages/RedisCache.Contrib/)

Library to use simple distributed caching.

## How to use

- You need install [docker](https://docs.docker.com/desktop/install/windows-install/) in your machine to build in local, you can use in production just alter a configuration Instace in startup project.

```
docker run -d -p 6379:6379 -i -t redis:3.2.5-alpine
```
 - Install RedisCache.Contrib: [![RedisCache](https://badgen.net/nuget/v/RedisCache.Contrib/latest)](https://www.nuget.org/packages/RedisCache.Contrib/) on your application.
 - Insert in your startup the code below:
 
 ```
  builder.Services.AddRedisCache(opt => { opt.InstanceName = "redis-cache"; opt.Configuration = "localhost:6379"; });
 ```
![image](https://github.com/brunoldias/RedisCache.Contrib/assets/40918591/5be4cacd-2b66-438f-aeea-dd255896227f)

- After installing you can use the interface ICacheManager in your application. you can see below:

![image](https://github.com/brunoldias/RedisCache.Contrib/assets/40918591/9f9a4058-0190-4f73-ae8c-237c07459797)

- In this interface there are two methods

- ExecuteCacheAsync - creates and retrieves information from the cache, you need to pass three parameters to class.
  
 ![image](https://github.com/brunoldias/RedisCache.Contrib/assets/40918591/0bf9969e-ca5e-4e5b-addb-615ff63ab65f)
 
Params : 
 - key - parameter to pass the name of the key value that will be stored
 - value - a lambda expression where the data you want to cache will run.
 - TimeExpiration - parameter used to expire the stored cache, it is an ENUM, which is composed as follows:
  
  ![image](https://github.com/brunoldias/RedisCache.Contrib/assets/40918591/c78ed424-de1b-4cb9-8487-6fc3b8f75716)
  
 - Another parameter is Get() - 
brings the key stored in the bank and its value.

Params: 
 - key - pass a key armazened and you have returned your value.

this project is growing, new features will be started, you can contribute.





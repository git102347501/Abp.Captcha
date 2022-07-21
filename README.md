# Abp.Captcha

This is an open source module based on ABP module, which provides human-machine verification and behavior safety verification. You can use this module to verify the human-machine of your application interface caller, and control the behavior risk of the user to match the appropriate verification rules, so as to ensure that the program call can be operated by yourself more safely.

[![NuGet](https://img.shields.io/nuget/v/MagicalConch.Abp.Captcha.Web.svg?style=flat-square)](https://www.nuget.org/packages/MagicalConch.Abp.Captcha.Web)
![NuGet Download(0.3.0.1)](https://img.shields.io/nuget/dt/Volo.Abp.Core.svg?style=flat-square)

The first stage will provide man-machine verification module, slide bar verification and puzzle verification and user behavior safety assessment module based on ABP vNext.

### Quick Start

Install the ABP CLI:

````bash
> dotnet add package MagicalConch.Abp.Captcha.Web
> dotnet add package MagicalConch.Abp.Captcha.Application.Contracts
> dotnet add package MagicalConch.Abp.Captcha.Domain
> dotnet add package MagicalConch.Abp.Captcha.Application 
> dotnet add package MagicalConch.Abp.Captcha.HttpApi.Client 
> dotnet add package MagicalConch.Abp.Captcha.EntityFrameworkCore 
> dotnet add package MagicalConch.Abp.Captcha.Domain.Shared 
> dotnet add package MagicalConch.Abp.Captcha.HttpApi 
> dotnet add package MagicalConch.Abp.Captcha.Web
````
Using module and configure:

````bash

  using MaigcalConch.Abp.Captcha;
  
  // Form:XXXApplicationModule:
    // ...
      typeof(MagicalConchCaptchaApplicationModule)
    // ...
    
  // Form:XXXApplicationContractsModule:
    // ...
      typeof(MagicalConchCaptchaApplicationContractsModule)
    // ...
    
  // Form:XXXDomainModule:
    // ...
      typeof(MagicalConchCaptchaDomainModule)
    // ...
    
  // Form:XXXDomainSharedModule:
    // ...
      typeof(MagicalConchCaptchaDomainSharedModule)
    // ...
    
  // Form:XXXEntityFrameworkCoreModule:
    // ...
      typeof(BlogEntityFrameworkCoreModule)
    // ...
    
  // Form:XXXHttpApiModule:
    // ...
      typeof(MagicalConchCaptchaHttpApiModule)
    // ...
    
  // Form:XXXHttpApiHostModule:
    // ...
      typeof(MagicalConchCaptchaWebModule)
    // ...
    private void ConfigureConventionalControllers()
      {
        // ...
        options
           .ConventionalControllers
           .Create(typeof(MagicalConchCaptchaApplicationModule).Assembly);
        // ...
      }
    ...
````


### Using frames
- Abp vNext：4.0
- Obj Type：Module


### Environment dependent
- Redis


### DEMO

- User Interface：
- ![User Interface](https://user-images.githubusercontent.com/37917403/112716491-b1866600-8f21-11eb-874e-fdfc6c328334.png)

- API Manage：
- ![API Manage](https://user-images.githubusercontent.com/37917403/125195593-e1673880-e288-11eb-8ff0-70f0570e29e1.png)

### Module Configuration Description
TODO

### Operation Instructions
TODO

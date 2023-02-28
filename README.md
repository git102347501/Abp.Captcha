# Abp.Captcha

This is an open source module based on ABP module, which provides human-machine verification and behavior safety verification. You can use this module to verify the human-machine of your application interface caller, and control the behavior risk of the user to match the appropriate verification rules, so as to ensure that the program call can be operated by yourself more safely.

[![NuGet](https://img.shields.io/nuget/v/MagicalConch.Abp.Captcha.Web.svg?style=flat-square)](https://www.nuget.org/packages/MagicalConch.Abp.Captcha.Web)
<a href="https://www.npmjs.com/package/abp-captcha"><img src="https://img.shields.io/npm/v/abpcaptcha.svg?sanitize=true"></a>
<a href="https://www.npmjs.com/package/abp-captcha"><img src="https://img.shields.io/npm/l/abpcaptcha.svg?sanitize=true" alt="License"></a>
### DEMO

- User Interface：
- ![User Interface](https://user-images.githubusercontent.com/37917403/112716491-b1866600-8f21-11eb-874e-fdfc6c328334.png)

- API Manage：
- ![API Manage](https://user-images.githubusercontent.com/37917403/125195593-e1673880-e288-11eb-8ff0-70f0570e29e1.png)

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

Using Authentication in API Controllers

````
 /// <summary>
    /// test
    /// </summary>
    [RemoteService]
    [Route("api/Captcha/sample")]
    public class SampleController : CaptchaController
    {
        [HttpGet]
        [Route("test")]
        [Captcha]
        public bool GetTest()
        {
            return true;
        }

        [HttpGet]
        [Route("slidertest")]
        [Slider]
        public bool GetTest1()
        {
            return true;
        }
    }
````

Angular Using:

Add Npm Package:
````
yarn add abpcaptcha
or
npm i abpcaptcha
````

Import Module:
````
@NgModule({
  ...
  imports: [
    ...
    CaptchaModule
  ]
  ...
})

export class YourModule { }
````

For Dom:
````
<app-captcha-picture ref="captcha" url="{your captcha api basic url}"></app-captcha-picture>
Get the properties {index, code} in the component through ref
````

For Modal:
````
const modal = this.modal.create({
  nzTitle: 'Captcha',
  nzContent: CaptchaPictureComponent,
  nzViewContainerRef: this.viewContainerRef,
  nzComponentParams: {
    url: {your captcha api basic url}
  }
});

modal.afterClose.subscribe(result => {
  const instance = modal.getContentComponent();
  this.httpservice.yourapi(this.yourform.value, instance.index, instance.code).subscribe((res: any) => {
    alert('sucess');
  }, err => {
    alert('err');
  });
});
````
### Using frames
- Abp vNext：5.3.0
- Obj Type：Module


### Environment dependent
- Redis

### Module Configuration Description
TODO

### UML
- User Action

  ![1677551288000](https://user-images.githubusercontent.com/37917403/221737819-b801adc2-2c69-4bbc-b722-e250c6ff18c5.png)

### Operation Instructions
TODO
### Online Demo
[MagicalConch](https://www.magicalconch.com)

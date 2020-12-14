import { ModuleWithProviders, NgModule } from '@angular/core';
import { CAPTCHA_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CaptchaConfigModule {
  static forRoot(): ModuleWithProviders<CaptchaConfigModule> {
    return {
      ngModule: CaptchaConfigModule,
      providers: [CAPTCHA_ROUTE_PROVIDERS],
    };
  }
}

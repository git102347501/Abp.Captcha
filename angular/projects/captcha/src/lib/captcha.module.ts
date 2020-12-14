import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CaptchaComponent } from './components/captcha.component';
import { CaptchaRoutingModule } from './captcha-routing.module';

@NgModule({
  declarations: [CaptchaComponent],
  imports: [CoreModule, ThemeSharedModule, CaptchaRoutingModule],
  exports: [CaptchaComponent],
})
export class CaptchaModule {
  static forChild(): ModuleWithProviders<CaptchaModule> {
    return {
      ngModule: CaptchaModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CaptchaModule> {
    return new LazyModuleFactory(CaptchaModule.forChild());
  }
}

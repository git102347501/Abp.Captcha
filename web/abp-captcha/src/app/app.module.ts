import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CaptchaJigsawComponent } from 'src/component/captcha-jigsaw/captcha-jigsaw.component';
import { CaptchaPictureComponent } from 'src/component/captcha-picture/captcha-picture.component';
import { CaptchaSliderComponent } from 'src/component/captcha-slider/captcha-slider.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CaptchaJigsawComponent,
    CaptchaPictureComponent,
    CaptchaSliderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

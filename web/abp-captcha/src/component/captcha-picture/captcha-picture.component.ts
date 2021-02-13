import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CaptchaPictureConfig } from './captcha-picture-config';

@Component({
  selector: 'app-captcha-picture',
  templateUrl: './captcha-picture.component.html',
  styleUrls: ['./captcha-picture.component.scss']
})
export class CaptchaPictureComponent implements OnInit {

  private url = 'https://localhost:44379/';
  public config: CaptchaPictureConfig = new CaptchaPictureConfig('','');
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPicture();
  }

  getPicture() {
     this.http.get(this.url + 'api/app/verify-picture?Length=4').subscribe((res: any) => {
       this.config = new CaptchaPictureConfig(res.index, 'data:image/png;base64,' + res.content);
     });
  }
}

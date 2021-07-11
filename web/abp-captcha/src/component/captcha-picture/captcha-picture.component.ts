import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { mergeMap, catchError } from 'rxjs/operators';
import { CaptchaPictureConfig } from './captcha-picture-config';

@Component({
  selector: 'app-captcha-picture',
  templateUrl: './captcha-picture.component.html',
  styleUrls: ['./captcha-picture.component.scss']
})
export class CaptchaPictureComponent implements OnInit {

  private url = 'https://localhost:44335/';
  public codeValue = '';
  public config: CaptchaPictureConfig = new CaptchaPictureConfig('','');
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPicture();
  }

  /**
   * 获取图片
   */
  getPicture() {
     this.http.get(this.url + 'api/app/verify-picture?Length=4').subscribe((res: any) => {
       this.config = new CaptchaPictureConfig(res.index, 'data:image/png;base64,' + res.content);
       this.codeValue = '';
     });
  }

  /**
   * 验证图片验证码
   */
  verifyInput() {
    var headers = new HttpHeaders({ImgIndex : this.config.index, ImgValue : this.codeValue});
    this.http.get(this.url + 'api/Captcha/sample/test', { headers: headers}).pipe(mergeMap(result => of(result)), catchError(e => { 
        if (e.status === 403) {
          alert('验证失败！');
          this.getPicture();
          return of(undefined);
        }
        return of(e);
      })).subscribe((res: any) => {
        if (res) {
          alert('验证成功！');
        }
    });
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { of } from 'rxjs';
import { catchError, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-captcha-slider',
  templateUrl: './captcha-slider.component.html',
  styleUrls: ['./captcha-slider.component.scss']
})

export class CaptchaSliderComponent implements OnInit {

  @ViewChild('sliderbtn') 
  sliderbtn!: ElementRef;
  @ViewChild('slidercontain') 
  slidercontain!: ElementRef;
  private url = 'http://localhost:44371/';
  public diffX: any;
  public diffY: any;
  public left: any;
  public width: any;
  private slider = false;
  private checkData = [0];
  public loading = false;
  // 是否验证成功 -1:未开启验证 0:验证中 1:验证成功 2:验证失败
  public checkSuccess = -1;
  public silderclass = 'slider-indicator'
  //public top: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
  
  @HostListener('mousedown', ['$event'])
  onMousedown(event: MouseEvent) {
    console.log('mousedown');
    this.slider = true;
    this.checkSuccess = 0;
    this.diffX = event.clientX - this.sliderbtn.nativeElement?.offsetLeft;
    this.diffY = event.clientY - this.sliderbtn.nativeElement?.offsetTop;
  }

  /**
   * 鼠标移动
   * @param event 
   */
  @HostListener('mousemove', ['$event'])
  onMousemove(event: MouseEvent) {
    console.log('onMousemove');
    if (!this.slider || this.loading == true) {
      return;
    }
    var event = event || window.event;
    var moveX = event.clientX - this.diffX;
    var moveY = event.clientY - this.diffY;

    // console.log('moveX:' + moveX + 
    // 'Width:' + this.sliderbtn.nativeElement.style.width + 
    // '差值：' + (this.slidercontain.nativeElement.offsetWidth - moveX));

    // 如果挪出滑条区域，停止滑动
    if (moveY <= -15 || moveY >= 15) {
      this.closeSlider();
      return;
    }

    // 如果推拽到底
    if((this.slidercontain.nativeElement.offsetWidth - moveX) < 40){
      this.width = this.slidercontain.nativeElement.offsetWidth;
      if (this.loading == false) {
        this.verifyData();
      }
      return;
    }

    // 移动
    if(moveX < 0){
        moveX = 0
    } else if(moveX > this.slidercontain.nativeElement.offsetWidth - this.sliderbtn.nativeElement.offsetWidth){
        moveX = this.slidercontain.nativeElement.offsetWidth - this.sliderbtn.nativeElement.offsetWidth
    }

    this.left = moveX;
    this.width = moveX;
    this.checkData.push(moveX);
  }

  /**
   * 鼠标离开
   * @param event 
   */
  @HostListener('mouseup', ['$event'])
  onMouseup(event: MouseEvent) {
    var event = event || window.event;
    var moveX = event.clientX - this.diffX;

    moveX = 0;
    if(this.loading === false){
      this.closeSlider();
    }
    console.log('mouseup:left:' + this.left);
  }

  /**
   * 滑条关闭
   */
  private closeSlider(){
    console.log('closeSlider');
    this.left = 0;
    this.width = 0;
    this.checkSuccess = -1;
    this.silderclass = 'slider-indicator';
    this.slider = false;
    this.checkData = [];
    this.loading = false;
  }

  private verifyData(){
    this.loading = true;
    var headers = new HttpHeaders({ Data : this.checkData.join(',') });
    this.http.get(this.url + 'api/Captcha/sample/slidertest', { headers: headers })
    .pipe(mergeMap(result => of(result)), catchError(e => { 
      console.log('e.status:' + e.status);
      if (e.status !== 200) {
        this.errorSlider();
        return of(undefined);
      }
      return of(e);
    })).subscribe((res: any) => {
      if (res) {
        this.successSlider();
      }
  });
  }

  /**
   * 验证成功
   */
  private successSlider(){
    this.checkSuccess = 1;
    console.log('mouseup:left:' + this.checkData);
    setTimeout(() => {
      this.closeSlider();
    }, 1000);
  }

  private errorSlider(){
    this.checkSuccess = 2;
    this.silderclass = 'slider-indicator slider-error';
    setTimeout(() => {
      this.closeSlider();
    }, 1000);
  }
}

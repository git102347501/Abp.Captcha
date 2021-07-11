import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { of, Subject } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, mergeMap } from 'rxjs/operators';

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
  private url = 'https://localhost:44335/';
  public diffX: any;
  public diffY: any;
  public left: any;
  public width: any;
  public errormsg = '验证失败，请重试';
  private slider = false;
  private checkData = [0];
  private dragDrop = new Subject<number>();
  public loading = false;
  // 是否验证成功 -1:未开启验证 0:验证中 1:验证成功 2:验证失败
  public checkSuccess = -1;
  public silderclass = 'slider-indicator'
  //public top: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.dragDrop.pipe(debounceTime(1), distinctUntilChanged()).subscribe(data => {
			this.checkData.push(data); 
      console.log('checkData+:' + data);
		});
  }
  
  @HostListener('mousedown', ['$event'])
  onMousedown(event: MouseEvent) {
    console.log('mousedown');
    this.slider = true;
    this.checkSuccess = 0;
    this.diffX = event.clientX - this.sliderbtn.nativeElement?.offsetLeft;
    this.diffY = event.clientY - this.sliderbtn.nativeElement?.offsetTop;
  }

  dropChange(data : number) {
    this.dragDrop.next(data);
  }

  /**
   * 鼠标移动
   * @param event 
   */
  @HostListener('window:mousemove', ['$event'])
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

    // // 如果挪出滑条区域，停止滑动
    // if (moveY <= -15 || moveY >= 15) {
    //   this.closeSlider();
    //   return;
    // }

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
    this.dropChange(moveX);
  }

  /**
   * 鼠标离开
   * @param event 
   */
  @HostListener('window:mouseup', ['$event'])
  onMouseup(event: MouseEvent) {
    var event = event || window.event;
    var moveX = event.clientX - this.diffX;

    moveX = 0;
    if (this.loading === false) {
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

  // 验证数据
  private verifyData(){
    this.loading = true;
    this.left = 324;
    console.dir(this.checkData);
    var data = this.checkData.join(',');
    console.dir(data);
    // if (data.length > 20) {
    //   var newData = new Array<string>();
    //   var count = data.length / 10;
    //   for (let index = 0; index < 10; index + count) {
    //     const element = data[index];
    //     newData.push(element);
    //   }
    //   data = newData.join(',');
    // }
    var headers = new HttpHeaders({ Data : data });
    this.http.get(this.url + 'api/Captcha/sample/slidertest', { headers: headers })
    .pipe(mergeMap(result => of(result)), catchError(e => { 
      // console.dir(e.error.message);
      // var error = e.error;
      // var message = error.message;
      if (e.status !== 200) {
        this.errorSlider(e.error.message ? e.error.message : '验证失败，请重试');
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

  private errorSlider(msg: string){
    this.checkSuccess = 2;
    this.silderclass = 'slider-indicator slider-error';
    this.errormsg = msg;
    setTimeout(() => {
      this.closeSlider();
    }, 1000);
  }
}

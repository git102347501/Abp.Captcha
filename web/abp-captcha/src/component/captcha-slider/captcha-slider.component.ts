import { NgStyle } from '@angular/common';
import { Component, Directive, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { timeStamp } from 'console';

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
  public diffX: any;
  public diffY: any;
  public left: any;
  public width: any;
  private slider = false;
  private checkData = [0];
  // 是否验证成功 -1:未开启验证 0:验证中 1:验证成功 2:验证失败
  public checkSuccess = -1;
  //public top: any;

  constructor() { }

  ngOnInit() {
  }
  
  @HostListener('mousedown', ['$event'])
  onMousedown(event: MouseEvent) {
    console.log('mousedown');
    this.slider = true;
    this.diffX = event.clientX - this.sliderbtn.nativeElement.offsetLeft;
    this.diffY = event.clientY - this.sliderbtn.nativeElement.offsetTop;
  }

  /**
   * 鼠标移动
   * @param event 
   */
  @HostListener('mousemove', ['$event'])
  onMousemove(event: MouseEvent) {
    console.log('onMousemove');
    if (!this.slider) {
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
      this.successSlider();
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
    this.closeSlider();
    console.log('mouseup:left:' + this.left);
  }

  /**
   * 滑条关闭
   */
  private closeSlider(){
    this.left = 0;
    if (this.checkSuccess != 1) {
      this.width = 0;
    }
    this.slider = false;
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
}

import { Component, OnInit } from '@angular/core';
import { CaptchaService } from '../services/captcha.service';

@Component({
  selector: 'lib-captcha',
  template: ` <p>captcha works!</p> `,
  styles: [],
})
export class CaptchaComponent implements OnInit {
  constructor(private service: CaptchaService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
